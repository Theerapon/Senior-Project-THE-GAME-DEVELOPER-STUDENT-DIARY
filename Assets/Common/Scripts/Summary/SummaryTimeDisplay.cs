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

    private CharacterStatusController character_status;
    private GameObject found_Player;
    private PlayerAction playerAction;

    protected void Start()
    {
        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.OnDateCalendar.AddListener(HandleOnDateCalendar);
            TimeManager.Instance.OnTimeCalendar.AddListener(HandleOnTimeCalendar);
            TimeManager.Instance.ValidationDisplay();
        }

        found_Player = GameObject.FindGameObjectWithTag("Player");
        character_status = CharacterStatusController.Instance;
        playerAction = found_Player.GetComponentInChildren<PlayerAction>();
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
        //string str = string.Format("Total second {0}", TimeManager.Instance.GetSecondText(playerAction.GetCalculateSleepTimeSecond(characterStats.GetSleepFullTimeSelected())));
        //totalTime.text = str;
    }
}
