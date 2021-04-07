using UnityEngine;

public class Leadership_Template : SoftSkill_Template
{
    [System.Serializable]
    public class LeadershipSkillLevel
    {
        public float BONUS_negativeEventsEffect;
        public float BONUS_positiveEventsEffect;

        public LeadershipSkillLevel(float negativeEffect, float positiveEffect)
        {
            BONUS_negativeEventsEffect = negativeEffect;
            BONUS_positiveEventsEffect = positiveEffect;
        }

    }

    private float totalBONUS_negativeEventsEffect;
    private float totalBONUS_positiveEventsEffect;

    private LeadershipSkillLevel[] softSkillLevelsList;

    public Leadership_Template(string softSkill_ID, string nameSoftSkill, string description, int softSkillArraySize, 
        LeadershipSkillLevel[] softSkillLevelsList, Sprite icon)
    {
        this.softSkill_ID = softSkill_ID;
        this.nameSoftSkill = nameSoftSkill;
        this.description = description;
        this.isUnlock = false;
        this.currentSoftSkillLevel = 0;
        this.softSkillMaxLevel = softSkillArraySize;
        this.softSkillType = SoftSkillType.LEADERSHIP;

        this.softSkillLevelsList = softSkillLevelsList;
        this.icon = icon;
        Initiate();
    }

    #region Override
    protected override void Initiate()
    {
        if (currentSoftSkillLevel == 0)
        {
            totalBONUS_negativeEventsEffect = softSkillLevelsList[0].BONUS_negativeEventsEffect;
            totalBONUS_positiveEventsEffect = softSkillLevelsList[0].BONUS_positiveEventsEffect;
        }
    }

    #region Get Current Level Bonus
    public override float GetTotalBONUS_negativeEventsEffect()
    {
        return totalBONUS_negativeEventsEffect;
    }
    public override float GetTotalBONUS_positiveEventsEffect()
    {
        return totalBONUS_positiveEventsEffect;
    }
    #endregion

    #region Get Next Level Bonus
    public override float GetNextBONUS_negativeEventsEffect()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_negativeEventsEffect;
        }
        else
        {
            value = totalBONUS_negativeEventsEffect;
        }

        return value;
    }
    public override float GetNextBONUS_positiveEventsEffect()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_positiveEventsEffect;
        }
        else
        {
            value = totalBONUS_positiveEventsEffect;
        }

        return value;
    }
    #endregion

    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_negativeEventsEffect = softSkillLevelsList[currentSoftSkillLevel].BONUS_negativeEventsEffect;
            totalBONUS_positiveEventsEffect = softSkillLevelsList[currentSoftSkillLevel].BONUS_positiveEventsEffect;
            //OnLevelUp.Invoke(charLevel);
        }
    }
    #endregion

}
