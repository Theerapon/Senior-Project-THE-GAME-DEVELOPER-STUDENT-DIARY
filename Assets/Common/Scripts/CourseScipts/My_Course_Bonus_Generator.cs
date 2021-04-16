using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class My_Course_Bonus_Generator : MonoBehaviour
{
    #region INST Bonus ID
    private const string INST_Math_Exp = "Math Exp";
    private const string INST_Programming_Exp = "programming_exp";
    private const string INST_Engine_Exp = "engine_exp";
    private const string INST_Ai_Exp = "ai_exp";
    private const string INST_Network_Exp = "network_exp";
    private const string INST_Design_Exp = "design_exp";
    private const string INST_Testing_Exp = "testing_exp";
    private const string INST_Art_Exp = "art_exp";
    private const string INST_Sound_Exp = "sound_exp";
    private const string INST_Coding_Status = "coding_status";
    private const string INST_Design_Status = "design_status";
    private const string INST_Testing_Status = "testing_status";
    private const string INST_Art_Status = "art_status";
    private const string INST_Sound_Status = "sound_status";
    #endregion

    [Header("Template")]
    [SerializeField] protected GameObject bonus_template;

    [Header("Color")]
    [SerializeField] protected Color coding_color;
    [SerializeField] protected Color design_color;
    [SerializeField] protected Color testing_color;
    [SerializeField] protected Color art_color;
    [SerializeField] protected Color sound_color;
    [SerializeField] protected Color status_color;


    [Header("Hard skills Icon")]
    [SerializeField] protected Sprite math_icon;
    [SerializeField] protected Sprite programming_icon;
    [SerializeField] protected Sprite engine_icon;
    [SerializeField] protected Sprite ai_icon;
    [SerializeField] protected Sprite network_icon;
    [SerializeField] protected Sprite design_icon;
    [SerializeField] protected Sprite testing_icon;
    [SerializeField] protected Sprite art_icon;
    [SerializeField] protected Sprite sound_icon;

    [Header("Status Icon")]
    [SerializeField] protected Sprite status_icon;

    protected Courses_Handler course_handler;
    private Dictionary<string, int> dicBonus;

    private void Awake()
    {
        course_handler = Courses_Handler.Instance;
        dicBonus = new Dictionary<string, int>();
    }

    private void Start()
    {
        bonus_template.SetActive(false);
    }

    private void CreateBonus(string id)
    {
        CreateBonusDictionary(id);
        GameObject copy;
        foreach (KeyValuePair<string, int> dic in dicBonus)
        {
            string key = dic.Key;

            copy = Instantiate(bonus_template, transform);
            //set border color
            copy.transform.GetChild(0).GetComponent<Image>().color = GetBonusColor(key);
            //set course bonus icon
            copy.transform.GetChild(1).GetComponent<Image>().sprite = GetCourseBonusIcon(key);

            //set name bonus
            copy.transform.GetComponentInChildren<TMP_Text>().text = GetValue(dic.Key, dic.Value);
        }

        bonus_template.SetActive(false);
    }
    public void CreateTemplate(string id)
    {
        bonus_template.SetActive(true);
        CreateBonus(id);
    }

    private Color GetBonusColor(string bonus_id)
    {
        Color color;

        switch (bonus_id)
        {
            case INST_Design_Exp:
                color = design_color;
                break;
            case INST_Testing_Exp:
                color = testing_color;
                break;
            case INST_Art_Exp:
                color = art_color;
                break;
            case INST_Sound_Exp:
                color = sound_color;
                break;
            case INST_Coding_Status:
                color = coding_color;
                break;
            case INST_Design_Status:
                color = design_color;
                break;
            case INST_Testing_Status:
                color = testing_color;
                break;
            case INST_Art_Status:
                color = art_color;
                break;
            case INST_Sound_Status:
                color = sound_color;
                break;
            default:
                color = coding_color;
                break;

        }

        return color;
    }

    private void CreateBonusDictionary(string id)
    {
        dicBonus.Clear();
        int bonusCheck = 0;

        #region Exp
        bonusCheck = course_handler.CourseDic[id].GetdefaultMathExpReward();
        
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Math_Exp, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultProgrammingExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Programming_Exp, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultEngineExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Engine_Exp, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultAiExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Ai_Exp, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultNetwordExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Network_Exp, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultDesignExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Design_Exp, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultTestingExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Testing_Exp, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultArtExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Art_Exp, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultSoundExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Sound_Exp, bonusCheck);
        #endregion

        #region Stat
        bonusCheck = course_handler.CourseDic[id].GetdefaultCodingStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Coding_Status, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultDesignStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Design_Status, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultTestingStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Testing_Status, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultArtStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Art_Status, bonusCheck);

        bonusCheck = course_handler.CourseDic[id].GetdefaultSoundStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add(INST_Sound_Status, bonusCheck);
        #endregion
    }

    private Sprite GetCourseBonusIcon(string bonus_id)
    {
        Sprite icon;
        switch (bonus_id)
        {
            case INST_Math_Exp:
                icon = math_icon;
                break;
            case INST_Programming_Exp:
                icon = programming_icon;
                break;
            case INST_Engine_Exp:
                icon = engine_icon;
                break;
            case INST_Ai_Exp:
                icon = ai_icon;
                break;
            case INST_Network_Exp:
                icon = network_icon;
                break;
            case INST_Design_Exp:
                icon = design_icon;
                break;
            case INST_Testing_Exp:
                icon = testing_icon;
                break;
            case INST_Art_Exp:
                icon = art_icon;
                break;
            case INST_Sound_Exp:
                icon = sound_icon;
                break;
            default:
                icon = status_icon;
                break;

        }
        return icon;
    }

    private string GetValue(string bonus_id, int value)
    {
        string str;

        if(bonus_id == INST_Coding_Status || bonus_id == INST_Design_Status || bonus_id == INST_Testing_Status ||
            bonus_id == INST_Art_Status || bonus_id == INST_Sound_Status)
        {
            str = string.Format("{0} Status", value);
        }
        else
        {
            str = string.Format("{0} Exp", value);
        }


        return str;
    }
}
