using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourseTagGenerated : MonoBehaviour
{
    private CourseManager courseManager;
    GameObject tagTemplate;

    private void Awake()
    {
        courseManager = CourseManager.Instance;
    }

    private void CreateTag(string id)
    {
        GameObject copy;
        CourseType[] types = courseManager.courses[id].GetCourseType();
        for (int i = 0; i < courseManager.courses[id].GetCountCourseType(); i++)
        {
            copy = Instantiate(tagTemplate, transform);
            copy.transform.GetComponent<Image>().sprite = null; //image
            copy.transform.GetChild(0).GetComponent<TMP_Text>().text = types[i].ToString();
        }
        Destroy(tagTemplate);
    }

    public void CreateTemplate(string id)
    {
        tagTemplate = transform.GetChild(0).gameObject;
        tagTemplate.transform.name = "Template";
        CreateTag(id);
    }

}
