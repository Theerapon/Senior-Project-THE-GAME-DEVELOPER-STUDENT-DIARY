﻿using UnityEngine;

public class Leadership_Template : SoftSkill_Template
{
    [System.Serializable]
    public class LeadershipSkillLevel
    {
        public float BONUS_negativeEventsChance;
        public float BONUS_negativeEventsEffect;
        public float BONUS_positiveEventsEffect;

        public LeadershipSkillLevel(float negativeChance, float negativeEffect, float positiveEffect)
        {
            BONUS_negativeEventsChance = negativeChance;
            BONUS_negativeEventsEffect = negativeEffect;
            BONUS_positiveEventsEffect = positiveEffect;
        }

    }

    private float totalBONUS_negativeEventsChance;
    private float totalBONUS_negativeEventsEffect;
    private float totalBONUS_positiveEventsEffect;

    private LeadershipSkillLevel[] softSkillLevelsList;

    public Leadership_Template(string softSkill_ID, string nameSoftSkill, string description, int softSkillArraySize, LeadershipSkillLevel[] softSkillLevelsList)
    {
        this.softSkill_ID = softSkill_ID;
        this.nameSoftSkill = nameSoftSkill;
        this.description = description;
        this.isUnlock = false;
        this.currentSoftSkillLevel = 0;
        this.softSkillArraySize = softSkillArraySize;
        this.softSkillType = SoftSkillType.LEADERSHIP;

        this.softSkillLevelsList = softSkillLevelsList;
        Initiate();
    }

    #region Override
    protected override void Initiate()
    {
        if (currentSoftSkillLevel == 0)
        {
            totalBONUS_negativeEventsChance = softSkillLevelsList[0].BONUS_negativeEventsChance;
            totalBONUS_negativeEventsEffect = softSkillLevelsList[0].BONUS_negativeEventsEffect;
            totalBONUS_positiveEventsEffect = softSkillLevelsList[0].BONUS_positiveEventsEffect;
        }
    }

    public override float GetTotalBONUS_negativeEventsChance()
    {
        return totalBONUS_negativeEventsChance;
    }
    public override float GetTotalBONUS_negativeEventsEffect()
    {
        return totalBONUS_negativeEventsEffect;
    }
    public override float GetTotalBONUS_positiveEventsEffect()
    {
        return totalBONUS_positiveEventsEffect;
    }
    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_negativeEventsChance += softSkillLevelsList[currentSoftSkillLevel].BONUS_negativeEventsChance;
            totalBONUS_negativeEventsEffect += softSkillLevelsList[currentSoftSkillLevel].BONUS_negativeEventsEffect;
            totalBONUS_positiveEventsEffect += softSkillLevelsList[currentSoftSkillLevel].BONUS_positiveEventsEffect;
            //OnLevelUp.Invoke(charLevel);
        }
    }
    #endregion

}