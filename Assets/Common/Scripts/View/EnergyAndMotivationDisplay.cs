using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class EnergyAndMotivationDisplay : MonoBehaviour
{
    [Header("Energy")]
    [SerializeField] private Image imageEnergy;
    [SerializeField] private TMP_Text textEnergy;

    [Header("Motivation")]
    [SerializeField] private Image imageMotivation;
    [SerializeField] private TMP_Text textMotivation;

    private GameObject found_Player;
    private Characters_Handler chracter_handler;

    private void Start()
    {
        found_Player = GameObject.FindGameObjectWithTag("Player");
        chracter_handler = found_Player.GetComponentInChildren<Characters_Handler>();
        chracter_handler.characterStats.OnEnergyUpdated.AddListener(OnEnergyHandler);
        chracter_handler.characterStats.OnMotivationUpdated.AddListener(OnMotivationHandler);
        Reset();
    }

    private void Reset()
    {
        OnMotivationHandler();
        OnEnergyHandler();
    }

    private void OnMotivationHandler()
    {
        imageMotivation.fillAmount = CalculateFillAmountMotivation();
        textMotivation.text = chracter_handler.characterStats.GetCurrentMotivation() + " / " + chracter_handler.characterStats.GetDEFAULT_MaxMotivation();
    }

    private void OnEnergyHandler()
    {
        imageEnergy.fillAmount = CalculateFillAmountEnergy();
        textEnergy.text = chracter_handler.characterStats.GetCurrentEnergy() + " / " + chracter_handler.characterStats.GetMaxEnergy();
    }

    private float CalculateFillAmountEnergy()
    {
        return (float)chracter_handler.characterStats.GetCurrentEnergy()  / chracter_handler.characterStats.GetMaxEnergy();
    }

    private float CalculateFillAmountMotivation()
    {
        return (float)chracter_handler.characterStats.GetCurrentMotivation() / chracter_handler.characterStats.GetDEFAULT_MaxMotivation();
    }
}
