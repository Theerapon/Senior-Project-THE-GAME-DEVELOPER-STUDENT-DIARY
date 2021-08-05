using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseIdTemplate : MonoBehaviour
{
    private string courseId;
    private CourseManager _courseManager;

    private void Awake()
    {
        _courseManager = FindObjectOfType<CourseManager>();
    }

    public string CourseId { get => courseId; set => courseId = value; }

    public void PurchaseCourse()
    {
        _courseManager.PurchaseCourse(courseId);
    }

    public void LearnCourse()
    {
        _courseManager.LearnCourse(courseId);
    }
}
