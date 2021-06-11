using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : Manager<BossManager>
{
    public Events.EventOnBetaTypingBossUpdate onBetaTypingBossUpdate;

    public enum BossState : int
    {
        Phase1,
        Phase2,
        Phase3,
        Phase4,
        Phase5
    }
    private BossState bossState;

    private int[] maxHp = { 50000, 37500, 25000, 12500, 2500 };
    private int[] maxChangeGenerateBox = { 7500, 5000, 3000, 2000, 750 };
    private int currentHp;
    private const int INST_TimeHealCooldown = 45;
    private float healCooldown;
    private bool canHeal;
    private int totalDamaged;

    private const int TIMESCALE = 1;

    public BossState GetBossState { get => bossState; }
    public int CurrentHp { get => currentHp; }
    public int[] MaxChangeGenerateBox { get => maxChangeGenerateBox; }
    public int TotalDamaged { get => totalDamaged; }

    protected override void Awake()
    {
        base.Awake();
        Initializing();
    }


    private void Initializing()
    {
        currentHp = maxHp[0];
        bossState = BossState.Phase1;
        healCooldown = 0f;
        totalDamaged = 0;
        canHeal = true;
    }

    private void Update()
    {
        CooldownHealSkill();
    }

    public void TakeDamaged(int damaged)
    {
        totalDamaged += damaged;

        if (currentHp - damaged <= 0)
        {
            currentHp = 0;
        }
        else
        {
            currentHp -= damaged;
        }

        if(currentHp <= maxHp[1])
        {
            bossState = BossState.Phase2;
        }
        else if(currentHp <= maxHp[2])
        {
            bossState = BossState.Phase3;
        }
        else if(currentHp <= maxHp[3])
        {
            bossState = BossState.Phase4;
        }
        else if (currentHp <= maxHp[4])
        {
            bossState = BossState.Phase5;
        }
        onBetaTypingBossUpdate?.Invoke();
    }

    public void Heal()
    {
        if (canHeal)
        {
            currentHp += (int)(maxHp[(int)bossState] * 0.08f);
            canHeal = false;
            healCooldown = INST_TimeHealCooldown;
        }
        onBetaTypingBossUpdate?.Invoke();

    }

    private void CooldownHealSkill()
    {
        if (healCooldown > 0f && !canHeal)
        {
            healCooldown -= Time.deltaTime * TIMESCALE;
            if (healCooldown < 0)
            {
                canHeal = true;
            }
        }
    }
}
