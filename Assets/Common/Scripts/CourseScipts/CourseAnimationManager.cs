using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseAnimationManager : MonoBehaviour
{
    private Courses_Handler course_handler;
    private Course_Notification_Controller courseController;
    private CourseID courseID;
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;

    //[Header("Bonus Generator")]
    //[SerializeField] private BonusBoxGenerator boxGenerator;

    private void Start()
    {
        courseController = FindObjectOfType<Course_Notification_Controller>();
        courseID = courseController.GetIdLearnCourse();
        course_handler = Courses_Handler.Instance;
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
