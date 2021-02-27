using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionGenerator : MonoBehaviour
{
    private CourseManager courseManager;
    GameObject courseTemplate;

    private void Awake()
    {
        courseManager = CourseManager.Instance;
        
    }

    private void Start()
    {
        CreateTemplate();
    }

    private void CreateCourse()
    {
        GameObject copy;
        for (int i = 0; i < courseManager.courses.Count; i++)
        {
            if (courseManager.courses[i].GetCourseCollected()) //collected = true;
            {
                copy = Instantiate(courseTemplate, transform);
                copy.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null; //Image Course > image
                copy.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetNameCourse(); //Title course
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetDescription(); //Description > Description text
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetNameAuthor(); //Author > Author Text
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetLevelRecommended().ToString(); //Tag > Recommended > Recommended text
                copy.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetSecondToConsume().ToString(); //time
                copy.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = courseManager.courses[i].GetEnergyToConsume().ToString(); //energy
                copy.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<CourseBonusGenerator>().CreateTemplate(i);

                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<CourseTagGenerated>().CreateTemplate(i); //Tag
            }
        }


        courseTemplate.SetActive(false);
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
