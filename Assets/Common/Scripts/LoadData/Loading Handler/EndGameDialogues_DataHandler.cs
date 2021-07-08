using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDialogues_DataHandler : DataHandler
{
    protected Dictionary<Grade, EndGameTemplate> _endGameDialogueDic;
    [SerializeField] private EndGameDialogueVM _endGameDialogueVM;
    [SerializeField] private InterpretHandler _interpretHandler;


    public Dictionary<Grade, EndGameTemplate> EndGameDialogueDic
    {
        get { return _endGameDialogueDic; }
    }

    protected void Awake()
    {
        _endGameDialogueDic = new Dictionary<Grade, EndGameTemplate>();
        _interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        _endGameDialogueDic = _endGameDialogueVM.Interpert();
        if (!ReferenceEquals(_endGameDialogueDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
    }
}
