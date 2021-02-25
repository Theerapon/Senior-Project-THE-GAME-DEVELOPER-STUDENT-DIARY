using System.Collections;
using UnityEngine;

public class TimeManager : Manager<TimeManager>
{

    #region Event
    public Events.EventDateCalendar OnDateCalendar;
    public Events.EventTimeCalendar OnTimeCalendar;
    public Events.EventSeasonCalendar OnSeasonCalendar;

    #endregion


    #region Default
    [Header("Time Default")]
    [SerializeField] private const double DEFAULT_TIMESCALE = 48;

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
    private static string onDate, onTime, onSeason;
    private double totalSecond = 0;
    private double memorySecond;

    private CharacterStats characterStats;

    protected void Start()
    {
        characterStats = CharacterStats.Instance;
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        second = 0;
        minute = 0;
        hour = 0;
        date = 1;
        _currentDays = SetsOfDays.SUN;
        month = 1;
        year = 2021;
        ValidationDisplay();
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        ValidateCalculateTime();
        ValidationDisplay();
    }

    void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameManager.GameState.RUNNING:
                CalculateTime();
                break;

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
        GameManager.Instance.GotoMainWithContiniueGameInNextDays();

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

        }
        
        if (minute >= DEFAULT_MINUTE)
        {
            hour++;
            minute = minute - DEFAULT_MINUTE;
        }
        
        if (hour >= DEFAULT_HOUR)
        {
            date++;
            hour = hour - DEFAULT_HOUR;
            CalculateDay();
            setText();
            OnDateCalendar?.Invoke(onDate);
        }
        
        if (date > DEFAULT_DATE)
        {
            month++;
            date = date - DEFAULT_DATE;
            CalculateDay();
            CalculateMonth();
            CalculateSeason();
            setText();
            OnDateCalendar?.Invoke(onDate);
            OnSeasonCalendar?.Invoke(onSeason);
        }
        
        if (month > DEFAULT_MONTH)
        {
            year++;
            month = month - DEFAULT_MONTH;
            CalculateMonth();
            CalculateSeason();
            setText();
            OnDateCalendar?.Invoke(onDate);
            OnSeasonCalendar?.Invoke(onSeason);
        }
        setText();
        OnTimeCalendar?.Invoke(onTime);
    }

    private void setText()
    {
        onDate = string.Format("{0} " + "{1}" + " {2} " + "{3}", _currentDays, date, _currentMonth, year);
        onTime = string.Format("{0:00}:{1:00}" + " Miniue", hour, minute);
        onSeason = string.Format("{0}", _currentSeason);
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
        OnSeasonCalendar?.Invoke(onSeason);
    }

    public void ContiniueGameInSummaryScene()
    {
        int totalSecond;

        if (characterStats.GetSleepFullTimeSelected())
        {
            totalSecond = characterStats.GetDEFAULT_fullTimeOfSleepingSecond();
        } else
        {
            totalSecond = characterStats.GetDEFAULT_twoThirdTimeOfSleepingSeond();
        }

        int hour;
        int miniue;
        int second;

        second = totalSecond % 60;
        totalSecond = totalSecond / 60;
        miniue = totalSecond % 60;
        hour = totalSecond / 60;


        IncreaseTime(hour, miniue, second);
    }

}
