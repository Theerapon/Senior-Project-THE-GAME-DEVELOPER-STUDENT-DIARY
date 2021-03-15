using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseAnimationManager : MonoBehaviour
{
    private CourseManager courseManager;
    private CourseController courseController;
    private CourseID courseID;
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;

    [Header("Bonus Generator")]
    [SerializeField] private BonusBoxGenerator boxGenerator;

    private void Start()
    {
        courseController = FindObjectOfType<CourseController>();
        courseID = courseController.GetIdLearnCourse();
        courseManager = CourseManager.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();

        int time = playerAction.GetCalculateCourseTimeSecond(courseManager.courses[courseID.GetID()]);
        TimeManager.Instance.SkilpTime(time);

    }

    public void BacktoCourse()
    {
        playerAction.CalCourseProcess(courseManager.courses[courseID.GetID()]);
        GameManager.Instance.BackFromCourseAnimationToCourse();
    }

    public void CreateTemplateBonus()
    {
        boxGenerator.CreateTemplate(courseID.GetID());
    }

}
