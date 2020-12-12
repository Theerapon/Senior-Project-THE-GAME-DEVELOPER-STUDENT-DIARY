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
        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            LoadGame();
            //Onloadgamecomplete event raised when take animation but now i dont have animation yet
            OnLoadGameComplete();
        }

        if (previousState != GameManager.GameState.PREGAME && currentState == GameManager.GameState.PREGAME)
        {
            UnLoadGame();
            OnUnLoadGameComplete(); //Onloadgamecomplete event raised when take animation 
        }
    }

    public void OnLoadGameComplete()
    {
        OnMainMenuLoadComplete.Invoke(true);
    }

    public void OnUnLoadGameComplete()
    {
        OnMainMenuLoadComplete.Invoke(false);
        UIManager.Instance.SetCameraActive(true);
    }

    public void LoadGame()
    {
        //animation for load game scene
        UIManager.Instance.SetCameraActive(false);
    }

    public void UnLoadGame()
    {
        //animation for unload game scene
    }
}
