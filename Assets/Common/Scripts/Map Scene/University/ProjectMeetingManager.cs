using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectMeetingManager : MonoBehaviour
{
    public Events.EventOnProjectAnalyzingCompleted OnProjectAnalyzingCompleted;

    public enum ProgressionState
    {
        Analyzing,
        Completed,
    }
    private ProgressionState _progressionState;

    private const int INST_30MINUTE_SECOND = 1800;

    [Header("Manager")]
    private ProjectController _projectController;
    private UniversityManager _universityManager;
    private CharacterStatusController _characterStatusController;
    private TimeManager _timeManager;
    private GameManager _gameManager;
    private SwitchScene _switchScene;
    private DialougeManager _dialougeManager;

    [Header("Display")]
    [SerializeField] ProjectMeetingDisplay _projectMeetingDisplay;

    [Header("Value Generator")]
    [SerializeField] ValueUpdateGenerator _codingGenerator;
    [SerializeField] ValueUpdateGenerator _designGenerator;
    [SerializeField] ValueUpdateGenerator _testingGenerator;
    [SerializeField] ValueUpdateGenerator _artGenerator;
    [SerializeField] ValueUpdateGenerator _soundGenerator;
    [SerializeField] ValueUpdateGenerator _bugGenerator;
    [SerializeField] ValueUpdateGenerator _expGenerator;

    [Header("Button")]
    [SerializeField] GameObject _button;

    #region Time
    private float _currentTimeHour;
    private float _currentTimeMinute;
    private float _curretnTimeSecond;
    private float _endTimeHour;
    private float _endTimeMinute;
    private float _endTimeSecond;
    private int _diffTimeSecond;
    private int _timePer30Minute;
    #endregion


    #region Project Status
    private int _lastCodingStatus;
    private int _lastDesignStatus;
    private int _lastTestingStatus;
    private int _lastArtStatus;
    private int _lastSoundStatus;
    private int _lastBugStatus;

    private int _currentCodingStatus;
    private int _currentDesignStatus;
    private int _currentTestingStatus;
    private int _currentArtStatus;
    private int _currentSoundStatus;
    private int _currentBugStatus;

    private int _updateCodingStatusPerTime;
    private int _updateDesignStatusPerTime;
    private int _updateTestingStatusPerTime;
    private int _updateArtStatusPerTime;
    private int _updateeSoundStatusPerTime;
    private int _updateBugStatusPerTime;

    private float _energy;
    #endregion

    #region Analyzing
    private float _progress;
    private int _score;
    private int countTime;
    #endregion
    public float Progress { get => _progress; }
    public int Score { get => _score; }
    private void Awake()
    {
        _universityManager = FindObjectOfType<UniversityManager>();
        _projectController = ProjectController.Instance;
        _characterStatusController = CharacterStatusController.Instance;
        _switchScene = SwitchScene.Instance;
        _gameManager = GameManager.Instance;
        _dialougeManager = DialougeManager.Instance;

        _gameManager.OnGameStateChanged.AddListener(OnGamestateChangedHandler);

        _timeManager = TimeManager.Instance;
        _timeManager.OnOneMiniuteTimePassed.AddListener(OnOneMinuteTimePassed);
        _timeManager.OnTimeSkip.AddListener(OnTimeSkipCompleted);
        countTime = 0;
        _progress = 0f;
        _score = 0;
        _progressionState = ProgressionState.Analyzing;
        ActiveButton(false);
    }

    private void OnGamestateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.MEETING_PROJECT && previous == GameManager.GameState.WORK_PROJECT_DESIGN)
        {
            if (_projectController.HasDesigned)
            {
                StartCoroutine("WaitTime");
            }
        }   
        else if (current == GameManager.GameState.MEETING_PROJECT && previous == GameManager.GameState.DIALOUGE)
        {
            UpdateProjectPhase();
            ActiveButton(true);
        }
    }

    private void Start()
    {
        _currentTimeHour = _universityManager.CurrentTimeHour;
        _currentTimeMinute = _universityManager.CurrentTimeMinute;
        _curretnTimeSecond = _universityManager.CurrentTimeSecond;

        _endTimeHour = _universityManager.EndTimeHour;
        _endTimeMinute = _universityManager.EndTimeMinute;
        _endTimeSecond = _universityManager.EndTimeSecond;

        _diffTimeSecond = DiffTimeSecond(_currentTimeHour, _currentTimeMinute, _curretnTimeSecond, _endTimeHour, _endTimeMinute, _endTimeSecond);
        
        _energy = _universityManager.Energy;

        _lastCodingStatus = _projectController.LasttimeCodingStatus;
        _lastDesignStatus = _projectController.LasttimeDesignStatus;
        _lastTestingStatus = _projectController.LasttimeTestingStatus;
        _lastArtStatus = _projectController.LasttimeArtStatus;
        _lastSoundStatus = _projectController.LasttimeSoundStatus;
        _lastBugStatus = _projectController.LasttimeBugStatus;

        _currentCodingStatus = _projectController.CurrentCodingStatus;
        _currentDesignStatus = _projectController.CurrentDesignStatus;
        _currentTestingStatus = _projectController.CurrentTestingStatus;
        _currentArtStatus = _projectController.CurrentArtStatus;
        _currentSoundStatus = _projectController.CurrentSoundStatus;      
        _currentBugStatus = _projectController.CurrentBugStatus;

        //count time to update value
        _timePer30Minute = (int) _diffTimeSecond / INST_30MINUTE_SECOND;
        if(_timePer30Minute > 0)
        {
            _updateCodingStatusPerTime = ((_currentCodingStatus - _lastCodingStatus) / _timePer30Minute);
            _updateDesignStatusPerTime = ((_currentDesignStatus - _lastDesignStatus) / _timePer30Minute);
            _updateTestingStatusPerTime = ((_currentTestingStatus - _lastTestingStatus) / _timePer30Minute);
            _updateArtStatusPerTime = ((_currentArtStatus - _lastArtStatus) / _timePer30Minute);
            _updateeSoundStatusPerTime = ((_currentSoundStatus - _lastSoundStatus) / _timePer30Minute);
            _updateBugStatusPerTime = ((_currentBugStatus - _lastBugStatus) / _timePer30Minute);
        }
        else
        {
            _updateCodingStatusPerTime = ((_currentCodingStatus - _lastCodingStatus));
            _updateDesignStatusPerTime = ((_currentDesignStatus - _lastDesignStatus));
            _updateTestingStatusPerTime = ((_currentTestingStatus - _lastTestingStatus));
            _updateArtStatusPerTime = ((_currentArtStatus - _lastArtStatus));
            _updateeSoundStatusPerTime = ((_currentSoundStatus - _lastSoundStatus));
            _updateBugStatusPerTime = ((_currentBugStatus - _lastBugStatus));
        }

        OnProjectAnalyzingCompleted?.Invoke(_progress, _score, _progressionState);

        if (_projectController.HasDesigned || _projectController.ProjectPhase == ProjectPhase.Decision)
        {
            StartCoroutine("WaitTime");
        }
        else
        {
            _switchScene.DisplayWorkProjectDesign(true);
        }
        
    }

    private void OnOneMinuteTimePassed(GameManager.GameState current)
    {
        if (current == GameManager.GameState.MEETING_PROJECT)
        {
            countTime++;
            if (countTime != 0 && countTime % 30 == 0)
            {
                UpdateStatus();
            }
        }
    }

    private void OnTimeSkipCompleted(GameManager.GameState current)
    {
        if (current == GameManager.GameState.MEETING_PROJECT)
        {
            ValidateStatus();
            UpdateCharacterInfo();
            Analyzing();
        }
    }

    private void UpdateStatus()
    {
        if(_updateCodingStatusPerTime > 0)
        {
            _projectController.IncreaseLastCodingStatus(_updateCodingStatusPerTime);
            _codingGenerator.CreateTemplate(_updateCodingStatusPerTime.ToString());
        }

        if(_updateDesignStatusPerTime > 0)
        {
            _projectController.IncreaseLastDesignStatus(_updateDesignStatusPerTime);
            _designGenerator.CreateTemplate(_updateDesignStatusPerTime.ToString());
        }

        if(_updateTestingStatusPerTime > 0)
        {
            _projectController.IncreaseLastTestingStatus(_updateTestingStatusPerTime);
            _testingGenerator.CreateTemplate(_updateTestingStatusPerTime.ToString());
        }

        if(_updateArtStatusPerTime > 0)
        {
            _projectController.IncreaseLastArtStatus(_updateArtStatusPerTime);
            _artGenerator.CreateTemplate(_updateArtStatusPerTime.ToString());
        }

        if(_updateeSoundStatusPerTime > 0)
        {
            _projectController.IncreaseLastSoundStatus(_updateeSoundStatusPerTime);
            _soundGenerator.CreateTemplate(_updateeSoundStatusPerTime.ToString());
        }

        if(_updateBugStatusPerTime > 0)
        {
            _projectController.IncreaseLastBugStatus(_updateBugStatusPerTime);
            _bugGenerator.CreateTemplate(_updateBugStatusPerTime.ToString());
        }
        else if(_updateBugStatusPerTime < 0)
        {
            _projectController.ReduceLastBugStatus(Mathf.Abs(_updateBugStatusPerTime));
            _bugGenerator.CreateTemplate(_updateBugStatusPerTime.ToString());
        }
    }
    private void UpdateCharacterInfo()
    {
        int exp = (int)(_characterStatusController.GetNextExpRequire() * 0.3f);
        _characterStatusController.IncreaseEXP(exp);
        _expGenerator.CreateTemplate(exp.ToString());

        _characterStatusController.TakeEnergy(_energy);
        _characterStatusController.IncreaseCurrentMotivation(_characterStatusController.Default_maxMotivation * 0.6f);
    }

    private void ValidateStatus()
    {
        int validateCoding = _currentCodingStatus - _projectController.LasttimeCodingStatus;
        int validateDesign = _currentDesignStatus - _projectController.LasttimeDesignStatus;
        int validateTesting = _currentTestingStatus - _projectController.LasttimeTestingStatus;
        int validateArt = _currentArtStatus - _projectController.LasttimeArtStatus;
        int validateSound = _currentSoundStatus - _projectController.LasttimeSoundStatus;
        int validateBug = _currentBugStatus - _projectController.LasttimeBugStatus;

        if (validateCoding > 0)
        {
            _projectController.IncreaseLastCodingStatus(validateCoding);
            _codingGenerator.CreateTemplate(validateCoding.ToString());
        }

        if (validateDesign > 0)
        {
            _projectController.IncreaseLastDesignStatus(validateDesign);
            _designGenerator.CreateTemplate(validateDesign.ToString());
        }

        if (validateTesting > 0)
        {
            _projectController.IncreaseLastTestingStatus(validateTesting);
            _testingGenerator.CreateTemplate(validateTesting.ToString());
        }

        if (validateArt > 0)
        {
            _projectController.IncreaseLastArtStatus(validateArt);
            _artGenerator.CreateTemplate(validateArt.ToString());
        }

        if (validateSound > 0)
        {
            _projectController.IncreaseLastSoundStatus(validateSound);
            _soundGenerator.CreateTemplate(validateSound.ToString());
        }

        if (validateBug > 0)
        {
            _projectController.IncreaseLastBugStatus(validateBug);
            _bugGenerator.CreateTemplate(validateBug.ToString());
        }
        else if (validateBug < 0)
        {
            _projectController.ReduceLastBugStatus(Mathf.Abs(validateBug));
            _bugGenerator.CreateTemplate(validateBug.ToString());
        }
    }

    private int DiffTimeSecond(float startHour, float startMinute, float startSecond, float endHour, float endMimute, float endSecond)
    {
        int totalStartSecond = (int)((startHour * 60 * 60) + (startMinute * 60) + startSecond);
        int totalEndSecond = (int)((endHour * 60 * 60) + (endMimute * 60) + endSecond);

        return totalEndSecond - totalStartSecond;
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(1f);
        _timeManager.SkilpTime(_diffTimeSecond, 4);
    }


    private void Analyzing()
    {
        _progress = 50f;
        _score = 234924;
        _progressionState = ProgressionState.Completed;
        OnProjectAnalyzingCompleted?.Invoke(_progress, _score, _progressionState);
        StartCoroutine("Dialogue");
    }

    IEnumerator Dialogue()
    {
        yield return new WaitForSecondsRealtime(1f);
        _dialougeManager.ProjectDialouge(_projectController.ProjectPhase);
    }

    private void ActiveButton(bool active)
    {
        if(_button.activeSelf != active)
        {
            _button.SetActive(active);
        }
    }

    private void UpdateProjectPhase()
    {
        _projectController.UpdateProjectState();
    }

    public void Next()
    {
        _switchScene.DisplayMeetingProject(false);
    }
}
