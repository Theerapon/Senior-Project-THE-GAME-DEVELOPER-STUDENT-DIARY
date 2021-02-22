using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO enginrs_HardSkill_Template;
    private HardSkill_SO enginrs_HardSkill_Current;
    void Start()
    {
        if (enginrs_HardSkill_Template != null)
        {
            enginrs_HardSkill_Current = Instantiate(enginrs_HardSkill_Template);
        }

    }


}
