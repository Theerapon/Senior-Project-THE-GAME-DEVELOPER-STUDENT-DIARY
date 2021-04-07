using System.Collections.Generic;
using UnityEngine;

public class Communication_Template : SoftSkill_Template
{
    [System.Serializable]
    public class CommunicationSkillLevel
    {
        public float BONUS_charm;
        public float BONUS_baseBootUpProject;
        public CommunicationSkillLevel(float charm, float baseBootUpProject)
        {
            BONUS_charm = charm;
            BONUS_baseBootUpProject = baseBootUpProject;
        }

        public CommunicationSkillLevel()
        {
            this.BONUS_charm = 0;
            this.BONUS_baseBootUpProject = 0;

        }


    }

    private float totalBONUS_charm;
    private float totalBONUS_baseBootUpProject;

    private CommunicationSkillLevel[] softSkillLevelsList;

    public Communication_Template(string softSkill_ID, string nameSoftSkill, string description, int softSkillArraySize, CommunicationSkillLevel[] softSkillLevelsList, Sprite icon)
    {
        this.softSkill_ID = softSkill_ID;
        this.nameSoftSkill = nameSoftSkill;
        this.description = description;
        this.isUnlock = false;
        this.currentSoftSkillLevel = 0;
        this.softSkillMaxLevel = softSkillArraySize;
        this.softSkillType = SoftSkillType.COMMUNICATION;

        this.softSkillLevelsList = softSkillLevelsList;
        this.icon = icon;
        Initiate();
    }

    #region Override
    protected override void Initiate()
    {
        if(currentSoftSkillLevel == 0)
        {
            totalBONUS_charm = softSkillLevelsList[0].BONUS_charm;
            totalBONUS_baseBootUpProject = softSkillLevelsList[0].BONUS_baseBootUpProject;
        }
    }

    #region Get Current Level Bonus
    public override float GetTotalBONUS_baseBootUpProject()
    {
        return totalBONUS_baseBootUpProject;
    }
    public override float GetTotalBONUS_charm()
    {
        return totalBONUS_charm;
    }
    #endregion

    #region Get Next Level Bonus
    public override float GetNextBONUS_baseBootUpProject()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_baseBootUpProject;
        }
        else
        {
            value = totalBONUS_baseBootUpProject;
        }

        return value;
    }
    public override float GetNextBONUS_charm()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_charm;
        }
        else
        {
            value = totalBONUS_charm;
        }

        return value;
    }
    #endregion

    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_baseBootUpProject = softSkillLevelsList[currentSoftSkillLevel].BONUS_baseBootUpProject;
            totalBONUS_charm = softSkillLevelsList[currentSoftSkillLevel].BONUS_charm;
            //OnLevelUp.Invoke(charLevel);
        }
    }

    #endregion


}
