using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Characters_Menu_Handler : MonoBehaviour
{
    #region INSI
    private const string INST_STATUS = "Status";
    private const string INST_BONUS = "Bonus";
    private const string INST_HardSkill = "Hard Skill";
    private const string INST_SoftSkill = "Soft Skill";
    #endregion

    [SerializeField] protected Status_Display status_display;
    [SerializeField] protected BaseBonusSlot bonusSlot;

    protected GameObject found_player;
    protected Characters_Handler characters_Handler;

    #region GameObjects
    [Header("Game Objects")]
    [SerializeField] protected GameObject description_box;
    [SerializeField] protected GameObject title_description;
    [SerializeField] protected GameObject status_description;
    [SerializeField] protected GameObject bonus_description;
    [SerializeField] protected GameObject hardskill_description;
    [SerializeField] protected GameObject softskill_description;
    #endregion

    #region Title
    [Header("Title")]
    [SerializeField] protected TMP_Text text_title_name;
    [SerializeField] protected TMP_Text text_sub_type;
    #endregion

    #region Status Description
    [Header("Status Description")]
    [SerializeField] protected TMP_Text text_status_value;
    [SerializeField] protected TMP_Text text_status_description;
    #endregion

    #region Bonus Description
    [Header("Bonus Description")]
    [SerializeField] protected TMP_Text text_bonus_charm;
    [SerializeField] protected TMP_Text text_bonus_base_bootupProject;
    [SerializeField] protected TMP_Text text_bonus_golden_bootupProject;
    [SerializeField] protected TMP_Text text_bonus_base_bootupMotivation;
    [SerializeField] protected TMP_Text text_bonus_golden_bootupMotivation;
    [SerializeField] protected TMP_Text text_bonus_base_energy;
    [SerializeField] protected TMP_Text text_bonus_golden_energy;
    [SerializeField] protected TMP_Text text_bonus_bug_chance;
    [SerializeField] protected TMP_Text text_bonus_negative_effect;
    [SerializeField] protected TMP_Text text_bonus_positive_effect;
    [SerializeField] protected TMP_Text text_bonus_time_course;
    [SerializeField] protected TMP_Text text_bonus_time_transport;
    [SerializeField] protected TMP_Text text_bonus_drop_rate;
    #endregion

    private void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        characters_Handler = found_player.GetComponentInChildren<Characters_Handler>();

        //Events status
        status_display.OnLeftClickStatusSlot.AddListener(SelectedStatusDisplayed);
        status_display.OnPointEnterStatusSlot.AddListener(DisplayedStatusDescription);
        status_display.OnPointExitStatusSlot.AddListener(UnDisplayedStatusDescription);

        //Events Bonus
        bonusSlot.OnLeftClickBonusSlotEvent.AddListener(SelectedBonusDisplayed);
        bonusSlot.OnPointEnterBonusSlotEvent.AddListener(DisplayedBonusDescription);
        bonusSlot.OnPointExitBonusSlotEvent.AddListener(UnDisplayedBonusDescription);

        Reset();
    }


    private void Reset()
    {
        DisplayDescriptionBox(false);
        status_description.SetActive(false);
        bonus_description.SetActive(false);
        hardskill_description.SetActive(false);
        softskill_description.SetActive(false);
    }

    #region Status
    private void SelectedStatusDisplayed(BaseStatusSlot statusSlot)
    {

    }
    private void DisplayedStatusDescription(BaseStatusSlot statusSlot)
    {
        //title
        DisplayDescriptionBox(true);
        SetTitleText(statusSlot.TYPE.ToString(), INST_STATUS);

        //description
        status_description.SetActive(true);
        text_status_value.text = statusSlot.VALUE.ToString();
        text_status_description.text = statusSlot.DESCRIPTION;
    }
    private void UnDisplayedStatusDescription(BaseStatusSlot statusSlot)
    {
        DisplayDescriptionBox(false);
        status_description.SetActive(false);
    }


    #endregion
    #region Bonus
    private void SelectedBonusDisplayed(BaseBonusSlot bonusSlot)
    {
        
    }

    private void DisplayedBonusDescription(BaseBonusSlot bonusSlot)
    {
        //title
        DisplayDescriptionBox(true);
        SetTitleText(bonusSlot.TITLE, INST_BONUS);
        
        //description
        bonus_description.SetActive(true);
        text_bonus_charm.text = ((int)(characters_Handler.STATUS.GetDEFAULT_charm() * 100)).ToString();
        text_bonus_base_bootupProject.text = ((int)(characters_Handler.STATUS.GetDEFAULT_baseBootUpProject() * 100)).ToString();
        text_bonus_golden_bootupProject.text = ((int)(characters_Handler.STATUS.GetDEFAULT_goldenTimeBootUpProject() * 100)).ToString();
        text_bonus_base_bootupMotivation.text = ((int)(characters_Handler.STATUS.GetDEFAULT_baseBootUpMotivation() * 100)).ToString();
        text_bonus_golden_bootupMotivation.text = ((int)(characters_Handler.STATUS.GetDEFAULT_goldenTimeBootUpMotivation() * 100)).ToString();
        text_bonus_base_energy.text = ((int)(characters_Handler.STATUS.GetDEFAULT_baseReduceEnergyConsumption() * 100)).ToString();
        text_bonus_golden_energy.text = ((int)(characters_Handler.STATUS.GetDEFAULT_goldenTimeReduceEnergyConsuption() * 100)).ToString();
        text_bonus_bug_chance.text = ((int)(characters_Handler.STATUS.GetDEFAULT_reduceBugChance() * 100)).ToString();
        text_bonus_negative_effect.text = ((int)(characters_Handler.STATUS.GetDEFAULT_negativeEventsEffect() * 100)).ToString();
        text_bonus_positive_effect.text = ((int)(characters_Handler.STATUS.GetDEFAULT_positiveEventsEffect() * 100)).ToString();
        text_bonus_time_course.text = ((int)(characters_Handler.STATUS.GetDEFAULT_reduceTimeTrainCourse() * 100)).ToString();
        text_bonus_time_transport.text = ((int)(characters_Handler.STATUS.GetDEFAULT_reduceTimeTransport() * 100)).ToString();
        text_bonus_drop_rate.text = ((int)(characters_Handler.STATUS.GetDropRate() * 100)).ToString();
    }

    private void UnDisplayedBonusDescription(BaseBonusSlot bonusSlot)
    {
        DisplayDescriptionBox(false);
        bonus_description.SetActive(false);
    }
    #endregion
    protected virtual void OnValidate()
    {
        if (description_box == null)
            description_box = transform.GetChild(3).gameObject;
        
        if (title_description == null)
            title_description = transform.GetChild(3).GetChild(0).gameObject;

        if (status_description == null)
            status_description = transform.GetChild(3).GetChild(1).gameObject;

        if (bonus_description == null)
            bonus_description = transform.GetChild(3).GetChild(2).gameObject;

        if (hardskill_description == null)
            hardskill_description = transform.GetChild(3).GetChild(3).gameObject;

        if (softskill_description == null)
            softskill_description = transform.GetChild(3).GetChild(4).gameObject;

        if (status_display == null)
            status_display = transform.GetChild(0).GetComponent<Status_Display>();

    }

    private void DisplayDescriptionBox(bool actived)
    {
        description_box.SetActive(actived);
        title_description.SetActive(actived);
    }

    private void SetTitleText(string title, string type)
    {
        text_title_name.text = title;
        text_sub_type.text = type;
    }
}
