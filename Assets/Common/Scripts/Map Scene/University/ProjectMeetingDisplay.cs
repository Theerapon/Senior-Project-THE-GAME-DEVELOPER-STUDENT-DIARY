using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ProjectMeetingManager;

public class ProjectMeetingDisplay : MonoBehaviour
{
    #region string time instance
    private const string goden = "Golden Time";
    private const string normal = "Normal Time";
    #endregion

    #region string progressing state
    private const string INST_ANALYZING = "กำลังประเมิลผล...";
    private const string INST_COMPLETED = "ประเมิลผลเสร็จสิ้น";
    #endregion

    [Header("Manager")]
    [SerializeField] private ProjectMeetingManager _projectMeetingManager;
    private ProjectController _projectController;
    private CharacterStatusController _characterStatusController;
    private TimeManager _timeManager;

    [Header("Time")]
    [SerializeField] TMP_Text _dateTMP;
    [SerializeField] TMP_Text _timeTMP;
    [SerializeField] TMP_Text _goldenTimeTMP;

    [Header("Project")]
    [SerializeField] Animator _animator;
    [SerializeField] TMP_Text _projectPhaseTMP;
    [SerializeField] TMP_Text _processingTMP;
    [SerializeField] TMP_Text _codingTMP;
    [SerializeField] TMP_Text _designTMP;
    [SerializeField] TMP_Text _testingTMP;
    [SerializeField] TMP_Text _artTMP;
    [SerializeField] TMP_Text _soundTMP;
    [SerializeField] TMP_Text _bugTMP;

    [Header("Analyzing")]
    [SerializeField] TMP_Text _analyingTMP;
    [SerializeField] TMP_Text _scoreTMP;

    [Header("Character")]
    [SerializeField] TMP_Text _charLevelTMP;
    [SerializeField] TMP_Text _charCurrectExp;
    [SerializeField] TMP_Text _charExpRequired;
    [SerializeField] Image _charExpFillImage;

    private void Awake()
    {
        _projectController = ProjectController.Instance;
        _characterStatusController = CharacterStatusController.Instance;
        _timeManager = TimeManager.Instance;

        if (!ReferenceEquals(_projectMeetingManager, null))
        {
            _projectMeetingManager.OnProjectAnalyzingCompleted.AddListener(OnAnalyzingCompletedHandler);
        }

        if (!ReferenceEquals(_projectController, null))
        {
            _projectController.OnProjectLastStatusUpdate.AddListener(OnLastStatusUpdateHandler);
            _projectController.OnProjectStateUpdate.AddListener(OnProjectStateHandler);
        }

        if(!ReferenceEquals(_characterStatusController, null))
        {
            _characterStatusController.OnExpUpdated.AddListener(OnExpUpdateHandler);
        }

        if(!ReferenceEquals(_timeManager, null))
        {
            _timeManager.OnDateCalendar.AddListener(OnDateUpdateHandler);
            _timeManager.OnTimeCalendar.AddListener(OnTimeUpdateHandler);
            _timeManager.OnGodenTime.AddListener(OnGodenTimeUpdateHandler);
            _timeManager.ValidationInitializing();
        }
    }

    private void OnAnalyzingCompletedHandler(float progress, int score, ProgressionState progressionState)
    {
        _analyingTMP.text = string.Format("{0:n2}", progress);
        _scoreTMP.text = string.Format("{0}", score);

        if(progressionState == ProgressionState.Completed)
        {
            _processingTMP.text = INST_COMPLETED;
            _animator.SetTrigger("Complete");
        }
        else
        {
            _processingTMP.text = INST_ANALYZING;
        }
        
    }

    private void Start()
    {
        Initializing();
    }

    private void Initializing()
    {
        if (!ReferenceEquals(_timeManager, null))
        {
            _timeManager.ValidationInitializing();
        }

        if (!ReferenceEquals(_projectController, null))
        {
            OnLastStatusUpdateHandler();
            OnProjectStateHandler();
        }

        if (!ReferenceEquals(_characterStatusController, null))
        {
            OnExpUpdateHandler();
        }

    }

    private void OnGodenTimeUpdateHandler(bool isTime)
    {
        if (isTime)
        {
            _goldenTimeTMP.text = goden;
        }
        else
        {
            _goldenTimeTMP.text = normal;
        }
    }

    private void OnTimeUpdateHandler(string time)
    {
        _timeTMP.text = _timeManager.GetOnTime();
    }

    private void OnDateUpdateHandler(string date)
    {
        _dateTMP.text = _timeManager.GetOnDate();
    }

    private void OnExpUpdateHandler()
    {
        _charExpFillImage.fillAmount = (float)_characterStatusController.CurrentExp / _characterStatusController.GetNextExpRequire();
        _charExpRequired.text = string.Format("{0}", _characterStatusController.GetNextExpRequire());
        _charCurrectExp.text = string.Format("{0}", _characterStatusController.CurrentExp);
        _charLevelTMP.text = string.Format("{0}", _characterStatusController.CurrentLevel);
    }

    private void OnLastStatusUpdateHandler()
    {
        _codingTMP.text = string.Format("{0}", _projectController.LasttimeCodingStatus);
        _designTMP.text = string.Format("{0}", _projectController.LasttimeDesignStatus);
        _testingTMP.text = string.Format("{0}", _projectController.LasttimeTestingStatus);
        _artTMP.text = string.Format("{0}", _projectController.LasttimeArtStatus);
        _soundTMP.text = string.Format("{0}", _projectController.LasttimeSoundStatus);
        _bugTMP.text = string.Format("{0}", _projectController.LasttimeBugStatus);
    }

    private void OnProjectStateHandler()
    {
        _projectPhaseTMP.text = ConvertType.ConvertProjectPhaseToString(_projectController.ProjectPhase);
    }
}
