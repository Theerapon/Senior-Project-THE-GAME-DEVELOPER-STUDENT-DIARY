using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingTimer : MonoBehaviour
{
    public Events.EventOnBetaTypingTimerUpdate OnBetaTypingTimerUpdate;

    [SerializeField] private BetaTypingGameBossManager bossManager;
    [SerializeField] private BetaTypingManager wordManager;
    [SerializeField] private BetaTypingPlayerManager playerManager;

    [Header("Time")]
    [SerializeField] private float maxTotalTime = 60;
    private float gameTime;
    private float countSecondTime;
    private float cooldownGenerateMonster;

    private int minChangeGenerateBox = 0;
    private const int TIMESCALE = 1;

    private const float maxtimeCoutDown = 3f;
    private float timeCountDown;
    private const float minTimeCountDown = 0;

    public float MaxTotalTime { get => maxTotalTime; }

    private void Awake()
    {
        bossManager.OnBetaTypingBossStateChange.AddListener(BossStateChangeHandler);
    }

    private void Start()
    {
        timeCountDown = maxtimeCoutDown;
    }

    private void BossStateChangeHandler(BetaTypingGameBossManager.BossState state)
    {
        if(state != BetaTypingGameBossManager.BossState.Dead && state != BetaTypingGameBossManager.BossState.Weekness)
        {
            UpdateMonsterGeneratorphase(bossManager.MaxCooldownChangeMonsterGenerator[(int)state]);
        }
    }

    void Update()
    {
        switch (wordManager.GetTypingGameState())
        {
            case BetaTypingManager.TypingGameState.PreGame:
                timeCountDown -= Time.deltaTime * Time.timeScale;
                OnBetaTypingTimerUpdate?.Invoke();
                if (timeCountDown <= minTimeCountDown)
                {
                    timeCountDown = maxtimeCoutDown;
                    wordManager.UpdateTypingGameState(BetaTypingManager.TypingGameState.Playing);
                    wordManager.AddBossWordBox();
                    wordManager.AddMonsterWordBox();
                }
                break;
            case BetaTypingManager.TypingGameState.Playing:
                gameTime += Time.deltaTime * Time.timeScale;
                countSecondTime += Time.deltaTime * Time.timeScale;
                OnBetaTypingTimerUpdate?.Invoke();

                if(bossManager.GetBossState != BetaTypingGameBossManager.BossState.Dead && bossManager.GetBossState != BetaTypingGameBossManager.BossState.Weekness)
                {
                    if (gameTime >= maxTotalTime)
                    {
                        playerManager.GameOver();
                        break;
                    }

                    if(countSecondTime >= cooldownGenerateMonster)
                    {
                        wordManager.AddMonsterWordBox();
                        countSecondTime = 0;
                    }

                }
                else
                {
                    if(bossManager.GetBossState == BetaTypingGameBossManager.BossState.Weekness)
                    {
                        if (gameTime >= maxTotalTime)
                        {
                            bossManager.Dead();
                            break;
                        }
                    }
                }                

                break;
        }
    }

    public void PlaysGame()
    {
        Time.timeScale = TIMESCALE;
    }

    public string GetTimeCountDown()
    {
        int time = (int)timeCountDown;
        string str = "";
        if (time == 0)
        {
            str = "START";
        }
        else
        {
            str = time.ToString().ToUpper();
        }

        return str;
    }
    public float GetTimeFillAmount()
    {
        return (float)gameTime / maxTotalTime;
    }

    private void UpdateMonsterGeneratorphase(float time)
    {
        cooldownGenerateMonster = time;
    }

    public void ReduceGameTime(int second)
    {
        gameTime -= second;
    }
}
