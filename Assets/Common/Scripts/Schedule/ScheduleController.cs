using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleController : Manager<ScheduleController>
{
    private Schedule_DataHandler schedule_DataHandler;
    private ScheduleRegister_DataHandler scheduleRegister_DataHandler;

    private int Inst_maxMount;
    private int Inst_maxDay;

    private Dictionary<string, Schedule_Template> scheduleDic;
    private Dictionary<string, ScheduleRegister_Template> scheduleRegisterDic;
    private Schedule[] gameCalendar;
    private Schedule[] characterCalendar;
    private int currentDate;
    private int currentMount;
    private int currentYear;
    private Day currentDay;

    private TimeManager _timeManager;
    [SerializeField] private StoreContoller _storeContoller;

    protected override void Awake()
    {
        base.Awake();
        _timeManager = TimeManager.Instance;
        _timeManager.OnStartNewDayComplete.AddListener(OnStartNewDayCompleteHandler);

        currentDate = _timeManager.DEFAULT_Origin_Date;
        currentMount = _timeManager.DEFAULT_Origin_Month;
        currentYear = _timeManager.DEFAULT_Origin_Year;
        Inst_maxDay = _timeManager.DEFAULT_MAXDATE;
        Inst_maxMount = _timeManager.DEFAULT_MAXMONTH;
        currentDay = _timeManager.DEFAULT_Origin_Day;

        schedule_DataHandler = FindObjectOfType<Schedule_DataHandler>();
        scheduleRegister_DataHandler = FindObjectOfType<ScheduleRegister_DataHandler>();
        scheduleDic = new Dictionary<string, Schedule_Template>();
        scheduleRegisterDic = new Dictionary<string, ScheduleRegister_Template>();

        gameCalendar = new Schedule[Inst_maxMount * Inst_maxDay];
        for(int i = 0; i < gameCalendar.Length; i++)
        {
            gameCalendar[i] = new Schedule(i);
        }
        
        characterCalendar = new Schedule[Inst_maxMount * Inst_maxDay];
        for (int i = 0; i < characterCalendar.Length; i++)
        {
            characterCalendar[i] = new Schedule(i);
        }

        //schedule register data handler
        if (!ReferenceEquals(scheduleRegister_DataHandler.GetScheduleRegisterDic, null))
        {
            foreach (KeyValuePair<string, ScheduleRegister_Template> register in scheduleRegister_DataHandler.GetScheduleRegisterDic)
            {
                scheduleRegisterDic.Add(register.Key, register.Value);
            }
        }

        //schedule data handler
        if (!ReferenceEquals(schedule_DataHandler.GetScheduleDic, null))
        {
            foreach (KeyValuePair<string, Schedule_Template> schedule in schedule_DataHandler.GetScheduleDic)
            {
                scheduleDic.Add(schedule.Key, schedule.Value);
            }
        }

        //register calendar for all schedule
        if(!ReferenceEquals(scheduleRegisterDic, null) && !ReferenceEquals(scheduleDic, null))
        {
            foreach (KeyValuePair<string, ScheduleRegister_Template> register in scheduleRegister_DataHandler.GetScheduleRegisterDic)
            {
                if(gameCalendar != null)
                {
                    if(register.Value.ScheduleId != null)
                    {
                        for (int i = 0; i < register.Value.ScheduleId.Count; i++)
                        {
                            string scheduleID = register.Value.ScheduleId[i];

                            if (scheduleDic.ContainsKey(scheduleID))
                            {
                                RegisterGameCalendar(scheduleDic[scheduleID]);
                            }

                        }
                    }
                    
                }
            }
        }

        //register calendar for beginner
        if (!ReferenceEquals(scheduleRegisterDic, null) && !ReferenceEquals(scheduleDic, null))
        {
            foreach (KeyValuePair<string, ScheduleRegister_Template> register in scheduleRegister_DataHandler.GetScheduleRegisterDic)
            {
                if (characterCalendar != null)
                {
                    //register for default equle TRUE
                    if (register.Value.ScheduleId != null && register.Value.DefaultRegister)
                    {
                        for (int i = 0; i < register.Value.ScheduleId.Count; i++)
                        {
                            string scheduleID = register.Value.ScheduleId[i];

                            if (scheduleDic.ContainsKey(scheduleID))
                            {
                                RegisterCharacterCalendar(scheduleDic[scheduleID]);
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
        currentDate = _timeManager.Date;
        currentMount = _timeManager.Month;
        currentYear = _timeManager.Year;
        currentDay = _timeManager.CurrentDays;

        //get schedules to day
        List<Schedule_Template> schedulesToday = new List<Schedule_Template>();
        int indexToday = CalIndexCalendar(currentDate, currentMount);
        if(indexToday < gameCalendar.Length - 1)
        {
            schedulesToday = gameCalendar[indexToday].Schedules;
        }

        //clear event on store
        _storeContoller.ClearEvent();

        //RegisterEvent
        for (int i = 0; i < schedulesToday.Count; i++)
        {
            ScheduleEvent scheduleEvents = schedulesToday[i].ScheduleEvents;
            if (scheduleEvents == ScheduleEvent.Project)
            {
                //for class activity on university
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
        _storeContoller.SetItemSetOnNewDay(currentDay);
    }

    private void RegisterGameCalendar(Schedule_Template schedule)
    {
        if(schedule.Year == currentYear)
        {
            int indexInCalendar = CalIndexCalendar(schedule.Day, schedule.Mount);
            if (!ReferenceEquals(gameCalendar[indexInCalendar].Schedules, null))
            {
                gameCalendar[indexInCalendar].AddSchedule(schedule);
            }
            
        }
    }

    private void RegisterCharacterCalendar(Schedule_Template schedule)
    {
        if (schedule.Year == currentYear)
        {
            int indexInCalendar = CalIndexCalendar(schedule.Day, schedule.Mount);
            if (!ReferenceEquals(characterCalendar[indexInCalendar].Schedules, null))
            {
                characterCalendar[indexInCalendar].AddSchedule(schedule);
            }
            
        }
    }

    private int CalIndexCalendar(int day, int mount)
    {
        //index = (วัน - 1) + (28 * (เดือน - 1))
        return (day - 1) + (Inst_maxDay * (mount - 1));
    }

    public void TestingGameCalendar()
    {
        for(int calendarIndex = 0; calendarIndex < gameCalendar.Length; calendarIndex++)
        {
            for(int schedule = 0; schedule < gameCalendar[calendarIndex].Schedules.Count; schedule++)
            {
                string name = gameCalendar[calendarIndex].Schedules[schedule].ScheduleName;
                string time = gameCalendar[calendarIndex].Schedules[schedule].Time;
                Debug.Log(string.Format("{0} Schedule {1} ", time, name));
            }
        }
    }

    public void TestingCharacterCalendar()
    {
        for (int calendarIndex = 0; calendarIndex < characterCalendar.Length; calendarIndex++)
        {
            for (int schedule = 0; schedule < characterCalendar[calendarIndex].Schedules.Count; schedule++)
            {
                string name = characterCalendar[calendarIndex].Schedules[schedule].ScheduleName;
                string time = characterCalendar[calendarIndex].Schedules[schedule].Time;
                Debug.Log(string.Format("{0} Schedule {1} ", time, name));
            }
        }
    }
}
