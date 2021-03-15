using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : Manager<CourseManager>
{
    [SerializeField] private Transform allCourse;
    public Dictionary<string, Course> courses;

    protected override void Awake()
    {
        base.Awake();
        courses = new Dictionary<string, Course>();
    }

    private void Start()
    {
        if (allCourse != null)
            courses = allCourse.transform.GetComponent<CourseDatabase>().courses;

    }


}
