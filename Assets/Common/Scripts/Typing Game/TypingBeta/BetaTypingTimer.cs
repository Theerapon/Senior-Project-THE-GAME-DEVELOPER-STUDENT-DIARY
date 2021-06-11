using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetaTypingTimer : MonoBehaviour
{
    public Events.EventOnBetaTypingTimerUpdate OnBetaTypingTimerUpdate;

    [SerializeField] private BossManager bossManager;
    [SerializeField] private BetaTypingManager wordManager;

    [Header("Time")]
    [SerializeField] private float maxTotalTime = 60;
    private float gameTime;


    private int minChangeGenerateBox = 0;
    private const int TIMESCALE = 1;

    private const float maxtimeCoutDown = 3f;
    private float timeCountDown;
    private const float minTimeCountDown = 0;

    private void Start()
    {
        timeCountDown = maxtimeCoutDown;
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
                int ran = Random.Range(minChangeGenerateBox, bossManager.MaxChangeGenerateBox[(int)bossManager.GetBossState]);
                if (ran < 10)
                {
                    wordManager.AddMonsterWordBox();
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
}
