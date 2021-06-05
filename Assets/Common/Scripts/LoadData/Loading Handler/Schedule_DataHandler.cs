using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule_DataHandler : DataHandler
{
    protected Dictionary<string, Schedule_Template> scheduleDic;
    [SerializeField] private ScheduleVM scheduleVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, Schedule_Template> GetScheduleDic
    {
        get { return scheduleDic; }
    }

    protected void Awake()
    {
        scheduleDic = new Dictionary<string, Schedule_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }


    private void EventInterpretHandler()
    {
        scheduleDic = scheduleVM.Interpert();
        if (!ReferenceEquals(scheduleDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Schedule interpret completed");
        //foreach (KeyValuePair<string, Schedule_Template> schedule in scheduleDic)
        //{
        //    Debug.Log(string.Format("Time {0}, ID = {1}, Event = {2}, Name = {3}, ",
        //        schedule.Value.Time, schedule.Value.Id, schedule.Value.ScheduleEvents, schedule.Value.ScheduleName));

        //}
    }
}
