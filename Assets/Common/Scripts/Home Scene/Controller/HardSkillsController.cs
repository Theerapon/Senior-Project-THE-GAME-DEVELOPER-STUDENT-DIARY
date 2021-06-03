using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkillsController : Manager<HardSkillsController>
{
    public Dictionary<string, HardSkill> hardskills;

    private void Start()
    {
        if (!ReferenceEquals(HardSkills_DataHandler.Instance.GetHardSkillsDic, null))
        {
            foreach (KeyValuePair<string, HardSkill_Template> hardskill in HardSkills_DataHandler.Instance.GetHardSkillsDic)
            {
                hardskills.Add(hardskill.Key, new HardSkill(hardskill.Value));
            }
            Debug.Log("wait implementation for load save data");
        }

    }
}
