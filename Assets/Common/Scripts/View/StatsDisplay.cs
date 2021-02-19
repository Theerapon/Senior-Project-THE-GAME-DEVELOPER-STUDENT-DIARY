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
    [SerializeField] private TMP_Text textAudio;


    protected void Start()
    {
        Debug.Log("Stats Display");
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        MenuManager.Instance.OnStatsShowed.AddListener(HandleStatsShowed);
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
        textCoding.text = characterStats.GetStatusCoding().ToString();
        textDesign.text = characterStats.GetStatusDesign().ToString();
        textTesting.text = characterStats.GetStatusTest().ToString();
        textArt.text = characterStats.GetStatusArt().ToString();
        textAudio.text = characterStats.GetStatusAudio().ToString();
    }

}
