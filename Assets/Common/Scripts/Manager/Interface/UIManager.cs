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
    [SerializeField] private MainMenuPreGame _mainMenu;
    [SerializeField] private GameObject mainMenuDisplayHandler;


    void Start()
    {
        _mainMenu.OnMainMenuLoadComplete.AddListener(HandleMainMenuLoadComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleMainMenuLoadComplete(bool loadGame)
    {
        mainMenuDisplayHandler.gameObject.SetActive(!loadGame);
        SetCameraActive(!loadGame);

    }


    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        
    }


    public void SetCameraActive(bool active)
    {
        _uiCamera.gameObject.SetActive(active);
    }


}
