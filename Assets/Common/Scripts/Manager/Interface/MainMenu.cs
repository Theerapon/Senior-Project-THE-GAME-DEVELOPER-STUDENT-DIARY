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

    }



    private void LoadGame()
    {
        OnMainMenuLoadComplete.Invoke(true);
        UIManager.Instance.SetCameraActive(false);
    }

    private void UnLoadGame()
    {
        OnMainMenuLoadComplete.Invoke(false);
        UIManager.Instance.SetCameraActive(true);
    }

    public void NewGame()
    {
        LoadGame();
        GameManager.Instance.StartGameWithNewGame();
    }

    public void Continiue()
    {
        LoadGame();
        GameManager.Instance.StartGameWithContiniueGame();
    }
}
