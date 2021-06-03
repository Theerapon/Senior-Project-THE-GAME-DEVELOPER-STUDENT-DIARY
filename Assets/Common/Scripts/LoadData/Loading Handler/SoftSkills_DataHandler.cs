using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkills_DataHandler : Manager<SoftSkills_DataHandler>
{
    protected Dictionary<string, SoftSkill_Template> softSkillsDic;
    [SerializeField] private SoftSkillsVM softSkillsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, SoftSkill_Template> GetSoftSkillsDic
    {
        get { return softSkillsDic; }
    }

    protected override void Awake()
    {
        base.Awake();
        softSkillsDic = new Dictionary<string, SoftSkill_Template>();
    }

    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        softSkillsDic = softSkillsVM.Interpert();
        //Debug.Log("SoftSkill interpret completed");
        //foreach (KeyValuePair<string, SoftSkill> softskill in softSkillsDic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Description = {2}",
        //        softskill.Key, softskill.Value.GetSoftSkillName(), softskill.Value.GetSoftSkillDescription()));

        //}
    }

}
