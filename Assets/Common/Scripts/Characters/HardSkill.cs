using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkill : MonoBehaviour
{
    private HardSkill_Template hardSkill_current;

    public HardSkill() { }
    public HardSkill(HardSkill_Template hardSkill_Template)
    {
        hardSkill_current = hardSkill_Template;
    }


    #region Stat Increasers
    public virtual void GiveXP(int xp)
    {
        hardSkill_current.GiveXP(xp);
    }
    #endregion
    #region Reporter
    public Sprite GetIconHardSKill()
    {
        return hardSkill_current.GetIconHardSKill();
    }
    public virtual string GetHardSkillName()
    {
        return hardSkill_current.GetHardSkillName();
    }
    public string GetHardSkillID()
    {
        return hardSkill_current.GetHardSkillID();
    }
    public string GetHardSkillDescription()
    {
        return hardSkill_current.GetHardSkillDescription();
    }
    public int GetMaxLevelHardSkill()
    {
        return hardSkill_current.GetMaxLevelHardSkill();
    }
    public virtual int GetCurrentHardSkillLevel()
    {
        return hardSkill_current.GetCurrentHardSkillLevel();
    }
    public virtual int GetCurrentHardSkillEXP()
    {
        return hardSkill_current.GetCurrentHardSkillEXP();
    }
    public virtual int GetTotalBonusCoding()
    {
        return hardSkill_current.GetTotalBonusCoding();
    }
    public virtual int GetTotalBonusDesign()
    {
        return hardSkill_current.GetTotalBonusDesign();
    }
    public virtual int GetTotalBonusArt()
    {
        return hardSkill_current.GetTotalBonusArt();
    }
    public virtual int GetTotalBonusTesting()
    {
        return hardSkill_current.GetTotalBonusTesting();
    }
    public virtual int GetTotalBonusSound()
    {
        return hardSkill_current.GetTotalBonusSound();
    }
    public virtual HardSkillType GetHardSkillType()
    {
        return hardSkill_current.GetHardSkillType();
    }
    public int GetExpRequire()
    {
        return hardSkill_current.GetExpRequire();
    }
    public float GetExpFillAmount()
    {
        return hardSkill_current.GetExpFillAmount();
    }
    public HardSkill GetCopy()
    {
        return this;
    }
    #endregion
}
