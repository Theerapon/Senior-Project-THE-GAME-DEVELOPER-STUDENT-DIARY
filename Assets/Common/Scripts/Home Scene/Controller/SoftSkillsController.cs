using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkillsController : Manager<SoftSkillsController>
{
    public Dictionary<string, SoftSkill> softskills;

    private void Start()
    {
        if (!ReferenceEquals(SoftSkills_DataHandler.Instance.GetSoftSkillsDic, null))
        {
            foreach (KeyValuePair<string, SoftSkill> softskill in SoftSkills_DataHandler.Instance.GetSoftSkillsDic)
            {
                softskills.Add(softskill.Key, Instantiate(softskill.Value));
            }
            Debug.Log("wait implementation for load save data");
        }

    }
}
