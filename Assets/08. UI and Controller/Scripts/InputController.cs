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
    //[SerializeField] private Projects _projects;
    [SerializeField] private GameObject _ProjectDisplayHolder;
    //[SerializeField] private TMP_Text project_textCoding = null;
    //[SerializeField] private TMP_Text project_textDesign = null;
    //[SerializeField] private TMP_Text project_textTesting = null;
    //[SerializeField] private TMP_Text project_textArt = null;
    //[SerializeField] private TMP_Text project_textAudio = null;
    //[SerializeField] private TMP_Text project_textBug = null;
    //[SerializeField] private TMP_Text project_textNameProject = null;
    //[SerializeField] private Image project_imageFillProject = null;


    [Header("Menu")]
    [SerializeField] private GameObject _MenuHandler;

    [Header("Hotbar")]
    [SerializeField] private GameObject _HotbarHandler;
    #endregion


    protected void Start()
    {

        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        switch (currentState)
        {
            case GameManager.GameState.PREGAME:
                break;
            case GameManager.GameState.RUNNING:
                if(_HotbarHandler.activeSelf == false)
                {
                    _HotbarHandler.SetActive(true);
                }
                break;
            case GameManager.GameState.PAUSE:
                if (_HotbarHandler.activeSelf == true)
                {
                    _HotbarHandler.SetActive(false);
                }
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
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    DisplayMenu();
                    GameManager.Instance.PuaseGame();

                }
                break;
            #endregion
            #region Pause
            case GameManager.GameState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    DisplayMenu();
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
        if (_ProjectDisplayHolder.activeSelf == true && _ProjectDisplayHolder != null)
        {
            _ProjectDisplayHolder.SetActive(false);
        }
        else
        {
            //SetDisplayProject();
            _ProjectDisplayHolder.SetActive(true);
        }
    }

    /*
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
    } */
    #endregion


    private void DisplayMenu()
    {
        if (_MenuHandler.activeSelf == true && _MenuHandler != null)
        {
            _MenuHandler.SetActive(false);
        }
        else
        {
            _MenuHandler.SetActive(true);
            _MenuHandler.GetComponent<MenuManager>().Reset();
        }
    }

    private void DisplayHotbar()
    {
        if (_HotbarHandler.activeSelf == true && _HotbarHandler != null)
        {
            _HotbarHandler.SetActive(false);
        }
        else
        {
            _HotbarHandler.SetActive(true);
        }
    }
}
