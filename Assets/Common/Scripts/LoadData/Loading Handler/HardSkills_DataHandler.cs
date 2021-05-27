using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkills_DataHandler : Manager<HardSkills_DataHandler>
{
    protected Dictionary<string, HardSkill> hardSkills;
    private HardSkillsVM hardSkillsVM;
    
    bool loaded = false;

    public Dictionary<string, HardSkill> HARDSKILLS
    {
        get { return hardSkills; }
    }
    
    protected override void Awake()
    {
        base.Awake();
        hardSkills = new Dictionary<string, HardSkill>();
    }
    private void Start()
    {
        hardSkillsVM = FindObjectOfType<HardSkillsVM>();
        loaded = false;

    }

    private void Update()
    {
        if (!loaded)
        {
            hardSkills = hardSkillsVM.Interpert();
            loaded = true;
        }

    }



}
