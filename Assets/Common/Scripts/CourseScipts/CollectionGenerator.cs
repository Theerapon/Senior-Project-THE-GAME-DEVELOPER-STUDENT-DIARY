using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionGenerator : MonoBehaviour
{
    private CourseManager courseManager;
    GameObject courseTemplate;
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;

    private void Awake()
    {
        courseManager = CourseManager.Instance;
    }

    private void Start()
    {
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();
        CreateTemplate();
    }

    private void CreateCourse()
    {
        GameObject copy;
        foreach (KeyValuePair<string, Course> dic in courseManager.courses)
        {
            if (dic.Value.GetCourseCollected() && playerAction != null) //collected = true;
            {
                copy = Instantiate(courseTemplate, transform);
                copy.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null; //Image Course > image
                copy.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.GetNameCourse(); //Title course
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.GetDescription(); //Description > Description text
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.GetNameAuthor(); //Author > Author Text
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.GetLevelRecommended().ToString(); //Tag > Recommended > Recommended text
                copy.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = TimeManager.Instance.GetSecondText(GetTimePlayerAction(dic.Value)); //time
                copy.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = playerAction.GetEnergyCourse(dic.Value).ToString() + " Energy" ; //energy
                copy.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<CourseBonusGenerator>().CreateTemplate(dic.Key);

                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<CourseTagGenerated>().CreateTemplate(dic.Key); //Tag
                copy.transform.GetChild(2).GetComponent<CourseID>().SetID(dic.Key); //set ID
            }
        }

        courseTemplate.SetActive(false);
    }

    private int GetTimePlayerAction(Course course)
    {
        return playerAction.GetCalculateCourseTimeSecond(course);
    }

    public void CreateTemplate()
    {
        courseTemplate = transform.GetChild(0).gameObject;
        courseTemplate.name = "Template";
        courseTemplate.SetActive(true);
        ClearTmeplate();
        CreateCourse();
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
}
