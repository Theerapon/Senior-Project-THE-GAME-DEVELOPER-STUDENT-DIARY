using UnityEngine;

public class WorkEthic_Template : SoftSkill_Template
{
    [System.Serializable]
    public class WorkEthicSkillLevel
    {
        public float BONUS_goldenTimeReduceEnergyConsuption;
        public float BONUS_goldenTimeBootUpMotivation;
        public float BONUS_goldenTimeBootUpProject;
        public WorkEthicSkillLevel(float reduceEnergy, float bootupMotivation, float bootupProject)
        {
            BONUS_goldenTimeReduceEnergyConsuption = reduceEnergy;
            BONUS_goldenTimeBootUpMotivation = bootupMotivation;
            BONUS_goldenTimeBootUpProject = bootupProject;
        }
    }

    private float totalBONUS_goldenTimeReduceEnergyConsuption;
    private float totalBONUS_goldenTimeBootUpMotivation;
    private float totalBONUS_goldenTimeBootUpProject;

    private WorkEthicSkillLevel[] softSkillLevelsList;

    public WorkEthic_Template(string softSkill_ID, string nameSoftSkill, string description, int softSkillArraySize, 
        WorkEthicSkillLevel[] softSkillLevelsList, Sprite icon)
    {
        this.softSkill_ID = softSkill_ID;
        this.nameSoftSkill = nameSoftSkill;
        this.description = description;
        this.isUnlock = false;
        this.currentSoftSkillLevel = 0;
        this.softSkillMaxLevel = softSkillArraySize;
        this.softSkillType = SoftSkillType.WORKETHIC;

        this.softSkillLevelsList = softSkillLevelsList;
        this.icon = icon;
        Initiate();
    }

    #region Override
    protected override void Initiate()
    {
        if (currentSoftSkillLevel == 0)
        {
            totalBONUS_goldenTimeReduceEnergyConsuption = softSkillLevelsList[0].BONUS_goldenTimeReduceEnergyConsuption;
            totalBONUS_goldenTimeBootUpMotivation = softSkillLevelsList[0].BONUS_goldenTimeBootUpMotivation;
            totalBONUS_goldenTimeBootUpProject = softSkillLevelsList[0].BONUS_goldenTimeBootUpProject;
        }
    }

    #region Get Current Level Bonus
    public override float GetTotalBONUS_goldenTimeReduceEnergyConsuption()
    {
        return totalBONUS_goldenTimeReduceEnergyConsuption;
    }

    public override float GetTotalBONUS_goldenTimeBootUpMotivation()
    {
        return totalBONUS_goldenTimeBootUpMotivation;
    }
    public override float GetTotalBONUS_goldenTimeBootUpProject()
    {
        return totalBONUS_goldenTimeBootUpProject;
    }
    #endregion

    #region Get Next Level Bonus
    public override float GetNextBONUS_goldenTimeReduceEnergyConsuption()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_goldenTimeReduceEnergyConsuption;
        }
        else
        {
            value = totalBONUS_goldenTimeReduceEnergyConsuption;
        }

        return value;
    }

    public override float GetNextBONUS_goldenTimeBootUpMotivation()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_goldenTimeBootUpMotivation;
        }
        else
        {
            value = totalBONUS_goldenTimeBootUpMotivation;
        }

        return value;
    }
    public override float GetNextBONUS_goldenTimeBootUpProject()
    {
        float value;
        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            value = softSkillLevelsList[currentSoftSkillLevel + 1].BONUS_goldenTimeBootUpProject;
        }
        else
        {
            value = totalBONUS_goldenTimeBootUpProject;
        }

        return value;
    }
    #endregion
    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_goldenTimeReduceEnergyConsuption = softSkillLevelsList[currentSoftSkillLevel].BONUS_goldenTimeReduceEnergyConsuption;
            totalBONUS_goldenTimeBootUpMotivation = softSkillLevelsList[currentSoftSkillLevel].BONUS_goldenTimeBootUpMotivation;
            totalBONUS_goldenTimeBootUpProject = softSkillLevelsList[currentSoftSkillLevel].BONUS_goldenTimeBootUpProject;
            //OnLevelUp.Invoke(charLevel);
        }
    }
    #endregion


}
