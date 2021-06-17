using System.Collections;
using UnityEngine;

public class WorkProjectSummaryManager : Manager<WorkProjectSummaryManager>
{
    #region Instace
    private const int INST_TimeScaleForSkip = 4;
    private const int INST_10miniute = 10;
    private const int INST_30miniute = 30;

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

    private int[] mixBugChancePerPase = { 0, 0, 80, 60, 60, 40, 20, 0 };
    private int[] maxBugChancePerPase = { 0, 0, 100, 100, 100, 80, 40, 0 };
    //bonus
    //โบนัสจากการทำโปรเจค
    //โบนัสจากการทำโปนเจคในเวลาทอง
    //โอกาสในการเกิดบัค
    #endregion

    #region Events
    public Events.EventOnProjectSummaryTimeUpdate OnProjectSummaryTimeUpdate;
    public Events.EventOnProjectSummaryCharacterLevelUpdate OnProjectSummaryCharacterLevelUpdate;
    public Events.EventOnProjectSummaryCharacterExpUpdate OnProjectSummaryCharacterExpUpdate;
    public Events.EventOnProjectSummaryEfficiencyUpdate OnProjectSummaryEfficiencyUpdate;
    public Events.EventOnProjectSummaryCodingStatusUpdate OnProjectSummaryCodingStatusUpdate;
    public Events.EventOnProjectSummaryDesignStatusUpdate OnProjectSummaryDesignStatusUpdate;
    public Events.EventOnProjectSummaryTestingStatusUpdate OnProjectSummaryTestingStatusUpdate;
    public Events.EventOnProjectSummaryArtStatusUpdate OnProjectSummaryArtStatusUpdate;
    public Events.EventOnProjectSummarySoundStatusUpdate OnProjectSummarySoundStatusUpdate;
    public Events.EventOnProjectSummaryBugStatusUpdate OnProjectSummaryBugStatusUpdate;
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
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;
    private CharacterStatusController characterStatusController;
    #endregion

    #region Properties
    private int times;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        characterStatusController = CharacterStatusController.Instance;
        projectController = ProjectController.Instance;
        timeManager = TimeManager.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();
        timeManager.OnOneMiniuteTimePassed.AddListener(OnOneMiniuteTimePassedHandler);
        timeManager.OnTimeSkip.AddListener(OnTimeSkipCompleteHandler);
        times = 0;
    }
    private void Start()
    {
        StartCoroutine("WaitAMiniue");
    }
    IEnumerator WaitAMiniue()
    {
        yield return new WaitForSecondsRealtime(2f);
        timeManager.SkilpTime(projectController.GetSecondTimeToWork(), INST_TimeScaleForSkip);
    }

    private void OnOneMiniuteTimePassedHandler(GameManager.GameState state)
    {
        if (state == GameManager.GameState.WORK_PROJECT_SUMMARY)
        {
            times++;
            if(times != 0 && times % INST_10miniute == 0)
            {
                UpdateProjectStatusSummary();
                if (times != 0 && times % INST_30miniute == 0)
                {
                    UpdateEnergyAndMotivationConsume();
                }
            }
            
        }
    }

    private void OnTimeSkipCompleteHandler(GameManager.GameState state)
    {
        if(state == GameManager.GameState.WORK_PROJECT_SUMMARY)
        {
            if(times != 0 && times % INST_10miniute != 0 && times % INST_30miniute != 0)
            {
                Debug.Log("Somting wrong");
            }
            else
            {
                Debug.Log("Complete");
            }
        }
    }
    
    private void UpdateProjectStatusSummary()
    {
        //expGenerator.CreateTemplate();
        //codingStatusGenerator.CreateTemplate();
        //designStatusGenerator.CreateTemplate();
        //testingStatusGenerator.CreateTemplate();
        //artStatusGenerator.CreateTemplate();
        //soundStatusGenerator.CreateTemplate();
        //bugStatusGenerator.CreateTemplate();
    }
    private void UpdateEnergyAndMotivationConsume()
    {
        //energy
        //motivation
        //exp
    }

    private int CalculateCodingStatus()
    {
        int phase = (int)projectController.ProjectPhase;
        int range = Random.Range(minCodingStatusUpgradePerPhase[phase], maxCodingStatusUpgradePerPhase[phase] + 1);
        float ratio = range / 100f;
        float status = playerAction.GetTotalCodingStatus() * ratio / 10f;
        status *= (characterStatusController.GetEfficiencyToDo() + projectController.GetBonusEfficiency() + playerAction.GetTotalBonusBootUpProject());
        return Mathf.RoundToInt(status + 0.5f);
    }

}
