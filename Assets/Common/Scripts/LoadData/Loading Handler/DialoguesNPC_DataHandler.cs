using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesNPC_DataHandler : DataHandler
{
    protected Dictionary<string, List<DialoguesNPC_Template>> dialoguesNpcDic;
    [SerializeField] private DialoguesNpcVM dialoguesNpcVM;
    [SerializeField] private InterpretHandler interpretHandler;
    public Dictionary<string, List<DialoguesNPC_Template>> GetDialoguesNpcDic
    {
        get { return dialoguesNpcDic; }
    }

    protected void Awake()
    {
        dialoguesNpcDic = new Dictionary<string, List<DialoguesNPC_Template>>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }


    private void EventInterpretHandler()
    {
        dialoguesNpcDic = dialoguesNpcVM.Interpert();
        if (!ReferenceEquals(dialoguesNpcDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
    }
}
