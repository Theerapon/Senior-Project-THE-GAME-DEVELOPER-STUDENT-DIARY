using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class CourseBonusGenerator : MonoBehaviour
{
    [SerializeField] private CourseManager courseManager;
    GameObject bonusTemplate;
    private Dictionary<string, int> dicBonus;

    private void Awake()
    {
        dicBonus = new Dictionary<string, int>();
    }

    private void CreateTag(int index)
    {
        GameObject copy;
        GetBonus(index);

        if(dicBonus != null)
        {
            foreach (KeyValuePair<string, int> dic in dicBonus)
            {
                copy = Instantiate(bonusTemplate, transform);
                copy.transform.GetComponent<Image>().sprite = null; //image
                copy.transform.GetChild(0).GetComponent<TMP_Text>().text = string.Format("{0:n0}", dic.Value);
            }
        }

        Destroy(bonusTemplate);
    }

    public void CreateTemplate(int index)
    {
        bonusTemplate = transform.GetChild(0).gameObject;
        bonusTemplate.transform.name = "Template";
        CreateTag(index);
    }

    private void GetBonus(int index)
    {
        int bonusCheck = 0;

        #region Exp
        bonusCheck = courseManager.courses[index].GetdefaultMathExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("MathExp", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultProgrammingExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("ProgrammingExp", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultEngineExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("EngineExp", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultAiExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("AiExp", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultNetwordExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("NetworkExp", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultDesignExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("DesignExp", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultTestingExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("TestingExp", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultArtExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("ArtExp", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultSoundExpReward();
        if (bonusCheck > 0f)
            dicBonus.Add("SoundExp", bonusCheck);


        #endregion

        #region Stat
        bonusCheck = courseManager.courses[index].GetdefaultCodingStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("CodingStat", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultDesignStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("DesignStat", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultTestingStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("TestingStat", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultArtStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("ArtStat", bonusCheck);

        bonusCheck = courseManager.courses[index].GetdefaultSoundStatReward();
        if (bonusCheck > 0f)
            dicBonus.Add("SoundStat", bonusCheck);
        #endregion
    }
}
