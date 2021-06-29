using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassActivities_DataHandler : DataHandler
{
    protected Dictionary<string, ClassActivities_Template> classActivitiesDic;
    [SerializeField] private ClassActivitiesVM classActivitiesVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public Dictionary<string, ClassActivities_Template> GetClassActivitiesDic
    {
        get { return classActivitiesDic; }
    }

    protected void Awake()
    {
        classActivitiesDic = new Dictionary<string, ClassActivities_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        classActivitiesDic = classActivitiesVM.Interpert();
        if (!ReferenceEquals(classActivitiesDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
    }
}
