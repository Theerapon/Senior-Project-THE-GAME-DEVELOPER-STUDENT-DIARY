using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypingGame2ScreenHandle : MonoBehaviour
{
    TypingGame2Manager typingGame2Manager;
    TypingGame2Timer typingGame2Timer;

    [Header("count down time")]
    [SerializeField] private Image imageTran;
    [SerializeField] private TMP_Text textCountTime;

    [Header("Time")]
    [SerializeField] private Image imageTimeFillbar;

    [Header("Level")]
    [SerializeField] private TMP_Text textLevel;

    void Start()
    {
        typingGame2Manager = TypingGame2Manager.Instance;
        typingGame2Timer = FindObjectOfType<TypingGame2Timer>();
        typingGame2Manager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
        typingGame2Manager.OnCheckedWordUpdate.AddListener(OnCheckedWordUpdateHandler);
    }

    private void OnCheckedWordUpdateHandler()
    {
        Reset();
    }

    private void OnTypingGameStateChangedHandler(TypingGame2Manager.TypingGameState currentTypingGameState)
    {
        switch (currentTypingGameState)
        {
            case TypingGame2Manager.TypingGameState.PreGame:
                SetActiveImageTran(true);
                break;
            case TypingGame2Manager.TypingGameState.Playing:
                SetActiveTimeCountTime();
                SetActiveImageTran(false);
                break;
            case TypingGame2Manager.TypingGameState.PostGame:
                SetActiveImageTran(true);
                break;
        }
    }

    private void Update()
    {
        switch (typingGame2Manager.GetTypingGameState())
        {
            case TypingGame2Manager.TypingGameState.PreGame:
                SetTimeCountTime();
                break;
            case TypingGame2Manager.TypingGameState.Playing:
                SetTimeFillBar();
                break;
        }
    }
    

    private void SetTimeCountTime()
    {
        textCountTime.text = typingGame2Timer.GetTimeCountDown();
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
        imageTimeFillbar.fillAmount = 1 - typingGame2Timer.GetTimeFillAmount();
    }

    private void Reset()
    {
        textLevel.text = typingGame2Manager.GetNameLevel();
    }

}
