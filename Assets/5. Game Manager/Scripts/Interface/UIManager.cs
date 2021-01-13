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
    [SerializeField] private Text _tagline;
    
    [Header("Time Menu")]
    [SerializeField] private Image _timeImage;

    [Header("Puase Menu")]
    [SerializeField] private TMP_Text _puaseText;

    public Events.EventLoadComplete OnMainMenuLoadComplete;

    void Start()
    {
        _mainMenu.OnMainMenuLoadComplete.AddListener(HandleMainMenuLoadComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
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
                DisplayTimeImage(false);
                DisplayPuaseText(false);
                break;
            case GameManager.GameState.RUNNING:
                DisplayTimeImage(true);
                DisplayPuaseText(false);
                break;
            case GameManager.GameState.PAUSE:
                DisplayPuaseText(true);
                DisplayTimeImage(false);
                break;
            case GameManager.GameState.INTERRUPTED:
                DisplayPuaseText(false);
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

    private void DisplayTimeImage(bool active)
    {
        _timeImage.gameObject.SetActive(active);
    }

    private void DisplayPuaseText(bool active)
    {
        _puaseText.gameObject.SetActive(active);
    }
}
