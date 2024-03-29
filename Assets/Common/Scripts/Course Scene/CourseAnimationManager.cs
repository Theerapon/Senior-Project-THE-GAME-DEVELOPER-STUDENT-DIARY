﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseAnimationManager : MonoBehaviour
{
    private CoursesController courseController;
    private CourseManager courseNotificationController;
    private string courseID;
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;

    //[Header("Bonus Generator")]
    //[SerializeField] private BonusBoxGenerator boxGenerator;

    private void Start()
    {
        courseNotificationController = FindObjectOfType<CourseManager>();
        courseID = courseNotificationController.GetIdLearnCourse();
        courseController = CoursesController.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();

        //int time = playerAction.GetCalculateCourseTimeSecond(course_handler.courses[courseID.GetID()]);
        //TimeManager.Instance.SkilpTime(time);

    }

    public void BacktoCourse()
    {
        //playerAction.CalCourseProcess(course_handler.courses[courseID.GetID()]);
        //GameManager.Instance.BackFromCourseAnimationToCourse();
    }

    public void CreateTemplateBonus()
    {
        //boxGenerator.CreateTemplate(courseID.GetID());
    }

}
