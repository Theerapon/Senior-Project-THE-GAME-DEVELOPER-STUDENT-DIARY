using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDetails_Handler : Manager<StatusDetails_Handler>
{
    protected Dictionary<string, Status> status_dic;
    private StatusDetailsVM statusDetailsVM;

    bool loaded = false;

    public Dictionary<string, Status> StatusDic
    {
        get { return status_dic; }
    }

    protected override void Awake()
    {
        base.Awake();
        status_dic = new Dictionary<string, Status>();
    }
    private void Start()
    {
        statusDetailsVM = FindObjectOfType<StatusDetailsVM>();
        loaded = false;

    }
    private void Update()
    {
        if (!loaded)
        {
            status_dic = statusDetailsVM.Interpert();
            loaded = true;
        }

    }
}
