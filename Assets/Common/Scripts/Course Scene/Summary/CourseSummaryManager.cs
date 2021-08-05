using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseSummaryManager : MonoBehaviour
{
    #region INST Bonus ID
    private const string INST_Math_Id = "MATH";
    private const string INST_Programming_Id = "PROGRAMMING";
    private const string INST_Engine_Id = "GAMEENGINE";
    private const string INST_Ai_Id = "AI";
    private const string INST_Network_Id = "NETWORK";
    private const string INST_Design_Id = "DESIGN";
    private const string INST_Testing_Id = "TESTING";
    private const string INST_Art_Id = "ART";
    private const string INST_Sound_Id = "SOUND";
    private const string INST_Coding_Status = "coding_status";
    private const string INST_Design_Status = "design_status";
    private const string INST_Testing_Status = "testing_status";
    private const string INST_Art_Status = "art_status";
    private const string INST_Sound_Status = "sound_status";
    #endregion

    private const int INST_10miniute = 10;

    #region Game Object
    [Header("Button")]
    [SerializeField] private GameObject nextButton;
    #endregion

    #region Value Update Generator
    [Header("Status Generator")]
    [SerializeField] private ValueUpdateGenerator _expGenerator;
    [SerializeField] private ValueUpdateGenerator _codingStatusGenerator;
    [SerializeField] private ValueUpdateGenerator _designStatusGenerator;
    [SerializeField] private ValueUpdateGenerator _testingStatusGenerator;
    [SerializeField] private ValueUpdateGenerator _artStatusGenerator;
    [SerializeField] private ValueUpdateGenerator _soundStatusGenerator;
    #endregion

    #region Exp Hardskill Update Generator
    [Header("Hardskill Generator")]
    [SerializeField] private ValueUpdateGenerator _mathHardSkilGenerator;
    [SerializeField] private ValueUpdateGenerator _programmingHardSkillGenerator;
    [SerializeField] private ValueUpdateGenerator _engineHardSkillGenerator;
    [SerializeField] private ValueUpdateGenerator _networkHardSkillGenerator;
    [SerializeField] private ValueUpdateGenerator _aiHardSkillGenerator;
    [SerializeField] private ValueUpdateGenerator _designHardSillGenerator;
    [SerializeField] private ValueUpdateGenerator _testingHardSillGenerator;
    [SerializeField] private ValueUpdateGenerator _artHardSillGenerator;
    [SerializeField] private ValueUpdateGenerator _soundHardSillGenerator;
    #endregion

    #region Class Manager
    [Header("Manager")]
    private CoursesController _coursesController;
    private CourseManager _courseManager;
    private TimeManager _timeManager;
    private PlayerAction _playerAction;
    private CharacterStatusController _characterStatusController;
    private HardSkillsController _hardSkillsController;
    private SwitchScene _switchScene;
    #endregion

    #region Properties
    private int countMinute;
    private int times;
    private string courseId;
    private int exp;
    private int numCourseTag;
    #endregion

    private Dictionary<string, int> dicBonus;

    private void Awake()
    {
        _courseManager = CourseManager.Instance;
        _timeManager = TimeManager.Instance;
        _playerAction = PlayerAction.Instance;
        _hardSkillsController = HardSkillsController.Instance;
        _characterStatusController = CharacterStatusController.Instance;
        _coursesController = CoursesController.Instance;
        _switchScene = SwitchScene.Instance;

        _timeManager.OnTimeSkip.AddListener(OnTimeSkipCompleteHandler);

        dicBonus = new Dictionary<string, int>();
        countMinute = 0;
        times = 0;
        SetButtonActive(false);
    }

    private void Start()
    {
        StartCoroutine("WaitAMiniue");
        courseId = _courseManager.CurrentCourseId;
        if (_coursesController.MyCourses.ContainsKey(courseId))
        {
            CreateBonusDictionary(_coursesController.MyCourses[courseId]);
        }
    }

    IEnumerator WaitAMiniue()
    {
        yield return new WaitForSecondsRealtime(1f);
        int second = _courseManager.TotalTimeSecond;
        times = second / (INST_10miniute * 60);
        int timescale = 3;
        _timeManager.SkilpTime(second, timescale);

    }

    private void OnTimeSkipCompleteHandler(GameManager.GameState state)
    {
        if (state == GameManager.GameState.COURSE_SUMMARY)
        {
            UpdateStatusSummary();
            UpdateEnergyAndMotivationConsume();
            SetButtonActive(true);
        }
    }

    private void UpdateEnergyAndMotivationConsume()
    {
        _playerAction.TakeEnergy(_courseManager.CurrentEnergyConsume);
        _playerAction.TakeMotivation(_courseManager.CurrentMotivation);
    }

    private void UpdateStatusSummary()
    {
        foreach (KeyValuePair<string, int> bonus in dicBonus)
        {
            string id = bonus.Key;
            int value = bonus.Value;

            switch (id)
            {
                case INST_Math_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _mathHardSkilGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Programming_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _programmingHardSkillGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Engine_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _engineHardSkillGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Ai_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _aiHardSkillGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Network_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _networkHardSkillGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Design_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _designHardSillGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Testing_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _testingHardSillGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Art_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _artHardSillGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Sound_Id:
                    _hardSkillsController.IncreaseEXP(id, value);
                    _soundHardSillGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Coding_Status:
                    _characterStatusController.IncreaseCodingStatus(value);
                    _codingStatusGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Design_Status:
                    _characterStatusController.IncreaseDesignStatus(value);
                    _designStatusGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Testing_Status:
                    _characterStatusController.IncreaseTestingStatus(value);
                    _testingStatusGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Art_Status:
                    _characterStatusController.IncreaseArtStatus(value);
                    _artStatusGenerator.CreateTemplate(value.ToString());
                    break;
                case INST_Sound_Status:
                    _characterStatusController.IncreaseSoundStatus(value);
                    _soundStatusGenerator.CreateTemplate(value.ToString());
                    break;
            }

        }

        _characterStatusController.IncreaseEXP(exp * times * numCourseTag);
    }

    
    private void SetButtonActive(bool active)
    {
        nextButton.SetActive(active);
    }
    private void CreateBonusDictionary(Course course)
    {
        exp = course.ExpPlayer;
        numCourseTag = course.CourseTypeNum.Count;

        dicBonus.Clear();
        int bonusCheck = 0;

        #region Exp
        bonusCheck = course.DefaultMathExpReward;

        if (bonusCheck > 0f)
            dicBonus.Add(INST_Math_Id, bonusCheck);

        bonusCheck = course.DefaultProgrammingExpReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Programming_Id, bonusCheck);

        bonusCheck = course.DefaultEngineExpReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Engine_Id, bonusCheck);

        bonusCheck = course.DefaultAiExpReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Ai_Id, bonusCheck);

        bonusCheck = course.DefaultNetwordExpReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Network_Id, bonusCheck);

        bonusCheck = course.DefaultDesignExpReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Design_Id, bonusCheck);

        bonusCheck = course.DefaultTestingExpReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Testing_Id, bonusCheck);

        bonusCheck = course.DefaultArtExpReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Art_Id, bonusCheck);

        bonusCheck = course.DefaultSoundExpReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Sound_Id, bonusCheck);
        #endregion

        #region Stat
        bonusCheck = course.DefaultCodingStatReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Coding_Status, bonusCheck);

        bonusCheck = course.DefaultDesignStatReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Design_Status, bonusCheck);

        bonusCheck = course.DefaultTestingStatReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Testing_Status, bonusCheck);

        bonusCheck = course.DefaultArtStatReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Art_Status, bonusCheck);

        bonusCheck = course.DefaultSoundStatReward;
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Sound_Status, bonusCheck);
        #endregion
    }

    public void Next()
    {
        _switchScene.DisplayCourseSummary(false);
    }
}
