using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseDatabase : MonoBehaviour
{
    [SerializeField] private CourseDatabase_SO courseDB_Template;
    protected CourseDatabase_SO courseDB_current;
    public List<Course> courses;

    private void Awake()
    {
        if (courseDB_Template != null)
        {
            courseDB_current = Instantiate(courseDB_Template);
        }

        Course_SO[] course_SOs = courseDB_current.GetCourses();
        for (int i = 0; i < course_SOs.Length; i++)
        {
            courses.Add(new Course(course_SOs[i]));
        }
    }


}
