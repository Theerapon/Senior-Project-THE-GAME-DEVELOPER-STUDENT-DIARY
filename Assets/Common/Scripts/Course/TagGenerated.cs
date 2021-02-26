using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CourseManager))]
public class TagGenerated : MonoBehaviour
{
    [SerializeField] private CourseManager courseManager;
    GameObject tagTemplate;
    private void Awake()
    {
        tagTemplate = transform.GetChild(0).gameObject;
    }

    public void CreateTag(int index)
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
}
