using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkTypingScreenHandle : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private WorkTypingManager typingGameManager;
    [SerializeField] private WorkTypingTimer typingGameTimer;
    [SerializeField] private WorkTypingPlayerManager playerManager;

    [Header("count down time")]
    [SerializeField] private Image imageTran;
    [SerializeField] private GameObject textCountObj;
    [SerializeField] private TMP_Text textCountTimeTMP;

    [Header("Time")]
    [SerializeField] private Image timeFillbarTmage;


    [Header("Player Info")]
    [SerializeField] private TMP_Text scoresTMP;
    [SerializeField] private TMP_Text combosTMP;
    [SerializeField] private Image comboBarImage;
    [SerializeField] private TMP_Text textWordGoodIdeaTMP;
    [SerializeField] private TMP_Text textWordBadIdeaTMP;

    [Header("Summary Canvas")]
    [SerializeField] private GameObject summaryObj;



    void Start()
    {
        typingGameManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
        typingGameTimer.OnworkTypingTimerUpdate.AddListener(OnworkTypingTimerUpdateHandler);
        playerManager.OnWorkTypingPlayerUpdate.AddListener(OnWorkTypingPlayerUpdateHandler);
        Initializing();
    }

    private void OnworkTypingTimerUpdateHandler()
    {
        switch (typingGameManager.GetTypingGameState)
        {
            case WorkTypingManager.TypingGameState.PreGame:
                SetPregameCountdownTime();
                break;
            case WorkTypingManager.TypingGameState.Playing:
                SetTimeFillBar();
                break;
        }
    }

    private void SetPregameCountdownTime()
    {
        textCountTimeTMP.text = typingGameTimer.GetTimeCountDown();
    }

    private void Initializing()
    {
        SetActiveTimeCountTime(true);
        SetActiveImageTran(true);
        SetActiveSummary(false);
        UpdatePlayerInfo();
        SetTimeFillBar();
    }

    private void SetTimeFillBar()
    {
        timeFillbarTmage.fillAmount = 1 - typingGameTimer.GetTimeFillAmount();
    }

    private void OnWorkTypingPlayerUpdateHandler()
    {
        UpdatePlayerInfo();
    }

    private void UpdatePlayerInfo()
    {
        scoresTMP.text = playerManager.Score.ToString();
        combosTMP.text = playerManager.CurrentCombo.ToString();
        if ((int)playerManager.ComboPhase + 1 < playerManager.MaxComboPhase)
        {
            comboBarImage.fillAmount = (float)playerManager.CurrentCombo / playerManager.CountCombo[(int)playerManager.ComboPhase + 1];
        }
        else
        {
            comboBarImage.fillAmount = 1;
        }
        textWordGoodIdeaTMP.text = playerManager.WordGoodIdea.ToString();
        textWordBadIdeaTMP.text = playerManager.WordBadIdea.ToString();
    }

    private void OnTypingGameStateChangedHandler(WorkTypingManager.TypingGameState currentTypingGameState)
    {
        switch (currentTypingGameState)
        {
            case WorkTypingManager.TypingGameState.PreGame:
                SetActiveImageTran(true);
                SetActiveTimeCountTime(true);
                SetActiveSummary(false);
                break;
            case WorkTypingManager.TypingGameState.Playing:
                SetActiveTimeCountTime(false);
                SetActiveImageTran(false);
                SetActiveSummary(false);
                break;
            case WorkTypingManager.TypingGameState.PostGame:
                SetActiveImageTran(true);
                SetActiveSummary(true);
                break;
        }
    }

    private void SetActiveSummary(bool active)
    {
        summaryObj.SetActive(active);
    }

    private void SetActiveTimeCountTime(bool active)
    {
        textCountObj.SetActive(active);
    }

    private void SetActiveImageTran(bool active)
    {
        imageTran.gameObject.SetActive(active);
    }


}
