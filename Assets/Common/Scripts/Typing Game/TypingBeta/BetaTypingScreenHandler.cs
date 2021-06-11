using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetaTypingScreenHandler : MonoBehaviour
{
    [SerializeField] private BetaTypingManager typingGameManager;
    [SerializeField] private BetaTypingTimer typingGameTimer;
    [SerializeField] private BossManager bossManager;

    [Header("count down time")]
    [SerializeField] private Image imageTran;
    [SerializeField] private GameObject textCountObj;
    [SerializeField] private TMP_Text textCountTime;

    [Header("Boss")]
    [SerializeField] private TMP_Text hpTMP;
    [SerializeField] private TMP_Text damagedTMP;

    // Start is called before the first frame update
    void Start()
    {
        
        typingGameManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
        typingGameTimer.OnBetaTypingTimerUpdate.AddListener(OnBetaTypingTimerUpdateHandler);
        bossManager.onBetaTypingBossUpdate.AddListener(onBetaTypingBossUpdateHandler);
        Reset();
    }

    private void Reset()
    {
        SetActiveTimeCountTime(true);
        SetActiveImageTran(true);
        UpdateBossInfo();
    }

    private void onBetaTypingBossUpdateHandler()
    {
        UpdateBossInfo();
    }

    private void OnBetaTypingTimerUpdateHandler()
    {
        switch (typingGameManager.GetTypingGameState())
        {
            case BetaTypingManager.TypingGameState.PreGame:
                SetTimeCountTime();
                break;
        }
    }

    private void OnTypingGameStateChangedHandler(BetaTypingManager.TypingGameState currentTypingGameState)
    {
        switch (currentTypingGameState)
        {
            case BetaTypingManager.TypingGameState.PreGame:
                SetActiveImageTran(true);
                SetActiveTimeCountTime(true);
                break;
            case BetaTypingManager.TypingGameState.Playing:
                SetActiveTimeCountTime(false);
                SetActiveImageTran(false);
                break;
            case BetaTypingManager.TypingGameState.PostGame:
                SetActiveImageTran(true);
                break;
        }
    }

    private void UpdateBossInfo()
    {
        hpTMP.text = string.Format("{0:n0}", bossManager.CurrentHp);
        damagedTMP.text = string.Format("{0:n0}", bossManager.TotalDamaged);

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
}
