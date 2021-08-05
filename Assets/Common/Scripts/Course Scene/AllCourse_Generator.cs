using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AllCourse_Generator : MonoBehaviour
{ 
    [SerializeField] protected GameObject courseTemplate;
    protected CoursesController courseController;

    private void Awake()
    {
        courseController = CoursesController.Instance;
    }

    private void CreateCourse()
    {

        GameObject copy;
        foreach (KeyValuePair<string, Course> dic in courseController.AllCourses)
        {
            if (!dic.Value.HasCollected) //collected == false
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
                //Create Tag
                copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetComponentInChildren<All_Course_Tags_Generator>().CreateTemplate(dic.Key);

                //Course Sell Price
                copy.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = string.Format("{0:n0}", dic.Value.GetTotalPrice());
                //Course Original Price
                copy.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = string.Format("{0:n0}", dic.Value.CourseOriginalPrice);

                //Set Course ID
                copy.transform.GetComponent<CourseIdTemplate>().CourseId = dic.Key; //set ID
            }
        }
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
