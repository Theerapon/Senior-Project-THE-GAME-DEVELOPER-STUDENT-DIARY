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

    private CharacterStatus character_status;
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

        character_status = CharacterStatus.Instance;
        
        if(!ReferenceEquals(character_status, null))
        {
            character_status.OnEnergyUpdated.AddListener(EnergyHandler);
            character_status.OnMotivationUpdated.AddListener(MotivationHandler);
            character_status.OnMoneyUpdated.AddListener(MoneyHandler);
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
        money.text = character_status.GetCurrentMoney().ToString();
    }

    private void MotivationHandler()
    {
        motivation_bar.fillAmount = CalculateFillAmountMotivation();
    }

    private float CalculateFillAmountMotivation()
    {
        return (float)character_status.GetCurrentMotivation() / character_status.GetDEFAULT_MaxMotivation();
    }

    private void EnergyHandler()
    {
        energy_bar.fillAmount = CalculateFillAmountEnergy();
    }

    private float CalculateFillAmountEnergy()
    {
        return (float)character_status.GetCurrentEnergy() / character_status.GetMaxEnergy();
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
