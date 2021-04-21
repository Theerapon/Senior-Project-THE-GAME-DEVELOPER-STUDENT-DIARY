using System;
using System.Collections;
using UnityEngine;

public class TimeManager : Manager<TimeManager>
{

    #region Event
    public Events.EventDateCalendar OnDateCalendar;
    public Events.EventTimeCalendar OnTimeCalendar;
    public Events.EventTimeDayOrNight OnTimeChange;
    public Events.EventOnTimeSkilpValidation OnTimeSkip;

    #endregion

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


    private float TIMESCALE = DEFAULT_TIMESCALE;

    private const int TIMEWORLD = 3;

    private const int DEFAULT_SECOND = 60;
    private const int DEFAULT_MINUTE = 60;
    private const int DEFAULT_HOUR = 24;
    private const int DEFAULT_DATE = 28;
    private const int DEFAULT_MONTH = 4;
    #endregion

    #region Enum
    private enum SetsOfMonth
    {
        JANUARY,
        FEBRUARY,
        MARCH,
        APRIL,
    }
    private SetsOfMonth _currentMonth;


    private enum SetsOfDays 
    {
        SUN,
        MON,
        TUE,
        WES,
        THU,
        FRI,
        SAT,
        NONE

    }
    private SetsOfDays _currentDays;
    #endregion


    private static float minute, hour, date, second, month, year;
    private static float tomorrow_minute, tomorrow_hour, tomorrow_second, tomorrow_date, tomorrow_month, tomorrow_year;
    private static string onDate, onTime;
    private static string tomorrow_onDate, tomorrow_onTime;
    private float totalSecond = 0;
    private float memorySecond;
    private bool isDay;

    private bool goldenTime = false;


    protected void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        Initialized();
        ValidateCalculateTime();
        ValidationDisplay();
        NotificationAll();

    }

    private void Initialized()
    {
        second = 0;
        minute = 0;
        hour = 8;
        date = 27;
        _currentDays = SetsOfDays.SUN;
        month = 4;
        year = 2021;
        Tomorrow();  
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (currentState == GameManager.GameState.HOME || currentState == GameManager.GameState.MAP)
        {
            ValidateCalculateTime();
            ValidationDisplay();
            NotificationAll();
        }
    }

    void Update()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.HOME 
            || GameManager.Instance.CurrentGameState == GameManager.GameState.MAP)
        {
            CalculateTime();
        }
    }



    private void IncreaseTime(int hour, int minute, int second)
    {
        totalSecond += (float) (hour * DEFAULT_MINUTE * DEFAULT_SECOND);
        totalSecond += (float) (minute * DEFAULT_SECOND);
        totalSecond += second;
        TIMESCALE = totalSecond / TIMEWORLD;
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
        while(second > DEFAULT_SECOND)
        {
            ValidateCalculateTime();
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1);

        OnTimeSkip?.Invoke(GameManager.Instance.CurrentGameState);
    }

    private void CalculateTime()
    {
        memorySecond = (float)(Time.deltaTime * (TIMESCALE));
        second += memorySecond;
        ValidateCalculateTime();
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

        tomorrow_onDate =  string.Format("{0:00}/{1:00}/{2:0000}", tomorrow_date, tomorrow_month, tomorrow_year);
        tomorrow_onTime = string.Format("{0:00}:{1:00}", tomorrow_hour, tomorrow_minute);
    }

    private void ValidateCalculateTime()
    {
        
        if (second >= DEFAULT_SECOND)
        {
            minute++;
            second = second - DEFAULT_SECOND;
            setText();
            OnTimeCalendar?.Invoke(onTime);
        }
        
        if (minute >= DEFAULT_MINUTE)
        {
            hour++;
            minute = minute - DEFAULT_MINUTE;
            setText();
            OnTimeCalendar?.Invoke(onTime);
            CalGoldenTime();
        }
        
        if (hour >= DEFAULT_HOUR)
        {
            date++;
            hour = hour - DEFAULT_HOUR;
            CalculateDay();
            setText();
            OnTimeCalendar?.Invoke(onTime);
            OnDateCalendar?.Invoke(onDate);

            CheckTimeChange();
        }
        
        if (date > DEFAULT_DATE)
        {
            month++;
            date = date - DEFAULT_DATE;
            CalculateDay();
            CalculateMonth();
            setText();
            OnTimeCalendar?.Invoke(onTime);
            OnDateCalendar?.Invoke(onDate);
        }
        
        if (month > DEFAULT_MONTH)
        {
            year++;
            month = month - DEFAULT_MONTH;
            CalculateMonth();
            setText();
            OnTimeCalendar?.Invoke(onTime);
            OnDateCalendar?.Invoke(onDate);
        }
    }

    private void CheckTimeChange()
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

    private void CalGoldenTime()
    {
        if(hour >= DEFAULT_STARTGOLDENTIME && hour <= DEFAULT_ENDGOLDENTIME)
        {
            goldenTime = true;
        } else
        {
            goldenTime = false;
        }
    }

    private void setText()
    {
        onDate = string.Format("{0:00}/{1:00}/{2:0000}", date, month, year);
        onTime = string.Format("{0:00}:{1:00}", hour, minute);
    }

    private void CalculateMonth()
    {
        switch (month)
        {
            case 1:
                _currentMonth = SetsOfMonth.JANUARY;
                break;
            case 2:
                _currentMonth = SetsOfMonth.FEBRUARY;
                break;
            case 3:
                _currentMonth = SetsOfMonth.MARCH;
                break;
            case 4:
                _currentMonth = SetsOfMonth.APRIL;
                break;
            default:
                break;
        }
    }


    private void CalculateDay()
    {
        switch (_currentDays)
        {
            case SetsOfDays.SUN:
                _currentDays = SetsOfDays.MON;
                break;
            case SetsOfDays.MON:
                _currentDays = SetsOfDays.TUE;
                break;
            case SetsOfDays.TUE:
                _currentDays = SetsOfDays.WES;
                break;
            case SetsOfDays.WES:
                _currentDays = SetsOfDays.THU;
                break;
            case SetsOfDays.THU:
                _currentDays = SetsOfDays.FRI;
                break;
            case SetsOfDays.FRI:
                _currentDays = SetsOfDays.SAT;
                break;
            case SetsOfDays.SAT:
                _currentDays = SetsOfDays.SUN;
                break;
            default:
                _currentDays = SetsOfDays.SUN;
                break;
        }
    }

    public void ValidationDisplay()
    {
        CalculateMonth();
        setText();
        OnDateCalendar?.Invoke(onDate);
        OnTimeCalendar?.Invoke(onTime);
    }

    public void SkilpTime(int totalSecond)
    {
        int hour;
        int miniue;
        int second;

        second = totalSecond % 60;
        totalSecond = totalSecond / 60;
        miniue = totalSecond % 60;
        hour = totalSecond / 60;


        IncreaseTime(hour, miniue, second);
    }

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

    public void NotificationAll()
    {
        OnDateCalendar?.Invoke(onDate);
        OnTimeCalendar?.Invoke(onTime);
        OnTimeChange?.Invoke(isDay);
    }

    public string GetTomorrowOnDate()
    {
        return tomorrow_onDate;
    }
    public string GetTomorrowOnTime()
    {
        return tomorrow_onTime;
    }
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

}
