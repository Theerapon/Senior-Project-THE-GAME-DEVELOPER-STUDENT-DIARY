using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalThinking : MonoBehaviour
{
    [SerializeField] private CriticalThinking_SO criticalThinking_SoftSkill_Template;
    private CriticalThinking_SO criticalThinking_SoftSkill_Current;

    void Start()
    {
        if (criticalThinking_SoftSkill_Template != null)
        {
            criticalThinking_SoftSkill_Current = Instantiate(criticalThinking_SoftSkill_Template);
        }
    }

    #region Bonus Increasers
    public void UnLockSkill()
    {
        criticalThinking_SoftSkill_Current.UnLockSkill();
    }
    public void UpSoftSkill()
    {
        criticalThinking_SoftSkill_Current.UpSoftSkill();
    }
    #endregion

    #region Bonus Reducers
    public void LockSkill()
    {
        criticalThinking_SoftSkill_Current.LockSkill();
    }
    #endregion

    #region Reporter
    public string GetName()
    {
        return criticalThinking_SoftSkill_Current.GetName();
    }
    public bool GetIsUnLock()
    {
        return criticalThinking_SoftSkill_Current.GetIsUnLock();
    }
    public int GetCurrentSoftSkillLevel()
    {
        return criticalThinking_SoftSkill_Current.GetCurrentSoftSkillLevel();
    }
    public SoftSkillType GetSoftSkillType()
    {
        return criticalThinking_SoftSkill_Current.GetSoftSkillType();
    }
    #endregion
    public float GetTotalBONUS_baseBootUpMotivation()
    {
        return criticalThinking_SoftSkill_Current.GetTotalBONUS_baseBootUpMotivation();
    }
    public float GetTotalBONUS_baseReduceEnergyConsumption()
    {
        return criticalThinking_SoftSkill_Current.GetTotalBONUS_baseReduceEnergyConsumption();
    }
    public float GetTotalBONUS_reduceBugChance()
    {
        return criticalThinking_SoftSkill_Current.GetTotalBONUS_reduceBugChance();
    }
}
