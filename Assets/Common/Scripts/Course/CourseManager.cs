using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : Manager<CourseManager>
{
    [SerializeField] private Transform allCourse;
    public Dictionary<string, Course> courses;

    private void Start()
    {
        if (allCourse != null)
            courses = allCourse.transform.GetComponent<CourseDatabase>().courses;

    }

    private void Update()
    {
        

    }

}
