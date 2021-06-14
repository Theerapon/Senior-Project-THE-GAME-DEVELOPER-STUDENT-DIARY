using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaTypingPlayerManager : Manager<AlphaTypingPlayerManager>
{
    public Events.EventOnAlphaTypingPlayerStateChange OnAlphaTypingPlayerStateChange;
    public Events.EventOnAlphaTypingPlayerUpdate OnAlphaTypingPlayerUpdate;

    public enum AlphaPlayerState
    {
        Alive,
        Dead,
        Timeout
    }
    private AlphaPlayerState playerState;

    public enum AlphaComboPhase : int
    {
        Phase1,
        Phase2,
        Phase3,
        Phase4,
        Phase5
    }
    private AlphaComboPhase comboPhase;
    private readonly int maxComboPhase = 5;
    private int[] countCombo = { 0, 14, 25, 50, 75 };
    private float[] comboDamageMultiplier = { 1f, 1.5f, 2.5f, 4f, 8f };

    #region Instace
    private const int INST_LIFE = 3;
    private const int INST_MultiplyScoreWordLength = 25;
    #endregion

    [Header("Alpha Typing")]
    [SerializeField] private AlphaTypingManager alphaTypingManager;

    private int life;
    private int currentCombo;
    private int maxCombo;
    private int score;

    public int Life { get => life; }
    public int CurrentCombo { get => currentCombo; }
    public int MaxCombo { get => maxCombo; }
    public int Score { get => score; }
    public AlphaPlayerState PlayerState { get => playerState; }
    public AlphaComboPhase ComboPhase { get => comboPhase; }

    public int MaxComboPhase => maxComboPhase;

    public int[] CountCombo { get => countCombo; }

    protected override void Awake()
    {
        base.Awake();
        Initailzing();
    }

    private void Initailzing()
    {
        life = INST_LIFE;
        score = 0;
        currentCombo = 0;
        maxCombo = currentCombo;
        UpdatePlayerState(AlphaPlayerState.Alive);
        UpdateComboPhase(AlphaComboPhase.Phase1);
    }

    public void IncreaseCombo()
    {
        currentCombo++;
        if (currentCombo > maxCombo)
        {
            maxCombo = currentCombo;
        }

        if ((int)comboPhase < maxComboPhase)
        {
            if (currentCombo >= countCombo[(int)comboPhase + 1])
            {
                UpdateComboPhase(comboPhase + 1);
            }
        }

        OnAlphaTypingPlayerUpdate?.Invoke();
    }

    private void UpdateComboPhase(AlphaComboPhase phase)
    {
        comboPhase = phase;
        OnAlphaTypingPlayerUpdate?.Invoke();
    }

    public void TakeDamage()
    {
        if (life - 1 <= 0)
        {
            life = 0;
            UpdatePlayerState(AlphaPlayerState.Dead);
        }
        else
        {
            life--;
        }
        ReduceCombo();
    }

    public void ReduceCombo()
    {
        currentCombo = 0;
        UpdateComboPhase(AlphaComboPhase.Phase1);
    }


    public void TimeOut()
    {
        UpdatePlayerState(AlphaPlayerState.Timeout);
    }

    private void UpdatePlayerState(AlphaPlayerState state)
    {
        playerState = state;
        OnAlphaTypingPlayerUpdate?.Invoke();
        OnAlphaTypingPlayerStateChange?.Invoke(playerState);

    }

    public bool HasAlive()
    {
        return AlphaPlayerState.Alive == playerState;
    }

    public void IncreaseScore(int score, int wordLength)
    {
        this.score += score * (int)(comboDamageMultiplier[(int)comboPhase]) + (wordLength * INST_MultiplyScoreWordLength);
        OnAlphaTypingPlayerUpdate?.Invoke();
    }
}
