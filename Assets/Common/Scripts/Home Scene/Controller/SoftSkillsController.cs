using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkillsController : Manager<SoftSkillsController>
{
    SoftSkills_DataHandler softSkills_DataHandler;
    private Dictionary<string, SoftSkill> softskills;

    public Dictionary<string, SoftSkill> Softskills { get => softskills; }

    protected override void Awake()
    {
        base.Awake();
        softSkills_DataHandler = FindObjectOfType<SoftSkills_DataHandler>();
        softskills = new Dictionary<string, SoftSkill>();
        if (!ReferenceEquals(softSkills_DataHandler.GetSoftSkillsDic, null))
        {
            foreach (KeyValuePair<string, SoftSkill> softskill in softSkills_DataHandler.GetSoftSkillsDic)
            {
                softskills.Add(softskill.Key, softskill.Value);
            }
            Debug.Log("wait implementation for load save data");
        }
    }


}
