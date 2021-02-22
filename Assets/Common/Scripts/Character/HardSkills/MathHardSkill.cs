using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO math_HardSkill_Template;

    void Start()
    {
        if (math_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(math_HardSkill_Template);
        }
    }


}
