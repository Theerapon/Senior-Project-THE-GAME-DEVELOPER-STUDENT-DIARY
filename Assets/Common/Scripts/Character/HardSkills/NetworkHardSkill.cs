using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO network_HardSkill_Template;
    private HardSkill_SO network_HardSkill_Current;
    void Start()
    {
        if (network_HardSkill_Template != null)
        {
            network_HardSkill_Current = Instantiate(network_HardSkill_Template);
        }
    }

}
