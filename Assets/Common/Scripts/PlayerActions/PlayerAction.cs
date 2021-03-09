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
    public int GetEnergyCourse(Course course)
    {
        int energy = 0;
        float reduceEnergy;
        if (TimeManager.Instance.GetGoldenTime())
        {
            reduceEnergy = characterStats.GetDEFAULT_goldenTimeReduceEnergyConsuption();
            
        }
        else
        {
            reduceEnergy = characterStats.GetDEFAULT_baseReduceEnergyConsumption();
        }

        energy = (int)(course.GetEnergyToConsume() * (1 - reduceEnergy));

        return energy;
    }
    public int GetCalculateCourseTimeSecond(Course courese)
    {
        int second = 0;
        float totalBonusReduced = (characterStats.GetDEFAULT_reduceTimeTrainCourse() + timeManagement.GetTotalBONUS_reduceTimeTrainCourse());

        second = (int)(courese.GetSecondToConsume() * (1 - totalBonusReduced));

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
