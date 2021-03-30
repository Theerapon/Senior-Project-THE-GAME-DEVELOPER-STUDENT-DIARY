using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryManager : MonoBehaviour
{
    private GameObject foundPlayerAction;
    private PlayerAction playerAction;
    private CharacterStats characterStats;

    private void Start()
    {
        characterStats = CharacterStats.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();

        TimeManager.Instance.OnTimeSkip.AddListener(TimeSkilpHandler);
    }

    private void TimeSkilpHandler(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.DAIRY)
        {
            GameManager.Instance.GotoMainWithContiniueGameInNextDays();
        }
    }

    public void OnContiniue()
    {
        playerAction.Sleep(playerAction.GetCalculateSleepTimeSecond(characterStats.GetSleepFullTimeSelected()));

    }
}
