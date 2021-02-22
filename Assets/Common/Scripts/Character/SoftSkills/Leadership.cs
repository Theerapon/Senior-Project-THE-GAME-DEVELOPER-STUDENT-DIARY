using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leadership : MonoBehaviour
{
    [SerializeField] private Leadership_SO leadership_SoftSkill_Template;
    private Leadership_SO leadership_SoftSkill_Current;

    void Start()
    {
        if (leadership_SoftSkill_Template != null)
        {
            leadership_SoftSkill_Current = Instantiate(leadership_SoftSkill_Template);
        }
    }

    #region Bonus Increasers
    public void UnLockSkill()
    {
        leadership_SoftSkill_Current.UnLockSkill();
    }
    public void UpSoftSkill()
    {
        leadership_SoftSkill_Current.UpSoftSkill();
    }
    #endregion

    #region Bonus Reducers
    public void LockSkill()
    {
        leadership_SoftSkill_Current.LockSkill();
    }
    #endregion

    #region Reporter
    public string GetName()
    {
        return leadership_SoftSkill_Current.GetName();
    }
    public bool GetIsUnLock()
    {
        return leadership_SoftSkill_Current.GetIsUnLock();
    }
    public int GetCurrentSoftSkillLevel()
    {
        return leadership_SoftSkill_Current.GetCurrentSoftSkillLevel();
    }
    public SoftSkillType GetSoftSkillType()
    {
        return leadership_SoftSkill_Current.GetSoftSkillType();
    }
    #endregion
    public float GetTotalBONUS_negativeEventsChance()
    {
        return leadership_SoftSkill_Current.GetTotalBONUS_negativeEventsChance();
    }
    public float GetTotalBONUS_negativeEventsEffect()
    {
        return leadership_SoftSkill_Current.GetTotalBONUS_negativeEventsEffect();
    }
    public float GetTotalBONUS_positiveEventsEffect()
    {
        return leadership_SoftSkill_Current.GetTotalBONUS_positiveEventsEffect();
    }
}
