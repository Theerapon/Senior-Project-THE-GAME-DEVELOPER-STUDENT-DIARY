using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProjectSummaryManager : Manager<WorkProjectSummaryManager>
{
    #region Instace
    private const int INST_TimeScalelessThanEqual_8Hour = 10;
    private const int INST_TimeScalelessThanEqual_4Hour = 5;
    private const int INST_TimeScalelessThanEqual_2Hour = 3;
    private const int INST_30miniute = 30;
    private const float INST_BugChance = 0.6f;

    //ProjectPhase { Decision 0, Design 1, FirstPlayable 2, Prototype 3, VerticalSlice 4, AlphaTest 5, BetaTest 6, Master 7}
    private int[] minCodingStatusUpgradePerPhase = { 0, 0 , 20, 40, 80, 60, 20, 0 };
    private int[] maxCodingStatusUpgradePerPhase = { 0, 20, 60, 80, 100, 100, 80, 20 };

    private int[] minDesignStatusUpgradePerPhase = { 0, 80, 60, 60, 60, 20, 10, 0 };
    private int[] maxDesignStatusUpgradePerPhase = { 0, 100, 100, 80, 80, 100, 40, 20 };

    private int[] minTestingStatusUpgradePerPhase = { 0, 0, 20, 20, 40, 80, 80, 60 };
    private int[] maxTestingStatusUpgradePerPhase = { 0, 0, 60, 60, 80, 100, 100, 80 };

    private int[] minArtStatusUpgradePerPhase = { 0, 0, 20, 40, 80, 80, 60, 0 };
    private int[] maxArtStatusUpgradePerPhase = { 0, 20, 60, 100, 100, 80, 80, 40 };

    private int[] minSoundStatusUpgradePerPhase = { 0, 0, 20, 40, 80, 60, 60, 0 };
    private int[] maxSoundStatusUpgradePerPhase = { 0, 20, 60, 80, 100, 100, 80, 40 };

    private float[] reduceBug = { 0, 0, 0.01f, 0.02f, 0.05f, 0.2f, 0.3f , 0.3f };
    //bonus
    //โบนัสจากการทำโปรเจค
    //โบนัสจากการทำโปนเจคในเวลาทอง
    //โอกาสในการเกิดบัค
    #endregion


    #region Game Object
    [Header("Button")]
    [SerializeField] private GameObject nextButton;
    #endregion

    #region Value Update Generator
    [Header("Generator")]
    [SerializeField] private ValueUpdateGenerator expGenerator;
    [SerializeField] private ValueUpdateGenerator codingStatusGenerator;
    [SerializeField] private ValueUpdateGenerator designStatusGenerator;
    [SerializeField] private ValueUpdateGenerator testingStatusGenerator;
    [SerializeField] private ValueUpdateGenerator artStatusGenerator;
    [SerializeField] private ValueUpdateGenerator soundStatusGenerator;
    [SerializeField] private ValueUpdateGenerator bugStatusGenerator;
    #endregion

    #region Class Manager
    [Header("Manager")]
    private ProjectController projectController;
    private TimeManager timeManager;
    private PlayerAction playerAction;
    private CharacterStatusController characterStatusController;
    #endregion

    #region Properties
    private int countMinute;
    private int countHalfHour;
    private int times;
    private List<float> energy;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        energy = new List<float>();
        characterStatusController = CharacterStatusController.Instance;
        projectController = ProjectController.Instance;
        timeManager = TimeManager.Instance;
        playerAction = PlayerAction.Instance;
        timeManager.OnOneMiniuteTimePassed.AddListener(OnOneMiniuteTimePassedHandler);
        timeManager.OnTimeSkip.AddListener(OnTimeSkipCompleteHandler);
        countMinute = 0;
        countHalfHour = 0;
        times = 0;
        SetButtonActive(false);
    }

    private void Start()
    {
        energy = projectController.GetListEnergyToConsumeByHalfHour();
        StartCoroutine("WaitAMiniue");
    }


    IEnumerator WaitAMiniue()
    {
        yield return new WaitForSecondsRealtime(2f);
        int second = projectController.GetSecondTimeToWork();
        times = second / 60 / 30;
        int timescale = 0;
        if(times >= 16)
        {
            timescale = INST_TimeScalelessThanEqual_8Hour;
        }
        else if(times >= 8)
        {
            timescale = INST_TimeScalelessThanEqual_4Hour;
        }
        else
        {
            timescale = INST_TimeScalelessThanEqual_2Hour;
        }
        timeManager.SkilpTime(second, timescale);

    }

    private void OnOneMiniuteTimePassedHandler(GameManager.GameState state)
    {
        if (state == GameManager.GameState.WORK_PROJECT_SUMMARY)
        {
            countMinute++;
            if (countMinute != 0 && countMinute % INST_30miniute == 0)
            {
                countHalfHour++;
                UpdateProjectStatusSummary();
                UpdateEnergyAndMotivationConsume();
            }

        }
    }

    private void OnTimeSkipCompleteHandler(GameManager.GameState state)
    {
        if(state == GameManager.GameState.WORK_PROJECT_SUMMARY)
        {
            SetButtonActive(true);
        }
    }
    
    private void UpdateProjectStatusSummary()
    {
        float motivation = characterStatusController.GetEfficiencyToDo();
        float minigame = projectController.MiniGameBonusEfficiency;
        float skill = playerAction.GetTotalBonusBootupProjectByTime();
        float sumEfficiency = motivation + minigame + skill;
        int rnd = Random.Range(0, 5);
        int status = 0;
        switch (rnd)
        {
            case 0:
                status = CalculateCodingStatus(sumEfficiency);
                projectController.IncreaseCodingStatus(status);
                if (status > 0)
                    codingStatusGenerator.CreateTemplate(status.ToString());
                break;
            case 1:
                status = CalculateDesignStatus(sumEfficiency);
                projectController.IncreaseDesignStatus(status);
                if (status > 0)
                    designStatusGenerator.CreateTemplate(status.ToString());
                break;
            case 2:
                status = CalculateTestingStatus(sumEfficiency);
                projectController.IncreaseTestingStatus(status);
                if (status > 0)
                    testingStatusGenerator.CreateTemplate(status.ToString());
                break;
            case 3:
                status = CalculateArtStatus(sumEfficiency);
                projectController.IncreaseArtStatus(status);
                if (status > 0)
                    artStatusGenerator.CreateTemplate(status.ToString());
                break;
            case 4:
                status = CalculateSoundStatus(sumEfficiency);
                projectController.IncreaseSoundStatus(status);
                if (status > 0)
                    soundStatusGenerator.CreateTemplate(status.ToString());
                break;
        }
        int exp = CalExp(sumEfficiency);
        characterStatusController.IncreaseEXP(exp);
        expGenerator.CreateTemplate(string.Format("+ {0}", exp.ToString()));

        int bug = CalBug(motivation);
        if (bug > 0)
        {
            projectController.IncreaseBugStatus(bug);
        }
        else
        {
            projectController.ReduceBugStatus(Mathf.Abs(bug));
        }

        if(!(projectController.CurrentBugStatus <= 0 && bug < 0))
        {
            bugStatusGenerator.CreateTemplate(bug.ToString());
        }
        
    }
    private void UpdateEnergyAndMotivationConsume()
    {
        playerAction.TakeEnergy(energy[countMinute / INST_30miniute - 1]);
        playerAction.TakeMotivation(projectController.GetMotivationToConsumeByHalfHour());
    }

    private int CalculateCodingStatus(float sumEfficiency)
    {
        int phase = (int)projectController.ProjectPhase;
        int range = Random.Range(minCodingStatusUpgradePerPhase[phase], maxCodingStatusUpgradePerPhase[phase] + 1);
        float ratio = range / 100f;
        float status = playerAction.GetTotalCodingStatus() * ratio / 10f;
        status *= sumEfficiency;
        return Mathf.RoundToInt(status + 0.5f);
    }
    private int CalculateDesignStatus(float sumEfficiency)
    {
        int phase = (int)projectController.ProjectPhase;
        int range = Random.Range(minDesignStatusUpgradePerPhase[phase], maxDesignStatusUpgradePerPhase[phase] + 1);
        float ratio = range / 100f;
        float status = playerAction.GetTotalDesignStatus() * ratio / 10f;
        status *= sumEfficiency;
        return Mathf.RoundToInt(status + 0.5f);
    }
    private int CalculateTestingStatus(float sumEfficiency)
    {
        int phase = (int)projectController.ProjectPhase;
        int range = Random.Range(minTestingStatusUpgradePerPhase[phase], maxTestingStatusUpgradePerPhase[phase] + 1);
        float ratio = range / 100f;
        float status = playerAction.GetTotalTestingStatus() * ratio / 10f;
        status *= sumEfficiency;
        return Mathf.RoundToInt(status + 0.5f);
    }
    private int CalculateArtStatus(float sumEfficiency)
    {
        int phase = (int)projectController.ProjectPhase;
        int range = Random.Range(minArtStatusUpgradePerPhase[phase], maxArtStatusUpgradePerPhase[phase] + 1);
        float ratio = range / 100f;
        float status = playerAction.GetTotalArtStatus() * ratio / 10f;
        status *= sumEfficiency;
        return Mathf.RoundToInt(status + 0.5f);
    }
    private int CalculateSoundStatus(float sumEfficiency)
    {
        int phase = (int)projectController.ProjectPhase;
        int range = Random.Range(minSoundStatusUpgradePerPhase[phase], maxSoundStatusUpgradePerPhase[phase] + 1);
        float ratio = range / 100f;
        float status = playerAction.GetTotalSoundStatus() * ratio / 10f;
        status *= sumEfficiency;
        return Mathf.RoundToInt(status + 0.5f);
    }

    private int CalExp(float sumEfficiency)
    {
        return Mathf.RoundToInt(projectController.BaseExp * sumEfficiency + 0.5f) * characterStatusController.CurrentLevel;
    }

    private void SetButtonActive(bool active)
    {
        nextButton.SetActive(active);
    }

    private int CalBug(float efficiency)
    {
        int bug = -1;
        float coding = playerAction.GetTotalCodingStatus();
        float testing = playerAction.GetTotalTestingStatus();
        float bugChance = ((coding / 5) / (testing)) + (1 - efficiency) + INST_BugChance;
        float reduceBugChance = ((testing / 10) * 0.01f) + playerAction.GetTotalBonusReduceBugChance() + reduceBug[(int)projectController.ProjectPhase];
        float totalBugChance = bugChance - reduceBugChance;
        float rnd = Random.Range(0f, 1f);
        if(!(rnd <= (1 - totalBugChance)))
        {
            bug = 1;
        }

        return bug;
    }

    public void Next()
    {
        SwitchScene.Instance.DisplayWorkProjectSummary(false);
    }
}
