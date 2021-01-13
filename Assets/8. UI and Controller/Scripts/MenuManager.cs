using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    #region Inventory
    [SerializeField] private GameObject _inventory = null;
    #endregion

    [Header("Stats")]
    #region Stats
    [SerializeField] private CharacterStats _characterStats = null;
    [SerializeField] private GameObject _StatsDisplayHolder = null;
    [SerializeField] private TMP_Text stats_textCoding = null;
    [SerializeField] private TMP_Text stats_textDesign = null;
    [SerializeField] private TMP_Text stats_textTesting = null;
    [SerializeField] private TMP_Text stats_textArt = null;
    [SerializeField] private TMP_Text stats_textAudio = null;
    #endregion

    [Header("Skills")]
    #region Skills
    [SerializeField] private GameObject _skills = null;
    #endregion

    private GameObject preDisplay;

    private void Start()
    {
    }

    void Update()
    {
        
    }

    public void DisplayInventory()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.PAUSE)
        {
            if (_inventory.activeSelf == false)
            {
                preDisplay.SetActive(false);
                _inventory.SetActive(true);
                preDisplay = _inventory;
            }
        }

    }

    #region Stats Display
    public void DisplayStats()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.PAUSE)
        {
            if (_StatsDisplayHolder.activeSelf == false)
            {
                preDisplay.SetActive(false);
                _StatsDisplayHolder.SetActive(true);
                preDisplay = _StatsDisplayHolder;
                SetText();
            }
        }
    }

    private void SetText()
    {
        stats_textCoding.text = _characterStats.GetStatusCoding().ToString();
        stats_textDesign.text = _characterStats.GetStatusDesign().ToString();
        stats_textTesting.text = _characterStats.GetStatusTest().ToString();
        stats_textArt.text = _characterStats.GetStatusArt().ToString();
        stats_textAudio.text = _characterStats.GetStatusAudio().ToString();
    }
    #endregion


    public void DisplaySkills()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.PAUSE)
        {
            if (_skills.activeSelf == false)
            {
                preDisplay.SetActive(false);
                _skills.SetActive(true);
                preDisplay = _skills;
            }
        }


    }

    public void Reset()
    {
        _inventory.SetActive(true);
        _StatsDisplayHolder.SetActive(false);
        _skills.SetActive(false);
        preDisplay = _inventory;
        DisplayInventory();
    }
}
