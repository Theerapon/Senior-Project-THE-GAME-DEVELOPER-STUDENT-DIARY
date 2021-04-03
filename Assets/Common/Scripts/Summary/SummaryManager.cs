using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryManager : MonoBehaviour
{
   
    private GameObject found_Player;
    private Characters_Handler chracter_handler;
    private PlayerAction playerAction;

    private void Start()
    {
        found_Player = GameObject.FindGameObjectWithTag("Player");
        playerAction = found_Player.GetComponentInChildren<PlayerAction>();
        chracter_handler = found_Player.GetComponentInChildren<Characters_Handler>();

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
        //playerAction.Sleep(playerAction.GetCalculateSleepTimeSecond(characterStats.GetSleepFullTimeSelected()));

    }
}
