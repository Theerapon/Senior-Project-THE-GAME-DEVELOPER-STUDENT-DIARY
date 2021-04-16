using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class My_Course_Generator : MonoBehaviour
{
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;

    [Header("Template")]
    [SerializeField] protected GameObject courseTemplate;
    protected Courses_Handler course_handler;

    private void Awake()
    {
        course_handler = Courses_Handler.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();
    }


    private void CreateCourse()
    {
        GameObject copy;
        foreach (KeyValuePair<string, Course> dic in course_handler.CourseDic)
        {
            if (dic.Value.GetCourseCollected() && !ReferenceEquals(playerAction, null)) //collected = true;
            {
                copy = Instantiate(courseTemplate, transform);
                
                //Course Icon
                copy.transform.GetChild(0).GetComponentInChildren<Image>().sprite = dic.Value.GetCourseIcon();
                //Course Name
                copy.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.GetNameCourse();
                //Course Description
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponentInChildren<TMP_Text>().text = dic.Value.GetDescription();
                //Course Recommend
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.GetLevelRecommended().ToString();
                //Course Author
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(2).GetComponent<TMP_Text>().text = dic.Value.GetNameAuthor();
                //Create Bonus
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetComponentInChildren<My_Course_Bonus_Generator>().CreateTemplate(dic.Key);

                //Course Seccond Time
                copy.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = TimeManager.Instance.GetSecondText(GetTimePlayerAction(dic.Value));
                //Course Energy
                copy.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = playerAction.GetEnergyCourse(dic.Value).ToString() + " Energy";

                //Set Course ID
                copy.transform.GetChild(3).GetComponent<CourseID>().SetID(dic.Key); //set ID
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
        courseTemplate.SetActive(true);
        ClearTmeplate();
        CreateCourse();
    }

    private void ClearTmeplate()
    {
        int count = transform.childCount;
        for (int i = 1; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
