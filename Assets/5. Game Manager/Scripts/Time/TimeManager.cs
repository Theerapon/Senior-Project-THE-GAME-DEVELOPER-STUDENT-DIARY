using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : Manager<TimeManager>
{

    #region Event
    public Events.EventDateCalendar OnDateCalendar;
    public Events.EventTimeCalendar OnTimeCalendar;
    public Events.EventSeasonCalendar OnSeasonCalendar;

    #endregion


    #region Default
    [Header("Time Default")]
    [SerializeField] private const int TIMESCALE = 60;

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


    void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
        second = 0;
        minute = 0;
        hour = 0;
        date = 1;
        _currentDays = SetsOfDays.SUN;
        month = 1;
        year = 2021;
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        switch (currentState)
        {
            case GameManager.GameState.PREGAME:
                break;

            case GameManager.GameState.RUNNING:
                Reset();
                break;
            case GameManager.GameState.PAUSE:
                break;
            default:
                break;
        }
    }

    void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameManager.GameState.PREGAME:
                break;
            case GameManager.GameState.RUNNING:
                CalculateTime();
                break;
            case GameManager.GameState.PAUSE:
                break;
            default:
                break;
        }
    }

    private void CalculateTime()
    {
        second += Time.deltaTime * TIMESCALE;
        if(second >= DEFAULT_SECOND)
        {
            minute++;
            second = 0;

        }
        else if(minute >= DEFAULT_MINUTE)
        {
            hour++;
            minute = 0;
        }
        else if(hour >= DEFAULT_HOUR)
        {
            date++;
            hour = 0;
            CalculateDay();
            setText();
            OnDateCalendar.Invoke(onDate);
        }
        else if(date >= DEFAULT_DATE)
        {
            month++;
            date = 1;
            CalculateDay();
            CalculateMonth();
            CalculateSeason();
            setText();
            OnDateCalendar.Invoke(onDate);
            OnSeasonCalendar.Invoke(onSeason);
        }
        else if(month >= DEFAULT_MONTH)
        {
            year++;
            month = 1;
            CalculateMonth();
            CalculateSeason();
            setText();
            OnDateCalendar.Invoke(onDate);
            OnSeasonCalendar.Invoke(onSeason);
        }
        setText();
        OnTimeCalendar.Invoke(onTime);

    }

    private void setText()
    {
        onDate = string.Format("{0} " + "{1}" + " {2} " + "{3}", _currentDays, date, _currentMonth, year);
        onTime = string.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);
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

    private void Reset()
    {
        CalculateMonth();
        CalculateSeason();
        setText();
        OnDateCalendar.Invoke(onDate);
        OnTimeCalendar.Invoke(onTime);
        OnSeasonCalendar.Invoke(onSeason);
    }


}
