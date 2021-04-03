using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkills_Handler : Manager<HardSkills_Handler>
{
    public List<HardSkill> hardSkills;
    private HardSkillsVM hardSkillsVM;
    protected override void Awake()
    {
        base.Awake();
        hardSkills = new List<HardSkill>();
    }
    private void Start()
    {
        hardSkillsVM = FindObjectOfType<HardSkillsVM>();
        hardSkills = hardSkillsVM.Interpert();

    }


}
