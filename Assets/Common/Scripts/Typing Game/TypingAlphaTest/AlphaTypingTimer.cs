using System;
using UnityEngine;

public class AlphaTypingTimer : MonoBehaviour
{
    public Events.EventOnAlphaTypingTimerUpdate OnAlphaTypingTimerUpdate;

    private AlphaTypingManager wordManager;

    [Header("Time")]
    [SerializeField] private float maxTotalTime = 60;
    [SerializeField] private float bonusTime = 30;
    private float gameTime;

    private const float maxtimeCoutDown = 3f;
    private float timeCountDown;
    private const float minTimeCountDown = 0;

    private const int TIME_SCALE = 1;

    [Header("Time Generator")]
    [SerializeField] private int totalTimeToFinishedGerator = 30;
    private float timeCountGenerator;
    private int amountGenerator;
    private float timeEachWordGenerated;

    private void Start()
    {
        timeCountDown = maxtimeCoutDown;
        wordManager = AlphaTypingManager.Instance;
        SetLevel();
    }

    void Update()
    {
        switch (wordManager.GetTypingGameState())
        {
            case AlphaTypingManager.TypingGameState.PreGame:
                timeCountDown -= Time.deltaTime * Time.timeScale;
                OnAlphaTypingTimerUpdate?.Invoke();
                if (timeCountDown <= minTimeCountDown)
                {
                    timeCountDown = maxtimeCoutDown;
                    wordManager.UpdateTypingGameState(AlphaTypingManager.TypingGameState.Playing);
                }
                break;
            case AlphaTypingManager.TypingGameState.Playing:
                OnAlphaTypingTimerUpdate?.Invoke();
                gameTime += Time.deltaTime * Time.timeScale;
                timeCountGenerator += Time.deltaTime * Time.timeScale;
                if(timeCountGenerator >= timeEachWordGenerated && amountGenerator > 0)
                {
                    GeneratedBox();
                    timeCountGenerator = 0;
                }

                break;
        }

        
    }

    public void PlaysGame()
    {
        Time.timeScale = TIME_SCALE;
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
        timeEachWordGenerated = (totalTimeToFinishedGerator / amountGenerator);
        timeCountGenerator = timeEachWordGenerated;
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
