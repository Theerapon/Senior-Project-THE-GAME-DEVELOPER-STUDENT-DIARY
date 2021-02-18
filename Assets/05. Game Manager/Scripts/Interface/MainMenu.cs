using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Events.EventLoadComplete OnMainMenuLoadComplete;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {

        if (previousState != GameManager.GameState.PREGAME && currentState == GameManager.GameState.PREGAME)
        {
            UnLoadGame();
        }
    }


    private void LoadGame()
    {
        UIManager.Instance.SetCameraActive(false);
        OnMainMenuLoadComplete.Invoke(true);
    }

    private void UnLoadGame()
    {
        UIManager.Instance.SetCameraActive(true);
        OnMainMenuLoadComplete.Invoke(false);
    }

    public void NewGame()
    {
        LoadGame();
        GameManager.Instance.NewGame();
    }

    public void Continiue()
    {
        GameManager.Instance.ContiniueGame();
    }
}
