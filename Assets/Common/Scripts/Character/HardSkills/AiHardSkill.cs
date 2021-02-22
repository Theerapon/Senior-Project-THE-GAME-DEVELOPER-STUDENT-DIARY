using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO ai_HardSkill_Template;
    // Start is called before the first frame update
    void Start()
    {
        if (ai_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(ai_HardSkill_Template);
        }
    }


}
