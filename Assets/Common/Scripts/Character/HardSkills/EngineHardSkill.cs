using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO enginrs_HardSkill_Template;
    void Start()
    {
        if (enginrs_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(enginrs_HardSkill_Template);
        }

    }


}
