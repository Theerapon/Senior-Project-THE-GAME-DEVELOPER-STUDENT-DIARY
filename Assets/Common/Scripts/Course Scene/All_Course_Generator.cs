﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class All_Course_Generator : MonoBehaviour
{ 
    [SerializeField] protected GameObject courseTemplate;
    protected Courses_DataHandler course_handler;

    private void Awake()
    {
        course_handler = Courses_DataHandler.Instance;
    }

    private void CreateCourse()
    {

        GameObject copy;
        Debug.Log("wait for Implementation");
        //foreach (KeyValuePair<string, Course> dic in course_handler.GetCourseDic)
        //{
        //    if (!dic.Value.GetCourseCollected()) //collected == false
        //    {
        //        copy = Instantiate(courseTemplate, transform);

        //        //Course Icon
        //        copy.transform.GetChild(0).GetComponentInChildren<Image>().sprite = dic.Value.GetCourseIcon();
        //        //Course Name
        //        copy.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.GetNameCourse();
        //        //Course Description
        //        copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponentInChildren<TMP_Text>().text = dic.Value.GetDescription();
        //        //Course Recommend
        //        copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = dic.Value.GetLevelRecommended().ToString();
        //        //Course Author
        //        copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(2).GetComponent<TMP_Text>().text = dic.Value.GetNameAuthor();
        //        //Create Tag
        //        copy.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(2).GetComponentInChildren<All_Course_Tags_Generator>().CreateTemplate(dic.Key);

        //        //Course Sell Price
        //        copy.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = string.Format("{0:n0}", dic.Value.GetTotalPrice());
        //        //Course Original Price
        //        copy.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = string.Format("{0:n0}", dic.Value.GetOriginalPrice());

        //        //Set Course ID
        //        copy.transform.GetChild(3).GetComponent<CourseID>().SetID(dic.Key); //set ID
        //    }
        //}

        courseTemplate.SetActive(false);

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