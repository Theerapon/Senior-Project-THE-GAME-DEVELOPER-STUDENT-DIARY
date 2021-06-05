using System.Collections.Generic;
using UnityEngine;

public class BonusDetails_DataHandler : DataHandler
{
    protected Dictionary<string, Bonus_Template> bonus_dic;
    [SerializeField] private BonusDetailsVM bonusDetailsVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public Dictionary<string, Bonus_Template> GetBonusDic
    {
        get { return bonus_dic; }
    }

    protected void Awake()
    {
        bonus_dic = new Dictionary<string, Bonus_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }


    private void EventInterpretHandler()
    {
        bonus_dic = bonusDetailsVM.Interpert();
        if (!ReferenceEquals(bonus_dic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("BonusDetail interpret completed");
        //foreach (KeyValuePair<string, Bonus_Template> bonus in bonus_dic)
        //{
        //    Debug.Log(string.Format("ID = {0}, id = {1}, name = {2}", bonus.Key, bonus.Value.BonusID, bonus.Value.BonusName));
        //}
    }

}
