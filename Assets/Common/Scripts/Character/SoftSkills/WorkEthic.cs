using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkEthic : MonoBehaviour
{
    [SerializeField] private WorkEthic_SO workEthic_SoftSkill_Template;
    private WorkEthic_SO workEthic_SoftSkill_Current;
    void Start()
    {
        if (workEthic_SoftSkill_Template != null)
        {
            workEthic_SoftSkill_Current = Instantiate(workEthic_SoftSkill_Template);
        }
    }

    #region Bonus Increasers
    public void UnLockSkill()
    {
        workEthic_SoftSkill_Current.UnLockSkill();
    }
    public void UpSoftSkill()
    {
        workEthic_SoftSkill_Current.UpSoftSkill();
    }
    #endregion

    #region Bonus Reducers
    public void LockSkill()
    {
        workEthic_SoftSkill_Current.LockSkill();
    }
    #endregion

    #region Reporter
    public string GetName()
    {
        return workEthic_SoftSkill_Current.GetName();
    }
    public bool GetIsUnLock()
    {
        return workEthic_SoftSkill_Current.GetIsUnLock();
    }
    public int GetCurrentSoftSkillLevel()
    {
        return workEthic_SoftSkill_Current.GetCurrentSoftSkillLevel();
    }
    public SoftSkillType GetSoftSkillType()
    {
        return workEthic_SoftSkill_Current.GetSoftSkillType();
    }
    #endregion

    public float GetTotalBONUS_goldenTimeReduceEnergyConsuption()
    {
        return workEthic_SoftSkill_Current.GetTotalBONUS_goldenTimeReduceEnergyConsuption();
    }
    public float GetTotalBONUS_goldenTimeBootUpMotivation()
    {
        return workEthic_SoftSkill_Current.GetTotalBONUS_goldenTimeBootUpMotivation();
    }
    public float GetTotalBONUS_goldenTimeBootUpProject()
    {
        return workEthic_SoftSkill_Current.GetTotalBONUS_goldenTimeBootUpProject();
    }

}
