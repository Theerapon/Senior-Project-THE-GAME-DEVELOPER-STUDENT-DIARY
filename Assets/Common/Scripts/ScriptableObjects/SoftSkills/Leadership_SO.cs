using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Character/Skills/SoftSkill/Leadership", order = 2)]
public class Leadership_SO : SoftSkill_SO
{
    [System.Serializable]
    public class LeadershipSkillLevel
    {
        [Header("Leadership")]
        public float BONUS_negativeEventsChance;
        public float BONUS_negativeEventsEffect;
        public float BONUS_positiveEventsEffect;

    }

    private float totalBONUS_negativeEventsChance;
    private float totalBONUS_negativeEventsEffect;
    private float totalBONUS_positiveEventsEffect;

    [SerializeField] private LeadershipSkillLevel[] softSkillLevelsList;

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
    public float GetTotalBONUS_negativeEventsChance()
    {
        return totalBONUS_negativeEventsChance;
    }
    public float GetTotalBONUS_negativeEventsEffect()
    {
        return totalBONUS_negativeEventsEffect;
    }
    public float GetTotalBONUS_positiveEventsEffect()
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
}
