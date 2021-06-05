using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursesController : Manager<CoursesController>
{
    private Courses_DataHandler courses_DataHandler;

    private Dictionary<string, Course> allCourses;
    private Dictionary<string, Course> myCourses;

    public Dictionary<string, Course> AllCourses { get => allCourses; }
    public Dictionary<string, Course> MyCourses { get => myCourses; }

    protected override void Awake()
    {
        base.Awake();
        allCourses = new Dictionary<string, Course>();
        myCourses = new Dictionary<string, Course>();
        courses_DataHandler = FindObjectOfType<Courses_DataHandler>();
        if (!ReferenceEquals(courses_DataHandler, null))
        {
            foreach (KeyValuePair<string, Course_Template> course in courses_DataHandler.GetCourseDic)
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
