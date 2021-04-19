using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Manager<UIManager>
{
    [Header("Camera")]
    [SerializeField] private Camera _uiCamera;


    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuDisplayHandler;


    void Start()
    {
        GameManager.Instance.onHomeDisplay.AddListener(HandleLoadGameComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);

        _uiCamera.gameObject.SetActive(true);
        mainMenuDisplayHandler.gameObject.SetActive(true);

    }

    private void HandleLoadGameComplete(bool loadGame)
    {
        if(GameManager.Instance.CurrentGameState != GameManager.GameState.MAP)
        {
            mainMenuDisplayHandler.gameObject.SetActive(!loadGame);
            SetCameraActive(!loadGame);
        }

    }


    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        
    }


    public void SetCameraActive(bool active)
    {
        _uiCamera.gameObject.SetActive(active);
    }


}
