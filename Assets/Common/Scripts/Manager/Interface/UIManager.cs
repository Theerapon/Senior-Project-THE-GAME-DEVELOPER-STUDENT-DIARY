using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Manager<UIManager>
{
    [SerializeField] GameManager gameManager;

    [Header("Camera")]
    [SerializeField] private Camera _uiCamera;


    [Header("Main Menu")]
    [SerializeField] private GameObject mainMenuDisplayHandler;

    [Header("Button")]
    [SerializeField] private GameObject[] _buttons;
    private List<ButtonHover> _buttonEvents;
    protected override void Awake()
    {
        base.Awake();
        gameManager.onHomeDisplay.AddListener(HandleLoadGameComplete);
        gameManager.OnGameStateChanged.AddListener(HandleGameStateChanged);
        _buttonEvents = new List<ButtonHover>();
    }

    private void HandleGameStateChanged(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.PREGAME)
        {
            SetCameraActive(true);
            mainMenuDisplayHandler.gameObject.SetActive(true);
        }   
    }

    void Start()
    {
       
        _uiCamera.gameObject.SetActive(true);
        mainMenuDisplayHandler.gameObject.SetActive(true);

        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttonEvents.Add(_buttons[i].GetComponentInChildren<ButtonHover>());
            _buttonEvents[i].OnButtonChange.AddListener(OnButtonChange);
        }

    }

    private void OnButtonChange(ButtonHover button, bool selecte)
    {
        if (selecte)
        {
            for (int i = 0; i < _buttonEvents.Count; i++)
            {

                if(_buttonEvents[i] != button)
                {
                    _buttonEvents[i].UnSelected();
                }
            }
        }
        else
        {
            bool isSelected = false;

            for (int i = 0; i < _buttonEvents.Count; i++)
            {

                if (_buttonEvents[i].IsSelected)
                {
                    isSelected = true;
                }
                else
                {
                    _buttonEvents[i].UnSelected();
                }
            }

            if (!isSelected)
            {
                _buttonEvents[0].SetIsSelected();
            }
        }
        
    }

    private void HandleLoadGameComplete(bool loadGame)
    {
        if(GameManager.Instance.CurrentGameState != GameManager.GameState.MAP && GameManager.Instance.CurrentGameState != GameManager.GameState.PREGAME)
        {
            mainMenuDisplayHandler.gameObject.SetActive(!loadGame);
            SetCameraActive(!loadGame);
        }

    }


    public void SetCameraActive(bool active)
    {
        _uiCamera.gameObject.SetActive(active);
    }


}
