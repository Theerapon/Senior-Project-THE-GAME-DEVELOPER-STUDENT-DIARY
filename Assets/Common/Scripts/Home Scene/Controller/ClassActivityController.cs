﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassActivityController : Manager<ClassActivityController>
{
    private ClassActivities_DataHandler _classActivities_DataHandler;
    private Dictionary<string, ClassActivity> _classActivitiesDic;


    public Dictionary<string, ClassActivity> ClassActivitiesDic { get => _classActivitiesDic; }

    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private ProjectController _projectController;

    private string _currentActivityId;
    private bool _currentDayHasEvent;
    private bool _eventFinish;
    private int _startHourEvent;
    private int _startMinuteEvent;

    protected override void Awake()
    {
        base.Awake();
        _classActivitiesDic = new Dictionary<string, ClassActivity>();
        _classActivities_DataHandler = FindObjectOfType<ClassActivities_DataHandler>();
        _timeManager = TimeManager.Instance;
        _timeManager.OnTenMinute.AddListener(OnTenMinuteHandler);

        //initializing Class activity
        if (!ReferenceEquals(_classActivities_DataHandler.GetClassActivitiesDic, null))
        {
            foreach (KeyValuePair<string, ClassActivities_Template> classActivity in _classActivities_DataHandler.GetClassActivitiesDic)
            {
                _classActivitiesDic.Add(classActivity.Key, new ClassActivity(classActivity.Value));
            }
        }
    }


    private void OnTenMinuteHandler()
    {
        float hour = _timeManager.Hour;
        float minute = _timeManager.Minute;

        foreach (KeyValuePair<string, ClassActivity> classActivity in _classActivitiesDic)
        {
            ClassActivity activity = classActivity.Value;
            if (activity.HasClass)
            {
                activity.CheckTimeToOpen(hour, minute);
            }
            else
            {
                activity.Close();
                if (_currentDayHasEvent && !_eventFinish)
                {
                    FinishEvent();
                    _projectController.MissingClass();
                }
            }
        }
    }

    public void EnableClass(ClassActivityType classActivityType, ScheduleEvent scheduleEvent, Day day)
    {
        foreach(KeyValuePair<string, ClassActivity> classActivity in _classActivitiesDic)
        {
            if(classActivityType == classActivity.Value.ActivityType)
            {
                string id = classActivity.Key;
                bool enable = classActivity.Value.EnableClass(scheduleEvent, day);
                if (enable)
                {
                    _currentActivityId = id;
                    _currentDayHasEvent = true;
                    _eventFinish = false;
                    _startHourEvent = classActivity.Value.Start_time_hour;
                    _startMinuteEvent = classActivity.Value.Start_time_minute;
                    break;
                }
            }
        }
    }

    public void ClearClassEvent()
    {
        _currentActivityId = string.Empty;
        _currentDayHasEvent = false;
        _eventFinish = false;
        _startHourEvent = 0;
        _startMinuteEvent = 0;

        foreach (KeyValuePair<string, ClassActivity> classActivity in _classActivitiesDic)
        {
            classActivity.Value.DisableClass();
        }
    }

    public void FinishEvent()
    {
        _eventFinish = true;
    }

    public bool HasFinishEvent()
    {
        return _eventFinish;
    }

    public bool HasEvent()
    {
        return _currentDayHasEvent;
    }

    public bool TimeEnoughForActivity(int totalSecond)
    {
        return _timeManager.HasEnoungTimeForProject(totalSecond, _startHourEvent, _startMinuteEvent);
    }
}
