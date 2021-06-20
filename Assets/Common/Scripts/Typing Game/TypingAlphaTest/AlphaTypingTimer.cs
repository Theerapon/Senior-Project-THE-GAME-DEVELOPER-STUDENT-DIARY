using System;
using UnityEngine;

public class AlphaTypingTimer : MonoBehaviour
{
    public Events.EventOnAlphaTypingTimerUpdate OnAlphaTypingTimerUpdate;

    [SerializeField] private AlphaTypingManager wordManager;
    [SerializeField] private AlphaTypingPlayerManager playerManager;

    [Header("Time")]
    [SerializeField] private float maxTotalTime = 60;
    [SerializeField] private float bonusTime = 30;
    private float gameTime;
    private bool canPlaying;

    private const float maxtimeCoutDown = 3f;
    private float timeCountDown;
    private const float minTimeCountDown = 0;

    private const int TIME_SCALE = 1;

    [Header("Time Generator")]
    [SerializeField] private int totalTimeToFinishedGerator = 30;
    private float timeCountGenerator;
    private int amountGenerator;

    private readonly float[] cooldown = { 1f, 1f, 1f, 1.25f, 1.35f, 1.45f, 1.5f, 1.60f, 1.65f, 1.75f, };

    private void Start()
    {
        timeCountGenerator = cooldown[0];
        canPlaying = false;
        timeCountDown = maxtimeCoutDown;
        SetLevel();
    }

    void Update()
    {
        switch (wordManager.GetTypingGameState())
        {
            case AlphaTypingManager.TypingGameState.PreGame:
                if (canPlaying)
                {
                    timeCountDown -= Time.deltaTime * Time.timeScale;
                    OnAlphaTypingTimerUpdate?.Invoke();
                    if (timeCountDown <= minTimeCountDown)
                    {
                        timeCountDown = maxtimeCoutDown;
                        wordManager.UpdateTypingGameState(AlphaTypingManager.TypingGameState.Playing);
                    }    
                }
                break;
            case AlphaTypingManager.TypingGameState.Playing:
                OnAlphaTypingTimerUpdate?.Invoke();
                gameTime += Time.deltaTime * Time.timeScale;

                if (gameTime >= maxTotalTime)
                {
                    playerManager.TimeOut();
                    break;
                }

                if (playerManager.PlayerState == AlphaTypingPlayerManager.AlphaPlayerState.Alive)
                {
                    
                    timeCountGenerator += Time.deltaTime * Time.timeScale;
                    if (timeCountGenerator >= cooldown[wordManager.CurrentLevel] && amountGenerator > 0)
                    {
                        GeneratedBox();
                        timeCountGenerator = 0;
                    }

                }
                break;
        }

        
    }

    public void PlaysGame()
    {
        canPlaying = true;
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
        return (float) gameTime / maxTotalTime;
    }

    private void SetLevel()
    {
        amountGenerator = wordManager.GetAmountTypingLevel();
    }

    public int GetAmountGenerator()
    {
        return amountGenerator;
    }

    public void GeneratedBox()
    {
        amountGenerator--;
        wordManager.AddWordBox();
    }

    public void LevelUp()
    {
        maxTotalTime += bonusTime;
        wordManager.TypingLevelUp();
        SetLevel();
    }
}
