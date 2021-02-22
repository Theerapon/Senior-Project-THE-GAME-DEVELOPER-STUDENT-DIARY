using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Character/Skills/SoftSkill/TimeManagement", order = 3)]
public class TimeManagement_SO : SoftSkill_SO
{
    [System.Serializable]
    public class TimeManagementSkillLevel
    {
        [Header("Time Management")]
        public float BONUS_reduceTimeSleeping;
        public float BONUS_reduceTimeReadBook;
        public float BONUS_reduceTimeTrainCourse;

    }

    private float totalBONUS_reduceTimeSleeping;
    private float totalBONUS_reduceTimeReadBook;
    private float totalBONUS_reduceTimeTrainCourse;

    [SerializeField] private TimeManagementSkillLevel[] softSkillLevelsList;

    public void UpSoftSkill()
    {
        if (currentSoftSkillLevel == 0)
        {
            UnLockSkill();
        }

        if (currentSoftSkillLevel < softSkillLevelsList.Length - 1)
        {
            SetSoftSkillLevel(currentSoftSkillLevel);
        }
        else
        {
            Debug.Log("soft Skill maxlevel");
        }
    }

    public float GetTotalBONUS_reduceTimeSleeping()
    {
        return totalBONUS_reduceTimeSleeping;
    }
    public float GetTotalBONUS_reduceTimeReadBook()
    {
        return totalBONUS_reduceTimeReadBook;
    }
    public float GetTotalBONUS_reduceTimeTrainCourse()
    {
        return totalBONUS_reduceTimeTrainCourse;
    }
    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_reduceTimeSleeping += softSkillLevelsList[currentSoftSkillLevel].BONUS_reduceTimeSleeping;
            totalBONUS_reduceTimeReadBook += softSkillLevelsList[currentSoftSkillLevel].BONUS_reduceTimeReadBook;
            totalBONUS_reduceTimeTrainCourse += softSkillLevelsList[currentSoftSkillLevel].BONUS_reduceTimeTrainCourse;
            //OnLevelUp.Invoke(charLevel);
        }
    }
}
