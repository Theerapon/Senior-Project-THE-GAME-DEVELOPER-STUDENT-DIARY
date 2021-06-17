﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectController : Manager<ProjectController>
{
    private Project project;
    private int secondToWork;
    private float bonusEfficiency;

    private const int INST_HalfHour = 1800;
    private const float INST_Energy_Reduce = 0.09f;
    private const float INST_Min_EnergyMultiply = 1f;

    [SerializeField] PlayerAction playerAction;
    [SerializeField] CharacterStatusController characterStatusController;

    protected override void Awake()
    {
        base.Awake();
        project = new Project();
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
    public int LevelMathSkillRequired { get => project.LevelMathSkillRequired; }
    public int LevelProgramingSkillRequired { get => project.LevelProgramingSkillRequired; }
    public int LevelEngineSkillRequired { get => project.LevelEngineSkillRequired; }
    public int LevelNetworkSkillRequired { get => project.LevelNetworkSkillRequired; }
    public int LevelAiSkillRequired { get => project.LevelAiSkillRequired; }
    public int LevelDesignSkillRequired { get => project.LevelDesignSkillRequired; }
    public int LevelTestingSkillRequired { get => project.LevelTestingSkillRequired; }
    public int LevelArtSkillRequired { get => project.LevelArtSkillRequired; }
    public int LevelSoundSkillRequired { get => project.LevelSoundSkillRequired; }
    public ProjectPhase ProjectPhase { get => project.ProjectPhase; }
    public bool HasDesigned { get => project.HasDesigned; }
    public string StartDate { get => project.StartDate; }
    public string DeadlineDate { get => project.DeadlineDate; }
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
            if (currentMotivation - motivationConsume <= playerAction.CalMinMotivation())
            {
                currentMotivation = playerAction.CalMinMotivation();
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
    public float GetBonusEfficiency()
    {
        return bonusEfficiency;
    }
}
