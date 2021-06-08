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

    [Header("WorkProject Display")]
    [SerializeField] private WorkProjectDisplay workProjectDisplay;

    private ProjectController projectController;
    private CharacterStatusController characterStatusController;

    private void Awake()
    {
        projectController = ProjectController.Instance;
        characterStatusController = CharacterStatusController.Instance;
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
        int seccond = 0;
        switch (choice)
        {
            case 0:
                seccond = eightHours_seccond;
                break;
            case 1:
                seccond = fourHours_seccond;
                break;
            case 2:
                seccond = twoHours_seccond;
                break;
            case 3:
                seccond = hour_seccond;
                break;
            case 4:
                seccond = Halfhour_seccond;
                break;
            default:
                seccond = eightHours_seccond;
                break;
        }

        OnButtonClicked(choice, GetMaxTimeCanSelect(), seccond);
    }
    public void Working()
    {
        switch (projectController.ProjectPhase)
        {
            case ProjectPhase.Design:
                SwitchScene.Instance.DisplayWorkProjectDesign(true);
                break;
            case ProjectPhase.FirstPlayable:
                break;
            case ProjectPhase.Prototype:
                break;
            case ProjectPhase.VerticalSlice:
                break;
            case ProjectPhase.AlphaTest:
                break;
            case ProjectPhase.BetaTest:
                break;
            case ProjectPhase.Master:
                break;
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
        int times = seccond / Halfhour_seccond;
        int baseEnergy = projectController.BaseEnergyConsumePer30Minute;
        float energy = 0;
        float value = 1f;
        for (int i = 0; i < times; i++)
        {
            energy += baseEnergy * value;
            if (i % 2 == 0)
            {
                value -= 0.045f;
            }
        }
        workProjectDisplay.DisplayEnergy((int)Math.Round(energy + 0.005f));
    }

    private void CalEfficiency(int seccond)
    {
        int times = seccond / Halfhour_seccond;
        int currentMotivation = characterStatusController.CurrentMotivation;

        int motivationConsume = projectController.BaseMotivationConsumePer30Minute;
        
        float[] tempMotivationCalculated = new float[times];
        for(int i = 0; i < tempMotivationCalculated.Length; i++)
        {
            tempMotivationCalculated[i] = characterStatusController.CalMotivation(currentMotivation);
            if(currentMotivation - motivationConsume <= 0)
            {
                currentMotivation = 0;
            }
            else
            {
                currentMotivation -= motivationConsume;
            }
        }

        float sumCalculated = 0;
        foreach(int motivationCalculated in tempMotivationCalculated)
        {
            sumCalculated += motivationCalculated;
        }
        float avgMotivationCalculated = (sumCalculated / tempMotivationCalculated.Length);
        avgMotivationCalculated = (float) Math.Round((avgMotivationCalculated + 0.005f), 2);

        workProjectDisplay.DisplayEfficiency(avgMotivationCalculated);
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
