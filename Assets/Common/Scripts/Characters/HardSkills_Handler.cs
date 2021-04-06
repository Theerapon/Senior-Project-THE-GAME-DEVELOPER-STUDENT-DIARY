using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkills_Handler : Manager<HardSkills_Handler>
{
    protected List<HardSkill> hardSkills;
    private HardSkillsVM hardSkillsVM;
    
    bool loaded = false;

    public List<HardSkill> HARDSKILLS
    {
        get { return hardSkills; }
    }
    
    protected override void Awake()
    {
        base.Awake();
        hardSkills = new List<HardSkill>();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hardSkills[0].GiveXP(50);
        }
    }



}
