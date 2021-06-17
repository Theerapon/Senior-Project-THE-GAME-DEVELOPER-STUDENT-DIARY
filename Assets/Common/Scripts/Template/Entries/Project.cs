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

    #region Project Design Phase
    private string projectName;
    private Idea goalIdea;
    private Idea[] mechanicIdea;
    private Idea themeIdea;
    private Idea platformIdea;
    private Idea playerIdea;
    private string detailMessage;
    private string contextMessage;

    private int levelMathSkillRequired;
    private int levelProgramingSkillRequired;
    private int levelEngineSkillRequired;
    private int levelNetworkSkillRequired;
    private int levelAiSkillRequired;
    private int levelDesignSkillRequired;
    private int levelTestingSkillRequired;
    private int levelArtSkillRequired;
    private int levelSoundSkillRequired;
    #endregion

    private ProjectPhase projectPhase;
    private bool hasDesigned;
    private string startDate;
    private string deadlineDate;
    private float baseEnergyConsumePer30Minute;
    private float baseMotivationConsumePer30Minute;

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
    public int LevelMathSkillRequired { get => levelMathSkillRequired; }
    public int LevelProgramingSkillRequired { get => levelProgramingSkillRequired; }
    public int LevelEngineSkillRequired { get => levelEngineSkillRequired; }
    public int LevelNetworkSkillRequired { get => levelNetworkSkillRequired; }
    public int LevelAiSkillRequired { get => levelAiSkillRequired; }
    public int LevelDesignSkillRequired { get => levelDesignSkillRequired; }
    public int LevelTestingSkillRequired { get => levelTestingSkillRequired; }
    public int LevelArtSkillRequired { get => levelArtSkillRequired; }
    public int LevelSoundSkillRequired { get => levelSoundSkillRequired; }
    public ProjectPhase ProjectPhase { get => projectPhase; set => projectPhase = value; }
    public bool HasDesigned { get => hasDesigned; }
    public string StartDate { get => startDate; }
    public string DeadlineDate { get => deadlineDate; }
    public float BaseEnergyConsumePer30Minute { get => baseEnergyConsumePer30Minute; }
    public float BaseMotivationConsumePer30Minute { get => baseMotivationConsumePer30Minute; }

    public Project()
    {
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

        levelMathSkillRequired = 0; 
        levelProgramingSkillRequired = 0;
        levelEngineSkillRequired = 0;
        levelNetworkSkillRequired = 0;
        levelAiSkillRequired = 0;
        levelDesignSkillRequired = 0;
        levelTestingSkillRequired = 0;
        levelArtSkillRequired = 0;
        levelSoundSkillRequired = 0;

        projectPhase = ProjectPhase.Design;
        hasDesigned = false;
        startDate = "Unknown";
        deadlineDate = "Unknown";
        baseEnergyConsumePer30Minute = 5;
        baseMotivationConsumePer30Minute = 3;
    }

    public void DesignGameDucument(string name, Idea goal, Idea[] machenic, Idea theme, Idea platform, Idea player, string detailMessage, string contextMessage, string developerMessage)
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
        levelMathSkillRequired = 2;
        levelProgramingSkillRequired = 2;
        levelEngineSkillRequired = 1;
        levelNetworkSkillRequired = 3;
        levelAiSkillRequired = 4;
        levelDesignSkillRequired = 1;
        levelTestingSkillRequired = 2;
        levelArtSkillRequired = 4;
        levelSoundSkillRequired = 3;
    }

       
}
