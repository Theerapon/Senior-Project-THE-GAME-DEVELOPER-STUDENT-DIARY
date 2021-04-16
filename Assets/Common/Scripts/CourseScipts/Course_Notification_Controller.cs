using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course_Notification_Controller : MonoBehaviour
{
    [Header("Course Display")]
    [SerializeField] private Course_Display_Controller courseDisplay;
    private Courses_Handler course_handler;

    private GameObject found_Player;
    private CharacterStatus chracter_status;
    private PlayerAction playerAction;

    [Header("Course ID")]
    [SerializeField] private CourseID purchase_course_id_temp;
    [SerializeField] private CourseID learn_course_id_temp;


    private void Start()
    {
        course_handler = Courses_Handler.Instance;
        found_Player = GameObject.FindGameObjectWithTag("Player");
        chracter_status = CharacterStatus.Instance;
        playerAction = found_Player.GetComponentInChildren<PlayerAction>();
    }

    public void PurchaseCourse(CourseID courseID)
    {
        string id = courseID.GetID();
        purchase_course_id_temp.SetID(id);
        courseDisplay.DisplayPurchaseNotification(id);
    }

    public void LearnCourse(CourseID courseID)
    {
        string id = courseID.GetID();
        learn_course_id_temp.SetID(id);
        courseDisplay.DisplayLearnNotification(id);
    }

    public void ConfirmLearnCourse()
    {
        string id = learn_course_id_temp.GetID();

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
        bool purchaseSuccessful;
        string id = purchase_course_id_temp.GetID();
        int totalPrice = course_handler.CourseDic[id].GetTotalPrice();
        if (totalPrice < chracter_status.GetCurrentMoney())
        {
            chracter_status.TakeMoney(totalPrice);
            course_handler.CourseDic[id].IsCollected();
            purchaseSuccessful = true;
        }
        else
        {
            purchaseSuccessful = false;
        }

        courseDisplay.CloseNotification();
        courseDisplay.ActivedAllCourse();
    }

    public CourseID GetIdLearnCourse()
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

