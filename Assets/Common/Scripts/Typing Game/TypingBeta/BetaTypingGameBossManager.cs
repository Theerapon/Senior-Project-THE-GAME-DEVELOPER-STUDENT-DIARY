using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingGameBossManager : Manager<BetaTypingGameBossManager>
{
    public Events.EventOnBetaTypingBossUpdate onBetaTypingBossUpdate;
    public Events.EventOnBetaTypingBossStateChange OnBetaTypingBossStateChange;

    public enum BossState : int
    {
        Phase0,
        Phase1,
        Phase2,
        Phase3,
        Phase4,
        Weekness,
        Dead,
    }
    private BossState bossState;

    #region Instace
    private int[] hpPhase = { 50000, 45000, 25000, 12500, 2500 };
    private float[] cooldownChangeMonsterGenerator = { 6f, 4f, 2.5f, 1.5f, 0.75f };
    private const int INST_CountMonsterToUseHeal = 4;
    private const int INST_TimeHealCooldown = 15;
    #endregion
    private int maxHp;
    private int currentHp;
    private float healCooldown;
    private bool canHeal;
    private int totalDamaged;
    private int maxBossState;
    private float recieveDamageMultiply;
    private int countMonsterDead;

    private const int TIMESCALE = 1;

    public BossState GetBossState { get => bossState; }
    public int CurrentHp { get => currentHp; }
    public float[] MaxCooldownChangeMonsterGenerator { get => cooldownChangeMonsterGenerator; }
    public int TotalDamaged { get => totalDamaged; }
    public int MaxHp { get => maxHp; }

    protected override void Awake()
    {
        base.Awake();
        Initializing();
    }

    private void Start()
    {
        
    }

    private void Initializing()
    {
        currentHp = hpPhase[0];
        maxHp = hpPhase[0];
        UpdateBossState(BossState.Phase0);
        healCooldown = 0f;
        totalDamaged = 0;
        maxBossState = 5;
        recieveDamageMultiply = 1f;
        canHeal = true;
    }

    private void Update()
    {
        if(bossState != BossState.Weekness && bossState != BossState.Dead)
        {
            CooldownHealSkill();
        }
    }

    public void TakeDamaged(int damaged)
    {
        int damagedRecieve = (int)(damaged * recieveDamageMultiply);
        totalDamaged += damagedRecieve;

        if(bossState != BossState.Weekness && bossState != BossState.Dead)
        {
            if (currentHp - damaged <= 0)
            {
                currentHp = 0;
                UpdateBossState(BossState.Weekness);
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
        }

        onBetaTypingBossUpdate?.Invoke();
    }

    public void Dead()
    {
        if(currentHp <= 0)
            UpdateBossState(BossState.Dead);
    }

    public bool Heal()
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
            Debug.Log("headl = " + heal);
            canHeal = false;
            healCooldown = INST_TimeHealCooldown;
            onBetaTypingBossUpdate?.Invoke();
            return true;
        }
        return false;

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
        if(bossState == BossState.Weekness)
        {
            recieveDamageMultiply = 2.5f;
        }
        OnBetaTypingBossStateChange?.Invoke(bossState);
    }

    public void MonsterDead()
    {
        countMonsterDead++;
        if(countMonsterDead >= INST_CountMonsterToUseHeal)
        {
            if (Heal())
            {
                countMonsterDead = 0;
            }
        }
    }
}
