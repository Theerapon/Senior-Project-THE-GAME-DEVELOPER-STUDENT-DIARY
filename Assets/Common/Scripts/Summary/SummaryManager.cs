using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryManager : MonoBehaviour
{
   
    private GameObject found_Player;
    private CharacterStatusController character_status;
    private PlayerAction playerAction;

    private void Start()
    {
        found_Player = GameObject.FindGameObjectWithTag("Player");
        playerAction = found_Player.GetComponentInChildren<PlayerAction>();
        character_status = CharacterStatusController.Instance;

        TimeManager.Instance.OnTimeSkip.AddListener(TimeSkilpHandler);
    }

    private void TimeSkilpHandler(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Diary)
        {
            //GameManager.Instance.GotoMainWithContiniueGameInNextDays();
        }
    }

    public void OnContiniue()
    {
        //playerAction.Sleep(playerAction.GetCalculateSleepTimeSecond(characterStats.GetSleepFullTimeSelected()));

    }
}
