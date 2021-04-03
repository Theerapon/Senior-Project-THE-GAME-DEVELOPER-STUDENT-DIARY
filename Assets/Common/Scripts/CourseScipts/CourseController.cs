using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseController : MonoBehaviour
{
    [Header("Course Display")]
    [SerializeField] private CourseDisplay courseDisplay;
    private CourseManager courseManager;

    private GameObject found_Player;
    private Characters_Handler chracter_handler;
    private PlayerAction playerAction;

    [Header("Course ID")]
    [SerializeField] private CourseID billID;
    [SerializeField] private CourseID learnID;


    private void Start()
    {
        courseManager = CourseManager.Instance;
        found_Player = GameObject.FindGameObjectWithTag("Player");
        chracter_handler = found_Player.GetComponentInChildren<Characters_Handler>();
        playerAction = found_Player.GetComponentInChildren<PlayerAction>();
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

        if(playerAction.GetEnergyCourse(courseManager.courses[id]) > chracter_handler.characterStats.GetCurrentEnergy())
        {
            courseDisplay.CloseAll();
            courseDisplay.UpdateCollectionCourseIsMain();
            courseDisplay.DisplayEnergyNotEnough();
        }
        else
        {
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
        if (totalPrice < chracter_handler.characterStats.GetCurrentMoney())
        {
            chracter_handler.characterStats.TakeMoney(totalPrice);
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

    public CourseID GetIdLearnCourse()
    {
        return learnID;
    }

}

