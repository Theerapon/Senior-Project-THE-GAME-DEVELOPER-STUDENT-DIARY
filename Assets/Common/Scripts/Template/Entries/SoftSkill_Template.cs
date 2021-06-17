using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoftSkillType { NONE, COMMUNICATION, CRITICALTHINKING, LEADERSHIP, TIMEMANAGEMENT, WORKETHIC}
public class SoftSkill_Template : MonoBehaviour
{
    protected Sprite icon;
    protected string softSkill_ID = "";
    protected string nameSoftSkill = "";
    protected string description = "";
    protected bool isUnlock = false;
    protected int currentSoftSkillLevel;
    protected int softSkillMaxLevel;
    protected SoftSkillType softSkillType = SoftSkillType.NONE;

    #region Bonus Increasers
    private void UnLockSkill()
    {
        isUnlock = true;
    }
    public void LevelUpSoftSkill()
    {
        if (currentSoftSkillLevel == 0)
        {
            UnLockSkill();
        }

        if (currentSoftSkillLevel < softSkillMaxLevel)
        {
            SetSoftSkillLevelUp(currentSoftSkillLevel);
        }
        else
        {
            Debug.Log("soft Skill maxlevel");
        }
    }
    #endregion

    #region Reporter
    public string GetSoftSkillName()
    {
        return nameSoftSkill;
    }
    public bool GetIsUnLock()
    {
        return isUnlock;
    }
    public int GetCurrentSoftSkillLevel()
    {
        return currentSoftSkillLevel;
    }
    public SoftSkillType GetSoftSkillType()
    {
        return softSkillType;
    }
    public Sprite GetIconSoftSkill()
    {
        return icon;
    }
    public string GetSoftSkillDescription()
    {
        return description;
    }
    #endregion

    #region Must Override

    protected virtual void Initialzing()
    {
        this.isUnlock = false;
        this.currentSoftSkillLevel = 0;
    }

    protected virtual void SetSoftSkillLevelUp(int softSkillLevel)
    {

    }
    #endregion

    #region WrkEthic
    //current
    public virtual float GetTotalBONUS_goldenTimeReduceEnergyConsuption()
    {
        return 0;
    }

    public virtual float GetTotalBONUS_goldenTimeBootUpMotivation()
    {
        return 0f;
    }
    public virtual float GetTotalBONUS_goldenTimeBootUpProject()
    {
        return 0;
    }
    //next
    public virtual float GetNextBONUS_goldenTimeReduceEnergyConsuption()
    {
        return 0;
    }

    public virtual float GetNextBONUS_goldenTimeBootUpMotivation()
    {
        return 0;
    }
    public virtual float GetNextBONUS_goldenTimeBootUpProject()
    {
        return 0;
    }
    #endregion

    #region TimeManagement
    //current
    public virtual float GetTotalBONUS_reduceTimeTrainCourse()
    {
        return 0;
    }
    public virtual float GetTotalBONUS_reduceTimeTransport()
    {
        return 0;
    }
    //next
    public virtual float GetNextBONUS_reduceTimeTrainCourse()
    {
        return 0;
    }
    public virtual float GetNextBONUS_reduceTimeTransport()
    {
        return 0;
    }
    #endregion

    #region Leadership
    //current
    public virtual float GetTotalBONUS_negativeEventsEffect()
    {
        return 0;
    }
    public virtual float GetTotalBONUS_positiveEventsEffect()
    {
        return 0;
    }
    //next
    public virtual float GetNextBONUS_negativeEventsEffect()
    {
        return 0;
    }
    public virtual float GetNextBONUS_positiveEventsEffect()
    {
        return 0;
    }
    #endregion

    #region Communication
    //current
    public virtual float GetTotalBONUS_baseBootUpProject()
    {
        return 0;
    }
    public virtual float GetTotalBONUS_charm()
    {
        return 0;
    }
    //next
    public virtual float GetNextBONUS_baseBootUpProject()
    {
        return 0;
    }
    public virtual float GetNextBONUS_charm()
    {
        return 0;
    }
    #endregion

    #region CriticalThinking
    //current
    public virtual float GetTotalBONUS_baseBootUpMotivation()
    {
        return 0;
    }
    public virtual float GetTotalBONUS_baseReduceEnergyConsumption()
    {
        return 0;
    }
    public virtual float GetTotalBONUS_reduceBugChance()
    {
        return 0;
    }
    //next
    public virtual float GetNextBONUS_baseBootUpMotivation()
    {
        return 0;
    }
    public virtual float GetNextBONUS_baseReduceEnergyConsumption()
    {
        return 0;
    }
    public virtual float GetNextBONUS_reduceBugChance()
    {
        return 0;
    }
    #endregion
}
