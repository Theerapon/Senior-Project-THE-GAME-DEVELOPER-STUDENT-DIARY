using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO art_HardSkill_Template;
    private HardSkill_SO art_HardSkill_Current;

    void Start()
    {
        if (art_HardSkill_Template != null)
        {
            art_HardSkill_Current = Instantiate(art_HardSkill_Template);
        }
    }

}
