using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkill : MonoBehaviour
{
    private SoftSkill_Template definition;

    #region New Object
    public SoftSkill(SoftSkill_Template softSkillEntry)
    {
        definition = softSkillEntry;
    }

    #endregion

    #region Reporter
    public string GetSoftSkillDescription()
    {
        return definition.GetSoftSkillDescription();
    }
    public Sprite GetIconSoftSkill()
    {
        return definition.GetIconSoftSkill();
    }
    public string GetSoftSkillName()
    {
        return definition.GetSoftSkillName();
    }
    public bool GetIsUnLock()
    {
        return definition.GetIsUnLock();
    }
    public int GetCurrentSoftSkillLevel()
    {
        return definition.GetCurrentSoftSkillLevel();
    }
    public SoftSkillType GetSoftSkillType()
    {
        return definition.GetSoftSkillType();
    }
    #endregion

    #region Current
    public float GetTotalBONUS_baseBootUpProject()
    {
        return definition.GetTotalBONUS_baseBootUpProject();
    }
    public float GetTotalBONUS_charm()
    {
        return definition.GetTotalBONUS_charm();
    }
    public float GetTotalBONUS_baseBootUpMotivation()
    {
        return definition.GetTotalBONUS_baseBootUpMotivation();
    }
    public float GetTotalBONUS_baseReduceEnergyConsumption()
    {
        return definition.GetTotalBONUS_baseReduceEnergyConsumption();
    }
    public float GetTotalBONUS_reduceBugChance()
    {
        return definition.GetTotalBONUS_reduceBugChance();
    }
    public float GetTotalBONUS_negativeEventsEffect()
    {
        return definition.GetTotalBONUS_negativeEventsEffect();
    }
    public float GetTotalBONUS_positiveEventsEffect()
    {
        return definition.GetTotalBONUS_positiveEventsEffect();
    }
    public float GetTotalBONUS_reduceTimeTrainCourse()
    {
        return definition.GetTotalBONUS_reduceTimeTrainCourse();
    }
    public virtual float GetTotalBONUS_reduceTimeTransport()
    {
        return definition.GetTotalBONUS_reduceTimeTransport();
    }
    public float GetTotalBONUS_goldenTimeReduceEnergyConsuption()
    {
        return definition.GetTotalBONUS_goldenTimeReduceEnergyConsuption();
    }
    public float GetTotalBONUS_goldenTimeBootUpMotivation()
    {
        return definition.GetTotalBONUS_goldenTimeBootUpMotivation();
    }
    public float GetTotalBONUS_goldenTimeBootUpProject()
    {
        return definition.GetTotalBONUS_goldenTimeBootUpProject();
    }
    #endregion

    #region Next
    public virtual float GetNextBONUS_goldenTimeReduceEnergyConsuption()
    {
        return definition.GetNextBONUS_goldenTimeReduceEnergyConsuption();
    }

    public virtual float GetNextBONUS_goldenTimeBootUpMotivation()
    {
        return definition.GetNextBONUS_goldenTimeBootUpMotivation();
    }
    public virtual float GetNextBONUS_goldenTimeBootUpProject()
    {
        return definition.GetNextBONUS_goldenTimeBootUpProject();
    }
    public virtual float GetNextBONUS_reduceTimeTrainCourse()
    {
        return definition.GetNextBONUS_reduceTimeTrainCourse();
    }
    public virtual float GetNextBONUS_reduceTimeTransport()
    {
        return definition.GetNextBONUS_reduceTimeTransport();
    }
    public virtual float GetNextBONUS_negativeEventsEffect()
    {
        return definition.GetNextBONUS_negativeEventsEffect();
    }
    public virtual float GetNextBONUS_positiveEventsEffect()
    {
        return definition.GetNextBONUS_positiveEventsEffect();
    }
    public virtual float GetNextBONUS_baseBootUpProject()
    {
        return definition.GetNextBONUS_baseBootUpProject();
    }
    public virtual float GetNextBONUS_charm()
    {
        return definition.GetNextBONUS_charm();
    }
    public virtual float GetNextBONUS_baseBootUpMotivation()
    {
        return definition.GetNextBONUS_baseBootUpMotivation();
    }
    public virtual float GetNextBONUS_baseReduceEnergyConsumption()
    {
        return definition.GetNextBONUS_baseReduceEnergyConsumption();
    }
    public virtual float GetNextBONUS_reduceBugChance()
    {
        return definition.GetNextBONUS_reduceBugChance();
    }
    #endregion
}
