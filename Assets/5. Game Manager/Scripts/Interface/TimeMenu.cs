using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMenu : MonoBehaviour
{
    [SerializeField] private Text dateCalendar;
    [SerializeField] private Text timeCalendar;
    [SerializeField] private Text seasonCalendar;

    void Start()
    {
        TimeManager.Instance.OnDateCalendar.AddListener(HandleOnDateCalendar);
        TimeManager.Instance.OnTimeCalendar.AddListener(HandleOnTimeCalendar);
        TimeManager.Instance.OnSeasonCalendar.AddListener(HandleOnSeasonCalender);
    }

    private void HandleOnSeasonCalender(string season)
    {
        seasonCalendar.text = season.ToUpper();
    }

    private void HandleOnTimeCalendar(string time)
    {
        timeCalendar.text = time.ToUpper();
    }

    private void HandleOnDateCalendar(string date)
    {
        dateCalendar.text = date.ToUpper();
    }

    void Update()
    {
        
    }
}
