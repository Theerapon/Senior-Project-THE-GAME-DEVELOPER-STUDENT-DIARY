using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Status_Generator : MonoBehaviour
{
    private const string INST_CODING_ID = "coding";
    private const string INST_DESIGN_ID = "design";
    private const string INST_TESTING_ID = "testing";
    private const string INST_ART_ID = "art";
    private const string INST_SOUND_ID = "sound";

    [SerializeField] protected GameObject _template;
    protected StatusDetails_DataHandler statusDetails_Handler;


    private void Awake()
    {
        statusDetails_Handler = FindObjectOfType<StatusDetails_DataHandler>();
    }

    private void CreateStatus(HardSkill hardSkill)
    {
        int nextCoding = hardSkill.GetNextBonusCoding();
        int nextDesign = hardSkill.GetNextBonusDesign();
        int nextTesting = hardSkill.GetNextBonusTesting();
        int nextArt = hardSkill.GetNextBonusArt();
        int nextSound = hardSkill.GetNextBonusSound();

        if (nextCoding > 0)
        {
            CreateTemplate(INST_CODING_ID, hardSkill.CurrentTotalBonusCodingStatus, nextCoding);
        }
        if (nextDesign > 0)
        {
            CreateTemplate(INST_DESIGN_ID, hardSkill.CurrentTotalBonusDesignStatus, nextDesign);
        }
        if (nextTesting > 0)
        {
            CreateTemplate(INST_TESTING_ID, hardSkill.CurrentTotalBonusTestingStatus, nextTesting);
        }
        if (nextArt > 0)
        {
            CreateTemplate(INST_ART_ID, hardSkill.CurrentTotalBonusArtStatus, nextArt);
        }

        if (nextSound > 0)
        {
            CreateTemplate(INST_SOUND_ID, hardSkill.CurrentTotalBonusSoundStatus, nextSound);
        }


        _template.SetActive(false);

    }

    private void CreateTemplate(string id, int currentValue, int nextValue)
    {

        GameObject copy;
        copy = Instantiate(_template, transform);
        Image icon = copy.transform.GetChild(0).GetComponent<Image>();


        icon.sprite = statusDetails_Handler.GetStatusDic[id].StatusIcon;
        icon.color = statusDetails_Handler.GetStatusDic[id].StatusColor;

        copy.transform.GetChild(1).GetComponent<TMP_Text>().text = statusDetails_Handler.GetStatusDic[id].StatusName; //name

        TMP_Text text_current_value = copy.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>();
        text_current_value.text = string.Format("{0} >", currentValue); //value;

        TMP_Text text_next_value = copy.transform.GetChild(2).GetChild(1).GetComponent<TMP_Text>();
        text_next_value.text = string.Format("{0}", nextValue); //value;
        text_next_value.color = statusDetails_Handler.GetStatusDic[id].StatusColor;
    }

    public void CreateTemplate(HardSkill hardSkill)
    {
        _template.SetActive(true);
        ClearTmeplate();
        CreateStatus(hardSkill);
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
        if (_template == null)
        {
            _template = transform.GetChild(0).gameObject;
        }
        else
        {
            _template.SetActive(false);
        }
    }
}
