using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsDisplay : MonoBehaviour
{
    public static StatsDisplay instance;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private GameObject StatsDisplayHolder;
    [SerializeField] private TMP_Text textCoding;
    [SerializeField] private TMP_Text textDesign;
    [SerializeField] private TMP_Text textTesting;
    [SerializeField] private TMP_Text textArt;
    [SerializeField] private TMP_Text textAudio;

    private GameManager.GameState _currentGameState;

    void Start()
    {
        instance = this;
        _currentGameState = GameManager.GameState.RUNNING;
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        switch (currentState)
        {
            case GameManager.GameState.PREGAME:
                _currentGameState = GameManager.GameState.RUNNING;
                break;
            case GameManager.GameState.RUNNING:
                _currentGameState = currentState;
                break;
            case GameManager.GameState.PAUSE:
                _currentGameState = currentState;
                break;
        }
    }

    void Update()
    {
        switch (_currentGameState)
        {
            case GameManager.GameState.PREGAME:
                break;
            case GameManager.GameState.RUNNING:
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    DisplayStats();
                }
                break;
            case GameManager.GameState.PAUSE:
                break;
        }
    }

    private void SetText()
    {
        textCoding.text = characterStats.GetStatusCoding().ToString();
        textDesign.text = characterStats.GetStatusDesign().ToString();
        textTesting.text = characterStats.GetStatusTest().ToString();
        textArt.text = characterStats.GetStatusArt().ToString();
        textAudio.text = characterStats.GetStatusAudio().ToString();
    }

    void DisplayStats()
    {
        if (StatsDisplayHolder.activeSelf == true)
        {
            StatsDisplayHolder.SetActive(false);
        }
        else
        {
            SetText();
            StatsDisplayHolder.SetActive(true);
        }
    }
}
