using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Communication : MonoBehaviour
{
    [SerializeField] private Communication_SO communication_SoftSkill_Template;
    private Communication_SO communication_SoftSkill_Current;

    void Start()
    {
        if (communication_SoftSkill_Template != null)
        {
            communication_SoftSkill_Current = Instantiate(communication_SoftSkill_Template);
        }
    }
    #region Bonus Increasers
    public void UnLockSkill()
    {
        communication_SoftSkill_Current.UnLockSkill();
    }
    public void UpSoftSkill()
    {
        communication_SoftSkill_Current.UpSoftSkill();
    }
    #endregion

    #region Bonus Reducers
    public void LockSkill()
    {
        communication_SoftSkill_Current.LockSkill();
    }
    #endregion

    #region Reporter
    public string GetName()
    {
        return communication_SoftSkill_Current.GetName();
    }
    public bool GetIsUnLock()
    {
        return communication_SoftSkill_Current.GetIsUnLock();
    }
    public int GetCurrentSoftSkillLevel()
    {
        return communication_SoftSkill_Current.GetCurrentSoftSkillLevel();
    }
    public SoftSkillType GetSoftSkillType()
    {
        return communication_SoftSkill_Current.GetSoftSkillType();
    }
    #endregion

    public float GetTotalBONUS_baseBootUpProject()
    {
        return communication_SoftSkill_Current.GetTotalBONUS_baseBootUpProject();
    }
    public float GetTotalBONUS_charm()
    {
        return communication_SoftSkill_Current.GetTotalBONUS_charm();
    }
}
