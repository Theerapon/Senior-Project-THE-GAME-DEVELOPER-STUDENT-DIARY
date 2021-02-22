using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO programming_HardSkill_Template;

    void Start()
    {
        if (programming_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(programming_HardSkill_Template);
        }
    }


}
