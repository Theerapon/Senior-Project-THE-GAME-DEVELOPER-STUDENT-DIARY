using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoftSkillType { NONE, COMMUNICATION, CRITICALTHINKING, LEADERSHIP, TIMEMANAGEMENT, WORKETHIC}
public class SoftSkill_SO : ScriptableObject
{
    [SerializeField] protected string nameSoftSkill = "";
    protected bool isUnlock = false;
    protected int currentSoftSkillLevel;


    [SerializeField] private SoftSkillType softSkillType = SoftSkillType.NONE;

    #region Bonus Increasers
    public void UnLockSkill()
    {
        isUnlock = true;
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

    #region EXP
    protected virtual void SetSoftSkillLevel(int softSkillLevel)
    {

    }
    #endregion
}
