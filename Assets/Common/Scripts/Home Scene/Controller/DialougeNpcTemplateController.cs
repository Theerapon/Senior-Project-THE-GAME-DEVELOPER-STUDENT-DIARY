using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeNpcTemplateController : Manager<DialougeNpcTemplateController>
{
    private DialoguesNPC_DataHandler _dialoguesNPC_DataHandler;
    private Dictionary<string, List<DialoguesNPC_Template>> dialoguesNpcDic;

    public Dictionary<string, List<DialoguesNPC_Template>> DialoguesNpcDic { get => dialoguesNpcDic; }

    protected override void Awake()
    {
        base.Awake();
        dialoguesNpcDic = new Dictionary<string, List<DialoguesNPC_Template>>();

        _dialoguesNPC_DataHandler = FindObjectOfType<DialoguesNPC_DataHandler>();

        //set Item template
        if (!ReferenceEquals(_dialoguesNPC_DataHandler.GetDialoguesNpcDic, null))
        {
            foreach (KeyValuePair<string, List<DialoguesNPC_Template>>  dialouge in _dialoguesNPC_DataHandler.GetDialoguesNpcDic)
            {
                string id = dialouge.Key;
                dialoguesNpcDic.Add(id, dialouge.Value);
            }

        }

    }
}
