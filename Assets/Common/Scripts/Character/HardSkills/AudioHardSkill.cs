using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHardSkill : MonoBehaviour
{
    [SerializeField] private HardSkill_SO audio_HardSkill_Template;
    private HardSkill_SO audio_HardSkill_Current;
    // Start is called before the first frame update
    void Start()
    {
        if (audio_HardSkill_Template != null)
        {
            audio_HardSkill_Current = Instantiate(audio_HardSkill_Template);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
