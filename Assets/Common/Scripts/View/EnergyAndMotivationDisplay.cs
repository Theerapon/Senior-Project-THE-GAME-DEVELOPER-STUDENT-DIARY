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

    private CharacterStats characterStats;

    private void Start()
    {
        characterStats = CharacterStats.Instance;
        characterStats.OnEnergyUpdated.AddListener(OnEnergyHandler);
        characterStats.OnMotivationUpdated.AddListener(OnMotivationHandler);
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
        textMotivation.text = characterStats.GetCurrentMotivation() + " / " + characterStats.GetDEFAULT_MaxMotivation();
    }

    private void OnEnergyHandler()
    {
        imageEnergy.fillAmount = CalculateFillAmountEnergy();
        textEnergy.text = characterStats.GetCurrentEnergy() + " / " + characterStats.GetMaxEnergy();
    }

    private float CalculateFillAmountEnergy()
    {
        return (float)characterStats.GetCurrentEnergy()  / characterStats.GetMaxEnergy();
    }

    private float CalculateFillAmountMotivation()
    {
        return (float)characterStats.GetCurrentMotivation() / characterStats.GetDEFAULT_MaxMotivation();
    }
}
