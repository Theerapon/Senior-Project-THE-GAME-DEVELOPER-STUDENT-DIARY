using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkills_DataHandler : DataHandler
{
    protected Dictionary<string, HardSkill_Template> hardSkillsDic;
    [SerializeField] private HardSkillsVM hardSkillsVM;
    [SerializeField] private InterpretHandler interpretHandler;
   

    public Dictionary<string, HardSkill_Template> GetHardSkillsDic
    {
        get { return hardSkillsDic; }
    }
    
    protected void Awake()
    {
        hardSkillsDic = new Dictionary<string, HardSkill_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        hardSkillsDic = hardSkillsVM.Interpert();
        if (!ReferenceEquals(hardSkillsDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("HardSkill interpret completed");
        //foreach (KeyValuePair<string, HardSkill> hardskill in hardSkillsDic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Level = {2}",
        //        hardskill.Value.GetHardSkillID(), hardskill.Value.GetHardSkillName(), hardskill.Value.GetCurrentHardSkillLevel()));

        //}
    }




}
