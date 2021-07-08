using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleController : Manager<ScheduleController>
{
    private Schedule_DataHandler _schedule_DataHandler;
    private ScheduleRegister_DataHandler _scheduleRegister_DataHandler;

    private int Inst_maxMount;
    private int Inst_maxDay;

    private Dictionary<string, Schedule_Template> _scheduleDic;
    private Dictionary<string, ScheduleRegister_Template> _scheduleRegisterDic;
    private Schedule[] _gameCalendar;
    private Schedule[] _characterCalendar;
    private int _currentDate;
    private int _currentMount;
    private int _currentYear;
    private Day _currentDay;

    private SwitchScene _switchScene;
    private TimeManager _timeManager;
    [SerializeField] private StoreContoller _storeContoller;
    [SerializeField] private ClassActivityController _classActivityController;

    public Schedule[] CharacterCalendar { get => _characterCalendar; }
    public Schedule[] GameCalendar { get => _gameCalendar; }

    protected override void Awake()
    {
        base.Awake();
        _switchScene = SwitchScene.Instance;
        _timeManager = TimeManager.Instance;
        _timeManager.OnStartNewDayComplete.AddListener(OnStartNewDayCompleteHandler);

        _currentDate = _timeManager.DEFAULT_Origin_Date;
        _currentMount = _timeManager.DEFAULT_Origin_Month;
        _currentYear = _timeManager.DEFAULT_Origin_Year;
        Inst_maxDay = _timeManager.DEFAULT_MAXDATE;
        Inst_maxMount = _timeManager.DEFAULT_MAXMONTH;
        _currentDay = _timeManager.DEFAULT_Origin_Day;

        _schedule_DataHandler = FindObjectOfType<Schedule_DataHandler>();
        _scheduleRegister_DataHandler = FindObjectOfType<ScheduleRegister_DataHandler>();
        _scheduleDic = new Dictionary<string, Schedule_Template>();
        _scheduleRegisterDic = new Dictionary<string, ScheduleRegister_Template>();

        _gameCalendar = new Schedule[Inst_maxMount * Inst_maxDay];
        for(int i = 0; i < _gameCalendar.Length; i++)
        {
            _gameCalendar[i] = new Schedule(i);
        }
        
        _characterCalendar = new Schedule[Inst_maxMount * Inst_maxDay];
        for (int i = 0; i < _characterCalendar.Length; i++)
        {
            _characterCalendar[i] = new Schedule(i);
        }

        //schedule register data handler
        if (!ReferenceEquals(_scheduleRegister_DataHandler.GetScheduleRegisterDic, null))
        {
            foreach (KeyValuePair<string, ScheduleRegister_Template> register in _scheduleRegister_DataHandler.GetScheduleRegisterDic)
            {
                _scheduleRegisterDic.Add(register.Key, register.Value);
            }
        }

        //schedule data handler
        if (!ReferenceEquals(_schedule_DataHandler.GetScheduleDic, null))
        {
            foreach (KeyValuePair<string, Schedule_Template> schedule in _schedule_DataHandler.GetScheduleDic)
            {
                _scheduleDic.Add(schedule.Key, schedule.Value);
            }
        }

        //register calendar for all schedule
        if(!ReferenceEquals(_scheduleRegisterDic, null) && !ReferenceEquals(_scheduleDic, null))
        {
            foreach (KeyValuePair<string, ScheduleRegister_Template> register in _scheduleRegister_DataHandler.GetScheduleRegisterDic)
            {
                if(_gameCalendar != null)
                {
                    if(register.Value.ScheduleId != null)
                    {
                        for (int i = 0; i < register.Value.ScheduleId.Count; i++)
                        {
                            string scheduleID = register.Value.ScheduleId[i];

                            if (_scheduleDic.ContainsKey(scheduleID))
                            {
                                RegisterGameCalendar(_scheduleDic[scheduleID]);
                            }

                        }
                    }
                    
                }
            }
        }

        //register calendar for beginner
        if (!ReferenceEquals(_scheduleRegisterDic, null) && !ReferenceEquals(_scheduleDic, null))
        {
            foreach (KeyValuePair<string, ScheduleRegister_Template> register in _scheduleRegister_DataHandler.GetScheduleRegisterDic)
            {
                if (_characterCalendar != null)
                {
                    //register for default equle TRUE
                    if (register.Value.ScheduleId != null && register.Value.DefaultRegister)
                    {
                        for (int i = 0; i < register.Value.ScheduleId.Count; i++)
                        {
                            string scheduleID = register.Value.ScheduleId[i];

                            if (_scheduleDic.ContainsKey(scheduleID))
                            {
                                RegisterCharacterCalendar(_scheduleDic[scheduleID]);
                            }

                        }
                    }

                }
            }
        }

        
    }

    private void OnStartNewDayCompleteHandler()
    {
        //set info current day   
        _currentDate = _timeManager.Date;
        _currentMount = _timeManager.Month;
        _currentYear = _timeManager.Year;
        _currentDay = _timeManager.CurrentDays;

        //get schedules to day
        List<Schedule_Template> schedulesToday = new List<Schedule_Template>();
        int indexToday = CalIndexCalendar(_currentDate, _currentMount);
        if (indexToday < _gameCalendar.Length - 1)
        {
            schedulesToday = _gameCalendar[indexToday].Schedules;
        }

        //clear event on store and class activity controller
        _storeContoller.ClearEvent();
        _classActivityController.ClearClassEvent();

        //RegisterEvent
        for (int i = 0; i < schedulesToday.Count; i++)
        {
            ScheduleEvent scheduleEvents = schedulesToday[i].ScheduleEvents;
            if (scheduleEvents == ScheduleEvent.Project || scheduleEvents == ScheduleEvent.Class)
            {
                ClassActivityType classActivityType = ConvertType.ConvertScheduleEventToClassActivityType(scheduleEvents);
                _classActivityController.EnableClass(classActivityType, scheduleEvents, _currentDay);
            }
            else if (scheduleEvents == ScheduleEvent.DiscountFoodStore)
            {
                _storeContoller.RegisterEvent(StoreType.FoodStore, scheduleEvents);
            }
            else if (scheduleEvents == ScheduleEvent.MysticFestival1st
                || scheduleEvents == ScheduleEvent.MysticFestival2nd
                || scheduleEvents == ScheduleEvent.MysticFestival3rd
                || scheduleEvents == ScheduleEvent.MysticFestival4th)
            {
                _storeContoller.RegisterEvent(StoreType.MysticStore, scheduleEvents);
            }
            else if (scheduleEvents == ScheduleEvent.ClothingFestival101
                || scheduleEvents == ScheduleEvent.ClothingFestival202
                || scheduleEvents == ScheduleEvent.ClothingFestival303
                || scheduleEvents == ScheduleEvent.ClothingFestival404)
            {
                _storeContoller.RegisterEvent(StoreType.ClothingStore, scheduleEvents);
            }
            //other just show info in calenda
        }

        //item store set id
        _storeContoller.SetItemSetOnNewDay(_currentDay);

    }

    private void RegisterGameCalendar(Schedule_Template schedule)
    {
        if(schedule.Year == _currentYear)
        {
            int indexInCalendar = CalIndexCalendar(schedule.Day, schedule.Mount);
            if (!ReferenceEquals(_gameCalendar[indexInCalendar].Schedules, null))
            {
                _gameCalendar[indexInCalendar].AddSchedule(schedule);
            }
            
        }
    }

    private void RegisterCharacterCalendar(Schedule_Template schedule)
    {
        if (schedule.Year == _currentYear)
        {
            int indexInCalendar = CalIndexCalendar(schedule.Day, schedule.Mount);
            if (!ReferenceEquals(_characterCalendar[indexInCalendar].Schedules, null))
            {
                _characterCalendar[indexInCalendar].AddSchedule(schedule);
            }
            
        }
    }

    private int CalIndexCalendar(int day, int mount)
    {
        //index = (วัน - 1) + (28 * (เดือน - 1))
        return (day - 1) + (Inst_maxDay * (mount - 1));
    }

    public int GetIndexCurrentDay()
    {
        return (_currentDate - 1) + (Inst_maxDay * (_currentMount - 1));
    }

    public void TestingGameCalendar()
    {
        for(int calendarIndex = 0; calendarIndex < _gameCalendar.Length; calendarIndex++)
        {
            for(int schedule = 0; schedule < _gameCalendar[calendarIndex].Schedules.Count; schedule++)
            {
                string name = _gameCalendar[calendarIndex].Schedules[schedule].ScheduleName;
                string time = _gameCalendar[calendarIndex].Schedules[schedule].Time;
                Debug.Log(string.Format("{0} Schedule {1} ", time, name));
            }
        }
    }

    public void TestingCharacterCalendar()
    {
        for (int calendarIndex = 0; calendarIndex < _characterCalendar.Length; calendarIndex++)
        {
            for (int schedule = 0; schedule < _characterCalendar[calendarIndex].Schedules.Count; schedule++)
            {
                string name = _characterCalendar[calendarIndex].Schedules[schedule].ScheduleName;
                string time = _characterCalendar[calendarIndex].Schedules[schedule].Time;
                Debug.Log(string.Format("{0} Schedule {1} ", time, name));
            }
        }
    }
}
