using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static AlphaTypingManager;

public class AlphaTypingSummaryHandler : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] AlphaTypingManager typingManager;
    [SerializeField] WordStatistics wordStatistics;
    [SerializeField] AlphaTypingTimer timer;
    [SerializeField] AlphaTypingPlayerManager playerManager;

    [Header("TMP")]
    [SerializeField] private TMP_Text scoreTMP;
    [SerializeField] private TMP_Text accuracyTMP;
    [SerializeField] private TMP_Text currectTMP;
    [SerializeField] private TMP_Text incurrectTMP;
    [SerializeField] private TMP_Text maxComboTMP;
    [SerializeField] private TMP_Text countTotalWordGenerateTMP;
    [SerializeField] private TMP_Text countWordVerifiedTMP;
    [SerializeField] private TMP_Text countFoundWordBugTMP;

    private void Awake()
    {
        typingManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
    }


    private void OnTypingGameStateChangedHandler(AlphaTypingManager.TypingGameState state)
    {
        if (state == AlphaTypingManager.TypingGameState.PostGame)
        {
            Innitialzing();
        }
    }

    private void Innitialzing()
    {
        scoreTMP.text = playerManager.Score.ToString();
        accuracyTMP.text = string.Format("{0:n2}", wordStatistics.GetAccuracy() * 100);
        currectTMP.text = wordStatistics.CorrectWord.ToString();
        incurrectTMP.text = wordStatistics.IncoreectWord.ToString();
        countTotalWordGenerateTMP.text = typingManager.CountTotalWordGenerate.ToString();
        countWordVerifiedTMP.text = typingManager.CountWordVerified.ToString();
        countFoundWordBugTMP.text = typingManager.CountFoundWordBug.ToString();
        maxComboTMP.text = playerManager.MaxCombo.ToString();
    }

    public void Next()
    {
        typingManager.UpdateTypingGameState(TypingGameState.Summary);
        SwitchScene.Instance.DisplayWorkProjectSummary(true);
    }
}
