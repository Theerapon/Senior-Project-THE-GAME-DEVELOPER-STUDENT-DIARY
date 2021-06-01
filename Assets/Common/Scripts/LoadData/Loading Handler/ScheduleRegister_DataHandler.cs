using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleRegister_DataHandler : Manager<ScheduleRegister_DataHandler>
{
    protected Dictionary<string, ScheduleRegister_Template> scheduleRegisterDic;
    [SerializeField] private ScheduleRegisterVM scheduleRegisterVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, ScheduleRegister_Template> GetScheduleRegisterDic
    {
        get { return scheduleRegisterDic; }
    }

    protected override void Awake()
    {
        base.Awake();
        scheduleRegisterDic = new Dictionary<string, ScheduleRegister_Template>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);

    }

    private void EventInterpretHandler()
    {
        scheduleRegisterDic = scheduleRegisterVM.Interpert();
        //Debug.Log("Schedule Rgister interpret completed");
        //foreach (KeyValuePair<string, ScheduleRegister_Template> scheduleRegister in scheduleRegisterDic)
        //{
        //    for(int i = 0; i < scheduleRegister.Value.ScheduleId.Count; i++)
        //    {
        //        Debug.Log(string.Format("ID = {0}, Name = {1}, ScheduleID = {2}",
        //        scheduleRegister.Key, scheduleRegister.Value.RegisterName, scheduleRegister.Value.ScheduleId[i]));
        //    }

        //}
    }
}
