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
        characterStatusController.CharacterStatus.OnEnergyUpdated.AddListener(OnEnergyHandler);
        characterStatusController.CharacterStatus.OnMotivationUpdated.AddListener(OnMotivationHandler);
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
        textMotivation.text = characterStatusController.CharacterStatus.CurrentMotivation + " / " + characterStatusController.CharacterStatus.Default_maxMotivation;
    }

    private void OnEnergyHandler()
    {
        imageEnergy.fillAmount = CalculateFillAmountEnergy();
        textEnergy.text = characterStatusController.CharacterStatus.CurrentEnergy + " / " + characterStatusController.CharacterStatus.Default_maxEnergy;
    }

    private float CalculateFillAmountEnergy()
    {
        return (float)characterStatusController.CharacterStatus.CurrentEnergy  / characterStatusController.CharacterStatus.Default_maxEnergy;
    }

    private float CalculateFillAmountMotivation()
    {
        return (float)characterStatusController.CharacterStatus.CurrentMotivation / characterStatusController.CharacterStatus.Default_maxMotivation;
    }
}
