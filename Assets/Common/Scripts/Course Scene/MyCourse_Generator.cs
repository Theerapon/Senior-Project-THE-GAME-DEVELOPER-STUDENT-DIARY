using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyCourse_Generator : MonoBehaviour
{
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;

    [Header("Template")]
    [SerializeField] protected GameObject courseTemplate;
    protected CoursesController coursesController;
    private TimeManager _timeManager;

    private void Awake()
    {
        _timeManager = TimeManager.Instance;
        coursesController = CoursesController.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();
    }


    private void CreateCourse()
    {
        GameObject copy;
        foreach (KeyValuePair<string, Course> dic in coursesController.MyCourses)
        {
            if (dic.Value.HasCollected && !ReferenceEquals(playerAction, null)) //collected = true;
            {
                copy = Instantiate(courseTemplate, transform);

                //Course Icon
                copy.transform.GetChild(0).GetComponentInChildren<Image>().sprite = dic.Value.Course_icon;
                //Course Name
                copy.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.CourseName;
                //Course Description
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponentInChildren<TMP_Text>().text = dic.Value.Description;
                //Course Recommend
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.CourseRecommended.ToString();
                //Course Author
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(2).GetComponent<TMP_Text>().text = dic.Value.AuthorName;
                //Create Bonus
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetComponentInChildren<My_Course_Bonus_Generator>().CreateTemplate(dic.Key);

                //Course Seccond Time
                copy.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = _timeManager.GetSecondText(GetTimePlayerAction(dic.Value.SecondTimeUsed));
                //Course Energy
                copy.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = string.Format("พลังงาน {0:n0}", playerAction.CalReduceEnergyToCunsume(dic.Value.EnergyUsed));

                //Set Course ID
                copy.transform.GetComponent<CourseIdTemplate>().CourseId = dic.Key; //set ID
            }
        }

    }

    private int GetTimePlayerAction(int energy)
    {
        return playerAction.GetCalculateCourseTimeSecond(energy);
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
        for (int i = 0; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
