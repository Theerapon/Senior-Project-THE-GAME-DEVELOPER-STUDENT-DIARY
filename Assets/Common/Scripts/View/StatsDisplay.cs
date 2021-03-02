using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private TMP_Text textCoding;
    [SerializeField] private TMP_Text textDesign;
    [SerializeField] private TMP_Text textTesting;
    [SerializeField] private TMP_Text textArt;
    [SerializeField] private TMP_Text textSound;


    protected void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        MenuInGameManager.Instance.OnStatsShowed.AddListener(HandleStatsShowed);
    }

    private void HandleStatsShowed()
    {
        SetText();
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        
    }

    void Update()
    {
        
    }

    private void SetText()
    {
        textCoding.text = characterStats.GetCodingStatus().ToString();
        textDesign.text = characterStats.GetDesignStatus().ToString();
        textTesting.text = characterStats.GetTestStatus().ToString();
        textArt.text = characterStats.GetArtStatus().ToString();
        textSound.text = characterStats.GetSoundStatus().ToString();
    }

}
