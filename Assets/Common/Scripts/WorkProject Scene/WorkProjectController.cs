using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkProjectController : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject lockObj;
    [SerializeField] private GameObject docObj;
    [SerializeField] private GameObject workingObj;
    [SerializeField] private GameObject canvas;

    [Header("Buttons")]
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color highlightColor;
    [SerializeField] private Color lockColor;

    private const int INST_CharacterLevelRequire_High = 12;
    private const int INST_CharacterLevelRequire_Medium = 8;
    private const int INST_CharacterLevelRequire_Low = 4;
    private const int maxTimeSelectHigh = 5;
    private const int maxTimeSelectMedium = 4;
    private const int maxTimeSelectLow = 3;
    private const int maxTimeSelectDefault = 2;
    private const int Halfhour_seccond = 1800;
    private const int hour_seccond = 3600;
    private const int twoHours_seccond = 7200;
    private const int fourHours_seccond = 14400;
    private const int eightHours_seccond = 28800;

    private float totalEnergy;
    private int totalSecond;

    [Header("WorkProject Display")]
    [SerializeField] private WorkProjectDisplay workProjectDisplay;

    private TimeManager timeManager;
    private ProjectController projectController;
    private CharacterStatusController characterStatusController;
    private GameObject foundNotificationControllerObject;
    private NotificationController notificationController;
    private ClassActivityController classActivityController;

    private void Awake()
    {
        classActivityController = ClassActivityController.Instance;
        projectController = ProjectController.Instance;
        characterStatusController = CharacterStatusController.Instance;
        timeManager = TimeManager.Instance;
        foundNotificationControllerObject = GameObject.FindGameObjectWithTag("NotificationController");
        notificationController = foundNotificationControllerObject.GetComponentInChildren<NotificationController>();

    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        Initializing();
    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.WORK_PROJECT)
        {
            DisplayCanvas(true);
        }
        else
        {
            DisplayCanvas(false);
        }
    }

    private void Initializing()
    {
        workProjectDisplay.Initializing();

        if (!projectController.ProjectIsNull)
        {
            if (projectController.HasDesigned)
            {
                DisplayDocument(true);
            }
            else
            {
                DisplayDocument(false);
            }
            
            if(projectController.ProjectPhase == ProjectPhase.Decision)
            {
                DisplayWorking(false);
            }
            else
            {
                DisplayWorking(true);
                LockBotton(GetMaxTimeCanSelect());
                SelectTime(0);
            }
        }
        else
        {
            DisplayDocument(false);
            DisplayWorking(false);
        }
    }

    private void DisplayDocument(bool active)
    {
        docObj.SetActive(active);
        lockObj.SetActive(!active);
    }

    private void DisplayWorking(bool active)
    {
        workingObj.SetActive(active);
    }
    
    public void SelectTime(int choice)
    {
        int second = 0;
        switch (choice)
        {
            case 0:
                second = eightHours_seccond;
                break;
            case 1:
                second = fourHours_seccond;
                break;
            case 2:
                second = twoHours_seccond;
                break;
            case 3:
                second = hour_seccond;
                break;
            case 4:
                second = Halfhour_seccond;
                break;
            default:
                second = eightHours_seccond;
                break;
        }

        totalSecond = second;
        OnButtonClicked(choice, GetMaxTimeCanSelect(), second);
    }
    public void Working()
    {
        bool time = CheckTimeToAction(totalSecond);
        bool energy = CheckEnergyToAction(totalEnergy);
        bool timeOnProjectDay = CheckTimeForProjectDay(totalSecond);

        if (!time)
        {
            notificationController.TimeNotEnoughForWork();
        }
        else if (!energy)
        {
            notificationController.EnergyNotEnoughForWork();
        }
        else if (!timeOnProjectDay)
        {
            notificationController.TimeNotEnoughForWorkOnProjectDay();
        }
        else
        {
            projectController.SecondToWork = totalSecond;

            switch (projectController.ProjectPhase)
            {
                case ProjectPhase.Design:
                    if (projectController.HasDesigned)
                    {
                        SwitchScene.Instance.DisplayWorkTypingGmae(true);
                    }
                    else
                    {
                        SwitchScene.Instance.DisplayWorkProjectDesign(true);
                    }

                    break;
                case ProjectPhase.FirstPlayable:
                    if (projectController.HasDesigned)
                    {
                        SwitchScene.Instance.DisplayWorkTypingGmae(true);
                    }
                    break;
                case ProjectPhase.Prototype:
                    if (projectController.HasDesigned)
                    {
                        SwitchScene.Instance.DisplayWorkTypingGmae(true);
                    }
                    break;
                case ProjectPhase.VerticalSlice:
                    if (projectController.HasDesigned)
                    {
                        SwitchScene.Instance.DisplayWorkTypingGmae(true);
                    }
                    break;
                case ProjectPhase.AlphaTest:
                    if (projectController.HasDesigned)
                    {
                        SwitchScene.Instance.DisplayAlphaTypingGmae(true);
                    }
                    break;
                case ProjectPhase.BetaTest:
                    if (projectController.HasDesigned)
                    {
                        SwitchScene.Instance.DisplayBetaTypingGmae(true);
                    }
                    break;
                case ProjectPhase.Master:
                    if (projectController.HasDesigned)
                    {
                        int rnd = UnityEngine.Random.Range(0, 3);
                        if (rnd >= 2)
                        {
                            SwitchScene.Instance.DisplayWorkTypingGmae(true);
                        }
                        else if (rnd >= 1)
                        {
                            SwitchScene.Instance.DisplayAlphaTypingGmae(true);
                        }
                        else
                        {
                            SwitchScene.Instance.DisplayBetaTypingGmae(true);
                        }

                    }
                    break;
            }
        }



    }

    private bool CheckTimeForProjectDay(int totalSecond)
    {
        if (timeManager.HasTimeEnough(totalSecond) && classActivityController.HasEvent() && classActivityController.TimeEnoughForActivity(totalSecond))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckTimeToAction(int totalSecond)
    {
        if (timeManager.HasTimeEnough(totalSecond))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CheckEnergyToAction(float energyToConsume)
    {
        if (characterStatusController.CurrentEnergy >= energyToConsume)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void LockBotton(int maxLevelCanselect)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < maxLevelCanselect)
            {
                buttons[i].transform.GetComponentInChildren<TMP_Text>().enabled = true;
                buttons[i].transform.GetChild(1).GetComponentInChildren<Image>().enabled = false;

                if (i == 0)
                {
                    buttons[i].transform.GetComponent<Image>().color = highlightColor;
                    buttons[i].transform.GetComponent<Button>().interactable = false;
                    buttons[i].transform.GetComponentInChildren<TMP_Text>().color = highlightColor;
                }
                else
                {
                    buttons[i].transform.GetComponent<Image>().color = normalColor;
                    buttons[i].transform.GetComponent<Button>().interactable = true;
                    buttons[i].transform.GetComponentInChildren<TMP_Text>().color = normalColor;
                }
            }
            else
            {
                buttons[i].transform.GetComponent<Image>().color = lockColor;
                buttons[i].transform.GetComponent<Button>().interactable = false;
                buttons[i].transform.GetComponentInChildren<TMP_Text>().enabled = false;
                buttons[i].transform.GetChild(1).GetComponentInChildren<Image>().enabled = true;
                buttons[i].transform.GetChild(1).GetComponentInChildren<Image>().color = lockColor;
            }

        }
    }

    private int GetMaxTimeCanSelect()
    {
        int amountCanselect = 0;
        if (characterStatusController.CurrentLevel >= INST_CharacterLevelRequire_High)
        {
            amountCanselect = maxTimeSelectHigh;
        }
        else if (characterStatusController.CurrentLevel >= INST_CharacterLevelRequire_Medium)
        {
            amountCanselect = maxTimeSelectMedium;
        }
        else if (characterStatusController.CurrentLevel >= INST_CharacterLevelRequire_Low)
        {
            amountCanselect = maxTimeSelectLow;
        }
        else
        {
            amountCanselect = maxTimeSelectDefault;
        }
        return amountCanselect;
    }

    private void SetAllButtonsInteractable(int index, int maxLevelCanselect)
    {

        for (int i = 0; i < maxLevelCanselect; i++)
        {
            if (i < maxLevelCanselect)
            {
                if (i == index)
                {
                    buttons[i].transform.GetComponent<Image>().color = highlightColor;
                    buttons[i].transform.GetComponent<Button>().interactable = false;
                    buttons[i].transform.GetComponentInChildren<TMP_Text>().color = highlightColor;
                }
                else
                {
                    buttons[i].transform.GetComponent<Image>().color = normalColor;
                    buttons[i].transform.GetComponent<Button>().interactable = true;
                    buttons[i].transform.GetComponentInChildren<TMP_Text>().color = normalColor;
                }
            }

        }

    }

    private void OnButtonClicked(int index, int maxLevelCanselect, int seccond)
    {
        if (index == -1)
            return;

        CalEnergy(seccond);
        CalEfficiency(seccond);
        SetAllButtonsInteractable(index, maxLevelCanselect);
    }

    private void CalEnergy(int seccond)
    {
        float energy = projectController.CalTotalEnergyToConsumeByTime(seccond);
        this.totalEnergy = energy;
        workProjectDisplay.DisplayEnergy(energy);
    }

    private void CalEfficiency(int seccond)
    {
        float avgEfficiency = projectController.CalAvgEfficiencyByTime(seccond);

        workProjectDisplay.DisplayEfficiency(avgEfficiency);
    }

    private void DisplayCanvas(bool active)
    {
        canvas.SetActive(active);
        if (active)
        {
            Initializing();
        }
    }

}
