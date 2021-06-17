using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bonus_Generator : MonoBehaviour
{
    private const string INST_CHARM_ID = "bonus001";
    private const string INST_BaseProject_ID = "bonus002";
    private const string INST_GoldenProject_ID = "bonus003";
    private const string INST_BaseMotivation_ID = "bonus004";
    private const string INST_GoldenMotivation_ID = "bonus005";
    private const string INST_BaseEnergy_ID = "bonus006";
    private const string INST_GoldenEnergy_ID = "bonus007";
    private const string INST_BugChance_ID = "bonus008";
    private const string INST_NegativeEffect_ID = "bonus009";
    private const string INST_PositiveEffect_ID = "bonus010";
    private const string INST_TimeCourse_ID = "bonus011";
    private const string INST_TimeTransport_ID = "bonus012";
    

    [SerializeField] protected GameObject _template;
    protected BonusDetails_DataHandler bonusDetails_Handler;

    private void Awake()
    {
        bonusDetails_Handler = FindObjectOfType<BonusDetails_DataHandler>();
    }



    private void CreateBonus(SoftSkill softSkill)
    {
        SoftSkillType softSkillType = softSkill.GetSoftSkillType();


        switch (softSkillType)
        {
            case SoftSkillType.COMMUNICATION:
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_CHARM_ID], softSkill.GetTotalBONUS_charm(), softSkill.GetNextBONUS_charm());
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_BaseProject_ID], softSkill.GetTotalBONUS_baseBootUpProject(), softSkill.GetNextBONUS_baseBootUpProject());
                break;
            case SoftSkillType.CRITICALTHINKING:
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_BaseMotivation_ID], softSkill.GetTotalBONUS_baseBootUpMotivation(), softSkill.GetNextBONUS_baseBootUpMotivation());
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_BaseEnergy_ID], softSkill.GetTotalBONUS_baseReduceEnergyConsumption(), softSkill.GetNextBONUS_baseReduceEnergyConsumption());
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_BugChance_ID], softSkill.GetTotalBONUS_reduceBugChance(), softSkill.GetNextBONUS_reduceBugChance());
                break;
            case SoftSkillType.LEADERSHIP:
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_NegativeEffect_ID], softSkill.GetTotalBONUS_negativeEventsEffect(), softSkill.GetNextBONUS_negativeEventsEffect());
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_PositiveEffect_ID], softSkill.GetTotalBONUS_positiveEventsEffect(), softSkill.GetNextBONUS_positiveEventsEffect());
                break;
            case SoftSkillType.TIMEMANAGEMENT:
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_TimeCourse_ID], softSkill.GetTotalBONUS_reduceTimeTrainCourse(), softSkill.GetNextBONUS_reduceTimeTrainCourse());
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_TimeTransport_ID], softSkill.GetTotalBONUS_reduceTimeTransport(), softSkill.GetNextBONUS_reduceTimeTransport());
                break;
            case SoftSkillType.WORKETHIC:
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_GoldenProject_ID], softSkill.GetTotalBONUS_goldenTimeBootUpProject(), softSkill.GetNextBONUS_goldenTimeBootUpProject());
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_GoldenMotivation_ID], softSkill.GetTotalBONUS_goldenTimeBootUpMotivation(), softSkill.GetNextBONUS_goldenTimeBootUpMotivation());
                CreateBonusCopy(bonusDetails_Handler.GetBonusDic[INST_GoldenEnergy_ID], softSkill.GetTotalBONUS_goldenTimeReduceEnergyConsuption(), softSkill.GetNextBONUS_goldenTimeReduceEnergyConsuption());
                break;
        }

        _template.SetActive(false);

    }

    private void CreateBonusCopy(Bonus_Template bonus, float currentValue, float nextValue)
    {
        GameObject copy;
        copy = Instantiate(_template, transform);
        copy.transform.GetChild(0).GetComponent<Image>().sprite = bonus.BonusIcon; //icon
        copy.transform.GetChild(1).GetComponent<TMP_Text>().text = bonus.BonusName; //name
        copy.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = string.Format("{0:n0} >", currentValue * 100); //current value
        copy.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>().text = string.Format("{0:p0}", nextValue); //next value
    }

    public void CreateTemplate(SoftSkill softSkill)
    {
        _template.SetActive(true);
        ClearTmeplate();
        CreateBonus(softSkill);
    }

    private void ClearTmeplate()
    {
        int count = transform.childCount;
        for (int i = 1; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void OnValidate()
    {
        if(_template == null)
        {
            _template = transform.GetChild(0).gameObject;
            _template.SetActive(false);
        }
    }
}
