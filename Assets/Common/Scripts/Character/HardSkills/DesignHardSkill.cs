using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO design_HardSkill_Template;

    void Start()
    {
        if (design_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(design_HardSkill_Template);
        }
    }

}
