﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDetails_DataHandler : DataHandler
{
    protected Dictionary<string, Status_Template> status_dic;
    [SerializeField] private StatusDetailsVM statusDetailsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, Status_Template> GetStatusDic
    {
        get { return status_dic; }
    }

    protected void Awake()
    {
        status_dic = new Dictionary<string, Status_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        status_dic = statusDetailsVM.Interpert();
        if (!ReferenceEquals(status_dic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Status Detail interpret completed");
        //foreach (KeyValuePair<string, Status> status in status_dic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Color = {2}",
        //        status.Key, status.Value.StatusName, status.Value.StatusColor));

        //}
    }

}
