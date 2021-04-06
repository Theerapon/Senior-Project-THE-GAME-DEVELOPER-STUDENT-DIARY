using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkills_Handler : Manager<SoftSkills_Handler>
{
    protected List<SoftSkill> softSkills;
    private SoftSkillsVM softSkillsVM;

    bool loaded = false;

    public List<SoftSkill> SOFTSKILLS
    {
        get { return softSkills; }
    }

    protected override void Awake()
    {
        base.Awake();
        softSkills = new List<SoftSkill>();
    }

    private void Start()
    {
        softSkillsVM = FindObjectOfType<SoftSkillsVM>();
        loaded = false;
    }

    private void Update()
    {
        if (!loaded)
        {
            softSkills = softSkillsVM.Interpert();
            loaded = true;
        }
    }
}
