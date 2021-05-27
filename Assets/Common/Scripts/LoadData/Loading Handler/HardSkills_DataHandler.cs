using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkills_DataHandler : Manager<HardSkills_DataHandler>
{
    protected Dictionary<string, HardSkill> hardSkillsDic;
    [SerializeField] private HardSkillsVM hardSkillsVM;
    [SerializeField] private InterpretHandler interpretHandler;
   

    public Dictionary<string, HardSkill> GetHardSkillsDic
    {
        get { return hardSkillsDic; }
    }
    
    protected override void Awake()
    {
        base.Awake();
        hardSkillsDic = new Dictionary<string, HardSkill>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        hardSkillsDic = hardSkillsVM.Interpert();
        Debug.Log("activities interpret completed");
        foreach (KeyValuePair<string, HardSkill> hardskill in hardSkillsDic)
        {
            Debug.Log(string.Format("ID = {0}, Name = {1}, Level = {2}",
                hardskill.Value.GetHardSkillID(), hardskill.Value.GetHardSkillName(), hardskill.Value.GetCurrentHardSkillLevel()));

        }
    }




}
