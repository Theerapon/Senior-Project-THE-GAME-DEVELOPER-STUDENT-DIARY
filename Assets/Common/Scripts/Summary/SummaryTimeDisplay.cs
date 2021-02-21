using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SummaryTimeDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text dateCalendar;
    [SerializeField] private TMP_Text timeCalendar;
    [SerializeField] private TMP_Text seasonCalendar;
    [SerializeField] private TMP_Text totalTime;

    private CharacterStats characterStats;

    protected void Start()
    {
        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.OnDateCalendar.AddListener(HandleOnDateCalendar);
            TimeManager.Instance.OnTimeCalendar.AddListener(HandleOnTimeCalendar);
            TimeManager.Instance.OnSeasonCalendar.AddListener(HandleOnSeasonCalender);
            TimeManager.Instance.ValidationDisplay();
        }

        if(CharacterStats.Instance != null)
        {
            characterStats = CharacterStats.Instance;
            SetTotalTime();
        }

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

    private void SetTotalTime()
    {
        if (characterStats.GetSleepFullTimeSelected())
        {
            totalTime.text = characterStats.GetFullTimeSleepText();
        } else
        {
            totalTime.text = characterStats.GetTwoThirdSleepText();
        }
    }
}
