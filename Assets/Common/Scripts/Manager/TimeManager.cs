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
    [SerializeField] private const double DEFAULT_TIMESCALE = 48;

    [Header("GoldenTIme")]
    [SerializeField] private const double DEFAULT_STARTGOLDENTIME = 9;
    [SerializeField] private const double DEFAULT_ENDGOLDENTIME = 17;


    private double TIMESCALE = DEFAULT_TIMESCALE;

    private const double TIMEWORLD = 3;

    private const double DEFAULT_SECOND = 60;
    private const double DEFAULT_MINUTE = 60;
    private const double DEFAULT_HOUR = 24;
    private const double DEFAULT_DATE = 28;
    private const double DEFAULT_MONTH = 4;
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

    private enum SetsOfSeason
    {
        SPRING,
        SUMMER,
        AUTUMN,
        WINTER

    }
    private SetsOfSeason _currentSeason;

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


    private static double minute, hour, date, second, month, year;
    private static string onDate, onTime;
    private double totalSecond = 0;
    private double memorySecond;
    private bool isDay;

    private bool goldenTime = false;


    protected void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        second = 0;
        minute = 0;
        hour = 0;
        date = 1;
        _currentDays = SetsOfDays.SUN;
        month = 1;
        year = 2021;
        ValidateCalculateTime();
        ValidationDisplay();
        NotificationAll();
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
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.HOME || GameManager.Instance.CurrentGameState == GameManager.GameState.MAP)
        {
            CalculateTime();
        }
    }

    private void IncreaseTime(int hour, int minute, int second)
    {
        totalSecond += (double) (hour * DEFAULT_MINUTE * DEFAULT_SECOND);
        totalSecond += (double) (minute * DEFAULT_SECOND);
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
        memorySecond = Time.deltaTime * (TIMESCALE);
        second += memorySecond;
        ValidateCalculateTime();
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
            CalculateSeason();
            setText();
            OnTimeCalendar?.Invoke(onTime);
            OnDateCalendar?.Invoke(onDate);
        }
        
        if (month > DEFAULT_MONTH)
        {
            year++;
            month = month - DEFAULT_MONTH;
            CalculateMonth();
            CalculateSeason();
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
        onDate = string.Format("{0}/{1}/{2}", date, month, year);
        onTime = string.Format("{0:00}:{1:00}", hour, minute);
    }

    private void CalculateSeason()
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

    private void CalculateMonth()
    {
        switch (month)
        {
            case 1:
                _currentSeason = SetsOfSeason.SPRING;
                break;
            case 2:
                _currentSeason = SetsOfSeason.SUMMER;
                break;
            case 3:
                _currentSeason = SetsOfSeason.AUTUMN;
                break;
            case 4:
                _currentSeason = SetsOfSeason.WINTER;
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
        CalculateSeason();
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
}
