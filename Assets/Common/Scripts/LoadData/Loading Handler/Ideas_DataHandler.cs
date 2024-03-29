﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ideas_DataHandler : DataHandler
{
    protected Dictionary<string, Idea_Template> ideasDic;
    [SerializeField] private IdeasVM ideasVM;
    [SerializeField] private InterpretHandler interpretHandler;
    public Dictionary<string, Idea_Template> GetIdeasDic
    {
        get { return ideasDic; }
    }

    protected void Awake()
    {
        ideasDic = new Dictionary<string, Idea_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }


    private void EventInterpretHandler()
    {
        ideasDic = ideasVM.Interpert();
        if (!ReferenceEquals(ideasDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Ideas interpret completed");
        //foreach (KeyValuePair<string, Idea_Template> idea in ideasDic)
        //{
        //    Debug.Log(string.Format("ID {0}, Type {1}, Name {2}, Collected = {3}", 
        //        idea.Key, idea.Value.IdeaType, idea.Value.IdeaName, idea.Value.Collected));

        //}
    }
}
