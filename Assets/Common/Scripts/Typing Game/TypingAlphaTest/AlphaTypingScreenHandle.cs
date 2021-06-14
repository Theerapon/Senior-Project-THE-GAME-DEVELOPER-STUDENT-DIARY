using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AlphaTypingScreenHandle : MonoBehaviour
{
    [SerializeField] private AlphaTypingManager typingGameManager;
    [SerializeField] private AlphaTypingTimer typingGameTimer;
    [SerializeField] private AlphaTypingPlayerManager playerManager;

    [Header("count down time")]
    [SerializeField] private Image imageTran;
    [SerializeField] private GameObject textCountObj;
    [SerializeField] private TMP_Text textCountTime;

    [Header("Time")]
    [SerializeField] private Image imageTimeFillbar;

    [Header("Level")]
    [SerializeField] private TMP_Text textLevel;

    [Header("Player Info")]
    [SerializeField] private TMP_Text scoresTMP;
    [SerializeField] private TMP_Text combosTMP;
    [SerializeField] private Image comboBarImage;


    [Header("Summary Canvas")]
    [SerializeField] private GameObject summaryObj;


    void Start()
    {
        typingGameManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
        typingGameManager.OnCheckedWordUpdate.AddListener(OnCheckedWordUpdateHandler);
        typingGameTimer.OnAlphaTypingTimerUpdate.AddListener(OnAlphaTypingTimerUpdateHandler);
        playerManager.OnAlphaTypingPlayerUpdate.AddListener(OnAlphaTypingPlayerUpdateHandler);
        Initializing();
    }

    private void OnAlphaTypingPlayerUpdateHandler()
    {
        UpdatePlayerInfo();
    }

    private void OnAlphaTypingTimerUpdateHandler()
    {
        switch (typingGameManager.GetTypingGameState())
        {
            case AlphaTypingManager.TypingGameState.PreGame:
                SetTimeCountTime();
                break;
            case AlphaTypingManager.TypingGameState.Playing:
                SetTimeFillBar();
                break;
        }
    }

    private void OnCheckedWordUpdateHandler()
    {
        SetGameLevel();
    }

    private void OnTypingGameStateChangedHandler(AlphaTypingManager.TypingGameState currentTypingGameState)
    {
        switch (currentTypingGameState)
        {
            case AlphaTypingManager.TypingGameState.PreGame:
                SetActiveImageTran(true);
                SetActiveTimeCountTime(true);
                SetActiveSummary(false);
                break;
            case AlphaTypingManager.TypingGameState.Playing:
                SetActiveTimeCountTime(false);
                SetActiveImageTran(false);
                SetActiveSummary(false);
                break;
            case AlphaTypingManager.TypingGameState.PostGame:
                SetActiveImageTran(true);
                SetActiveSummary(true);
                break;
        }
    }

    private void Initializing()
    {
        SetActiveTimeCountTime(true);
        SetActiveImageTran(true);
        SetActiveSummary(false);
        SetGameLevel();
        UpdatePlayerInfo();
        SetTimeFillBar();
    }

    private void SetTimeCountTime()
    {
        textCountTime.text = typingGameTimer.GetTimeCountDown();
    }

    private void SetActiveImageTran(bool active)
    {
        imageTran.gameObject.SetActive(active);
    }

    private void SetActiveTimeCountTime(bool active)
    {
        textCountObj.SetActive(active);
    }

    private void SetTimeFillBar()
    {
        imageTimeFillbar.fillAmount = 1 - typingGameTimer.GetTimeFillAmount();
    }    

    private void SetGameLevel()
    {
        textLevel.text = typingGameManager.GetNameLevel();
    }

    private void UpdatePlayerInfo()
    {
        combosTMP.text = string.Format("{0}", playerManager.CurrentCombo);
        if ((int)playerManager.ComboPhase + 1 < playerManager.MaxComboPhase)
        {
            comboBarImage.fillAmount = (float)playerManager.CurrentCombo / playerManager.CountCombo[(int)playerManager.ComboPhase + 1];
        }
        else
        {
            comboBarImage.fillAmount = 1;
        }
        scoresTMP.text = playerManager.Score.ToString();
    }

    private void SetActiveSummary(bool active)
    {
        summaryObj.SetActive(active);
    }
}
