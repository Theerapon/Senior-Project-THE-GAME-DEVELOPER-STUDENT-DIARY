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

    private GameObject foundPlayerAction;
    private PlayerAction playerAction;
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

        characterStats = CharacterStats.Instance;
        foundPlayerAction = GameObject.FindGameObjectWithTag("Player");
        playerAction = foundPlayerAction.GetComponent<PlayerAction>();
        SetTotalTime();

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
        //time manager set text from total second that recive pass Player Action acconding  to time seleced between Full Time or Tow Third Time
        string str = string.Format("Total second {0}", TimeManager.Instance.GetSecondText(playerAction.GetCalculateSleepTimeSecond(characterStats.GetSleepFullTimeSelected())));
        totalTime.text = str;
    }
}
