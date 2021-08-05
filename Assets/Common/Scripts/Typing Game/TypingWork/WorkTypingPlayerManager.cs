using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTypingPlayerManager : Manager<WorkTypingPlayerManager>
{
    public Events.EventOnWorkTypingPlayerStateChange OnWorkTypingPlayerStateChange;
    public Events.EventOnWorkTypingPlayerUpdate OnWorkTypingPlayerUpdate;
    public Events.EventOnWorkTypingPlayerGeneratorBoxStateChange OnWorkTypingPlayerGeneratorBoxStateChange;

    public enum WorkPlayerState
    {
        Alive,
        Timeout
    }
    private WorkPlayerState playerState;
    public enum WorkComboPhase : int
    {
        Phase1,
        Phase2,
        Phase3,
        Phase4,
        Phase5
    }
    private WorkComboPhase comboPhase;

    public enum WorkTypingChanceGenerator : int
    {
        Chance1,
        Changc2,
        Changc3,
        Changc4,
        Changc5,
    }
    private WorkTypingChanceGenerator chancePhase;

    private readonly int maxComboPhase = 5;
    private readonly int[] countCombo = { 0, 5, 12, 18, 25 };
    private readonly float[] comboScoreMultiplier = { 1f, 1.5f, 2.5f, 4f, 8f };
    private int minChanceGenerateBox = 0;
    private int[] countComboToGenerate = { 0, 25, 45, 55, 80};
    private int[] cooldownToGenerate = { 14, 12, 8, 6, 5 };
    private readonly float[] boxGenerateMultiply = { 1f, 1.5f, 2.2f, 2.8f, 4f };
    private readonly float normalBoxMultiply = 1f;
    private readonly int maxChanceGenerator = 5;

    #region Instace
    private const int INST_MultiplyScoreWordLength = 25;
    #endregion

    [Header("Work Typing")]
    [SerializeField] private WorkTypingManager typingManager;

    private int currentCombo;
    private int maxCombo;
    private int score;
    private int wordGoodIdea;
    private int wordBadIdea;
    private int totalCombo;

    public WorkPlayerState PlayerState { get => playerState; }
    public WorkComboPhase ComboPhase { get => comboPhase; }
    public int[] CountCombo { get => countCombo; }
    public float[] ComboDamageMultiplier { get => comboScoreMultiplier; }
    public int CurrentCombo { get => currentCombo; }
    public int MaxCombo { get => maxCombo; }
    public int Score { get => score; }
    public int WordGoodIdea { get => wordGoodIdea; }
    public int WordBadIdea { get => wordBadIdea; }

    public int MaxComboPhase => maxComboPhase;

    public WorkTypingChanceGenerator ChancePhase { get => chancePhase;}
    public int MinChanceGenerateBox { get => minChanceGenerateBox; }

    public int MaxChanceGenerator => maxChanceGenerator;

    public float[] BoxGenerateMultiplier { get => boxGenerateMultiply; }

    public float NormalBoxMultiply => normalBoxMultiply;

    public int[] CountComboToGenerate { get => countComboToGenerate; }
    public int[] CooldownToGenerate { get => cooldownToGenerate; }

    protected override void Awake()
    {
        base.Awake();
        Initailzing();
    }

    private void Initailzing()
    {
        totalCombo = 0;
        score = 0;
        currentCombo = 0;
        maxCombo = currentCombo;
        wordGoodIdea = 0;
        wordBadIdea = 0;
        UpdatePlayerState(WorkPlayerState.Alive);
        UpdateComboPhase(WorkComboPhase.Phase1);
        UpdateChangeState(WorkTypingChanceGenerator.Chance1);
    }
    private void IncreaseCombo()
    {
        totalCombo++;
        currentCombo++;
        if (currentCombo > maxCombo)
        {
            maxCombo = currentCombo;
        }

        if ((int)comboPhase < maxComboPhase - 1)
        {
            if (currentCombo >= countCombo[(int)comboPhase + 1])
            {
                UpdateComboPhase(comboPhase + 1);
            }
        }

        if((int)chancePhase < maxChanceGenerator - 1)
        {
            if(totalCombo >= countComboToGenerate[(int)chancePhase + 1])
            {
                UpdateChangeState(chancePhase + 1);
            }
        }

        OnWorkTypingPlayerUpdate?.Invoke();
    }
    public void TakeDamage()
    {
        ReduceCombo();
    }

    private void IncreaseGoodIdea()
    {
        wordGoodIdea++;
        OnWorkTypingPlayerUpdate?.Invoke();
    }

    public void IncreaseBadIdea()
    {
        wordBadIdea++;
        OnWorkTypingPlayerUpdate?.Invoke();
    }

    public void ReduceCombo()
    {
        currentCombo = 0;
        UpdateComboPhase(WorkComboPhase.Phase1);
    }


    public void TimeOut()
    {
        UpdatePlayerState(WorkPlayerState.Timeout);
    }

    private void UpdateComboPhase(WorkComboPhase phase)
    {
        comboPhase = phase;
        OnWorkTypingPlayerUpdate?.Invoke();
    }

    private void UpdatePlayerState(WorkPlayerState state)
    {
        playerState = state;
        OnWorkTypingPlayerUpdate?.Invoke();
        OnWorkTypingPlayerStateChange?.Invoke(playerState);
    }

    public void UpdateChangeState(WorkTypingChanceGenerator state)
    {
        chancePhase = state;
        OnWorkTypingPlayerGeneratorBoxStateChange?.Invoke();
    }

    public bool HasAlive()
    {
        return WorkPlayerState.Alive == playerState;
    }

    public void IncreaseScore(int score, int wordLength, float multiply)
    {
        int thisScore = (int)(score * (int)(comboScoreMultiplier[(int)comboPhase]) * multiply) + (wordLength * INST_MultiplyScoreWordLength);
        this.score += thisScore;
        IncreaseGoodIdea();
        IncreaseCombo();
        OnWorkTypingPlayerUpdate?.Invoke();
    }
}
