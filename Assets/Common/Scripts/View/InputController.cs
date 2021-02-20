using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InputController : MonoBehaviour
{

    #region Defination
    [Header("Project")]
    [SerializeField] private GameObject _ProjectDisplayHolder;


    [Header("Menu")]
    [SerializeField] private GameObject _MenuHandler;

    [Header("Hotbar")]
    [SerializeField] private GameObject _HotbarHandler;
    #endregion


    protected void Start()
    {

        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        switch (currentState)
        {
            case GameManager.GameState.PREGAME:
                break;
            case GameManager.GameState.RUNNING:
                if(_HotbarHandler.activeSelf == false)
                {
                    _HotbarHandler.SetActive(true);
                }
                break;
            case GameManager.GameState.DISPLAYMENU:
                if (_HotbarHandler.activeSelf == true)
                {
                    _HotbarHandler.SetActive(false);
                }
                break;
            default:
                break;
        }
    }

    void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            #region Pregame
            case GameManager.GameState.PREGAME:
                break;
            #endregion
            #region Running
            case GameManager.GameState.RUNNING:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    DisplayMenu();
                    GameManager.Instance.DisplayMenuUpdatedState();

                }
                break;
            #endregion
            #region Pause
            case GameManager.GameState.DISPLAYMENU:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    DisplayMenu();
                    GameManager.Instance.DisplayMenuUpdatedState();
                }
                break;
            #endregion
            default:
                break;
        }

    }

    #region Projects
    private void DisplayProject()
    {
        if (_ProjectDisplayHolder.activeSelf == true && _ProjectDisplayHolder != null)
        {
            _ProjectDisplayHolder.SetActive(false);
        }
        else
        {
            //SetDisplayProject();
            _ProjectDisplayHolder.SetActive(true);
        }
    }
    #endregion


    private void DisplayMenu()
    {
        if (_MenuHandler.activeSelf == true && _MenuHandler != null)
        {
            _MenuHandler.SetActive(false);
        }
        else
        {
            _MenuHandler.SetActive(true);
            MenuManager.Instance.Reset();
        }
    }

    private void DisplayHotbar()
    {
        if (_HotbarHandler.activeSelf == true && _HotbarHandler != null)
        {
            _HotbarHandler.SetActive(false);
        }
        else
        {
            _HotbarHandler.SetActive(true);
        }
    }
}
