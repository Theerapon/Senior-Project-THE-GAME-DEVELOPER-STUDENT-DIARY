using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkill_Handler : MonoBehaviour
{
    private List<SoftSkill> softSkills;
    private SoftSkillsVM softSkillsVM;

    private void Awake()
    {
        softSkills = new List<SoftSkill>();
    }

    private void Start()
    {
        softSkillsVM = FindObjectOfType<SoftSkillsVM>();
        softSkills = softSkillsVM.Interpert();
        
        for(int i = 0; i < softSkills.Count; i++)
        {
            softSkills[i].UpSoftSkill();
        }
    }
}
