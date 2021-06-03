using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDetails_DataHandler : Manager<StatusDetails_DataHandler>
{
    protected Dictionary<string, Status_Template> status_dic;
    [SerializeField] private StatusDetailsVM statusDetailsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, Status_Template> GetStatusDic
    {
        get { return status_dic; }
    }

    protected override void Awake()
    {
        base.Awake();
        status_dic = new Dictionary<string, Status_Template>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);

    }

    private void EventInterpretHandler()
    {
        status_dic = statusDetailsVM.Interpert();
        //Debug.Log("Status Detail interpret completed");
        //foreach (KeyValuePair<string, Status> status in status_dic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Color = {2}",
        //        status.Key, status.Value.StatusName, status.Value.StatusColor));

        //}
    }

}
