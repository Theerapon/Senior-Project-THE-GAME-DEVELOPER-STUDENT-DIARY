using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHardSkills : MonoBehaviour
{
    #region Template Skill
    [Header("Template Hard Skills")]
    [SerializeField] private HardSkill_SO math_HardSkill_Template;
    [SerializeField] private HardSkill_SO programming_HardSkill_Template;
    [SerializeField] private HardSkill_SO enginrs_HardSkill_Template;
    [SerializeField] private HardSkill_SO ai_HardSkill_Template;
    [SerializeField] private HardSkill_SO network_HardSkill_Template;
    [SerializeField] private HardSkill_SO art_HardSkill_Template;
    [SerializeField] private HardSkill_SO design_HardSkill_Template;
    [SerializeField] private HardSkill_SO testing_HardSkill_Template;
    [SerializeField] private HardSkill_SO audio_HardSkill_Template;
    #endregion


    #region Current Skill
    [Header("Current Hard Skill")]
    public HardSkill_SO math_HardSkill_Current;
    public HardSkill_SO programming_HardSkill_Current;
    public HardSkill_SO enginrs_HardSkill_Current;
    public HardSkill_SO ai_HardSkill_Current;
    public HardSkill_SO network_HardSkill_Current;
    public HardSkill_SO art_HardSkill_Current;
    public HardSkill_SO design_HardSkill_Current;
    public HardSkill_SO testing_HardSkill_Current;
    public HardSkill_SO audio_HardSkill_Current;


    #endregion
    #region Initializations
    protected void Awake()
    {
        //-----------Hard Skill----------------
        //Math
        if (math_HardSkill_Template != null)
        {
            math_HardSkill_Current = Instantiate(math_HardSkill_Template);
        }

        //Programming
        if (programming_HardSkill_Template != null)
        {
            programming_HardSkill_Current = Instantiate(programming_HardSkill_Template);
        }

        //Engine
        if (enginrs_HardSkill_Template != null)
        {
            enginrs_HardSkill_Current = Instantiate(enginrs_HardSkill_Template);
        }

        //Ai
        if (ai_HardSkill_Template != null)
        {
            ai_HardSkill_Current = Instantiate(ai_HardSkill_Template);
        }

        //Network
        if (network_HardSkill_Template != null)
        {
            network_HardSkill_Current = Instantiate(network_HardSkill_Template);
        }

        //Art
        if (art_HardSkill_Template != null)
        {
            art_HardSkill_Current = Instantiate(art_HardSkill_Template);
        }

        //Design
        if (design_HardSkill_Template != null)
        {
            design_HardSkill_Current = Instantiate(design_HardSkill_Template);
        }

        //Testing
        if (testing_HardSkill_Template != null)
        {
            testing_HardSkill_Current = Instantiate(testing_HardSkill_Template);
        }

        //Audio
        if (audio_HardSkill_Template != null)
        {
            audio_HardSkill_Current = Instantiate(audio_HardSkill_Template);
        }



    }
    #endregion
}
