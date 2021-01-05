using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Manager<UIManager>
{
    [Header("Camera")]
    [SerializeField] private Camera _uiCamera;

    [Space]

    [Header("Main Menu")]
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Text _tagline;
    [SerializeField] private TimeMenu timeMenu;

    public Events.EventLoadComplete OnMainMenuLoadComplete;

    void Start()
    {
        _mainMenu.OnMainMenuLoadComplete.AddListener(HandleMainMenuLoadComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        //DisplayUI(false);
    }

    private void HandleMainMenuLoadComplete(bool loadGame)
    {
        //what happen when load scene game from main menu
        _tagline.gameObject.SetActive(!loadGame);

        OnMainMenuLoadComplete.Invoke(loadGame);   
    }

    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        switch (currentState)
        {
            case GameManager.GameState.PREGAME:
                //DisplayUI(false);
                break;

            case GameManager.GameState.RUNNING:
                //DisplayUI(true);
                break;

            default:
                break;
        }
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameManager.GameState.PREGAME)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.StartGame();
        }
    }

    public void SetCameraActive(bool active)
    {
        _uiCamera.gameObject.SetActive(active);
    }

    private void DisplayUI(bool active)
    {
        timeMenu.gameObject.SetActive(active);
    }
}
