using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDetails_Handler : Manager<BonusDetails_Handler>
{
    protected Dictionary<string, Bonus> bonus_dic;
    private BonusDetailsVM bonusDetailsVM;

    bool loaded = false;

    public Dictionary<string, Bonus> BonusDic
    {
        get { return bonus_dic; }
    }

    protected override void Awake()
    {
        base.Awake();
        bonus_dic = new Dictionary<string, Bonus>();
    }
    private void Start()
    {
        bonusDetailsVM = FindObjectOfType<BonusDetailsVM>();
        loaded = false;

    }
    private void Update()
    {
        if (!loaded)
        {
            bonus_dic = bonusDetailsVM.Interpert();
            loaded = true;
        }

    }
}
