using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusBoxGenerator : MonoBehaviour
{
    private CourseManager courseManager;
    GameObject bonusTemplate;
    private Dictionary<string, int> dicBonus;

    private void Awake()
    {
        dicBonus = new Dictionary<string, int>();
        courseManager = CourseManager.Instance;
    }
    private void CreateBonusContent(string id)
    {
        GameObject copy;
        GetBonus(id);

        if (dicBonus != null)
        {
            foreach (KeyValuePair<string, int> dic in dicBonus)
            {
                copy = Instantiate(bonusTemplate, transform);
                copy.transform.GetChild(0).GetComponent<TMP_Text>().text = dic.Key.ToString(); //name
                copy.transform.GetChild(1).GetComponent<TMP_Text>().text = string.Format("{0:n0}", dic.Value); //value
            }
        }

        Destroy(bonusTemplate);
    }

    public void CreateTemplate(string id)
    {
        bonusTemplate = transform.GetChild(3).gameObject; //reward
        bonusTemplate.transform.name = "Template";
        CreateBonusContent(id);
    }

    private void GetBonus(string id)
    {
        dicBonus.Clear();
        int bonusCheck = 0;

        #region Exp
        bonusCheck = courseManager.courses[id].GetdefaultMathExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Math Exp", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultProgrammingExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Programming Exp", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultEngineExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Engine Exp", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultAiExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Ai Exp", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultNetwordExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Network Exp", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultDesignExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Design Exp", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultTestingExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Testing Exp", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultArtExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Art Exp", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultSoundExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Sound Exp", bonusCheck);


        #endregion

        #region Stat
        bonusCheck = courseManager.courses[id].GetdefaultCodingStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Coding Stat", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultDesignStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Design Stat", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultTestingStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Testing Stat", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultArtStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Art Stat", bonusCheck);

        bonusCheck = courseManager.courses[id].GetdefaultSoundStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("Sound Stat", bonusCheck);
        #endregion
    }

}
