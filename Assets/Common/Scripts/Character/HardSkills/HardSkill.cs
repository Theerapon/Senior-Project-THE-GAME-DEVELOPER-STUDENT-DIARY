using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkill : MonoBehaviour
{
    protected HardSkill_SO hardSkill_current;
    [SerializeField] private HardSkill_SO hardSkill_Template;

    void Start()
    {
        if (hardSkill_Template != null)
        {
            hardSkill_current = Instantiate(hardSkill_Template);
        }
    }

    #region Stat Increasers
    public virtual void GiveXP(int xp)
    {
        hardSkill_current.GiveXP(xp);
    }
    #endregion
    #region Reporter
    public virtual string GetHardSkillName()
    {
        return hardSkill_current.GetHardSkillName();
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
    public virtual int GetTotalBonusAudio()
    {
        return hardSkill_current.GetTotalBonusAudio();
    }
    public virtual HardSkillType GetHardSkillType()
    {
        return hardSkill_current.GetHardSkillType();
    }
    #endregion
}
