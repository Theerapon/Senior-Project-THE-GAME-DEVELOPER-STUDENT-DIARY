﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : Manager<MenuManager>
{
    #region Events
    public Events.EventStatsValueShowed OnStatsShowed;
    public Events.EventSoftSkillsValueShowed OnSoftSKillsShowed;
    public Events.EventHardSkillsValueShowed OnHardSkillsShowed;
    #endregion

    #region Inventory
    [Header("Inventory")]
    [SerializeField] private GameObject _inventory = null;
    #endregion

    #region Stats
    [Header("Stats")]
    [SerializeField] private GameObject _StatsDisplayHolder = null;
    #endregion

    #region Skills
    [Header("Skills")]
    [SerializeField] private GameObject _skills = null;
    #endregion

    #region Bonus
    [Header("Bonus")]
    [SerializeField] private GameObject _bonus = null;
    #endregion

    private GameObject preDisplay;


    #region Display
    public void DisplayInventory()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.DISPLAYMENU)
        {
            if (_inventory.activeSelf == false && _inventory != null)
            {
                preDisplay.SetActive(false);
                _inventory.SetActive(true);
                preDisplay = _inventory;
            }
        }

    }
    public void DisplayStats()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.DISPLAYMENU)
        {
            if (_StatsDisplayHolder.activeSelf == false && _StatsDisplayHolder != null)
            {
                OnStatsShowed?.Invoke();
                preDisplay.SetActive(false);
                _StatsDisplayHolder.SetActive(true);
                preDisplay = _StatsDisplayHolder;
                
            }
        }
    }
    public void DisplaySkills()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.DISPLAYMENU)
        {
            if (_skills.activeSelf == false && _skills != null)
            {
                OnHardSkillsShowed?.Invoke();
                preDisplay.SetActive(false);
                _skills.SetActive(true);
                preDisplay = _skills;
            }
        }


    }
    public void DisplayBonus()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.DISPLAYMENU)
        {
            if (_bonus.activeSelf == false && _bonus != null)
            {
                OnSoftSKillsShowed?.Invoke();
                preDisplay.SetActive(false);
                _bonus.SetActive(true);
                preDisplay = _bonus;
            }
        }


    }
    #endregion

    public void Reset()
    {
        if(_inventory != null && _StatsDisplayHolder != null && _skills != null && _bonus != null)
        {
            _inventory.SetActive(true);
            _StatsDisplayHolder.SetActive(false);
            _skills.SetActive(false);
            _bonus.SetActive(false);
            preDisplay = _inventory;
            DisplayInventory();
        }
    }
}
