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

    private int[] hpPhase = { 50000, 45000, 25000, 12500, 2500 };
    private int[] maxChangeGenerateBox = { 7500, 5000, 3000, 2000, 750 };
    private int maxHp;
    private int currentHp;
    private const int INST_TimeHealCooldown = 45;
    private float healCooldown;
    private bool canHeal;
    private int totalDamaged;
    private int maxBossState;

    private const int TIMESCALE = 1;

    public BossState GetBossState { get => bossState; }
    public int CurrentHp { get => currentHp; }
    public int[] MaxChangeGenerateBox { get => maxChangeGenerateBox; }
    public int TotalDamaged { get => totalDamaged; }
    public int MaxHp { get => maxHp; }

    protected override void Awake()
    {
        base.Awake();
        Initializing();
    }


    private void Initializing()
    {
        currentHp = hpPhase[0];
        maxHp = hpPhase[0];
        bossState = BossState.Phase1;
        healCooldown = 0f;
        totalDamaged = 0;
        maxBossState = 5;
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

        if ((int)bossState < maxBossState)
        {
            if (currentHp <= hpPhase[(int)bossState + 1])
            {
                UpdateBossState(bossState + 1);
            }
        }

        onBetaTypingBossUpdate?.Invoke();
    }

    public void Heal()
    {
        if (canHeal)
        {
            int heal = (int)(hpPhase[(int)bossState] * 0.08f);
            if(currentHp + heal >= maxHp)
            {
                currentHp = maxHp;
            }
            else
            {
                currentHp += heal;
            }
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

    private void UpdateBossState(BossState state)
    {
        bossState = state;
    }
}
