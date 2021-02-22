using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammingHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO programming_HardSkill_Template;
    private HardSkill_SO programming_HardSkill_Current;

    void Start()
    {
        if (programming_HardSkill_Template != null)
        {
            programming_HardSkill_Current = Instantiate(programming_HardSkill_Template);
        }
    }


}
