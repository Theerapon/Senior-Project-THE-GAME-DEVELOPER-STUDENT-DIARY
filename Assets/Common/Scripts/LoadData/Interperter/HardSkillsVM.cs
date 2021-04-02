using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkillsVM : MonoBehaviour
{
    private HardSkillsLoading hardskillsLoading;

    private void Start()
    {
        hardskillsLoading = HardSkillsLoading.instance;
    }

    public List<HardSkill> Interpert()
    {
        List<HardSkill> hardSkills = new List<HardSkill>();

        return hardSkills;
    }
}
