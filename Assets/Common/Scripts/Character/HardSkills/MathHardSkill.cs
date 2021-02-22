using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO math_HardSkill_Template;
    private HardSkill_SO math_HardSkill_Current;

    void Start()
    {
        if (math_HardSkill_Template != null)
        {
            math_HardSkill_Current = Instantiate(math_HardSkill_Template);
        }
    }


}
