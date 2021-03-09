using TMPro;
using UnityEngine;

public class CourseAnimationDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text dateCalendar;
    [SerializeField] private TMP_Text timeCalendar;
    [SerializeField] private TMP_Text seasonCalendar;

    private void Start()
    {
        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.OnDateCalendar.AddListener(HandleOnDateCalendar);
            TimeManager.Instance.OnTimeCalendar.AddListener(HandleOnTimeCalendar);
            TimeManager.Instance.OnSeasonCalendar.AddListener(HandleOnSeasonCalender);
            TimeManager.Instance.ValidationDisplay();
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
}
