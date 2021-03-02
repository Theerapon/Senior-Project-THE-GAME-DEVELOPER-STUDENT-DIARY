using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour, ICourseAction, ISleepAction
{
    private CharacterStats characterStats;

    private GameObject foundTimeManagement;
    private TimeManagement timeManagement;

    private void Start()
    {
        characterStats = CharacterStats.Instance;

        foundTimeManagement = GameObject.FindGameObjectWithTag("TimeManagement");
        timeManagement = foundTimeManagement.GetComponent<TimeManagement>();
    }

    #region Course
    public int GetCalculateCourseTimeSecond(Course course)
    {
        int second = 0;
        float totalBonusReduced = (characterStats.GetDEFAULT_reduceTimeTrainCourse() + timeManagement.GetTotalBONUS_reduceTimeTrainCourse());

        second = (int)(course.GetSecondToConsume() * (1 - totalBonusReduced));

        return second;
    }
    #endregion

    #region Sleep
    public void Sleep(int totalSecond)
    {
        TimeManager.Instance.SkilpTime(totalSecond);
    }
    public int GetCalculateSleepTimeSecond(bool fullTimeSelected)
    {
        int second = 0;
        Debug.Log("characterStats " + characterStats);
        Debug.Log("time management " + timeManagement.GetTotalBONUS_reduceTimeSleeping());
        float totalBonusReduced = (characterStats.GetDEFAULT_reduceTimeSleeping() + timeManagement.GetTotalBONUS_reduceTimeSleeping());
        if (fullTimeSelected)
        {
            second = (int)(characterStats.GetDEFAULT_fullTimeOfSleepingSecond() * (1 - totalBonusReduced));
        }
        else
        {
            second = (int)(characterStats.GetDEFAULT_twoThirdTimeOfSleepingSeond() * (1 - totalBonusReduced));
        }

        return second;
    }
    #endregion
}
