using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : Manager<CourseManager>
{
    [SerializeField] private Transform allCourse;
    public List<Course> courses;

    private void Start()
    {
        if (allCourse != null)
            courses = allCourse.transform.GetComponent<CourseDatabase>().courses;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            courses[0].IsCollected();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            courses[0].UnIsCollected();
        }

    }

}
