using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO testing_HardSkill_Template;

    void Start()
    {
        if (testing_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(testing_HardSkill_Template);
        }
    }

}
