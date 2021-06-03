using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaymentDetailGenerator : MonoBehaviour
{
    private Courses_DataHandler course_handler;
    GameObject bonusTemplate;
    private Dictionary<string, int> dicBonus;

    private void Awake()
    {
        dicBonus = new Dictionary<string, int>();
        course_handler = Courses_DataHandler.Instance;
    }

    private void CreateBonus(string id)
    {
        GameObject copy;
        GetBonus(id);

        if (dicBonus != null)
        {
            foreach (KeyValuePair<string, int> dic in dicBonus)
            {
                copy = Instantiate(bonusTemplate, transform);
                copy.transform.GetChild(0).GetComponent<TMP_Text>().text = dic.Key;
                copy.transform.GetChild(1).GetComponent<TMP_Text>().text = string.Format("{0:n0}", dic.Value);
            }
            bonusTemplate.SetActive(false);
        }

        Destroy(bonusTemplate);
    }
    public void CreateTemplate(string id)
    {
        bonusTemplate = transform.GetChild(0).gameObject;
        bonusTemplate.name = "Template";
        bonusTemplate.SetActive(true);
        ClearTmeplate();
        CreateBonus(id);
    }

    private void ClearTmeplate()
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            if (transform.GetChild(i).name == ("Template"))
            {
                continue;
            }
            else
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    private void GetBonus(string id)
    {
        dicBonus.Clear();
        int bonusCheck = 0;

        #region Exp
        //bonusCheck = course_handler.courses[id].GetdefaultMathExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Mathematics Exp", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultProgrammingExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Programming Exp", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultEngineExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Engines Exp", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultAiExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Artificial Intelligence Exp", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultNetwordExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Network Exp", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultDesignExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Design Exp", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultTestingExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Testing Exp", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultArtExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Art Exp", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultSoundExpReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Sound Exp", bonusCheck);


        #endregion

        #region Stat
        //bonusCheck = course_handler.courses[id].GetdefaultCodingStatReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Coding Stat", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultDesignStatReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Design Stat", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultTestingStatReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Testing Stat", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultArtStatReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Art Stat", bonusCheck);

        //bonusCheck = course_handler.courses[id].GetdefaultSoundStatReward();
        //if (bonusCheck > 0f)
        //    dicBonus.Add("Sound Stat", bonusCheck);
        #endregion
    }
}
