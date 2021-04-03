using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkills_Handler : Manager<SoftSkills_Handler>
{
    public List<SoftSkill> softSkills;
    private SoftSkillsVM softSkillsVM;

    protected override void Awake()
    {
        base.Awake();
        softSkills = new List<SoftSkill>();
    }

    private void Start()
    {
        softSkillsVM = FindObjectOfType<SoftSkillsVM>();
        softSkills = softSkillsVM.Interpert();
    }
}
