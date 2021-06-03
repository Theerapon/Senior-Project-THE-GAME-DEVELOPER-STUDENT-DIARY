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
    private CharacterStatusController chracter_status;

    private void Start()
    {
        found_Player = GameObject.FindGameObjectWithTag("Player");
        chracter_status = CharacterStatusController.Instance;
        chracter_status.OnEnergyUpdated.AddListener(OnEnergyHandler);
        chracter_status.OnMotivationUpdated.AddListener(OnMotivationHandler);
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
        textMotivation.text = chracter_status.CurrentMotivation + " / " + chracter_status.Default_maxMotivation;
    }

    private void OnEnergyHandler()
    {
        imageEnergy.fillAmount = CalculateFillAmountEnergy();
        textEnergy.text = chracter_status.CurrentEnergy + " / " + chracter_status.Default_maxEnergy;
    }

    private float CalculateFillAmountEnergy()
    {
        return (float)chracter_status.CurrentEnergy  / chracter_status.Default_maxEnergy;
    }

    private float CalculateFillAmountMotivation()
    {
        return (float)chracter_status.CurrentMotivation / chracter_status.Default_maxMotivation;
    }
}
