using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InputController : MonoBehaviour
{
    #region Defination
    [Header("Project")]
    [SerializeField] private Projects _projects;
    [SerializeField] private GameObject _ProjectDisplayHolder;
    [SerializeField] private TMP_Text project_textCoding = null;
    [SerializeField] private TMP_Text project_textDesign = null;
    [SerializeField] private TMP_Text project_textTesting = null;
    [SerializeField] private TMP_Text project_textArt = null;
    [SerializeField] private TMP_Text project_textAudio = null;
    [SerializeField] private TMP_Text project_textBug = null;
    [SerializeField] private TMP_Text project_textNameProject = null;
    [SerializeField] private Image project_imageFillProject = null;

    [Header("Stats")]
    [SerializeField] private CharacterStats _characterStats = null;
    [SerializeField] private GameObject _StatsDisplayHolder = null;
    [SerializeField] private TMP_Text stats_textCoding = null;
    [SerializeField] private TMP_Text stats_textDesign = null;
    [SerializeField] private TMP_Text stats_textTesting = null;
    [SerializeField] private TMP_Text stats_textArt = null;
    [SerializeField] private TMP_Text stats_textAudio = null;
    #endregion


    void Start()
    {
        SetDisplayProject();
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        switch (currentState)
        {
            case GameManager.GameState.PREGAME:
                break;
            case GameManager.GameState.RUNNING:
                break;
            case GameManager.GameState.PAUSE:
                if (_ProjectDisplayHolder.activeSelf == true)
                {
                    DisplayProject();
                }
                if (_StatsDisplayHolder.activeSelf == true)
                {
                    DisplayStats();
                }
                break;
            case GameManager.GameState.INTERRUPTED:
                break;
            default:
                break;
        }
    }

    void Update()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            #region Pregame
            case GameManager.GameState.PREGAME:
                break;
            #endregion
            #region Running
            case GameManager.GameState.RUNNING:
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    DisplayProject();
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    DisplayStats();
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameManager.Instance.PuaseGame();

                }
                break;
            #endregion
            #region Pause
            case GameManager.GameState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameManager.Instance.PuaseGame();
                }
                break;
            #endregion
            #region Interrupted
            case GameManager.GameState.INTERRUPTED:

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    DisplayProject();
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    DisplayStats();
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameManager.Instance.PuaseGame();
                }

                break;
            #endregion
            default:
                break;
        }

    }

    #region Projects
    private void DisplayProject()
    {
        if (_ProjectDisplayHolder.activeSelf == true)
        {
            _ProjectDisplayHolder.SetActive(false);
        }
        else
        {
            SetDisplayProject();
            _ProjectDisplayHolder.SetActive(true);
        }
        ChangedGameState();
    }


    private void SetDisplayProject()
    {
        project_textCoding.text = _projects.GetCodingQuality().ToString();
        project_textDesign.text = _projects.GetDesignQuality().ToString();
        project_textTesting.text = _projects.GetTestingQuality().ToString();
        project_textArt.text = _projects.GetArtQuality().ToString();
        project_textAudio.text = _projects.GetAudioQuality().ToString();
        project_textBug.text = _projects.GetBugValue().ToString();
        project_textNameProject.text = _projects.GetNameProject().ToString(); //wait for name project phase
        project_imageFillProject.fillAmount = CalculateFillAmountProject(_projects.GetCurrentXpProject());
        
    }

    private float CalculateFillAmountProject(int xp)
    {
        return (float)xp / _projects.project_Current.GetRequireXpProject(0);
    }
    #endregion

    #region Stats
    private void SetText()
    {
        stats_textCoding.text = _characterStats.GetStatusCoding().ToString();
        stats_textDesign.text = _characterStats.GetStatusDesign().ToString();
        stats_textTesting.text = _characterStats.GetStatusTest().ToString();
        stats_textArt.text = _characterStats.GetStatusArt().ToString();
        stats_textAudio.text = _characterStats.GetStatusAudio().ToString();
    }

    void DisplayStats()
    {
        if (_StatsDisplayHolder.activeSelf == true)
        {
            _StatsDisplayHolder.SetActive(false);
        }
        else
        {
            SetText();
            _StatsDisplayHolder.SetActive(true);
        }
        ChangedGameState();
    }
    #endregion

    private void ChangedGameState()
    {
        switch (GameManager.Instance.CurrentGameState)
        {
            case GameManager.GameState.RUNNING:
                GameManager.Instance.InterrupedGame();
                break;
            case GameManager.GameState.INTERRUPTED:
                if(_StatsDisplayHolder.activeSelf == true || _ProjectDisplayHolder.activeSelf == true)
                {
                    return;
                }
                else
                {
                    GameManager.Instance.InterrupedGame();
                }
                break;
            default:
                break;
        }
    }

    private void InterrupedGame()
    {

    }
}
