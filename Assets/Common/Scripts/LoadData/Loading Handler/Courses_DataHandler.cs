using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courses_DataHandler : Manager<Courses_DataHandler>
{
    protected Dictionary<string, Course> course_dic;
    private CoursesVM coursesVM;

    bool loaded = false;

    public Dictionary<string, Course> CourseDic
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
        coursesVM = FindObjectOfType<CoursesVM>();
        loaded = false;

    }
    private void Update()
    {
        if (!loaded)
        {
            course_dic = coursesVM.Interpert();
            loaded = true;
        }

    }
}
