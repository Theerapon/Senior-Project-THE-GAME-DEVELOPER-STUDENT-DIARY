using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WorkTypingManager;

public class WorkTypingSummaryHandler : MonoBehaviour
{
    private readonly float[] bonusEfficiency = { -0.5f, -0.1f, 0.1f, 0.15f, 0.2f, 0.35f, 0.5f, 0.7f, 1f, 1.5f, 2f, 3f};
    private readonly int[] scoreStandard = { 0,  0, 0, 0, 25000, 45000, 80000, 156000, 450000, 600000, 1000000, 2000000, };
    private int indexOfEfficiency;


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
    [SerializeField] private TMP_Text efficiencyBonus;

    private void Awake()
    {
        typingManager.OnTypingGameStateChanged.AddListener(OnTypingGameStateChangedHandler);
    }



    private void OnTypingGameStateChangedHandler(WorkTypingManager.TypingGameState state)
    {
        if (state == WorkTypingManager.TypingGameState.PostGame)
        {
            indexOfEfficiency = CalculateIndexOfEfficiency();
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
        efficiencyBonus.text = string.Format("{0:p0}", bonusEfficiency[indexOfEfficiency]);
        if (ProjectController.Instance != null)
            ProjectController.Instance.MiniGameBonusEfficiency = bonusEfficiency[indexOfEfficiency];
    }

    private int CalculateIndexOfEfficiency()
    {
        int index = 0;
        int score = playerManager.Score;
        int correct = wordStatistics.CorrectWord;
        int incorrect = wordStatistics.IncoreectWord;
        int goodIdea = playerManager.WordGoodIdea;
        int badIdea = playerManager.WordBadIdea;
        int maxCombo = playerManager.MaxCombo;
        int standardScore = (((correct + incorrect) + (goodIdea + badIdea)) + playerManager.CountCombo[playerManager.MaxComboPhase - 1]);
        int recieveScore = ((correct + goodIdea + maxCombo)  - ((incorrect + badIdea) * 5));
        float avgScore = (float) recieveScore / standardScore;
        if(avgScore <= 0.5f)
        {
            index = 0;
        }
        else if(avgScore <= 0.6f)
        {
            index = 1;
        }
        else if (avgScore <= 0.7f)
        {
            index = 2;
        }
        else if (avgScore <= 0.8f)
        {
            index = 3;
        }
        else
        {
            index = 3;
            for (int i = 4; i < scoreStandard.Length; i++)
            {
                if(score >= scoreStandard[i])
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
        if (SwitchScene.Instance != null)
            SwitchScene.Instance.DisplayWorkProjectSummary(true);
    }
}
