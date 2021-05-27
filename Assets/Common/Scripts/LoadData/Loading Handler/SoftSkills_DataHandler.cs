using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkills_DataHandler : Manager<SoftSkills_DataHandler>
{
    protected Dictionary<string, SoftSkill> softSkills;
    private SoftSkillsVM softSkillsVM;

    bool loaded = false;

    public Dictionary<string, SoftSkill> SOFTSKILLS
    {
        get { return softSkills; }
    }

    protected override void Awake()
    {
        base.Awake();
        softSkills = new Dictionary<string, SoftSkill>();
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
