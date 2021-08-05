using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    #region Project Status
    private int lasttimeCodingStatus;
    private int lasttimeDesignStatus;
    private int lasttimeTestingStatus;
    private int lasttimeArtStatus;
    private int lasttimeSoundStatus;
    private int lasttimeBugStatus;

    private int currentCodingStatus;
    private int currentDesignStatus;
    private int currentTestingStatus;
    private int currentArtStatus;
    private int currentSoundStatus;
    private int currentBugStatus;
    #endregion

    #region Instace
    private const int Inst_MaxSkillAmount = 9;
    private const int Inst_MaxAmountSkill = 3;
    private const int Inst_MaxPhase = 4;
    private const int Inst_MaxLevelRequire = 4;
    private int[] tempLevelRequire = { 1, 1, 1, 2, 2, 2, 3, 3, 4 };
    private const float Inst_BaseEnergy = 3;
    private const float Inst_BaseMotivation = 2;
    private const int Inst_BaseExp = 50;
    #endregion

    #region Project Design Phase
    private string projectName;
    private Idea goalIdea;
    private Idea[] mechanicIdea;
    private Idea themeIdea;
    private Idea platformIdea;
    private Idea playerIdea;
    private string detailMessage;
    private string contextMessage;

    private static Dictionary<HardSkillId, int> levelHardSkillRequired;
    #endregion

    private ProjectPhase projectPhase;
    private bool hasDesigned;
    private string startDate;
    private string deadlineDate;
    private float baseEnergyConsumePer30Minute;
    private float baseMotivationConsumePer30Minute;
    private int baseExpPer30Minute;

    public int LasttimeCodingStatus { get => lasttimeCodingStatus; set => lasttimeCodingStatus = value; }
    public int LasttimeDesignStatus { get => lasttimeDesignStatus; set => lasttimeDesignStatus = value; }
    public int LasttimeTestingStatus { get => lasttimeTestingStatus; set => lasttimeTestingStatus = value; }
    public int LasttimeArtStatus { get => lasttimeArtStatus; set => lasttimeArtStatus = value; }
    public int LasttimeSoundStatus { get => lasttimeSoundStatus; set => lasttimeSoundStatus = value; }
    public int LasttimeBugStatus { get => lasttimeBugStatus; set => lasttimeBugStatus = value; }
    public int CurrentCodingStatus { get => currentCodingStatus; set => currentCodingStatus = value; }
    public int CurrentDesignStatus { get => currentDesignStatus; set => currentDesignStatus = value; }
    public int CurrentTestingStatus { get => currentTestingStatus; set => currentTestingStatus = value; }
    public int CurrentArtStatus { get => currentArtStatus; set => currentArtStatus = value; }
    public int CurrentSoundStatus { get => currentSoundStatus; set => currentSoundStatus = value; }
    public int CurrentBugStatus { get => currentBugStatus; set => currentBugStatus = value; }
    public string ProjectName { get => projectName; }
    public Idea GoalIdea { get => goalIdea; }
    public Idea[] MechanicIdea { get => mechanicIdea; }
    public Idea ThemeIdea { get => themeIdea; }
    public Idea PlatformIdea { get => platformIdea; }
    public Idea PlayerIdea { get => playerIdea; }
    public string DetailMessage { get => detailMessage; }
    public string ContextMessage { get => contextMessage; }
    public ProjectPhase ProjectPhase { get => projectPhase; set => projectPhase = value; }
    public bool HasDesigned { get => hasDesigned; }
    public string StartDate { get => startDate; }
    public string DeadlineDate { get => deadlineDate; }
    public float BaseEnergyConsumePer30Minute { get => baseEnergyConsumePer30Minute; }
    public float BaseMotivationConsumePer30Minute { get => baseMotivationConsumePer30Minute; }
    public int BaseExpPer30Minute { get => baseExpPer30Minute; }

    public Project()
    {
        levelHardSkillRequired = new Dictionary<HardSkillId, int>();
        Initializing();
    }

    private void Initializing()
    {
        lasttimeCodingStatus = 0;
        lasttimeDesignStatus = 0;
        lasttimeTestingStatus = 0;
        lasttimeArtStatus = 0;
        lasttimeSoundStatus = 0;
        lasttimeBugStatus = 0;

        currentCodingStatus = 0;
        currentDesignStatus = 0;
        currentTestingStatus = 0;
        currentArtStatus = 0;
        currentSoundStatus = 0;
        currentBugStatus = 0;

        projectName = string.Empty;
        goalIdea = null;
        mechanicIdea = new Idea[2];
        themeIdea = null;
        platformIdea = null;
        playerIdea = null;
        detailMessage = string.Empty;
        contextMessage = string.Empty;

        levelHardSkillRequired.Add(HardSkillId.MATH, 0);
        levelHardSkillRequired.Add(HardSkillId.PROGRAMMING, 0);
        levelHardSkillRequired.Add(HardSkillId.GAMEENGINE, 0);
        levelHardSkillRequired.Add(HardSkillId.AI, 0);
        levelHardSkillRequired.Add(HardSkillId.NETWORK, 0);
        levelHardSkillRequired.Add(HardSkillId.DESIGN, 0);
        levelHardSkillRequired.Add(HardSkillId.TESTING, 0);
        levelHardSkillRequired.Add(HardSkillId.ART, 0);
        levelHardSkillRequired.Add(HardSkillId.SOUND, 0);

        projectPhase = ProjectPhase.Decision;
        hasDesigned = false;
        startDate = "Unknown";
        deadlineDate = "Unknown";
        baseEnergyConsumePer30Minute = Inst_BaseEnergy;
        baseMotivationConsumePer30Minute = Inst_BaseMotivation;
        baseExpPer30Minute = Inst_BaseExp;
    }

    public void DesignGameDucument(string name, Idea goal, Idea[] machenic, Idea theme, Idea platform, Idea player, string detailMessage, string contextMessage)
    {

        projectName = name;
        goalIdea = goal;
        mechanicIdea = machenic;
        themeIdea = theme;
        platformIdea = platform;
        playerIdea = player;
        this.detailMessage = detailMessage;
        this.contextMessage = contextMessage;
        GenerateLevelSkillRequire();
        hasDesigned = true;
    }

    
    private void GenerateLevelSkillRequire()
    {
        tempLevelRequire = SufferArray(tempLevelRequire);
        levelHardSkillRequired[HardSkillId.MATH] = tempLevelRequire[0];
        levelHardSkillRequired[HardSkillId.PROGRAMMING] = tempLevelRequire[1];
        levelHardSkillRequired[HardSkillId.GAMEENGINE] = tempLevelRequire[2];
        levelHardSkillRequired[HardSkillId.AI] = tempLevelRequire[3];
        levelHardSkillRequired[HardSkillId.NETWORK] = tempLevelRequire[4];
        levelHardSkillRequired[HardSkillId.DESIGN] = tempLevelRequire[5];
        levelHardSkillRequired[HardSkillId.TESTING] = tempLevelRequire[6];
        levelHardSkillRequired[HardSkillId.ART] = tempLevelRequire[7];
        levelHardSkillRequired[HardSkillId.SOUND] = tempLevelRequire[8];

    }


    public int[] SufferArray(int[] array)
    {
        for(int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = UnityEngine.Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
        return array;
    }

    #region Set
    public void IncreaseCodingStatus(int status)
    {
        currentCodingStatus += status;
    }
    public void IncreaseDesignStatus(int status)
    {
        currentDesignStatus += status;
    }
    public void IncreaseTestingStatus(int status)
    {
        currentTestingStatus += status;
    }
    public void IncreaseArtStatus(int status)
    {
        currentArtStatus += status;
    }
    public void IncreaseSoundStatus(int status)
    {
        currentSoundStatus += status;
    }
    public void IncreaseBugStatus(int status)
    {
        currentBugStatus += status;
    }
    public void ReduceBugStatus(int status)
    {
        if(currentBugStatus - status <= 0)
        {
            currentBugStatus = 0;
        }
        else
        {
            currentBugStatus -= status;
        }
    }
    public void IncreaseLastCodingStatus(int status)
    {
        lasttimeCodingStatus += status;
    }
    public void IncreaseLastDesignStatus(int status)
    {
        lasttimeDesignStatus += status;
    }
    public void IncreaseLastTestingStatus(int status)
    {
        lasttimeTestingStatus += status;
    }
    public void IncreaseLastArtStatus(int status)
    {
        lasttimeArtStatus += status;
    }
    public void IncreaseLastSoundStatus(int status)
    {
        lasttimeSoundStatus += status;
    }
    public void IncreaseLastBugStatus(int status)
    {
        lasttimeBugStatus += status;
    }
    public void ReduceLastBugStatus(int status)
    {
        if (lasttimeBugStatus - status <= 0)
        {
            lasttimeBugStatus = 0;
        }
        else
        {
            lasttimeBugStatus -= status;
        }
    }
    public void UpdateProjectPhase(ProjectPhase projectPhase)
    {
        this.projectPhase = projectPhase;
    }
    #endregion
}
