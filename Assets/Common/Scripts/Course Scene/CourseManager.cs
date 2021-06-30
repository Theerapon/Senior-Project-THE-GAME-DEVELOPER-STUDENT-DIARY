using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : Manager<CourseManager>
{
    [Header("Course Display")]
    [SerializeField] private Course_Display_Controller courseDisplay;
    private CoursesController courseController;

    private NotificationController _notificationController;

    private CharacterStatusController characterStatusController;
    private PlayerAction playerAction;
    private TimeManager _timeManager;
    private ClassActivityController _classActivityController;
    private NotificationController notificationController;
    private SwitchScene _switchScene;


    private string purchase_course_id_temp;
    private string learn_course_id_temp;

    private int _totalTimeSecond;
    private string _currentCourseId;
    private float _currentEnergyConsume;
    private float _currentMotivation;

    public int TotalTimeSecond { get => _totalTimeSecond; }
    public string CurrentCourseId { get => _currentCourseId; }
    public float CurrentEnergyConsume { get => _currentEnergyConsume; }
    public float CurrentMotivation { get => _currentMotivation; }

    protected override void Awake()
    {
        base.Awake();
        _switchScene = SwitchScene.Instance;
        _timeManager = TimeManager.Instance;
        _classActivityController = ClassActivityController.Instance;
        courseController = CoursesController.Instance;
        _notificationController = NotificationController.Instance;
        characterStatusController = CharacterStatusController.Instance;
        playerAction = PlayerAction.Instance;
    }

    public void PurchaseCourse(string courseID)
    {
        purchase_course_id_temp = courseID;
        courseDisplay.DisplayPurchaseNotification(courseID);
    }

    public void LearnCourse(string courseID)
    {
        learn_course_id_temp = courseID;
        courseDisplay.DisplayLearnNotification(courseID);
    }

    public void ConfirmLearnCourse()
    {
        string id = learn_course_id_temp;
        Course course = null;

        if (courseController.MyCourses.ContainsKey(id))
        {
            course = courseController.MyCourses[id];
        }

        _totalTimeSecond = course.SecondTimeUsed;
        _totalTimeSecond = playerAction.GetCalculateCourseTimeSecond(_totalTimeSecond);
        _currentCourseId = id;
        _currentEnergyConsume = course.EnergyUsed;
        _currentMotivation = course.MotivationUsed;

        bool time = CheckTimeToAction(_totalTimeSecond);
        bool energy = CheckEnergyToAction(_currentEnergyConsume);
        bool timeOnProjectDay = CheckTimeForProjectDay(_totalTimeSecond);

        if (!time)
        {
            notificationController.TimeNotEnoughForWork();
        }
        else if (!energy)
        {
            notificationController.EnergyNotEnoughForWork();
        }
        else if (!timeOnProjectDay)
        {
            notificationController.TimeNotEnoughForWorkOnProjectDay();
        }
        else
        {
            courseDisplay.CloseNotification();
            courseDisplay.ActivedMyCourse();
            _switchScene.DisplayCourseSummary(true);
        }

        

    }

    public void ConfirmPurchaseCourse()
    {
        string id = purchase_course_id_temp;
        int totalPrice = courseController.AllCourses[id].GetTotalPrice();
        if (totalPrice < characterStatusController.CurrentMoney)
        {
            characterStatusController.TakeMoney(totalPrice);
            courseController.BuyCourse(id);
        }
        else
        {
            _notificationController.MoneyNotEnough(courseController.AllCourses[id].Course_icon);
        }

        courseDisplay.CloseNotification();
        courseDisplay.ActivedAllCourse();
    }

    public string GetIdLearnCourse()
    {
        return learn_course_id_temp;
    }

    public void CancelPurchaseCourse()
    {
        courseDisplay.CloseNotification();
    }

    public void CancelLearnCourse()
    {
        courseDisplay.CloseNotification();
    }

    private bool CheckTimeToAction(int totalSecond)
    {
        if (_timeManager.HasTimeEnough(totalSecond))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CheckEnergyToAction(float energyToConsume)
    {
        if (characterStatusController.CurrentEnergy >= energyToConsume)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CheckTimeForProjectDay(int totalSecond)
    {
        if (!_classActivityController.HasEvent())
        {
            return true;
        }
        else if (_timeManager.HasTimeEnough(totalSecond) && _classActivityController.HasEvent() && _classActivityController.TimeEnoughForActivity(totalSecond))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

