using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassActivities_DataHandler : Manager<ClassActivities_DataHandler>
{
    protected Dictionary<string, ClassActivities_Template> classActivitiesDic;
    [SerializeField] private ClassActivitiesVM classActivitiesVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public Dictionary<string, ClassActivities_Template> GetClassActivitiesDic
    {
        get { return classActivitiesDic; }
    }

    protected override void Awake()
    {
        base.Awake();
        classActivitiesDic = new Dictionary<string, ClassActivities_Template>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);

    }

    private void EventInterpretHandler()
    {
        classActivitiesDic = classActivitiesVM.Interpert();
        //Debug.Log("Class Activities interpret completed");
        //foreach (KeyValuePair<string, ClassActivities_Template> classAcitivity in classActivitiesDic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Day = {2}, Start {3:00}:{4:00}",
        //        classAcitivity.Key, classAcitivity.Value.Activity_name, classAcitivity.Value.Day,
        //        classAcitivity.Value.Start_time_hour, classAcitivity.Value.Start_time_minute));

        //}
    }
}
