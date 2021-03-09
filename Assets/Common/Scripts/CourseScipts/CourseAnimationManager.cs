using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseAnimationManager : MonoBehaviour
{
    private CourseController courseController;

    private void Start()
    {
        courseController = FindObjectOfType<CourseController>();
        int time = courseController.GetTimeForCourse();
        Debug.Log("course " + TimeManager.Instance.GetSecondText(time));
        TimeManager.Instance.SkilpTime(courseController.GetTimeForCourse());
    }

    public void BacktoCourse()
    {
        GameManager.Instance.BackFromCourseAnimationToCourse();
    }
}
