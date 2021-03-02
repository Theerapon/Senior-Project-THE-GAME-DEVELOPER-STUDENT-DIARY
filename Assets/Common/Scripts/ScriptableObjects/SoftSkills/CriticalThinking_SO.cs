using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Character/Skills/SoftSkill/CriticalThinking", order = 1)]
public class CriticalThinking_SO : SoftSkill_SO
{
    [System.Serializable]
    public class CriticalThinkingSkillLevel
    {
        [Header("Critical Thinking")]
        public float BONUS_baseReduceEnergyConsumption;
        public float BONUS_baseBootUpMotivation;
        public float BONUS_reduceBugChance;

    }

    private float totalBONUS_baseReduceEnergyConsumption;
    private float totalBONUS_baseBootUpMotivation;
    private float totalBONUS_reduceBugChance;

    [SerializeField] private CriticalThinkingSkillLevel[] softSkillLevelsList;

    public void Initiate()
    {
        if (currentSoftSkillLevel == 0)
        {
            totalBONUS_baseReduceEnergyConsumption = softSkillLevelsList[0].BONUS_baseReduceEnergyConsumption;
            totalBONUS_baseBootUpMotivation = softSkillLevelsList[0].BONUS_baseBootUpMotivation;
            totalBONUS_reduceBugChance = softSkillLevelsList[0].BONUS_reduceBugChance;
        }
    }
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
    public float GetTotalBONUS_baseBootUpMotivation()
    {
        return totalBONUS_baseBootUpMotivation;
    }
    public float GetTotalBONUS_baseReduceEnergyConsumption()
    {
        return totalBONUS_baseReduceEnergyConsumption;
    }
    public float GetTotalBONUS_reduceBugChance()
    {
        return totalBONUS_reduceBugChance;
    }

    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_baseReduceEnergyConsumption += softSkillLevelsList[currentSoftSkillLevel].BONUS_baseReduceEnergyConsumption;
            totalBONUS_baseBootUpMotivation += softSkillLevelsList[currentSoftSkillLevel].BONUS_baseBootUpMotivation;
            totalBONUS_reduceBugChance += softSkillLevelsList[currentSoftSkillLevel].BONUS_reduceBugChance;
            //OnLevelUp.Invoke(charLevel);
        }
    }
}
