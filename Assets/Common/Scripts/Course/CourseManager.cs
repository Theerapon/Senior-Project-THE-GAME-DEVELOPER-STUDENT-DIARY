using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : MonoBehaviour
{
    [SerializeField] private Transform allCourse;
    public List<Course> courses;

    private void Start()
    {
        if (allCourse != null)
            courses = allCourse.transform.GetComponent<CourseDatabase>().courses;

    }

}
