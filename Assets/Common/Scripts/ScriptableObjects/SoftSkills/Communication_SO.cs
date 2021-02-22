using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Character/Skills/SoftSkill/Communication", order = 0)]
public class Communication_SO : SoftSkill_SO
{
    [System.Serializable]
    public class CommunicationSkillLevel
    {
        [Header("Communication")]
        public float BONUS_charm;
        public float BONUS_baseBootUpProject;

    }

    private float totalBONUS_charm;
    private float totalBONUS_baseBootUpProject;

    [SerializeField] private CommunicationSkillLevel[] softSkillLevelsList;

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

    public float GetTotalBONUS_baseBootUpProject()
    {
        return totalBONUS_baseBootUpProject;
    }
    public float GetTotalBONUS_charm()
    {
        return totalBONUS_charm;
    }

    protected override void SetSoftSkillLevel(int softSkillLevel)
    {
        currentSoftSkillLevel = softSkillLevel + 1;

        if (currentSoftSkillLevel > 0)
        {
            totalBONUS_baseBootUpProject += softSkillLevelsList[currentSoftSkillLevel].BONUS_baseBootUpProject;
            totalBONUS_charm += softSkillLevelsList[currentSoftSkillLevel].BONUS_charm;
            //OnLevelUp.Invoke(charLevel);
        }
    }
}
