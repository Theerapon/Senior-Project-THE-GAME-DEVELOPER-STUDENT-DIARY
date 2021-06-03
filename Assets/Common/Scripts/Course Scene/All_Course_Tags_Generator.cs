using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class All_Course_Tags_Generator : MonoBehaviour
{
    [Header("Template")]
    [SerializeField] protected GameObject tagTemplate;

    [Header("Color")]
    [SerializeField] protected Color coding_color;
    [SerializeField] protected Color design_color;
    [SerializeField] protected Color testing_color;
    [SerializeField] protected Color art_color;
    [SerializeField] protected Color sound_color;

    protected CoursesController coursesController;

    private void Awake()
    {
        coursesController = CoursesController.Instance;
    }

    private void Start()
    {
        tagTemplate.SetActive(false);
    }

    private void CreateTag(string id)
    {
        GameObject copy;
        List<CourseTag> types = coursesController.allCourses[id].CourseTypeNum;
        for (int i = 0; i < coursesController.allCourses[id].CourseTypeNum.Count; i++)
        {
            copy = Instantiate(tagTemplate, transform);
            //set border color
            copy.transform.GetComponentInChildren<Image>().color = GetBorderTagColor(types[i]); //image
            //set tag
            copy.transform.GetComponentInChildren<TMP_Text>().text = types[i].ToString();
        }

        tagTemplate.SetActive(false);
    }

    public void CreateTemplate(string id)
    {
        CreateTag(id);
    }

    private Color GetBorderTagColor(CourseTag courseTag)
    {
        Color color;

        switch (courseTag)
        {
            case CourseTag.DESIGN:
                color = design_color;
                break;
            case CourseTag.TESTING:
                color = testing_color;
                break;
            case CourseTag.ART:
                color = art_color;
                break;
            case CourseTag.SOUND:
                color = sound_color;
                break;
            default:
                color = coding_color;
                break;

        }

        return color;
    }
}
