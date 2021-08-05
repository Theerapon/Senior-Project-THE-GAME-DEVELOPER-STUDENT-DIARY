using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseActivitySlot;

public class UniversityManager : MonoBehaviour
{
    [SerializeField] private ActivityTemplateGenerator _activityTemplateGenerator;

    private ClassActivityController _classActivityController;
    private SwitchScene _switchScene;
    private TimeManager _timeManager;
    private PlayerAction _playerAction;
    private GameManager _gameManager;

    private float _energy;
    public float Energy { get => _energy; }

    private void Awake()
    {
        _classActivityController = ClassActivityController.Instance;
        _switchScene = SwitchScene.Instance;
        _timeManager = TimeManager.Instance;
        _playerAction = PlayerAction.Instance;
        _gameManager = GameManager.Instance;
        
        if(!ReferenceEquals(_gameManager, null))
        {
            _gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        }
    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.PLACE && previous == GameManager.GameState.MEETING_PROJECT)
        {
            Initializing();
        }
    }

    private void Start()
    {
        Initializing();
    }

    private void Initializing()
    {
        Dictionary<string, ClassActivity> classActivity = new Dictionary<string, ClassActivity>();
        classActivity = _classActivityController.ClassActivitiesDic;

        _activityTemplateGenerator.Clear();
        foreach (KeyValuePair<string, ClassActivity> activity in classActivity)
        {
            ClassActivity copy = activity.Value;
            string activityId = activity.Key;
            string activityName = copy.Activity_name;
            Day activityDay = copy.Day;
            string activityTime = string.Format("{0}:{1:00}-{2}:{3:00} น.", copy.Start_time_hour, copy.Start_time_minute, copy.End_time_hour, copy.End_time_minute);
            float energy = _playerAction.CalReduceEnergyToCunsume(copy.Energy);
            ClassActivityType activityType = copy.ActivityType;
            Sprite activityIcon = copy.Icon;
            bool isOpen = false;
            if (!_classActivityController.HasFinishEvent())
            {
                isOpen = copy.IsOpening;
            }
            UniversityActivity universityActivity = new UniversityActivity(activityId, activityName, activityDay, activityTime, energy, activityType, activityIcon, isOpen);
            _activityTemplateGenerator.CreateTemplate(universityActivity);
        }
    }

    public void EnterActivity(BaseActivitySlot baseActivitySlot)
    {
        string id = baseActivitySlot.ACTIVITY.ActivityId;
        if (_classActivityController.ClassActivitiesDic.ContainsKey(id))
        {
            ClassActivity classActivity = _classActivityController.ClassActivitiesDic[id];

            _energy = baseActivitySlot.ACTIVITY.Energy;

            if (baseActivitySlot.ACTIVITY.ActivityType == ClassActivityType.Project)
            {
                _classActivityController.FinishEvent();
                _switchScene.DisplayMeetingProject(true);
            }
        }

        
    }
}
