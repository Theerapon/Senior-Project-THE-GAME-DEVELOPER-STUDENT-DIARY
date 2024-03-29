﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectController : Manager<ProjectController>
{
    public Events.EventOnProjectUpdate OnProjectUpdate;
    public Events.EventOnProjectLastStatusUpdate OnProjectLastStatusUpdate;
    public Events.EventOnProjectStateUpdate OnProjectStateUpdate;

    private Project project;
    private int secondToWork;
    private float minigameBonusEfficiency;

    private const int INST_HalfHour = 1800;
    private const float INST_Energy_Reduce = 0.09f;
    private const float INST_Min_EnergyMultiply = 1f;

    private bool[] enterClass;
    private float[] progress;
    private int[] score;

    private int countEnterClass;

    [SerializeField] PlayerAction playerAction;
    [SerializeField] CharacterStatusController characterStatusController;
    [SerializeField] IdeasController ideasController;
    [SerializeField] GameDesignMessageController gameDesignMessageController;

    protected override void Awake()
    {
        base.Awake();
        project = new Project();
        countEnterClass = 0;
        enterClass = new bool[8];
        progress = new float[8];
        score = new int[8];
    }


    #region Get
    public int LasttimeCodingStatus { get => project.LasttimeCodingStatus; }
    public int LasttimeDesignStatus { get => project.LasttimeDesignStatus; }
    public int LasttimeTestingStatus { get => project.LasttimeTestingStatus; }
    public int LasttimeArtStatus { get => project.LasttimeArtStatus; }
    public int LasttimeSoundStatus { get => project.LasttimeSoundStatus; }
    public int LasttimeBugStatus { get => project.LasttimeBugStatus; }
    public int CurrentCodingStatus { get => project.CurrentCodingStatus; }
    public int CurrentDesignStatus { get => project.CurrentDesignStatus; }
    public int CurrentTestingStatus { get => project.CurrentTestingStatus; }
    public int CurrentArtStatus { get => project.CurrentArtStatus; }
    public int CurrentSoundStatus { get => project.CurrentSoundStatus; }
    public int CurrentBugStatus { get => project.CurrentBugStatus; }
    public string ProjectName { get => project.ProjectName; }
    public Idea GoalIdea { get => project.GoalIdea; }
    public Idea[] MechanicIdea { get => project.MechanicIdea; }
    public Idea ThemeIdea { get => project.ThemeIdea; }
    public Idea PlatformIdea { get => project.PlatformIdea; }
    public Idea PlayerIdea { get => project.PlayerIdea; }
    public string DetailMessage { get => project.DetailMessage; }
    public string ContextMessage { get => project.ContextMessage; }
    public ProjectPhase ProjectPhase { get => project.ProjectPhase; }
    public bool HasDesigned { get => project.HasDesigned; }
    public string StartDate { get => project.StartDate; }
    public string DeadlineDate { get => project.DeadlineDate; }
    public int BaseExp { get => project.BaseExpPer30Minute; }
    public bool ProjectIsNull 
    { 
        get
        {
            if(ReferenceEquals(project, null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }  
    }

    public int SecondToWork { get => secondToWork; set => secondToWork = value; }
    public float MiniGameBonusEfficiency { get => minigameBonusEfficiency; set => minigameBonusEfficiency = value; }
    public bool[] GetEnterClass { get => enterClass; }
    public float[] GetProgress { get => progress; }
    public int[] GetScore { get => score; }
    #endregion

    public float CalTotalEnergyToConsumeByTime(int seccond)
    {
        int times = seccond / INST_HalfHour;
        float baseEnergy = playerAction.CalReduceEnergyToCunsume(project.BaseEnergyConsumePer30Minute);
        float energy = 0;
        float energyMultiply = INST_Min_EnergyMultiply;
        for (int i = 0; i < times; i++)
        {
            energy += baseEnergy * energyMultiply;
            if (i % 2 == 0)
            {
                energyMultiply -= INST_Energy_Reduce;
            }
        }
        return energy;
    }
    public float CalAvgEfficiencyByTime(int seccond)
    {
        int times = seccond / INST_HalfHour;
        float currentMotivation = characterStatusController.CurrentMotivation;

        float motivationConsume = project.BaseMotivationConsumePer30Minute;

        float[] tempMotivationCalculated = new float[times];
        for (int i = 0; i < tempMotivationCalculated.Length; i++)
        {
            tempMotivationCalculated[i] = characterStatusController.CalEfficiencyToDo(currentMotivation);
            if (currentMotivation - motivationConsume <= playerAction.GetMinMotivation())
            {
                currentMotivation = playerAction.GetMinMotivation();
            }
            else
            {
                currentMotivation -= motivationConsume;
            }
        }

        float sumCalculated = 0;
        foreach (int motivationCalculated in tempMotivationCalculated)
        {
            sumCalculated += motivationCalculated;
        }
        float avgMotivationCalculated = (sumCalculated / tempMotivationCalculated.Length);
        return avgMotivationCalculated;
    }

    public int GetSecondTimeToWork()
    {
        return secondToWork;
    }
    public int GetMiniuteTimeToWork()
    {
        return secondToWork / 60;
    }
    public List<float> GetListEnergyToConsumeByHalfHour()
    {
        List<float> energyList = new List<float>();
        int times = secondToWork / INST_HalfHour;
        float baseEnergy = playerAction.CalReduceEnergyToCunsume(project.BaseEnergyConsumePer30Minute);
        float energyMultiply = INST_Min_EnergyMultiply;
        for (int i = 0; i < times; i++)
        {
            energyList.Add((baseEnergy * energyMultiply));
            if (i % 2 == 0)
            {
                energyMultiply -= INST_Energy_Reduce;
            }
        }
        return energyList;
    }
    public float GetMotivationToConsumeByHalfHour()
    {
        return project.BaseMotivationConsumePer30Minute;
    }
    public void DesignGameDucument(string name, string goalId, string[] machenicId, string themeId, string platformSelectName, string playerSelectName)
    {
        string projectName = name;
        Idea goal = ideasController.GoalIdeas[goalId];
        Idea[] mechanics = { ideasController.MechanicIdeas[machenicId[0]], ideasController.MechanicIdeas[machenicId[1]] };
        Idea theme = ideasController.ThemeIdeas[themeId];
        Idea platform = ideasController.GetPlatformIdeaByName(platformSelectName);
        Idea player = ideasController.GetPlayerIdeaByName(playerSelectName);
        string detailMessage = gameDesignMessageController.GetDetailMessage(platform.Message, player.Message);
        string contextMessage = gameDesignMessageController.GetContextMessage(projectName, mechanics[0].Message, mechanics[1].Message, goal.Message, theme.Message);
        project.DesignGameDucument(projectName, goal, mechanics, theme, platform, player, detailMessage, contextMessage);
        OnProjectUpdate?.Invoke();
    }
    #region Set
    public void UpdateProjectState()
    {
        ProjectPhase projectPhase = ProjectPhase;
        switch (projectPhase)
        {
            case ProjectPhase.Decision:
                project.UpdateProjectPhase(ProjectPhase.Design);
                break;
            case ProjectPhase.Design:
                project.UpdateProjectPhase(ProjectPhase.FirstPlayable);
                break;
            case ProjectPhase.FirstPlayable:
                project.UpdateProjectPhase(ProjectPhase.Prototype);
                break;
            case ProjectPhase.Prototype:
                project.UpdateProjectPhase(ProjectPhase.VerticalSlice);
                break;
            case ProjectPhase.VerticalSlice:
                project.UpdateProjectPhase(ProjectPhase.AlphaTest);
                break;
            case ProjectPhase.AlphaTest:
                project.UpdateProjectPhase(ProjectPhase.BetaTest);
                break;
            case ProjectPhase.BetaTest:
                project.UpdateProjectPhase(ProjectPhase.Master);
                break;
        }

        OnProjectStateUpdate?.Invoke();
    }
    public void IncreaseCodingStatus(int status)
    {
        project.IncreaseCodingStatus(status);
        OnProjectUpdate?.Invoke();
    }
    public void IncreaseDesignStatus(int status)
    {
        project.IncreaseDesignStatus(status);
        OnProjectUpdate?.Invoke();
    }
    public void IncreaseTestingStatus(int status)
    {
        project.IncreaseTestingStatus(status);
        OnProjectUpdate?.Invoke();
    }
    public void IncreaseArtStatus(int status)
    {
        project.IncreaseArtStatus(status);
        OnProjectUpdate?.Invoke();
    }
    public void IncreaseSoundStatus(int status)
    {
        project.IncreaseSoundStatus(status);
        OnProjectUpdate?.Invoke();
    }
    public void IncreaseBugStatus(int status)
    {
        project.IncreaseBugStatus(status);
        OnProjectUpdate?.Invoke();
    }
    public void ReduceBugStatus(int status)
    {
        project.ReduceBugStatus(status);
        OnProjectUpdate?.Invoke();
    }
    public void IncreaseLastCodingStatus(int status)
    {
        project.IncreaseLastCodingStatus(status);
        OnProjectLastStatusUpdate?.Invoke();
    }
    public void IncreaseLastDesignStatus(int status)
    {
        project.IncreaseLastDesignStatus(status);
        OnProjectLastStatusUpdate?.Invoke();
    }
    public void IncreaseLastTestingStatus(int status)
    {
        project.IncreaseLastTestingStatus(status);
        OnProjectLastStatusUpdate?.Invoke();
    }
    public void IncreaseLastArtStatus(int status)
    {
        project.IncreaseLastArtStatus(status);
        OnProjectLastStatusUpdate?.Invoke();
    }
    public void IncreaseLastSoundStatus(int status)
    {
        project.IncreaseLastSoundStatus(status);
        OnProjectLastStatusUpdate?.Invoke();
    }
    public void IncreaseLastBugStatus(int status)
    {
        project.IncreaseLastBugStatus(status);
        OnProjectLastStatusUpdate?.Invoke();
    }
    public void ReduceLastBugStatus(int status)
    {
        project.ReduceLastBugStatus(status);
        OnProjectLastStatusUpdate?.Invoke();
    }
    #endregion

    public void EnterClass(float progress, int score)
    {
        if(countEnterClass + 1 < 8)
        {
            enterClass[countEnterClass] = true;
            this.progress[countEnterClass] = progress;
            this.score[countEnterClass] = score;
            countEnterClass++;
        }
    }

    public void MissingClass()
    {
        if (countEnterClass + 1 < 8)
        {
            enterClass[countEnterClass] = false;
            this.progress[countEnterClass] = 0f;
            this.score[countEnterClass] = 0;
            countEnterClass++;
        }
    }
}
