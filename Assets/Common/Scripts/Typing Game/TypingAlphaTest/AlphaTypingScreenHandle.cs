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

    [Header("count down time")]
    [SerializeField] private Image imageTran;
    [SerializeField] private TMP_Text textCountTime;

    [Header("Time")]
    [SerializeField] private Image imageTimeFillbar;

    [Header("Level")]
    [SerializeField] private TMP_Text textLevel;

    void Start()
    {
        typingGameManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
        typingGameManager.OnCheckedWordUpdate.AddListener(OnCheckedWordUpdateHandler);
        typingGameTimer.OnAlphaTypingTimerUpdate.AddListener(OnAlphaTypingTimerUpdateHandler);
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
        Reset();
    }

    private void OnTypingGameStateChangedHandler(AlphaTypingManager.TypingGameState currentTypingGameState)
    {
        switch (currentTypingGameState)
        {
            case AlphaTypingManager.TypingGameState.PreGame:
                SetActiveImageTran(true);
                break;
            case AlphaTypingManager.TypingGameState.Playing:
                SetActiveTimeCountTime();
                SetActiveImageTran(false);
                break;
            case AlphaTypingManager.TypingGameState.PostGame:
                SetActiveImageTran(true);
                break;
        }
    }
    

    private void SetTimeCountTime()
    {
        textCountTime.text = typingGameTimer.GetTimeCountDown();
    }

    private void SetActiveImageTran(bool active)
    {
        imageTran.gameObject.SetActive(active);
    }

    private void SetActiveTimeCountTime()
    {
        textCountTime.gameObject.SetActive(false);
    }

    private void SetTimeFillBar()
    {
        imageTimeFillbar.fillAmount = 1 - typingGameTimer.GetTimeFillAmount();
    }

    private void Reset()
    {
        textLevel.text = typingGameManager.GetNameLevel();
    }

}
