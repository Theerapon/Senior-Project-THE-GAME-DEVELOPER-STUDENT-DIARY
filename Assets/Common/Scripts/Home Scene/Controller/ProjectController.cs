using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectController : Manager<ProjectController>
{
    private Project project;

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
    public string DeveloperMessage { get => project.DeveloperMessage; }
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
    public int BaseEnergyConsumePer30Minute { get => project.BaseEnergyConsumePer30Minute; }
    public int BaseMotivationConsumePer30Minute { get => project.BaseMotivationConsumePer30Minute; }
    #endregion
}
