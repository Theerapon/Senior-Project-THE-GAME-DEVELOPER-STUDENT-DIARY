using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkProjectSummaryDisplay : MonoBehaviour
{
    [SerializeField] private WorkProjectSummaryManager summaryManager;

    [SerializeField] private TMP_Text workingTimeTMP;
    [SerializeField] private TMP_Text characterLevelTMP;
    [SerializeField] private TMP_Text currentExpTMP;
    [SerializeField] private TMP_Text goalExpTMP;
    [SerializeField] private TMP_Text currentCodingStatusTMP;
    [SerializeField] private TMP_Text currentDesignStatusTMP;
    [SerializeField] private TMP_Text currentTestingStatusTMP;
    [SerializeField] private TMP_Text currentArtStatusTMP;
    [SerializeField] private TMP_Text currentSoundStatusTMP;
    [SerializeField] private TMP_Text currentBugStatusTMP;
    [SerializeField] private TMP_Text efficiencyFormMotivationTMP;
    [SerializeField] private TMP_Text efficiencyBonusTMP;
    [SerializeField] private TMP_Text efficiencySum;
    [SerializeField] private Image fillCharacterExpImage;

    protected void Awake()
    {
        summaryManager.OnProjectSummaryTimeUpdate.AddListener(OnProjectSummaryTimeUpdateHandler);
        summaryManager.OnProjectSummaryTestingStatusUpdate.AddListener(OnProjectSummaryTestingStatusUpdateHandler);
        summaryManager.OnProjectSummarySoundStatusUpdate.AddListener(OnProjectSummarySoundStatusUpdateHandler);
        summaryManager.OnProjectSummaryEfficiencyUpdate.AddListener(OnProjectSummaryEfficiencyUpdateHandler);
        summaryManager.OnProjectSummaryDesignStatusUpdate.AddListener(OnProjectSummaryDesignStatusUpdateHandler);
        summaryManager.OnProjectSummaryCodingStatusUpdate.AddListener(OnProjectSummaryCodingStatusUpdateHandler);
        summaryManager.OnProjectSummaryCharacterLevelUpdate.AddListener(OnProjectSummaryCharacterLevelUpdateHandler);
        summaryManager.OnProjectSummaryCharacterExpUpdate.AddListener(OnProjectSummaryCharacterExpUpdateHandler);
        summaryManager.OnProjectSummaryBugStatusUpdate.AddListener(OnProjectSummaryBugStatusUpdateHandler);
        summaryManager.OnProjectSummaryArtStatusUpdate.AddListener(OnProjectSummaryArtStatusUpdateHandler);
    }

    private void OnProjectSummaryArtStatusUpdateHandler(string value)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummaryBugStatusUpdateHandler(string value)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummaryCharacterExpUpdateHandler(int currentExp, int goalExp)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummaryCharacterLevelUpdateHandler(string level)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummaryCodingStatusUpdateHandler(string value)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummaryDesignStatusUpdateHandler(string value)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummaryEfficiencyUpdateHandler(float efficiencyMotivation, float efficiencyBonus, float efficiencySum)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummarySoundStatusUpdateHandler(string value)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummaryTestingStatusUpdateHandler(string value)
    {
        throw new NotImplementedException();
    }

    private void OnProjectSummaryTimeUpdateHandler(string time)
    {
        throw new NotImplementedException();
    }
}
