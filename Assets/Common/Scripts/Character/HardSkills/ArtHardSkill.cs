using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtHardSkill : HardSkill
{
    [SerializeField] private HardSkill_SO art_HardSkill_Template;

    void Start()
    {
        if (art_HardSkill_Template != null)
        {
            hardSkill_current = Instantiate(art_HardSkill_Template);
        }
    }

}
