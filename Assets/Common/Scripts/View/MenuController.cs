﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Events.EventOnOpenMenu OnGameOpenMaenu;

    [SerializeField] private GameObject _blur;
    private GameManager gameManager;

    private GameManager.GameState previousGameStateMenu;

    private bool hasDisplayed;

    protected void Start()
    {
        Reset();
        if(GameManager.Instance != null)
        {
            gameManager = GameManager.Instance;
        }
       GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        hasDisplayed = false;
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if(currentState == GameManager.GameState.HOME_ACTION || currentState == GameManager.GameState.MENU)
        {
            ActivedBlur(true);
        }
    }

    void Update()
    {
        if(gameManager != null)
        {
            if (Input.GetKeyDown(KeyboardManager.Instance.GetBackKeyCode()))
            {
                if (hasDisplayed)
                {
                    EscClose();
                }
                else
                {
                    EscOpen();
                }
            }


        }

    }


    private bool ActivedBlur(bool actived)
    {
        _blur.SetActive(actived);

        return _blur.activeSelf;
    }

    private void Reset()
    {
        _blur.SetActive(false);
    }

    private void DisplayMenu(bool action, GameManager.GameScene currentGameScene)
    {
        GameManager.Instance.DisplerMenu(action, currentGameScene, previousGameStateMenu);
    }

    private void DisplayHomeAction(bool action, GameManager.GameScene currentGameScene)
    {
        GameManager.Instance.DisplerHomeAction(ActivedBlur(action), currentGameScene);
    }

    public GameManager.GameState GetPreviousGameStateMenu()
    {
        return previousGameStateMenu;
    }

    public void SetPreviousGameStateMenu(GameManager.GameState gameState)
    {
        previousGameStateMenu = gameState;
    }

    public void Close(GameManager.GameScene gameScene)
    {
        //close menu
        if (gameManager.CurrentGameState == GameManager.GameState.MENU)
        {
            DisplayMenu(ActivedBlur(false), gameScene);
        }

        if (gameManager.CurrentGameState == GameManager.GameState.HOME_ACTION)
        {
            DisplayHomeAction(ActivedBlur(false), gameScene);
        }

        hasDisplayed = false;
    }

    public void OpenMenu(GameManager.GameScene gameScene)
    {
        //open menu home
        if (gameManager.CurrentGameState == GameManager.GameState.HOME)
        {
            previousGameStateMenu = GameManager.GameState.HOME;
        }

        //open menu map
        if (gameManager.CurrentGameState == GameManager.GameState.MAP)
        {
            previousGameStateMenu = GameManager.GameState.MAP;
        }

        DisplayMenu(ActivedBlur(true), gameScene);
        hasDisplayed = true;
    }

    public void OpenHomeAction(GameManager.GameScene gameScene)
    {
        DisplayHomeAction(ActivedBlur(true), gameScene);
    }

    private void EscOpen()
    {
        //Esc key open Bag first anyway
        GameManager.GameScene scene = GameManager.GameScene.Menu_Bag;
        OnGameOpenMaenu?.Invoke(scene);
        OpenMenu(scene);

    }

    private void EscClose()
    {
        //Esc key close current scene
        Close(GameManager.Instance.CurrentGameScene);
    }
}
