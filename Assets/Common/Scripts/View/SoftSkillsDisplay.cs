using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SoftSkillsDisplay : MonoBehaviour
{
    [Header("Character Stats")]
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private TMP_Text softSkillPoint;

    [Header("Communication")]
    [SerializeField] private Communication communication;
    [SerializeField] private TMP_Text communicationNameText;
    [SerializeField] private Transform communicationDetail;
    private Image[] communicationDisplay;
    [SerializeField] private TMP_Text communicationLevelText;

    [Header("Critical Thinking")]
    [SerializeField] private CriticalThinking criticalThinking;
    [SerializeField] private TMP_Text criticalThinkingNameText;
    [SerializeField] private Transform criticalThinkingDetail;
    private Image[] criticalThinkingDisplay;
    [SerializeField] private TMP_Text criticalThinkingLevelText;

    [Header("Leadership")]
    [SerializeField] private Leadership leadership;
    [SerializeField] private TMP_Text leadershipNameText;
    [SerializeField] private Transform leadershipDetail;
    private Image[] leadershipDisplay;
    [SerializeField] private TMP_Text leadershipLevelText;

    [Header("Time Management")]
    [SerializeField] private TimeManagement timeManagement;
    [SerializeField] private TMP_Text timeManagementNameText;
    [SerializeField] private Transform timeManagementDetail;
    private Image[] timeManagementDisplay;
    [SerializeField] private TMP_Text timeManagementLevelText;

    [Header("Work Ethic")]
    [SerializeField] private WorkEthic workEthic;
    [SerializeField] private TMP_Text workEthicNameText;
    [SerializeField] private Transform workEthicDetail;
    private Image[] workEthicDisplay;
    [SerializeField] private TMP_Text workEthicLevelText;



    protected void Start()
    {
        MenuManager.Instance.OnSoftSKillsShowed.AddListener(HandleSkillsShowed);
        communicationDisplay = communicationDetail.GetComponentsInChildren<Image>();
        criticalThinkingDisplay = criticalThinkingDetail.GetComponentsInChildren<Image>();
        leadershipDisplay = leadershipDetail.GetComponentsInChildren<Image>();
        timeManagementDisplay = timeManagementDetail.GetComponentsInChildren<Image>();
        workEthicDisplay = workEthicDetail.GetComponentsInChildren<Image>();
    }

    private void HandleSkillsShowed()
    {
        SetPoints();
        SetName();
        SetLevel();
    }

    private void SetLevel()
    {
        communicationLevelText.text = communication.GetCurrentSoftSkillLevel().ToString();
        criticalThinkingLevelText.text = criticalThinking.GetCurrentSoftSkillLevel().ToString();
        leadershipLevelText.text = leadership.GetCurrentSoftSkillLevel().ToString();
        timeManagementLevelText.text = timeManagement.GetCurrentSoftSkillLevel().ToString();
        workEthicLevelText.text = workEthic.GetCurrentSoftSkillLevel().ToString();
    }

    private void SetPoints()
    {
        softSkillPoint.text = characterStats.GetSoftSkillPoints().ToString();
    }

    private void SetName()
    {
        communicationNameText.text = communication.GetName();
        criticalThinkingNameText.text = criticalThinking.GetName();
        leadershipNameText.text = leadership.GetName();
        timeManagementNameText.text = timeManagement.GetName();
        workEthicNameText.text = workEthic.GetName();
    }



}
