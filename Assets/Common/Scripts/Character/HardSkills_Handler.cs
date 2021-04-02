using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkills_Handler : MonoBehaviour
{
    private List<HardSkill> hardSkills;
    private HardSkillsVM hardSkillsVM;
    private void Awake()
    {
        hardSkills = new List<HardSkill>();
    }
    private void Start()
    {
        hardSkillsVM = FindObjectOfType<HardSkillsVM>();
        hardSkills = hardSkillsVM.Interpert();

    }


}
