using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkill : MonoBehaviour
{
    private SoftSkill_Template softSkill_Current;

    #region New Object

    public SoftSkill() { }

    public SoftSkill(Communication_Template softSkill_Template)
    {
        softSkill_Current = softSkill_Template;

    }
    public SoftSkill(CriticalThinking_Template softSkill_Template)
    {
        softSkill_Current = softSkill_Template;

    }
    public SoftSkill(TimeManagement_Template softSkill_Template)
    {
        softSkill_Current = softSkill_Template;

    }
    public SoftSkill(Leadership_Template softSkill_Template)
    {
        softSkill_Current = softSkill_Template;

    }
    public SoftSkill(WorkEthic_Template softSkill_Template)
    {
        softSkill_Current = softSkill_Template;

    }
    #endregion

    #region Bonus Increasers
    public void UnLockSkill()
    {
        softSkill_Current.UnLockSkill();
    }
    public void UpSoftSkill()
    {
        softSkill_Current.UpSoftSkill();
    }
    #endregion

    #region Bonus Reducers
    public void LockSkill()
    {
        softSkill_Current.LockSkill();
    }
    #endregion

    #region Reporter
    public string GetSoftSkillDescription()
    {
        return softSkill_Current.GetSoftSkillDescription();
    }
    public Sprite GetIconSoftSkill()
    {
        return softSkill_Current.GetIconSoftSkill();
    }
    public string GetSoftSkillName()
    {
        return softSkill_Current.GetSoftSkillName();
    }
    public bool GetIsUnLock()
    {
        return softSkill_Current.GetIsUnLock();
    }
    public int GetCurrentSoftSkillLevel()
    {
        return softSkill_Current.GetCurrentSoftSkillLevel();
    }
    public SoftSkillType GetSoftSkillType()
    {
        return softSkill_Current.GetSoftSkillType();
    }
    #endregion

    #region Current
    public float GetTotalBONUS_baseBootUpProject()
    {
        return softSkill_Current.GetTotalBONUS_baseBootUpProject();
    }
    public float GetTotalBONUS_charm()
    {
        return softSkill_Current.GetTotalBONUS_charm();
    }
    public float GetTotalBONUS_baseBootUpMotivation()
    {
        return softSkill_Current.GetTotalBONUS_baseBootUpMotivation();
    }
    public float GetTotalBONUS_baseReduceEnergyConsumption()
    {
        return softSkill_Current.GetTotalBONUS_baseReduceEnergyConsumption();
    }
    public float GetTotalBONUS_reduceBugChance()
    {
        return softSkill_Current.GetTotalBONUS_reduceBugChance();
    }
    public float GetTotalBONUS_negativeEventsEffect()
    {
        return softSkill_Current.GetTotalBONUS_negativeEventsEffect();
    }
    public float GetTotalBONUS_positiveEventsEffect()
    {
        return softSkill_Current.GetTotalBONUS_positiveEventsEffect();
    }
    public float GetTotalBONUS_reduceTimeTrainCourse()
    {
        return softSkill_Current.GetTotalBONUS_reduceTimeTrainCourse();
    }
    public virtual float GetTotalBONUS_reduceTimeTransport()
    {
        return softSkill_Current.GetTotalBONUS_reduceTimeTransport();
    }
    public float GetTotalBONUS_goldenTimeReduceEnergyConsuption()
    {
        return softSkill_Current.GetTotalBONUS_goldenTimeReduceEnergyConsuption();
    }
    public float GetTotalBONUS_goldenTimeBootUpMotivation()
    {
        return softSkill_Current.GetTotalBONUS_goldenTimeBootUpMotivation();
    }
    public float GetTotalBONUS_goldenTimeBootUpProject()
    {
        return softSkill_Current.GetTotalBONUS_goldenTimeBootUpProject();
    }
    #endregion

    #region Next
    public virtual float GetNextBONUS_goldenTimeReduceEnergyConsuption()
    {
        return softSkill_Current.GetNextBONUS_goldenTimeReduceEnergyConsuption();
    }

    public virtual float GetNextBONUS_goldenTimeBootUpMotivation()
    {
        return softSkill_Current.GetNextBONUS_goldenTimeBootUpMotivation();
    }
    public virtual float GetNextBONUS_goldenTimeBootUpProject()
    {
        return softSkill_Current.GetNextBONUS_goldenTimeBootUpProject();
    }
    public virtual float GetNextBONUS_reduceTimeTrainCourse()
    {
        return softSkill_Current.GetNextBONUS_reduceTimeTrainCourse();
    }
    public virtual float GetNextBONUS_reduceTimeTransport()
    {
        return softSkill_Current.GetNextBONUS_reduceTimeTransport();
    }
    public virtual float GetNextBONUS_negativeEventsEffect()
    {
        return softSkill_Current.GetNextBONUS_negativeEventsEffect();
    }
    public virtual float GetNextBONUS_positiveEventsEffect()
    {
        return softSkill_Current.GetNextBONUS_positiveEventsEffect();
    }
    public virtual float GetNextBONUS_baseBootUpProject()
    {
        return softSkill_Current.GetNextBONUS_baseBootUpProject();
    }
    public virtual float GetNextBONUS_charm()
    {
        return softSkill_Current.GetNextBONUS_charm();
    }
    public virtual float GetNextBONUS_baseBootUpMotivation()
    {
        return softSkill_Current.GetNextBONUS_baseBootUpMotivation();
    }
    public virtual float GetNextBONUS_baseReduceEnergyConsumption()
    {
        return softSkill_Current.GetNextBONUS_baseReduceEnergyConsumption();
    }
    public virtual float GetNextBONUS_reduceBugChance()
    {
        return softSkill_Current.GetNextBONUS_reduceBugChance();
    }
    #endregion
}
