using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagement : MonoBehaviour
{
    [SerializeField] private TimeManagement_SO time_SoftSkill_Template;
    private TimeManagement_SO time_SoftSkill_Current;
    // Start is called before the first frame update
    void Start()
    {
        if (time_SoftSkill_Template != null)
        {
            time_SoftSkill_Current = Instantiate(time_SoftSkill_Template);
        }
    }

    #region Bonus Increasers
    public void UnLockSkill()
    {
        time_SoftSkill_Current.UnLockSkill();
    }
    public void UpSoftSkill()
    {
        time_SoftSkill_Current.UpSoftSkill();
    }
    #endregion

    #region Bonus Reducers
    public void LockSkill()
    {
        time_SoftSkill_Current.LockSkill();
    }
    #endregion

    #region Reporter
    public string GetName()
    {
        return time_SoftSkill_Current.GetName();
    }
    public bool GetIsUnLock()
    {
        return time_SoftSkill_Current.GetIsUnLock();
    }
    public int GetCurrentSoftSkillLevel()
    {
        return time_SoftSkill_Current.GetCurrentSoftSkillLevel();
    }
    public SoftSkillType GetSoftSkillType()
    {
        return time_SoftSkill_Current.GetSoftSkillType();
    }
    #endregion
    public float GetTotalBONUS_reduceTimeSleeping()
    {
        return time_SoftSkill_Current.GetTotalBONUS_reduceTimeSleeping();
    }
    public float GetTotalBONUS_reduceTimeReadBook()
    {
        return time_SoftSkill_Current.GetTotalBONUS_reduceTimeReadBook();
    }
    public float GetTotalBONUS_reduceTimeTrainCourse()
    {
        return time_SoftSkill_Current.GetTotalBONUS_reduceTimeTrainCourse();
    }
}
