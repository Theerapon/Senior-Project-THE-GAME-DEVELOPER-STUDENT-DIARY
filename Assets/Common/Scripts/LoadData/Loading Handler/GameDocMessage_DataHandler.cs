using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDocMessage_DataHandler : DataHandler
{
    protected GameDocMessage_Template gameDocMessage;
    [SerializeField] private GameDocMessageVM gameDocMessageVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public GameDocMessage_Template GetGameDocMessage
    {
        get { return gameDocMessage; }
    }

    protected void Awake()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        gameDocMessage = gameDocMessageVM.Interpert();
        if (!ReferenceEquals(gameDocMessage, null))
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
