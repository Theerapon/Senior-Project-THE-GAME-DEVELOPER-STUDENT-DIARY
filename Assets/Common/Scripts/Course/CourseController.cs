using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseController : MonoBehaviour
{
    [SerializeField] private CourseDisplay courseDisplay;
    private CourseManager courseManager;
    private CharacterStats characterStats;

    [SerializeField] private CourseID billID;
    [SerializeField] private CourseID learnID;

    private void Start()
    {
        characterStats = CharacterStats.Instance;
        courseManager = CourseManager.Instance;
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
        /*
        courseManager.courses[id].UnIsCollected();
        */
        courseDisplay.CloseAll();
        courseDisplay.UpdateCollectionCourseIsMain();
    }

    public void ConfirmPurchaseCourse()
    {
        string id = billID.GetID();
        int totalPrice = courseManager.courses[id].GetTotalPrice();
        if (totalPrice < characterStats.GetCurrentMoney())
        {
            characterStats.TakeMoney(totalPrice);
            courseManager.courses[billID.GetID()].IsCollected();
        }
        courseDisplay.CloseAll();
        courseDisplay.UpdateAllCourseIsMain();
    }

}
