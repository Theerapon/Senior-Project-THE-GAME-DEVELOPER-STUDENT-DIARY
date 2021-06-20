using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkProjectSummaryDisplay : MonoBehaviour
{
    [SerializeField] private WorkProjectSummaryManager summaryManager;
    ProjectController projectController;
    TimeManager timeManager;
    CharacterStatusController characterStatusController;
    PlayerAction playerAction;

    private const string goden = "Golden Time";
    private const string normal = "Normal Time";

    [Header("Time Manager")]
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text dateTMP;
    [SerializeField] private TMP_Text timeTMP;
    [SerializeField] private TMP_Text godenTime;

    [Header("Contents")]
    [SerializeField] private TMP_Text projectWorkingTimeTMP;
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
    [SerializeField] private TMP_Text efficiencyMiniGameBonusTMP;
    [SerializeField] private TMP_Text efficiencyBonusTMP;
    [SerializeField] private TMP_Text efficiencySum;
    [SerializeField] private Image fillCharacterExpImage;

    protected void Awake()
    {
        if(TimeManager.Instance != null)
        {
            timeManager = TimeManager.Instance;
            timeManager.OnTimeCalendar.AddListener(OnTimeCalendarHandler);
            timeManager.OnDateCalendar.AddListener(OnDateCalendarHandler);
            timeManager.OnTimeChange.AddListener(OnTimeChangeHandler);
            timeManager.OnGodenTime.AddListener(OnGodenTimeHandler);
            timeManager.ValidationDisplay();
        }

        if(ProjectController.Instance != null)
        {
            projectController = ProjectController.Instance;
            projectController.OnProjectUpdate.AddListener(OnProjectUpdateHandler);
        }

        if(CharacterStatusController.Instance != null)
        {
            characterStatusController = CharacterStatusController.Instance;
            characterStatusController.OnExpUpdated.AddListener(OnExpUpdatedHandler);
            characterStatusController.OnMotivationUpdated.AddListener(OnMotivationUpdatedHandler);
        }

        if (PlayerAction.Instance != null)
        {
            playerAction = PlayerAction.Instance;
        }
        Initializing();
    }

    

    private void Initializing()
    {
        projectWorkingTimeTMP.text = string.Format("{0}", projectController.GetMiniuteTimeToWork());
        efficiencyMiniGameBonusTMP.text = string.Format("{0:p}", projectController.MiniGameBonusEfficiency);
        OnMotivationUpdatedHandler();
        OnExpUpdatedHandler();
        OnProjectUpdateHandler();
    }

    private void OnMotivationUpdatedHandler()
    {
        efficiencyFormMotivationTMP.text = string.Format("{0:p}", characterStatusController.GetEfficiencyToDo());
        SumEfficienc();
    }

    private void SumEfficienc()
    {
        float minigame = projectController.MiniGameBonusEfficiency;
        float skill = playerAction.GetTotalBonusBootupProjectByTime();
        float motivation = characterStatusController.GetEfficiencyToDo();
        efficiencySum.text = string.Format("{0:p}", minigame + skill + motivation);
    }

    private void OnExpUpdatedHandler()
    {
        fillCharacterExpImage.fillAmount = (float) characterStatusController.CurrentExp / characterStatusController.GetNextExpRequire();
        goalExpTMP.text = string.Format("{0}", characterStatusController.GetNextExpRequire());
        currentExpTMP.text = string.Format("{0}", characterStatusController.CurrentExp);
        characterLevelTMP.text = string.Format("{0}", characterStatusController.CurrentLevel);
        efficiencyBonusTMP.text = string.Format("{0:p}", playerAction.GetTotalBonusBootupProjectByTime());
        SumEfficienc();
    }

    private void OnProjectUpdateHandler()
    {
        currentArtStatusTMP.text = string.Format("{0}", projectController.CurrentArtStatus);
        currentBugStatusTMP.text = string.Format("{0}", projectController.CurrentBugStatus);
        currentCodingStatusTMP.text = string.Format("{0}", projectController.CurrentCodingStatus);
        currentDesignStatusTMP.text = string.Format("{0}", projectController.CurrentDesignStatus);
        currentSoundStatusTMP.text = string.Format("{0}", projectController.CurrentSoundStatus);
        currentTestingStatusTMP.text = string.Format("{0}", projectController.CurrentTestingStatus);
    }


    #region Time Manager
    private void OnGodenTimeHandler(bool isTime)
    {
        if (isTime)
        {
            godenTime.text = goden;
        }
        else
        {
            godenTime.text = normal;
        }
    }

    private void OnTimeChangeHandler(bool day)
    {
        if (day)
        {
            icon.sprite = timeManager.DayImage;
        }
        else
        {
            icon.sprite = timeManager.NightImage;
        }
    }

    private void OnDateCalendarHandler(string date)
    {
        dateTMP.text = timeManager.GetOnDate();
    }

    private void OnTimeCalendarHandler(string time)
    {
        timeTMP.text = timeManager.GetOnTime();
    }
    #endregion
}
