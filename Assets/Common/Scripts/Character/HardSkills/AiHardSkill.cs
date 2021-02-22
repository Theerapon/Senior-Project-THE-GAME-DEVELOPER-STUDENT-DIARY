using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO ai_HardSkill_Template;
    private HardSkill_SO ai_HardSkill_Current;
    // Start is called before the first frame update
    void Start()
    {
        if (ai_HardSkill_Template != null)
        {
            ai_HardSkill_Current = Instantiate(ai_HardSkill_Template);
        }
    }


}
