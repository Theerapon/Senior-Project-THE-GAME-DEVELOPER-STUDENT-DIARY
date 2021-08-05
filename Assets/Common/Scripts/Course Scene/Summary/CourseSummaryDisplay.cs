using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CourseSummaryDisplay : MonoBehaviour
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
    #endregion

    [SerializeField] private CourseSummaryManager _courseManager;
    private TimeManager _timeManager;
    private CharacterStatusController _characterStatusController;
    private PlayerAction _playerAction;
    private HardSkillsController _hardSkillsController;

    private const string goden = "Golden Time";
    private const string normal = "Normal Time";

    Dictionary<string, HardSkill> hardskills;


    [Header("Time Manager")]
    [SerializeField] private TMP_Text dateTMP;
    [SerializeField] private TMP_Text timeTMP;
    [SerializeField] private TMP_Text godenTime;

    [Header("Character Contents")]
    [SerializeField] private TMP_Text characterLevelTMP;
    [SerializeField] private TMP_Text currentExpTMP;
    [SerializeField] private TMP_Text goalExpTMP;
    [SerializeField] private Image fillCharacterExpImage;
    [SerializeField] private TMP_Text currentCodingStatusTMP;
    [SerializeField] private TMP_Text currentDesignStatusTMP;
    [SerializeField] private TMP_Text currentTestingStatusTMP;
    [SerializeField] private TMP_Text currentArtStatusTMP;
    [SerializeField] private TMP_Text currentSoundStatusTMP;

    [Header("Math HardSkills")]
    [SerializeField] private TMP_Text math_levelTMP;
    [SerializeField] private Image mathExpImage;

    [Header("Programming HardSkills")]
    [SerializeField] private TMP_Text programming_levelTMP;
    [SerializeField] private Image programmingExpImage;

    [Header("Engine HardSkills")]
    [SerializeField] private TMP_Text engine_levelTMP;
    [SerializeField] private Image engineExpImage;

    [Header("Network HardSkills")]
    [SerializeField] private TMP_Text network_levelTMP;
    [SerializeField] private Image networkExpImage;

    [Header("Ai HardSkills")]
    [SerializeField] private TMP_Text ai_levelTMP;
    [SerializeField] private Image aiExpImage;

    [Header("Design HardSkills")]
    [SerializeField] private TMP_Text design_levelTMP;
    [SerializeField] private Image designExpImage;

    [Header("Testing HardSkills")]
    [SerializeField] private TMP_Text testing_levelTMP;
    [SerializeField] private Image testingExpImage;

    [Header("Art HardSkills")]
    [SerializeField] private TMP_Text art_levelTMP;
    [SerializeField] private Image artExpImage;

    [Header("Sound HardSkills")]
    [SerializeField] private TMP_Text sound_levelTMP;
    [SerializeField] private Image soundExpImage;

    protected void Awake()
    {
        if (TimeManager.Instance != null)
        {
            _timeManager = TimeManager.Instance;
            _timeManager.OnTimeCalendar.AddListener(OnTimeCalendarHandler);
            _timeManager.OnDateCalendar.AddListener(OnDateCalendarHandler);
            _timeManager.OnGodenTime.AddListener(OnGodenTimeHandler);
            _timeManager.ValidationInitializing();
        }

        if (CharacterStatusController.Instance != null)
        {
            _characterStatusController = CharacterStatusController.Instance;
            _characterStatusController.OnExpUpdated.AddListener(OnExpUpdatedHandler);
            _characterStatusController.OnStatusUpdated.AddListener(OnStatusUpdateHandler);
        }

        if (PlayerAction.Instance != null)
        {
            _playerAction = PlayerAction.Instance;
        }

        if (HardSkillsController.Instance != null)
        {
            _hardSkillsController = HardSkillsController.Instance;
            _hardSkillsController.OnHardSkillExpUpdate.AddListener(OnHardSkillUpdateHandler);
            hardskills = new Dictionary<string, HardSkill>();
            hardskills = _hardSkillsController.Hardskills;

        }


    }

    private void Start()
    { 
        Initializing();
    }


    private void Initializing()
    {
        OnExpUpdatedHandler();
        math_levelTMP.text = hardskills[INST_Math_Id].CurrentLevel.ToString();
        mathExpImage.fillAmount = hardskills[INST_Math_Id].GetExpFillAmount();

        programming_levelTMP.text = hardskills[INST_Programming_Id].CurrentLevel.ToString();
        programmingExpImage.fillAmount = hardskills[INST_Programming_Id].GetExpFillAmount();

        engine_levelTMP.text = hardskills[INST_Engine_Id].CurrentLevel.ToString();
        engineExpImage.fillAmount = hardskills[INST_Engine_Id].GetExpFillAmount();

        ai_levelTMP.text = hardskills[INST_Ai_Id].CurrentLevel.ToString();
        aiExpImage.fillAmount = hardskills[INST_Ai_Id].GetExpFillAmount();

        network_levelTMP.text = hardskills[INST_Network_Id].CurrentLevel.ToString();
        networkExpImage.fillAmount = hardskills[INST_Network_Id].GetExpFillAmount();

        design_levelTMP.text = hardskills[INST_Design_Id].CurrentLevel.ToString();
        designExpImage.fillAmount = hardskills[INST_Design_Id].GetExpFillAmount();

        testing_levelTMP.text = hardskills[INST_Testing_Id].CurrentLevel.ToString();
        testingExpImage.fillAmount = hardskills[INST_Testing_Id].GetExpFillAmount();
        
        art_levelTMP.text = hardskills[INST_Art_Id].CurrentLevel.ToString();
        artExpImage.fillAmount = hardskills[INST_Art_Id].GetExpFillAmount();

        sound_levelTMP.text = hardskills[INST_Sound_Id].CurrentLevel.ToString();
        soundExpImage.fillAmount = hardskills[INST_Sound_Id].GetExpFillAmount();
    }

    private void OnExpUpdatedHandler()
    {
        fillCharacterExpImage.fillAmount = (float)_characterStatusController.CurrentExp / _characterStatusController.GetNextExpRequire();
        goalExpTMP.text = string.Format("{0}", _characterStatusController.GetNextExpRequire());
        currentExpTMP.text = string.Format("{0}", _characterStatusController.CurrentExp);
        characterLevelTMP.text = string.Format("{0}", _characterStatusController.CurrentLevel);
    }

    private void OnStatusUpdateHandler()
    {
        currentCodingStatusTMP.text = _characterStatusController.CurrentCodingStatus.ToString();
        currentDesignStatusTMP.text = _characterStatusController.CurrentDesignStatus.ToString();
        currentTestingStatusTMP.text = _characterStatusController.CurrentTestingStatus.ToString();
        currentArtStatusTMP.text = _characterStatusController.CurrentArtStatus.ToString();
        currentSoundStatusTMP.text = _characterStatusController.CurrentSoundStatus.ToString();
    }

    private void OnHardSkillUpdateHandler(string id)
    {
        HardSkill hardSkill = hardskills[id];
        

        switch (id)
        {
            case INST_Math_Id:
                math_levelTMP.text = hardSkill.CurrentLevel.ToString();
                mathExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;
            case INST_Programming_Id:
                programming_levelTMP.text = hardSkill.CurrentLevel.ToString();
                programmingExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;
            case INST_Engine_Id:
                engine_levelTMP.text = hardSkill.CurrentLevel.ToString();
                engineExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;
            case INST_Ai_Id:
                ai_levelTMP.text = hardSkill.CurrentLevel.ToString();
                aiExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;
            case INST_Network_Id:
                network_levelTMP.text = hardSkill.CurrentLevel.ToString();
                networkExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;
            case INST_Design_Id:
                design_levelTMP.text = hardSkill.CurrentLevel.ToString();
                designExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;
            case INST_Testing_Id:
                testing_levelTMP.text = hardSkill.CurrentLevel.ToString();
                testingExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;
            case INST_Art_Id:
                art_levelTMP.text = hardSkill.CurrentLevel.ToString();
                artExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;
            case INST_Sound_Id:
                sound_levelTMP.text = hardSkill.CurrentLevel.ToString();
                soundExpImage.fillAmount = hardSkill.GetExpFillAmount();
                break;

        }
    }

    #region Time Manager
    private void OnGodenTimeHandler(bool isTime)
    {
        if (isTime)
        {
            godenTime.text = goden;
        }
        else
        {
            godenTime.text = normal;
        }
    }


    private void OnDateCalendarHandler(string date)
    {
        dateTMP.text = _timeManager.GetOnDate();
    }

    private void OnTimeCalendarHandler(string time)
    {
        timeTMP.text = _timeManager.GetOnTime();
    }
    #endregion

}
