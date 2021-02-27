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

    private void CreateTag(int index)
    {
        GameObject copy;
        CourseType[] types = courseManager.courses[index].GetCourseType();
        for (int i = 0; i < courseManager.courses[index].GetCountCourseType(); i++)
        {
            copy = Instantiate(tagTemplate, transform);
            copy.transform.GetComponent<Image>().sprite = null; //image
            copy.transform.GetChild(0).GetComponent<TMP_Text>().text = types[i].ToString();
        }
        Destroy(tagTemplate);
    }

    public void CreateTemplate(int index)
    {
        tagTemplate = transform.GetChild(0).gameObject;
        tagTemplate.transform.name = "Template";
        CreateTag(index);
    }

}
