using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Manager<UIManager>
{
    [SerializeField] GameManager gameManager;

    [Header("Camera")]
    [SerializeField] private Camera _uiCamera;


    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuDisplayHandler;

    protected override void Awake()
    {
        base.Awake();
        gameManager.onHomeDisplay.AddListener(HandleLoadGameComplete);
        gameManager.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.PREGAME)
        {
            SetCameraActive(true);
            mainMenuDisplayHandler.gameObject.SetActive(true);
        }   
    }

    void Start()
    {
       
        _uiCamera.gameObject.SetActive(true);
        mainMenuDisplayHandler.gameObject.SetActive(true);

    }

    private void HandleLoadGameComplete(bool loadGame)
    {
        if(GameManager.Instance.CurrentGameState != GameManager.GameState.MAP && GameManager.Instance.CurrentGameState != GameManager.GameState.PREGAME)
        {
            mainMenuDisplayHandler.gameObject.SetActive(!loadGame);
            SetCameraActive(!loadGame);
        }

    }


    public void SetCameraActive(bool active)
    {
        _uiCamera.gameObject.SetActive(active);
    }


}
