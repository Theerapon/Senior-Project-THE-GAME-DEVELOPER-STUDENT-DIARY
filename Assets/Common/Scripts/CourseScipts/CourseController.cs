using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseController : MonoBehaviour
{
    [SerializeField] private CourseDisplay courseDisplay;
    private CourseManager courseManager;
    private CharacterStats characterStats;
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;

    [SerializeField] private CourseID billID;
    [SerializeField] private CourseID learnID;

    private int timeForCourse;

    private void Start()
    {
        characterStats = CharacterStats.Instance;
        courseManager = CourseManager.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();
    }

    public void PurchaseCourse(CourseID courseID)
    {
        string id = courseID.GetID();
        billID.SetID(id);
        courseDisplay.DisplayBill(id);
    }

    public void LearnCourse(CourseID courseID)
    {
        string id = courseID.GetID();
        learnID.SetID(id);
        courseDisplay.DisplayLearn();
    }

    public void ConfirmLearnCourse()
    {
        string id = learnID.GetID();

        if(playerAction.GetEnergyCourse(courseManager.courses[id]) > characterStats.GetCurrentEnergy())
        {
            courseDisplay.CloseAll();
            courseDisplay.UpdateCollectionCourseIsMain();
            courseDisplay.DisplayEnergyNotEnough();
        }
        else
        {
            timeForCourse = playerAction.GetCalculateCourseTimeSecond(courseManager.courses[id]);
            courseDisplay.CloseAll();
            courseDisplay.UpdateCollectionCourseIsMain();
            GameManager.Instance.GotoCourseAnimation();
        }

    }

    public void ConfirmPurchaseCourse()
    {
        bool purchaseSuccessful;
        string id = billID.GetID();
        int totalPrice = courseManager.courses[id].GetTotalPrice();
        if (totalPrice < characterStats.GetCurrentMoney())
        {
            characterStats.TakeMoney(totalPrice);
            courseManager.courses[billID.GetID()].IsCollected();
            purchaseSuccessful = true;
        }
        else
        {
            purchaseSuccessful = false;
        }
        courseDisplay.CloseAll();
        courseDisplay.UpdateAllCourseIsMain();
        courseDisplay.DisplayTransaction(purchaseSuccessful);
    }

    public int GetTimeForCourse()
    {
        return timeForCourse;
    }
}

