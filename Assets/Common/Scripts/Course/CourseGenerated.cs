using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CourseManager))]
public class CourseGenerated : MonoBehaviour
{
    [SerializeField] private CourseManager courseManager;
    GameObject courseTemplate;

    private void Start()
    {
        CreateTemplate();
    }

    private void CreateCourse()
    {
        GameObject copy;
        for (int i = 0; i < courseManager.courses.Count; i++)
        {
            copy = Instantiate(courseTemplate, transform);
            copy.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null; //Image Course > image
            copy.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetNameCourse(); //Title course
            copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetDescription(); //Description > Description text
            copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetNameAuthor(); //Author > Author Text
            copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetLevelRecommended().ToString(); //Tag > Recommended > Recommended text
            copy.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = string.Format("{0:n0}", courseManager.courses[i].GetPrice()); //On sell
            copy.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = string.Format("{0:n0}", courseManager.courses[i].GetPrice());  //Normal price
            copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<TagGenerated>().CreateTemplate(i); //Tag
        }
        Destroy(courseTemplate);
    }

    public void CreateTemplate()
    {
        ClearTmeplate();
        courseTemplate = transform.GetChild(0).gameObject;
        courseTemplate.transform.name = "Course Template";
        CreateCourse();
    }

    private void ClearTmeplate()
    {
        int count = transform.childCount;
        if (count <= 1) 
        {
            return;
        } else
        {
            //destroy all else first object for template
            for (int i = 1; i < count; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
