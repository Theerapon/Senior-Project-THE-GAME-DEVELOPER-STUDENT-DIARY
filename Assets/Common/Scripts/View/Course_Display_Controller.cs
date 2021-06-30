using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class Course_Display_Controller : Manager<Course_Display_Controller>
{

    public enum CourseDisplayState
    {
        SHOW,
        NOTIFICATION
    }
    public CourseDisplayState courseDisplayState;

    public enum CourseDisplayed
    {
        AllCourse,
        MyCourse
    }
    public CourseDisplayed courseDisplayed;

    [Header("Course Generator")]
    [SerializeField] private AllCourse_Generator all_course_generator;
    [SerializeField] private MyCourse_Generator my_course_generator;


    [Header("Displays")]
    [SerializeField] private GameObject all_course;
    [SerializeField] private GameObject my_course;
    private GameObject preDisplay;


    [Header("Notification")]
    [SerializeField] private GameObject notification;
    [SerializeField] private GameObject confirm_purchase_notification;
    [SerializeField] private GameObject confirm_learn_notification;

    [Header("Scroll")]
    [SerializeField] private ScrollRect all_course_scroll;
    [SerializeField] private ScrollRect my_course_scroll;


    [Header("Course Canvas")]
    [SerializeField] private GameObject courseCanvas;

    private GameManager _gameManager;
    private SwitchScene _switchScene;
    private CoursesController courseController;
    private TimeManager _timeManager;
    private PlayerAction _playerAction;

    protected void Start()
    {
        _playerAction = PlayerAction.Instance;
        _timeManager = TimeManager.Instance;
        courseController = CoursesController.Instance;
        _gameManager = GameManager.Instance;
        _switchScene = SwitchScene.Instance;


        courseDisplayed = CourseDisplayed.AllCourse;
        _gameManager.OnGameStateChanged.AddListener(HandleGameStateChanged);

        all_course.SetActive(false);
        my_course.SetActive(false);
        ActivedNotificationCanvas(false);
        ActivedAllCourse();
    }


    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (currentState == GameManager.GameState.COURSE)
        {
            DisplayCourseCanvas(true);
            CloseAllNotification();

            switch (courseDisplayed)
            {
                case CourseDisplayed.AllCourse:
                    ActivedAllCourse();
                    break;
                case CourseDisplayed.MyCourse:
                    ActivedMyCourse();
                    break;
            }
        } 
        else if (currentState == GameManager.GameState.COURSE_SUMMARY)
        {
            DisplayCourseCanvas(false);
        }
    }


    public void ActivedAllCourse()
    {
        if (_gameManager.CurrentGameState == GameManager.GameState.COURSE)
        {
            if (all_course.activeSelf == false)
            {
                if(preDisplay != null)
                {
                    preDisplay.SetActive(false);
                }

                all_course.SetActive(true);
                preDisplay = all_course;
                CreateAllCourses();
            }
            else
            {
                CreateAllCourses();
            }
            courseDisplayed = CourseDisplayed.AllCourse;
        }

    }
    public void ActivedMyCourse()
    {
        if (_gameManager.CurrentGameState == GameManager.GameState.COURSE)
        {
            if (my_course.activeSelf == false)
            {
                if (preDisplay != null)
                {
                    preDisplay.SetActive(false);
                }

                my_course.SetActive(true);
                preDisplay = my_course;
                CreateMyCourses();
            }
            else
            {
                CreateMyCourses();
            }
            courseDisplayed = CourseDisplayed.MyCourse;
        }
    }

    public void DisplayCourseCanvas(bool actived)
    {
        courseCanvas.SetActive(actived);
    }


    private void CreateAllCourses()
    {
        all_course_generator.CreateTemplate();
    }

    private void CreateMyCourses()
    {
        my_course_generator.CreateTemplate();
    }



    public void DisplayPurchaseNotification(string id)
    {
        Course course = courseController.AllCourses[id];
        string courseName = course.CourseName;
        string price = string.Format("{0:n0}", course.GetTotalPrice());

        ActivedNotificationCanvas(true);
        confirm_purchase_notification.SetActive(true);
        confirm_purchase_notification.transform.GetChild(3).GetComponent<TMP_Text>().text = courseName;
        confirm_purchase_notification.transform.GetChild(6).GetComponentInChildren<TMP_Text>().text = price;
        _switchScene.DisplayCourseNotification(true);
        UpdateDisplayState(CourseDisplayState.NOTIFICATION);
    }

    public void CloseNotification()
    {
        _switchScene.DisplayCourseNotification(false);
    }


    private void CloseAllNotification()
    {
        ActivedNotificationCanvas(false);
        confirm_purchase_notification.SetActive(false);
        confirm_learn_notification.SetActive(false);
        UpdateDisplayState(CourseDisplayState.SHOW);
    }

    public void DisplayLearnNotification(string id)
    {
        Course course = courseController.MyCourses[id];
        string courseName = course.CourseName;
        string courseTime = _timeManager.GetSecondText(course.SecondTimeUsed);
        string energyToConsume = string.Format("{0:n0}", _playerAction.CalReduceEnergyToCunsume(course.EnergyUsed));

        ActivedNotificationCanvas(true);
        confirm_learn_notification.SetActive(true);
        confirm_learn_notification.transform.GetChild(3).GetComponent<TMP_Text>().text = courseName;
        confirm_learn_notification.transform.GetChild(6).GetChild(0).GetComponentInChildren<TMP_Text>().text = courseTime; //time
        confirm_learn_notification.transform.GetChild(6).GetChild(1).GetComponentInChildren<TMP_Text>().text = energyToConsume; //energy
        _switchScene.DisplayCourseNotification(true);
        UpdateDisplayState(CourseDisplayState.NOTIFICATION);
    }

    public void ActivedNotificationCanvas(bool actived)
    {
        if(notification.activeSelf != actived)
        {
            notification.SetActive(actived);
        }
     
    }


    private void UpdateDisplayState(CourseDisplayState state)
    {
        courseDisplayState = state;
        switch (courseDisplayState)
        {
            case CourseDisplayState.SHOW:
                all_course_scroll.movementType = ScrollRect.MovementType.Elastic;
                my_course_scroll.movementType = ScrollRect.MovementType.Elastic;
                break;
            case CourseDisplayState.NOTIFICATION:
                all_course_scroll.movementType = ScrollRect.MovementType.Clamped;
                my_course_scroll.movementType = ScrollRect.MovementType.Clamped;
                break;
        }
    }
}
