using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoftSkillType { NONE, COMMUNICATION, CRITICALTHINKING, LEADERSHIP, TIMEMANAGEMENT, WORKETHIC}
public class SoftSkill_Template : MonoBehaviour
{
    protected string softSkill_ID = "";
    protected string nameSoftSkill = "";
    protected string description = "";
    protected bool isUnlock = false;
    protected int currentSoftSkillLevel;
    protected int softSkillArraySize;
    protected SoftSkillType softSkillType = SoftSkillType.NONE;

    #region Bonus Increasers
    public void UnLockSkill()
    {
        isUnlock = true;
    }
    public void UpSoftSkill()
    {
        if (currentSoftSkillLevel == 0)
        {
            UnLockSkill();
        }

        if (currentSoftSkillLevel < softSkillArraySize - 1)
        {
            SetSoftSkillLevel(currentSoftSkillLevel);
        }
        else
        {
            Debug.Log("soft Skill maxlevel");
        }
    }
    #endregion

    #region Bonus Reducers
    public void LockSkill()
    {
        isUnlock = false;
    }
    #endregion

    #region Reporter
    public string GetName()
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
    #endregion

    #region Must Override
    protected virtual void Initiate()
    {
        
    }

    protected virtual void SetSoftSkillLevel(int softSkillLevel)
    {

    }
    #endregion

    #region WrkEthic
    public virtual float GetTotalBONUS_goldenTimeReduceEnergyConsuption()
    {
        return -1f;
    }

    public virtual float GetTotalBONUS_goldenTimeBootUpMotivation()
    {
        return -1f;
    }
    public virtual float GetTotalBONUS_goldenTimeBootUpProject()
    {
        return -1f;
    }
    #endregion

    #region TimeManagement
    public virtual float GetTotalBONUS_reduceTimeTrainCourse()
    {
        return -1f;
    }
    #endregion

    #region Leadership
    public virtual float GetTotalBONUS_negativeEventsChance()
    {
        return -1f;
    }
    public virtual float GetTotalBONUS_negativeEventsEffect()
    {
        return -1f;
    }
    public virtual float GetTotalBONUS_positiveEventsEffect()
    {
        return -1f;
    }
    #endregion

    #region Communication
    public virtual float GetTotalBONUS_baseBootUpProject()
    {
        return -1f;
    }
    public virtual float GetTotalBONUS_charm()
    {
        return -1f;
    }
    #endregion

    #region CriticalThinking
    public virtual float GetTotalBONUS_baseBootUpMotivation()
    {
        return -1f;
    }
    public virtual float GetTotalBONUS_baseReduceEnergyConsumption()
    {
        return -1f;
    }
    public virtual float GetTotalBONUS_reduceBugChance()
    {
        return -1f;
    }
    #endregion
}
