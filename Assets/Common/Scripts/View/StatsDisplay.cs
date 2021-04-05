using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsDisplay : MonoBehaviour
{
    [Header("Stats")]
    private CharacterStatus characterStats;
    [SerializeField] private TMP_Text textCoding;
    [SerializeField] private TMP_Text textDesign;
    [SerializeField] private TMP_Text textTesting;
    [SerializeField] private TMP_Text textArt;
    [SerializeField] private TMP_Text textSound;

    [Header("Stats Point")]
    [SerializeField] private TMP_Text textStatPoints;

    [Header("Up Stats")]
    [SerializeField] private TMP_Text valueUpstatCoding;
    [Space]
    [SerializeField] private TMP_Text valueUpstatDesign;
    [Space]
    [SerializeField] private TMP_Text valueUpstatTesting;
    [Space]
    [SerializeField] private TMP_Text valueUpstatArt;
    [Space]
    [SerializeField] private TMP_Text valueUpstatSound;

    private GameObject found_Player;
    private Characters_Handler chracter_handler;
    private PlayerAction playerAction;

    protected void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        //MenuInGameManager.Instance.OnStatsShowed.AddListener(HandleStatsShowed);

        found_Player = GameObject.FindGameObjectWithTag("Player");
        playerAction = found_Player.GetComponentInChildren<PlayerAction>();
        chracter_handler = found_Player.GetComponentInChildren<Characters_Handler>();
    }

    private void HandleStatsShowed()
    {
        SetText();
        SetTextUpStats();
    }

    private void SetTextUpStats()
    {
        
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        
    }


    private void SetText()
    {
        textCoding.text = string.Format("{0} ({1} + {2})", (characterStats.GetCodingStatus() + playerAction.GetBonusCodingStatus()), characterStats.GetCodingStatus(), playerAction.GetBonusCodingStatus()); 
        textDesign.text = string.Format("{0} ({1} + {2})", (characterStats.GetDesignStatus() + playerAction.GetBonusDesignStatus()), characterStats.GetDesignStatus(), playerAction.GetBonusDesignStatus());
        textTesting.text = string.Format("{0} ({1} + {2})", (characterStats.GetTestStatus() +  playerAction.GetBonusTestingStatus()), characterStats.GetTestStatus(), playerAction.GetBonusTestingStatus());
        textArt.text = string.Format("{0} ({1} + {2})", (characterStats.GetArtStatus() + playerAction.GetBonusArtStatus()), characterStats.GetArtStatus(), playerAction.GetBonusArtStatus());
        textSound.text = string.Format("{0} ({1} + {2})", (characterStats.GetSoundStatus() + playerAction.GetBonusSoundStatus()), characterStats.GetSoundStatus(), playerAction.GetBonusSoundStatus());

        textStatPoints.text = characterStats.GetPointStatus().ToString();
    }

}
