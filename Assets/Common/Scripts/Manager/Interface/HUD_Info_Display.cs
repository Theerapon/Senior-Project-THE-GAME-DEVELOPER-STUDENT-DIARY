using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD_Info_Display : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private TMP_Text dateCalendar;
    [SerializeField] private TMP_Text timeCalendar;
    [SerializeField] private Image icon;

    [Header("Energy and Motivation")]
    [SerializeField] private Image energy_bar;
    [SerializeField] private Image motivation_bar;

    [Header("Money")]
    [SerializeField] private TMP_Text money;

    [Header("Resourse")]
    [SerializeField] private Sprite image_day;
    [SerializeField] private Sprite image_night;

    private CharacterStatusController characterStatusController;
    private TimeManager timeManager;

    protected void Start()
    {
        timeManager = TimeManager.Instance;
        if (!ReferenceEquals(timeManager, null))
        {
            timeManager.OnDateCalendar.AddListener(HandleOnDateCalendar);
            timeManager.OnTimeCalendar.AddListener(HandleOnTimeCalendar);
            timeManager.OnTimeChange.AddListener(HandlerTimeChange);
            timeManager.NotificationAll();
        }

        characterStatusController = CharacterStatusController.Instance;
        
        if(!ReferenceEquals(characterStatusController, null))
        {
            characterStatusController.characterStatus.OnEnergyUpdated.AddListener(EnergyHandler);
            characterStatusController.characterStatus.OnMotivationUpdated.AddListener(MotivationHandler);
            characterStatusController.characterStatus.OnMoneyUpdated.AddListener(MoneyHandler);
        }

        Reset();
    }

    

    private void Reset()
    {
        MoneyHandler();
        MotivationHandler();
        EnergyHandler();
    }

    private void MoneyHandler()
    {
        money.text = characterStatusController.characterStatus.ToString();
    }

    private void MotivationHandler()
    {
        motivation_bar.fillAmount = CalculateFillAmountMotivation();
    }

    private float CalculateFillAmountMotivation()
    {
        return (float)characterStatusController.characterStatus.CurrentMotivation / characterStatusController.characterStatus.Default_maxMotivation;
    }

    private void EnergyHandler()
    {
        energy_bar.fillAmount = CalculateFillAmountEnergy();
    }

    private float CalculateFillAmountEnergy()
    {
        return (float)characterStatusController.characterStatus.CurrentEnergy / characterStatusController.characterStatus.Default_maxEnergy;
    }

    private void HandlerTimeChange(bool isDay)
    {
        if (isDay)
        {
            icon.sprite = image_day;
        }
        else
        {
            icon.sprite = image_night;
        }
    }

    private void HandleOnTimeCalendar(string time)
    {
        timeCalendar.text = time.ToUpper();
    }

    private void HandleOnDateCalendar(string date)
    {
        dateCalendar.text = date.ToUpper();
    }

}
