using TMPro;
using UnityEngine;

public class CourseAnimationDisplay : MonoBehaviour
{   
    [Header("Time")]
    [SerializeField] private TMP_Text dateCalendar;
    [SerializeField] private TMP_Text timeCalendar;
    [SerializeField] private TMP_Text seasonCalendar;

    [Header("Bonus")]
    [SerializeField] private GameObject bonusBox;
    private CourseAnimationManager courseAnimationManager;


    private void Start()
    {
        if (TimeManager.Instance != null)
        {
            TimeManager.Instance.OnDateCalendar.AddListener(HandleOnDateCalendar);
            TimeManager.Instance.OnTimeCalendar.AddListener(HandleOnTimeCalendar);
            TimeManager.Instance.OnSeasonCalendar.AddListener(HandleOnSeasonCalender);
            TimeManager.Instance.ValidationDisplay();
        }

        courseAnimationManager = FindObjectOfType<CourseAnimationManager>();
        TimeManager.Instance.OnTimeSkip.AddListener(TimeSkilpHandler);
    }

    private void TimeSkilpHandler(GameManager.GameState gameState)
    {
        /*
        if (gameState == GameManager.GameState.COURSEANIMATION)
        {
            DisplayBonusBox();
        }*/
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

    public void DisplayBonusBox()
    {
        /*
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.COURSEANIMATION)
        {
            if (bonusBox.activeSelf == false && bonusBox != null)
            {
                bonusBox.SetActive(true);
                courseAnimationManager.CreateTemplateBonus();
            }
        }*/
    }
}
