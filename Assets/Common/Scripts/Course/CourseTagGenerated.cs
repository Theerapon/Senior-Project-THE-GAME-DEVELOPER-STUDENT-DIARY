using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CourseManager))]
public class CourseTagGenerated : MonoBehaviour
{
    [SerializeField] private CourseManager courseManager;
    GameObject tagTemplate;

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
        ClearTmeplate();
        tagTemplate = transform.GetChild(0).gameObject;
        tagTemplate.transform.name = "Template";
        CreateTag(index);
    }

    private void ClearTmeplate()
    {
        int count = transform.childCount;
        if (count <= 1)
        {
            return;
        }
        else
        {
            //destroy all else first object for template
            for (int i = 1; i < count; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
