using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetaTypingScreenHandler : MonoBehaviour
{
    [SerializeField] private BetaTypingPlayerManager playerManager;
    [SerializeField] private BetaTypingManager typingGameManager;
    [SerializeField] private BetaTypingTimer typingGameTimer;
    [SerializeField] private BetaTypingGameBossManager bossManager;

    [Header("count down time")]
    [SerializeField] private Image imageTran;
    [SerializeField] private GameObject textCountObj;
    [SerializeField] private TMP_Text textCountTime;

    [Header("Boss")]
    [SerializeField] private TMP_Text hpTMP;
    [SerializeField] private TMP_Text maxHpTMP;
    [SerializeField] private Image hpBarImage;
    [SerializeField] private TMP_Text damagedTMP;

    [Header("Player")]
    [SerializeField] private TMP_Text comboTMP;
    [SerializeField] private Image comboBarImage;

    [Header("Time")]
    [SerializeField] private Image timeBarImage;

    [Header("Summary Canvas")]
    [SerializeField] private GameObject summaryObj;

    // Start is called before the first frame update
    void Start()
    {
        
        typingGameManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
        typingGameTimer.OnBetaTypingTimerUpdate.AddListener(OnBetaTypingTimerUpdateHandler);
        bossManager.onBetaTypingBossUpdate.AddListener(onBetaTypingBossUpdateHandler);
        bossManager.OnBetaTypingBossStateChange.AddListener(OnBetaTypingBossStateChangeHandler);
        playerManager.OnBetaTypingPlayerUpdate.AddListener(OnBetaTypingPlayerUpdateHandler);
        Initializing();
    }

    private void OnBetaTypingBossStateChangeHandler(BetaTypingGameBossManager.BossState state)
    {
        if (state == BetaTypingGameBossManager.BossState.Weekness)
        {
            
        }
    }

    private void OnBetaTypingPlayerUpdateHandler()
    {
        UpdatePlayerInfo();
    }

    

    private void Initializing()
    {
        SetActiveTimeCountTime(true);
        SetActiveImageTran(true);
        SetActiveSummary(false);
        UpdateBossInfo();
        UpdatePlayerInfo();
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
            case BetaTypingManager.TypingGameState.Playing:
                SetTimeFillBar();
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
                SetActiveSummary(false);
                break;
            case BetaTypingManager.TypingGameState.Playing:
                SetActiveTimeCountTime(false);
                SetActiveImageTran(false);
                SetActiveSummary(false);
                break;
            case BetaTypingManager.TypingGameState.PostGame:
                SetActiveImageTran(true);
                SetActiveSummary(true);
                break;
        }
    }

    private void UpdateBossInfo()
    {
        hpTMP.text = string.Format("{0}", bossManager.CurrentHp);
        maxHpTMP.text = string.Format("{0}", bossManager.MaxHp);
        hpBarImage.fillAmount = (float)bossManager.CurrentHp / bossManager.MaxHp;
        damagedTMP.text = string.Format("{0}", bossManager.TotalDamaged);

    }
    private void UpdatePlayerInfo()
    {
        comboTMP.text = string.Format("{0}", playerManager.Combo);
        if((int)playerManager.GetComboPhase + 1 < playerManager.MaxComboPhase)
        {
            comboBarImage.fillAmount = (float)playerManager.Combo / playerManager.CountCombo[(int)playerManager.GetComboPhase + 1];
        }
        else
        {
            comboBarImage.fillAmount = 1;
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

    private void SetActiveTimeCountTime(bool active)
    {
        textCountObj.SetActive(active);
    }
    private void SetActiveSummary(bool active)
    {
        summaryObj.SetActive(active);
    }

    private void SetTimeFillBar()
    {
        timeBarImage.fillAmount = 1 - typingGameTimer.GetTimeFillAmount();
    }
}
