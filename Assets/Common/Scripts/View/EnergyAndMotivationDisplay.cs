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
    private CharacterStatusController characterStatusController;

    private void Start()
    {
        found_Player = GameObject.FindGameObjectWithTag("Player");
        characterStatusController = CharacterStatusController.Instance;
        characterStatusController.OnEnergyUpdated.AddListener(OnEnergyHandler);
        characterStatusController.OnMotivationUpdated.AddListener(OnMotivationHandler);
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
        textMotivation.text = characterStatusController.CurrentMotivation + " / " + characterStatusController.Default_maxMotivation;
    }

    private void OnEnergyHandler()
    {
        imageEnergy.fillAmount = CalculateFillAmountEnergy();
        textEnergy.text = characterStatusController.CurrentEnergy + " / " + characterStatusController.Default_maxEnergy;
    }

    private float CalculateFillAmountEnergy()
    {
        return (float)characterStatusController.CurrentEnergy  / characterStatusController.Default_maxEnergy;
    }

    private float CalculateFillAmountMotivation()
    {
        return (float)characterStatusController.CurrentMotivation / characterStatusController.Default_maxMotivation;
    }
}
