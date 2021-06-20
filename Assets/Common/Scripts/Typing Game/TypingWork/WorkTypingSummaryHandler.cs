using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WorkTypingManager;

public class WorkTypingSummaryHandler : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] WorkTypingManager typingManager;
    [SerializeField] WordStatistics wordStatistics;
    [SerializeField] WorkTypingTimer timer;
    [SerializeField] WorkTypingPlayerManager playerManager;

    [Header("TMP")]
    [SerializeField] private TMP_Text scoreTMP;
    [SerializeField] private TMP_Text accuracyTMP;
    [SerializeField] private TMP_Text correctTMP;
    [SerializeField] private TMP_Text incorrectTMP;
    [SerializeField] private TMP_Text maxComboTMP;
    [SerializeField] private TMP_Text countGoodIdeaTMP;
    [SerializeField] private TMP_Text countBadIdeaTMP;

    private void Awake()
    {
        typingManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
    }


    private void OnTypingGameStateChangedHandler(WorkTypingManager.TypingGameState state)
    {
        if (state == WorkTypingManager.TypingGameState.PostGame)
        {
            Innitialzing();
        }
    }

    private void Innitialzing()
    {
        scoreTMP.text = playerManager.Score.ToString();
        accuracyTMP.text = string.Format("{0:n2}", wordStatistics.GetAccuracy() * 100);
        correctTMP.text = wordStatistics.CorrectWord.ToString();
        incorrectTMP.text = wordStatistics.IncoreectWord.ToString();
        countGoodIdeaTMP.text = playerManager.WordGoodIdea.ToString();
        countBadIdeaTMP.text = playerManager.WordBadIdea.ToString();
        maxComboTMP.text = playerManager.MaxCombo.ToString();
    }

    public void Next()
    {
        typingManager.UpdateTypingGameState(TypingGameState.Summary);
        SwitchScene.Instance.DisplayWorkProjectSummary(true);
    }
}
