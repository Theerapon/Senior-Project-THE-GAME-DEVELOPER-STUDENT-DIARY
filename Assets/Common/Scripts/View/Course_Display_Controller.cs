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

    //[Header("Player")]
    //[SerializeField] private TMP_Text namePlayer;
    //[SerializeField] private TMP_Text moneyPlayer;

    //[Header("Time")]
    //[SerializeField] private TMP_Text time;
    //[SerializeField] private TMP_Text date;
    //private TimeManager timeManager;

    [Header("Notification")]
    [SerializeField] private GameObject notification;
    [SerializeField] private GameObject confirm_purchase_notification;
    [SerializeField] private GameObject confirm_learn_notification;

    [Header("Scroll")]
    [SerializeField] private ScrollRect all_course_scroll;
    [SerializeField] private ScrollRect my_course_scroll;


    [Header("Course Canvas")]
    [SerializeField] private GameObject courseCanvas;

    private CharacterStatusController characterStatusController;
    private CoursesController courseController;

    protected bool first_displayed;

    protected void Start()
    {
        courseController = CoursesController.Instance;
        //timeManager = TimeManager.Instance;
        characterStatusController = CharacterStatusController.Instance;

        courseDisplayed = CourseDisplayed.AllCourse;
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);

        all_course.SetActive(false);
        my_course.SetActive(false);
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

        if (currentState == GameManager.GameState.COURSE_LEARN_ANIMATION)
        {
            DisplayCourseCanvas(false);
        }
    }

    void Update()
    {
        if (!first_displayed)
        {
            ActivedAllCourse();
            first_displayed = true;
        }
    }

    public void ActivedAllCourse()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.COURSE)
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
        }

    }
    public void ActivedMyCourse()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.COURSE)
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

    private void UpdatePlayerData()
    {
        //namePlayer.text = characterStatusController.CharacterStatus.Character_Name;;
        //moneyPlayer.text = string.Format("{0:n0}", characterStatusController.CharacterStatus.CurrentMoney);
    }


    public void DisplayPurchaseNotification(string id)
    {
        ActivedNotificationCanvas(true);
        confirm_purchase_notification.SetActive(true);
        confirm_purchase_notification.transform.GetChild(3).GetComponent<TMP_Text>().text = courseController.AllCourses[id].CourseName;
        SwitchScene.Instance.DisplayCourseNotification(true);
        UpdateDisplayState(CourseDisplayState.NOTIFICATION);
    }

    public void CloseNotification()
    {
        SwitchScene.Instance.DisplayCourseNotification(false);
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
        ActivedNotificationCanvas(true);
        confirm_learn_notification.SetActive(true);
        confirm_learn_notification.transform.GetChild(3).GetComponent<TMP_Text>().text = courseController.MyCourses[id].CourseName;
        SwitchScene.Instance.DisplayCourseNotification(true);
        UpdateDisplayState(CourseDisplayState.NOTIFICATION);
    }

    public void ActivedNotificationCanvas(bool actived)
    {
        notification.SetActive(actived);
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
