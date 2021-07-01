using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkillsController : Manager<HardSkillsController>
{
    public readonly string INST_Math_Id = "MATH";
    public readonly string INST_Programming_Id = "PROGRAMMING";
    public readonly string INST_Engine_Id = "GAMEENGINE";
    public readonly string INST_Ai_Id = "AI";
    public readonly string INST_Network_Id = "NETWORK";
    public readonly string INST_Design_Id = "DESIGN";
    public readonly string INST_Testing_Id = "TESTING";
    public readonly string INST_Art_Id = "ART";
    public readonly string INST_Sound_Id = "SOUND";

    public Events.EventOnHardSkillExpUpdate OnHardSkillExpUpdate;

    private HardSkills_DataHandler hardSkills_DataHandler;
    private Dictionary<string, HardSkill> hardskills;
    public Dictionary<string, HardSkill> Hardskills { get => hardskills; }

    protected override void Awake()
    {
        base.Awake();
        hardSkills_DataHandler = FindObjectOfType<HardSkills_DataHandler>();
        hardskills = new Dictionary<string, HardSkill>();
        if (!ReferenceEquals(hardSkills_DataHandler.GetHardSkillsDic, null))
        {
            foreach (KeyValuePair<string, HardSkill_Template> hardskill in hardSkills_DataHandler.GetHardSkillsDic)
            {
                hardskills.Add(hardskill.Key, new HardSkill(hardskill.Value));
            }
            Debug.Log("wait implementation for load save data");
        }

    }

    public void IncreaseEXP(string id, int xp)
    {
        if (hardskills.ContainsKey(id))
        {
            hardskills[id].IncreaseEXP(xp);
            OnHardSkillExpUpdate?.Invoke(id);
        }
    }

}
