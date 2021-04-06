using UnityEngine;

public class TimeManagement_Template : SoftSkill_Template
{
    [System.Serializable]
    public class TimeManagementSkillLevel
    {
        public float BONUS_reduceTimeTrainCourse;
        public float BONUS_reduceTimeTransport;

        public TimeManagementSkillLevel(float reduceTimeCourse, float reduceTimeTransport)
        {
            BONUS_reduceTimeTrainCourse = reduceTimeCourse;
            BONUS_reduceTimeTransport = reduceTimeTransport;
        }

    }

    private float totalBONUS_reduceTimeTrainCourse;
    private float totalBONUS_reduceTimeTransport;

    private TimeManagementSkillLevel[] softSkillLevelsList;
    public TimeManagement_Template(string softSkill_ID, string nameSoftSkill, string description, int softSkillArraySize, TimeManagementSkillLevel[] softSkillLevelsList, Sprite icon)
    {
        this.softSkill_ID = softSkill_ID;
        this.nameSoftSkill = nameSoftSkill;
        this.description = description;
        this.isUnlock = false;
        this.currentSoftSkillLevel = 0;
        this.softSkillMaxLevel = softSkillArraySize;
        this.softSkillType = SoftSkillType.TIMEMANAGEMENT;

        this.softSkillLevelsList = softSkillLevelsList;
        this.icon = icon;
        Initiate();
    }

    #region Override
    protected override void Initiate()
    {
        if(currentSoftSkillLevel == 0)
        {
            totalBONUS_reduceTimeTrainCourse = softSkillLevelsList[0].BONUS_reduceTimeTrainCourse;
            totalBONUS_reduceTimeTransport = softSkillLevelsList[0].BONUS_reduceTimeTransport;
        }
    }

    public override float GetTotalBONUS_reduceTimeTrainCourse()
    {
        return totalBONUS_reduceTimeTrainCourse;
    }
    public override float GetTotalBONUS_reduceTimeTransport()
    {
        return totalBONUS_reduceTimeTransport;
    }
    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_reduceTimeTrainCourse = softSkillLevelsList[currentSoftSkillLevel].BONUS_reduceTimeTrainCourse;
            //OnLevelUp.Invoke(charLevel);
        }
    }
    #endregion

}
