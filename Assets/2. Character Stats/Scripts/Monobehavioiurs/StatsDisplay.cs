using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatsDisplay : MonoBehaviour
{
    public static StatsDisplay instance;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private GameObject StatsDisplayHolder;
    [SerializeField] private TMP_Text textCoding;
    [SerializeField] private TMP_Text textDesign;
    [SerializeField] private TMP_Text textTesting;
    [SerializeField] private TMP_Text textArt;
    [SerializeField] private TMP_Text textAudio;

    void Start()
    {
        instance = this;   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisplayStats();
        }
    }

    private void SetText()
    {
        textCoding.text = characterStats.GetStatusCoding().ToString();
        textDesign.text = characterStats.GetStatusDesign().ToString();
        textTesting.text = characterStats.GetStatusTest().ToString();
        textArt.text = characterStats.GetStatusArt().ToString();
        textAudio.text = characterStats.GetStatusAudio().ToString();
    }

    void DisplayStats()
    {
        if (StatsDisplayHolder.activeSelf == true)
        {
            StatsDisplayHolder.SetActive(false);
        }
        else
        {
            SetText();
            StatsDisplayHolder.SetActive(true);
        }
    }
}
