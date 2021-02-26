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
        courseTemplate = transform.GetChild(0).gameObject;
        CreateCourse();
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
            copy.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = courseManager.courses[i].GetPrice().ToString(); //On sell
            copy.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = courseManager.courses[i].GetPrice().ToString(); //Normal price
            copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<TagGenerated>().CreateTag(i);
        }
        Destroy(courseTemplate);
    }
}
