using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static AlphaTypingManager;

public class AlphaTypingSummaryHandler : MonoBehaviour
{
    private readonly float[] bonusEfficiency = { -0.5f, -0.1f, 0.1f, 0.15f, 0.2f, 0.35f, 0.5f, 0.7f, 1f, 1.5f, 2f, 3f };
    private readonly int[] scoreStandard = { 0, 0, 0, 0, 25000, 45000, 80000, 156000, 450000, 600000, 1000000, 2000000, };
    private int indexOfEfficiency;

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
    [SerializeField] private TMP_Text efficiencyBonus;

    private void Awake()
    {
        typingManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
    }


    private void OnTypingGameStateChangedHandler(AlphaTypingManager.TypingGameState state)
    {
        if (state == AlphaTypingManager.TypingGameState.PostGame)
        {
            indexOfEfficiency = CalculateIndexOfEfficiency();
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
        efficiencyBonus.text = string.Format("{0:p0}", bonusEfficiency[indexOfEfficiency]);
        if(ProjectController.Instance != null)
            ProjectController.Instance.MiniGameBonusEfficiency = bonusEfficiency[indexOfEfficiency];
    }
    private int CalculateIndexOfEfficiency()
    {
        int index = 0;
        int score = playerManager.Score;
        float avgScore = wordStatistics.GetAccuracy();
        if (avgScore <= 0.7f)
        {
            index = 0;
        }
        else if (avgScore <= 0.75f)
        {
            index = 1;
        }
        else if (avgScore <= 0.8f)
        {
            index = 2;
        }
        else if (avgScore <= 0.85f)
        {
            index = 3;
        }
        else
        {
            index = 3;
            for (int i = 4; i < scoreStandard.Length; i++)
            {
                if (score >= scoreStandard[i])
                {
                    index = i;
                }
            }
        }

        return index;
    }
    public void Next()
    {
        typingManager.UpdateTypingGameState(TypingGameState.Summary);
        if(SwitchScene.Instance != null)
            SwitchScene.Instance.DisplayWorkProjectSummary(true);
    }
}
