using UnityEngine;

public class TimeManagement_Template : SoftSkill_Template
{
    [System.Serializable]
    public class TimeManagementSkillLevel
    {
        public float BONUS_reduceTimeTrainCourse;

        public TimeManagementSkillLevel(float reduceTime)
        {
            BONUS_reduceTimeTrainCourse = reduceTime;
        }

    }

    private float totalBONUS_reduceTimeTrainCourse;

    private TimeManagementSkillLevel[] softSkillLevelsList;
    public TimeManagement_Template(string softSkill_ID, string nameSoftSkill, string description, int softSkillArraySize, TimeManagementSkillLevel[] softSkillLevelsList)
    {
        this.softSkill_ID = softSkill_ID;
        this.nameSoftSkill = nameSoftSkill;
        this.description = description;
        this.isUnlock = false;
        this.currentSoftSkillLevel = 0;
        this.softSkillArraySize = softSkillArraySize;
        this.softSkillType = SoftSkillType.TIMEMANAGEMENT;

        this.softSkillLevelsList = softSkillLevelsList;
        Initiate();
    }

    #region Override
    protected override void Initiate()
    {
        if(currentSoftSkillLevel == 0)
        {
            totalBONUS_reduceTimeTrainCourse = softSkillLevelsList[0].BONUS_reduceTimeTrainCourse;
        }
    }

    public override float GetTotalBONUS_reduceTimeTrainCourse()
    {
        return totalBONUS_reduceTimeTrainCourse;
    }
    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_reduceTimeTrainCourse += softSkillLevelsList[currentSoftSkillLevel].BONUS_reduceTimeTrainCourse;
            //OnLevelUp.Invoke(charLevel);
        }
    }
    #endregion

}
