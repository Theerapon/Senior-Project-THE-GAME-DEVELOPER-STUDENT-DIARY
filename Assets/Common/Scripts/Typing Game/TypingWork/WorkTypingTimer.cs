using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkTypingTimer : MonoBehaviour
{
    public Events.EventOnWorkTypingTimerUpdate OnworkTypingTimerUpdate;

    [SerializeField] private WorkTypingManager wordManager;
    [SerializeField] private WorkTypingPlayerManager playerManager;

    [SerializeField] private float maxWordDelay;
    [SerializeField] private float minWordDelay;
    [SerializeField] private float timeReduce;
    private float currentWordDelay;
    private const int TIMESCALE = 1;

    [Header("Time")]
    [SerializeField] private float maxTotalTime;
    private float gameTime;

    private const float maxtimeCoutDown = 3f;
    private float timeCountDown;
    private const float minTimeCountDown = 0;

    private float countSecondTime;
    private float cooldownGenerateBox;

    private void Awake()
    {
        playerManager.OnWorkTypingPlayerGeneratorBoxStateChange.AddListener(GeneratorBoxHandler);
    }

    private void Start()
    {
        currentWordDelay = maxWordDelay;
        wordManager.AddMainWordBox();
    }

    private void GeneratorBoxHandler()
    {
        UpdateBoxGeneratorphase(playerManager.CooldownToGenerate[(int)playerManager.ChancePhase]);
    }

    void Update()
    {

        switch (wordManager.GetTypingGameState)
        {
            case WorkTypingManager.TypingGameState.PreGame:
                timeCountDown -= Time.deltaTime * Time.timeScale;
                OnworkTypingTimerUpdate?.Invoke();
                if (timeCountDown <= minTimeCountDown)
                {
                    timeCountDown = maxtimeCoutDown;
                    wordManager.UpdateTypingGameState(WorkTypingManager.TypingGameState.Playing);
                }
                break;
            case WorkTypingManager.TypingGameState.Playing:
                OnworkTypingTimerUpdate?.Invoke();
                gameTime += Time.deltaTime * Time.timeScale;
                countSecondTime += Time.deltaTime * Time.timeScale;



                if (gameTime >= maxTotalTime)
                {
                    playerManager.TimeOut();
                    break;
                }

                if (playerManager.PlayerState == WorkTypingPlayerManager.WorkPlayerState.Alive)
                {
                    if (playerManager.PlayerState == WorkTypingPlayerManager.WorkPlayerState.Alive)
                    {
                        if (countSecondTime >= cooldownGenerateBox)
                        {
                            wordManager.AddRandomWordBox();
                            countSecondTime = 0;
                        }
                    }
                }
                break;
        }

    }

    public float GetWordTimeDelay()
    {
        return currentWordDelay;
    }

    public void ReduceWordTimeDelay()
    {
        currentWordDelay -= timeReduce;
        if(currentWordDelay < minWordDelay)
        {
            currentWordDelay = minWordDelay;
        }
    }

    public void IncreaseWordTimeDelay()
    {
        currentWordDelay += timeReduce;
        if (currentWordDelay > maxWordDelay)
        {
            currentWordDelay = maxWordDelay;
        }
    }

    public float GetTimeFillAmount()
    {
        return (float)gameTime / maxTotalTime;
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

    private void UpdateBoxGeneratorphase(float time)
    {
        cooldownGenerateBox = time;
        countSecondTime = time;
        Debug.Log("Cooltime = " + time);
    }
}
