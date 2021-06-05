using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courses_DataHandler : DataHandler
{
    protected Dictionary<string, Course_Template> course_dic;
    [SerializeField] private CoursesVM coursesVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public Dictionary<string, Course_Template> GetCourseDic
    {
        get { return course_dic; }
    }

    protected void Awake()
    {
        course_dic = new Dictionary<string, Course_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        course_dic = coursesVM.Interpert();
        if (!ReferenceEquals(course_dic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Course interpret completed");
        //foreach (KeyValuePair<string, Course> course in course_dic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Price = {2}", 
        //        course.Key, course.Value.GetNameCourse(), course.Value.GetOriginalPrice()));

        //}
    }

}
