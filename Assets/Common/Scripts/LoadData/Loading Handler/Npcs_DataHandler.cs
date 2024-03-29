﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcs_DataHandler : DataHandler
{
    protected Dictionary<string, Npc_Template> npcsDic;
    [SerializeField] private NpcsVM npcsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, Npc_Template> GetNpcsDic
    {
        get { return npcsDic; }
    }

    protected void Awake()
    {
        npcsDic = new Dictionary<string, Npc_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        npcsDic = npcsVM.Interpert();
        if(!ReferenceEquals(npcsDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Npcs interpret completed");
        //foreach (KeyValuePair<string, Npc_Template> npc in npcsDic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Birthday = {2}, Home = {3}",
        //        npc.Value.Id, npc.Value.NpcName, npc.Value.Birthday, npc.Value.OriginHome));

        //}
    }
}
