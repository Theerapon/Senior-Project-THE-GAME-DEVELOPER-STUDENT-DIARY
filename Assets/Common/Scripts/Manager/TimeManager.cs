using System;
using System.Collections;
using UnityEngine;

public class TimeManager : Manager<TimeManager>
{

    #region Event
    public Events.EventOnTenMinute OnTenMinute;
    public Events.EventDateCalendar OnDateCalendar;
    public Events.EventTimeCalendar OnTimeCalendar;
    public Events.EventTimeDayOrNight OnTimeChange;
    public Events.EventOnGodenTime OnGodenTime;
    public Events.EventOnTimeSkilpValidation OnTimeSkip;
    public Events.EventOnOneMiniuteTimePassed OnOneMiniuteTimePassed;
    #endregion

    [Header("Image")]
    [SerializeField] private Sprite dayImage;
    [SerializeField] private Sprite nightImage;

    #region Default
    [Header("Time Default")]
    [SerializeField] private const float DEFAULT_TIMESCALE = 48;

    [Header("Awake and Sleep")]
    [SerializeField] private const int DEFAULT_AWAKE_HOUR_TIME = 6;
    [SerializeField] private const int DEFAULT_AWAKE_MINUTE_TIME = 30;
    [SerializeField] private const int DEFAULT_AWAKE_SECOND_TIME = 0;
    [SerializeField] private const  int DEFAULT_SLEEP_LIMIT_TIME = 2;

    [Header("GoldenTIme")]
    [SerializeField] private const int DEFAULT_STARTGOLDENTIME = 9;
    [SerializeField] private const int DEFAULT_ENDGOLDENTIME = 17;


    private const int DEFAULT_Origin_Date = 1;
    private const int DEFAULT_Origin_Month = 1;
    private const int DEFAULT_Origin_Year = 2021;
    private const Day DEFAULT_Origin_Day = Day.Sun;


    private float TIMESCALE = DEFAULT_TIMESCALE;

    private const int DEFAULT_SECOND = 60;
    private const int DEFAULT_MINUTE = 60;
    private const int DEFAULT_HOUR = 24;
    private const int DEFAULT_DATE = 28;
    private const int DEFAULT_MONTH = 4;
    #endregion

    #region Enum
    public enum SetsOfMonth
    {
        JANUARY,
        FEBRUARY,
        MARCH,
        APRIL,
    }
    private SetsOfMonth currentMonth;
    private Day currentDays;
    #endregion

    #region Properties
    private static float minute, hour, date, second, month, year;
    private static float tomorrow_minute, tomorrow_hour, tomorrow_second, tomorrow_date, tomorrow_month, tomorrow_year;
    private static string onDate, onTime;
    private static string tomorrow_onDate, tomorrow_onTime;
    private float totalSecond = 0;
    private float memorySecond;
    private bool isDay;

    private bool goldenTime = false;

    public Sprite DayImage { get => dayImage; }
    public Sprite NightImage { get => nightImage; }
    public float Minute { get => minute; }
    public float Hour { get => hour; }
    public float Date { get => date; }
    public float Second { get => second; }
    public float Month { get => month; }
    public float Year { get => year; }
    public Day CurrentDays { get => currentDays; }
    public SetsOfMonth CurrentMonth { get => currentMonth; }
    #endregion

    protected void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        Initialized();
        ValidateCalculateTime();
        ValidationInitializing();
        NotificationAll();

    }

    private void Initialized()
    {
        second = DEFAULT_AWAKE_SECOND_TIME;
        minute = DEFAULT_AWAKE_MINUTE_TIME;
        hour = DEFAULT_AWAKE_HOUR_TIME;
        date = DEFAULT_Origin_Date;
        currentDays = DEFAULT_Origin_Day;
        month = DEFAULT_Origin_Month;
        year = DEFAULT_Origin_Year;
        Tomorrow();  
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (currentState == GameManager.GameState.HOME || currentState == GameManager.GameState.MAP)
        {
            ValidateCalculateTime();
            ValidationInitializing();
            NotificationAll();
        }
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.HOME
            || GameManager.Instance.CurrentGameState == GameManager.GameState.MAP)
        {
            CalculateTime();
        }
    }

    #region Calculate Time
    private void CalculateTime()
    {
        memorySecond = (float)(Time.deltaTime * (TIMESCALE));
        second += memorySecond;
        ValidateCalculateTime();
    }
    private void PassTenMiniute()
    {
        if (minute % 10 == 0 && minute != 60 && hour != 24 && date < 29 && month < 5)
        {
            OnTenMinute?.Invoke();
        }
    }
    private void ValidateCalculateTime()
    {
        //miniute change
        if (second >= DEFAULT_SECOND)
        {
            minute++;
            second = second - DEFAULT_SECOND;
            setText();
            OnOneMiniuteTimePassed?.Invoke(GameManager.Instance.CurrentGameState);
            OnTimeCalendar?.Invoke(onTime);
            PassTenMiniute();
        }

        //hour change
        if (minute >= DEFAULT_MINUTE)
        {
            hour++;
            minute = minute - DEFAULT_MINUTE;
            setText();
            OnTimeCalendar?.Invoke(onTime);
            CalGoldenTime();
            PassTenMiniute();
        }

        //day change
        if (hour >= DEFAULT_HOUR)
        {
            date++;
            hour = hour - DEFAULT_HOUR;
            CalculateDay();
            setText();
            OnTimeCalendar?.Invoke(onTime);
            OnDateCalendar?.Invoke(onDate);
            SetTimezone();
            PassTenMiniute();
        }

        //month change
        if (date > DEFAULT_DATE)
        {
            month++;
            date = date - DEFAULT_DATE;
            CalculateDay();
            CalculateMonth();
            setText();
            OnTimeCalendar?.Invoke(onTime);
            OnDateCalendar?.Invoke(onDate);
            PassTenMiniute();
        }

        //year change
        if (month > DEFAULT_MONTH)
        {
            year++;
            month = month - DEFAULT_MONTH;
            CalculateMonth();
            setText();
            OnTimeCalendar?.Invoke(onTime);
            OnDateCalendar?.Invoke(onDate);
            PassTenMiniute();
        }

    }
    private void CalGoldenTime()
    {
        if (hour >= DEFAULT_STARTGOLDENTIME && hour <= DEFAULT_ENDGOLDENTIME)
        {
            goldenTime = true;
            OnGodenTime?.Invoke(true);
        }
        else
        {
            goldenTime = false;
            OnGodenTime?.Invoke(false);
        }
        
    }
    private void CalculateMonth()
    {
        switch (month)
        {
            case 1:
                currentMonth = SetsOfMonth.JANUARY;
                break;
            case 2:
                currentMonth = SetsOfMonth.FEBRUARY;
                break;
            case 3:
                currentMonth = SetsOfMonth.MARCH;
                break;
            case 4:
                currentMonth = SetsOfMonth.APRIL;
                break;
            default:
                break;
        }
    }
    private void CalculateDay()
    {
        int multiply = (int)(date - 1) / 7;
        int dayIndex = (int)date - (7 * multiply);
        switch (dayIndex)
        {
            case 1:
                currentDays = Day.Mon;
                break;
            case 2:
                currentDays = Day.Tue;
                break;
            case 3:
                currentDays = Day.Wed;
                break;
            case 4:
                currentDays = Day.Thu;
                break;
            case 5:
                currentDays = Day.Fri;
                break;
            case 6:
                currentDays = Day.Sat;
                break;
            case 7:
                currentDays = Day.Sun;
                break;
        }
    }
    private void SetTimezone()
    {
        if (hour > 5 && hour < 18)
        {
            isDay = true;
        }
        else
        {
            isDay = false;
        }
        OnTimeChange?.Invoke(isDay);
    }
    #endregion

    #region Get
    public string GetOnDate()
    {
        return onDate;
    }
    public string GetOnTime()
    {
        return onTime;
    }
    public string GetSecondText(int totalSecond)
    {
        int hourFullTime;
        int miniueFullTime;
        int secondFullTime;

        secondFullTime = totalSecond % 60;
        totalSecond = totalSecond / 60;
        miniueFullTime = totalSecond % 60;
        hourFullTime = totalSecond / 60;

        return string.Format("{0} Hrs. {1} Min. {2} Sec.", hourFullTime, miniueFullTime, secondFullTime);
    }
    public bool GetGoldenTime()
    {
        return goldenTime;
    }
    public string GetTomorrowOnDate()
    {
        return tomorrow_onDate;
    }
    public string GetTomorrowOnTime()
    {
        return tomorrow_onTime;
    }
    #endregion

    #region Diary Calculate Time Skip
    public void SetNewDay()
    {
        second = tomorrow_second;
        minute = tomorrow_minute;
        hour = tomorrow_hour;
        date = tomorrow_date;
        month = tomorrow_month;
        year = tomorrow_year;
        CalculateDay();
        CalculateMonth();
        Tomorrow();

        Debug.Log(string.Format("Today {0:00}/{1:00}/{2:0000}  {3:00}{4:00}", date, month, year, hour, minute));
        Debug.Log(string.Format("Tomorrow {0:00}/{1:00}/{2:0000}  {3:00}{4:00}", tomorrow_date, tomorrow_month, tomorrow_year, tomorrow_hour, tomorrow_minute));
    }

    private void Tomorrow()
    {
        tomorrow_second = DEFAULT_AWAKE_SECOND_TIME;
        tomorrow_minute = DEFAULT_AWAKE_MINUTE_TIME;
        tomorrow_hour = DEFAULT_AWAKE_HOUR_TIME;

        tomorrow_date = date;
        tomorrow_month = month;
        tomorrow_year = year;

        tomorrow_date++;

        if (tomorrow_date > DEFAULT_DATE)
        {
            tomorrow_month++;
            tomorrow_date = tomorrow_date - DEFAULT_DATE;
        }

        if (tomorrow_month > DEFAULT_MONTH)
        {
            tomorrow_year++;
            tomorrow_month = tomorrow_month - DEFAULT_MONTH;
        }

        tomorrow_onDate = string.Format("{0:00}/{1:00}/{2:0000}", tomorrow_date, tomorrow_month, tomorrow_year);
        tomorrow_onTime = string.Format("{0:00}:{1:00}", tomorrow_hour, tomorrow_minute);
    }
    #endregion

    #region Display
    public void NotificationAll()
    {
        OnDateCalendar?.Invoke(onDate);
        OnTimeCalendar?.Invoke(onTime);
        OnTimeChange?.Invoke(isDay);
    }
    private void setText()
    {
        onDate = string.Format("{0:00}/{1:00}/{2:0000}", date, month, year);
        onTime = string.Format("{0:00}:{1:00}", hour, minute);
    }
    public void ValidationInitializing()
    {
        CalculateMonth();
        setText();
        OnDateCalendar?.Invoke(onDate);
        OnTimeCalendar?.Invoke(onTime);
        SetTimezone();
        CalGoldenTime();
        PassTenMiniute();
    }
    #endregion

    #region Time Skip
    public void SkilpTime(int totalSecond, int timeScaleToSkip)
    {
        int hour;
        int miniue;
        int second;

        second = totalSecond % 60;
        totalSecond = totalSecond / 60;
        miniue = totalSecond % 60;
        hour = totalSecond / 60;


        IncreaseTime(hour, miniue, second, timeScaleToSkip);
    }
    private void IncreaseTime(int hour, int minute, int second, int timeScaleToSkip)
    {
        totalSecond += (float)(hour * DEFAULT_MINUTE * DEFAULT_SECOND);
        totalSecond += (float)(minute * DEFAULT_SECOND);
        totalSecond += second;
        TIMESCALE = totalSecond / timeScaleToSkip;
        StartCoroutine("TimeIncreaseCalculate");

    }
    IEnumerator TimeIncreaseCalculate()
    {
        while (totalSecond > 0)
        {
            CalculateTime();
            totalSecond -= memorySecond;
            yield return null;
        }

        yield return null;
        TIMESCALE = DEFAULT_TIMESCALE;
        StartCoroutine("Validation");

    }

    IEnumerator Validation()
    {
        while (second > DEFAULT_SECOND)
        {
            ValidateCalculateTime();
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1);

        OnTimeSkip?.Invoke(GameManager.Instance.CurrentGameState);
    }
    #endregion

    #region Time Check
    public bool HasTimeEnough(int totalSecond)
    {
        float recieveHour = 0f;
        float recieveMiniue = 0f;
        float recieveSecond = 0f;

        float tempHour = hour;
        float tempMiniue = minute;
        float tempSecond = second;

        recieveSecond = totalSecond % 60;
        totalSecond = totalSecond / 60;
        recieveMiniue = totalSecond % 60;
        recieveHour = totalSecond / 60;


        if (recieveHour >= DEFAULT_HOUR)
        {
            return false;
        }
        else
        {
            tempHour += recieveHour;
            tempMiniue += recieveMiniue;
            tempSecond += recieveSecond;

            if(tempSecond >= DEFAULT_SECOND)
            {
                tempSecond -= DEFAULT_SECOND;
                tempMiniue++;
            }

            if(tempMiniue >= DEFAULT_MINUTE)
            {
                tempMiniue -= DEFAULT_MINUTE;
                tempHour++;
            }

            //equal 02:00:00 return true
            if (tempHour - DEFAULT_HOUR < DEFAULT_SLEEP_LIMIT_TIME + 1 && tempMiniue < 1 && tempSecond < 1)
            {
                return true;
            }

            //more than 02:00:00
            if (tempHour - DEFAULT_HOUR >= DEFAULT_SLEEP_LIMIT_TIME)
            {
                return false;
            }

            //less than 02:00:00
            return true;

        }
    }
    #endregion
}
