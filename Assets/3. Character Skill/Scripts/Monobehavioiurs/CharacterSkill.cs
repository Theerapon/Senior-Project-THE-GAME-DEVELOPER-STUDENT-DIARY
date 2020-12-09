using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    #region Template Skill
    [Header("Template Skill")]
    //Template Hard Skill
    public CharacterSkill_SO math_HardSkill_Template;
    public CharacterSkill_SO programming_HardSkill_Template;
    public CharacterSkill_SO enginrs_HardSkill_Template;
    public CharacterSkill_SO ai_HardSkill_Template;
    public CharacterSkill_SO network_HardSkill_Template;
    public CharacterSkill_SO art_HardSkill_Template;
    public CharacterSkill_SO design_HardSkill_Template;
    public CharacterSkill_SO testing_HardSkill_Template;
    public CharacterSkill_SO audio_HardSkill_Template;

    [Space]
    //Template Soft Skill
    public CharacterSkill_SO communication_SoftSkill_Template;
    public CharacterSkill_SO criticalThinking_SoftSkill_Template;
    public CharacterSkill_SO leadership_SoftSkill_Template;
    public CharacterSkill_SO positive_SoftSkill_Template;
    public CharacterSkill_SO teamwork_SoftSkill_Template;
    public CharacterSkill_SO workEthic_SoftSkill_Template;
    #endregion

    #region Current Skill
    [Header("Current Skill")]
    //Current Hard Skill
    public CharacterSkill_SO math_HardSkill_Current;
    public CharacterSkill_SO programming_HardSkill_Current;
    public CharacterSkill_SO enginrs_HardSkill_Current;
    public CharacterSkill_SO ai_HardSkill_Current;
    public CharacterSkill_SO network_HardSkill_Current;
    public CharacterSkill_SO art_HardSkill_Current;
    public CharacterSkill_SO design_HardSkill_Current;
    public CharacterSkill_SO testing_HardSkill_Current;
    public CharacterSkill_SO audio_HardSkill_Current;

    [Space]
    //Current Soft Skill
    public CharacterSkill_SO communication_SoftSkill_Current;
    public CharacterSkill_SO criticalThinking_SoftSkill_Current;
    public CharacterSkill_SO leadership_SoftSkill_Current;
    public CharacterSkill_SO positive_SoftSkill_Current;
    public CharacterSkill_SO teamwork_SoftSkill_Current;
    public CharacterSkill_SO workEthic_SoftSkill_Current;
    #endregion

    #region Initializations
    private void Awake()
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

        //----------------Soft Skill------------------
        //communication
        if (communication_SoftSkill_Template != null)
        {
            communication_SoftSkill_Current = Instantiate(communication_SoftSkill_Template);
        }

        //Critical Thinking
        if (criticalThinking_SoftSkill_Template != null)
        {
            criticalThinking_SoftSkill_Current = Instantiate(criticalThinking_SoftSkill_Template);
        }

        //Leadership
        if (leadership_SoftSkill_Template != null)
        {
            leadership_SoftSkill_Current = Instantiate(leadership_SoftSkill_Template);
        }

        //Positive Attitude
        if (positive_SoftSkill_Template != null)
        {
            positive_SoftSkill_Current  = Instantiate(positive_SoftSkill_Template);
        }

        //Teamwork
        if (teamwork_SoftSkill_Template != null)
        {
            teamwork_SoftSkill_Current = Instantiate(teamwork_SoftSkill_Template);
        }

        //Work Ethic
        if (workEthic_SoftSkill_Template != null)
        {
            workEthic_SoftSkill_Current = Instantiate(workEthic_SoftSkill_Template);
        }

    }
    #endregion
}
