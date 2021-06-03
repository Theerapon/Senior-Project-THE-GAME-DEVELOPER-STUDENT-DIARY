using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursesController : Manager<CoursesController>
{
    public Dictionary<string, Course> allCourses;
    public Dictionary<string, Course> myCourses;

    protected override void Awake()
    {
        base.Awake();
        allCourses = new Dictionary<string, Course>();
        myCourses = new Dictionary<string, Course>();
    }

    private void Start()
    {
        if (!ReferenceEquals(Courses_DataHandler.Instance.GetCourseDic, null))
        {
            foreach (KeyValuePair<string, Course_Template> course in Courses_DataHandler.Instance.GetCourseDic)
            {
                allCourses.Add(course.Key, new Course(course.Value));
            }
            Debug.Log("wait implementation for load save data");
        }

    }

    public void CollectCourse(string id)
    {
        Debug.Log("Implementation");
    }
}
