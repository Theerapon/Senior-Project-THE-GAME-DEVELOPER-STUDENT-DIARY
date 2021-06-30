using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : MonoBehaviour
{
    [Header("Course Display")]
    [SerializeField] private Course_Display_Controller courseDisplay;
    private CoursesController courseController;

    private NotificationController _notificationController;

    private GameObject found_Player;
    private CharacterStatusController characterStatusController;
    private PlayerAction playerAction;

    private string purchase_course_id_temp;
    private string learn_course_id_temp;


    private void Start()
    {
        courseController = CoursesController.Instance;
        found_Player = GameObject.FindGameObjectWithTag("Player");
        _notificationController = NotificationController.Instance;
        characterStatusController = CharacterStatusController.Instance;
        playerAction = found_Player.GetComponentInChildren<PlayerAction>();
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
        courseController.LearnCourse(id);
        courseDisplay.CloseNotification();
        courseDisplay.ActivedMyCourse();
        //if(playerAction.GetEnergyCourse(course_handler.courses[id]) > chracter_handler.STATUS.GetCurrentEnergy())
        //{
        //    courseDisplay.CloseAll();
        //    courseDisplay.UpdateCollectionCourseIsMain();
        //    courseDisplay.DisplayEnergyNotEnough();
        //}
        //else
        //{
        //    courseDisplay.CloseAll();
        //    courseDisplay.UpdateCollectionCourseIsMain();
        //    GameManager.Instance.GotoCourseAnimation();
        //}

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

}

