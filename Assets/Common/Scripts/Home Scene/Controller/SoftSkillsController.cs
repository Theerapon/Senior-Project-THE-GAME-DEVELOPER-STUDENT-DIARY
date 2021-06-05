using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkillsController : Manager<SoftSkillsController>
{
    SoftSkills_DataHandler softSkills_DataHandler;
    private Dictionary<string, SoftSkill> softskills;

    public Dictionary<string, SoftSkill> Softskills { get => softskills; set => softskills = value; }

    private void Start()
    {
        softSkills_DataHandler = FindObjectOfType<SoftSkills_DataHandler>();
        if (!ReferenceEquals(softSkills_DataHandler, null))
        {

            foreach (KeyValuePair<string, SoftSkill> softskill in softSkills_DataHandler.GetSoftSkillsDic)
            {
                softskills.Add(softskill.Key, Instantiate(softskill.Value));
            }
            Debug.Log("wait implementation for load save data");
        }

    }
}
