using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActivitiesNpc_Template;

public class ActivitiesNPC_DataHandler : DataHandler
{
    protected Dictionary<string, ActivitiesNpc_Template> activitiesDic;
    [SerializeField] private ActivitiesNpcVM activitiesNpcVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public Dictionary<string, ActivitiesNpc_Template> GetActivitiesDic
    {
        get { return activitiesDic; }
    }

    private void Awake()
    {
        activitiesDic = new Dictionary<string, ActivitiesNpc_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        activitiesDic = activitiesNpcVM.Interpert();
        if (!ReferenceEquals(activitiesDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
    }
}
