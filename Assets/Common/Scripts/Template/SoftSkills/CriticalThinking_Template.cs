using UnityEngine;

public class CriticalThinking_Template : SoftSkill_Template
{
    [System.Serializable]
    public class CriticalThinkingSkillLevel
    {
        public float BONUS_baseReduceEnergyConsumption;
        public float BONUS_baseBootUpMotivation;
        public float BONUS_reduceBugChance;
        
        public CriticalThinkingSkillLevel(float baseReduceEnergy, float baseBootUpMotivation, float reduceBugChange)
        {
            BONUS_baseReduceEnergyConsumption = baseReduceEnergy;
            BONUS_baseBootUpMotivation = baseBootUpMotivation;
            BONUS_reduceBugChance = reduceBugChange;
        }
    }

    private float totalBONUS_baseReduceEnergyConsumption;
    private float totalBONUS_baseBootUpMotivation;
    private float totalBONUS_reduceBugChance;

    private CriticalThinkingSkillLevel[] softSkillLevelsList;

    public CriticalThinking_Template(string softSkill_ID, string nameSoftSkill, string description, int softSkillArraySize, 
        CriticalThinkingSkillLevel[] softSkillLevelsList, Sprite icon)
    {
        this.softSkill_ID = softSkill_ID;
        this.nameSoftSkill = nameSoftSkill;
        this.description = description;
        this.softSkillMaxLevel = softSkillArraySize;
        this.softSkillType = SoftSkillType.CRITICALTHINKING;

        this.softSkillLevelsList = softSkillLevelsList;
        this.icon = icon;
        Initialzing();
    }

    #region Override
    protected override void Initialzing()
    {
        base.Initialzing();
        if (currentSoftSkillLevel == 0)
        {
            totalBONUS_baseReduceEnergyConsumption = softSkillLevelsList[0].BONUS_baseReduceEnergyConsumption;
            totalBONUS_baseBootUpMotivation = softSkillLevelsList[0].BONUS_baseBootUpMotivation;
            totalBONUS_reduceBugChance = softSkillLevelsList[0].BONUS_reduceBugChance;
        }
    }

    #region Get Current Level Bonus 
    public override float GetTotalBONUS_baseBootUpMotivation()
    {
        return totalBONUS_baseBootUpMotivation;
    }
    public override float GetTotalBONUS_baseReduceEnergyConsumption()
    {
        return totalBONUS_baseReduceEnergyConsumption;
    }
    public override float GetTotalBONUS_reduceBugChance()
    {
        return totalBONUS_reduceBugChance;
    }
    #endregion

    #region Get Next Level Bonus
    public override float GetNextBONUS_baseBootUpMotivation()
    {
        float value;
        if(currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_baseBootUpMotivation;
        }
        else
        {
            value = totalBONUS_baseBootUpMotivation;
        }

        return value;
    }
    public override float GetNextBONUS_baseReduceEnergyConsumption()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_baseReduceEnergyConsumption;
        }
        else
        {
            value = totalBONUS_baseReduceEnergyConsumption;
        }

        return value;
    }
    public override float GetNextBONUS_reduceBugChance()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_reduceBugChance;
        }
        else
        {
            value = totalBONUS_reduceBugChance;
        }

        return value;
    }
    #endregion

    protected override void SetSoftSkillLevelUp(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_baseReduceEnergyConsumption = softSkillLevelsList[currentSoftSkillLevel].BONUS_baseReduceEnergyConsumption;
            totalBONUS_baseBootUpMotivation = softSkillLevelsList[currentSoftSkillLevel].BONUS_baseBootUpMotivation;
            totalBONUS_reduceBugChance = softSkillLevelsList[currentSoftSkillLevel].BONUS_reduceBugChance;
            //OnLevelUp.Invoke(charLevel);
        }
    }
    #endregion

    
}
