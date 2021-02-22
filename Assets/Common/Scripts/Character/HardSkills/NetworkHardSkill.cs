using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO network_HardSkill_Template;
    void Start()
    {
        if (network_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(network_HardSkill_Template);
        }
    }

}
