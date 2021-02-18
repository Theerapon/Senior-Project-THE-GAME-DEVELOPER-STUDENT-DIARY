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
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameObject mainMenuDisplayHandler;

    


    void Start()
    {
        _mainMenu.OnMainMenuLoadComplete.AddListener(HandleMainMenuLoadComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleMainMenuLoadComplete(bool loadGame)
    {

        if (loadGame)
        {
            mainMenuDisplayHandler.gameObject.SetActive(!loadGame);
        } else
        {
            mainMenuDisplayHandler.gameObject.SetActive(!loadGame);
        }

 
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {

    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameManager.GameState.PREGAME)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.NewGame();
        }
    }

    public void SetCameraActive(bool active)
    {
        _uiCamera.gameObject.SetActive(active);
    }


}
