using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courses_DataHandler : Manager<Courses_DataHandler>
{
    protected Dictionary<string, Course> course_dic;
    [SerializeField] private CoursesVM coursesVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public Dictionary<string, Course> GetCourseDic
    {
        get { return course_dic; }
    }

    protected override void Awake()
    {
        base.Awake();
        course_dic = new Dictionary<string, Course>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);

    }

    private void EventInterpretHandler()
    {
        course_dic = coursesVM.Interpert();
        //Debug.Log("activities interpret completed");
        //foreach (KeyValuePair<string, Course> course in course_dic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Price = {2}", 
        //        course.Key, course.Value.GetNameCourse(), course.Value.GetOriginalPrice()));

        //}
    }

}
