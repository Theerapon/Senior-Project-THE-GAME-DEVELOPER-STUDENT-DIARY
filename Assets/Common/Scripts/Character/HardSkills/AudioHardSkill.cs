using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO audio_HardSkill_Template;

    void Start()
    {
        if (audio_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(audio_HardSkill_Template);
        }
    }

}
