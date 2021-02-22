using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO design_HardSkill_Template;
    private HardSkill_SO design_HardSkill_Current;

    void Start()
    {
        if (design_HardSkill_Template != null)
        {
            design_HardSkill_Current = Instantiate(design_HardSkill_Template);
        }
    }

}
