using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD_Info_Display : MonoBehaviour
{
    private const string _bagName = "กระเป๋า";
    private const string _status = "สถานะตัวละคร";
    private const string _ideas = "ไอเดีย";
    private const string _exit = "ออกจากเกม";

    [Header("Name")]
    [SerializeField] private TMP_Text _menuName;

    [Header("Time")]
    [SerializeField] private TMP_Text dateCalendar;
    [SerializeField] private TMP_Text timeCalendar;
    [SerializeField] private Image icon;

    [Header("Energy and Motivation")]
    [SerializeField] private Image energy_bar;
    [SerializeField] private Image motivation_bar;
    [SerializeField] private TMP_Text energy;
    [SerializeField] private TMP_Text motivation;

    [Header("Money")]
    [SerializeField] private TMP_Text money;

    [Header("Resourse")]
    [SerializeField] private Sprite image_day;
    [SerializeField] private Sprite image_night;

    private CharacterStatusController characterStatusController;
    private TimeManager timeManager;
    private GameManager gameManager;

    private void Awake()
    {
        timeManager = TimeManager.Instance;
        gameManager = GameManager.Instance;
        characterStatusController = CharacterStatusController.Instance;
    }

    protected void Start()
    {
        
        if (!ReferenceEquals(gameManager, null))
        {
            gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        }

        if (!ReferenceEquals(timeManager, null))
        {
            timeManager.OnDateCalendar.AddListener(HandleOnDateCalendar);
            timeManager.OnTimeCalendar.AddListener(HandleOnTimeCalendar);
            timeManager.OnTimeChange.AddListener(HandlerTimeChange);
            timeManager.NotificationAll();
        }

        
        
        if(!ReferenceEquals(characterStatusController, null))
        {
            characterStatusController.OnEnergyUpdated.AddListener(EnergyHandler);
            characterStatusController.OnMotivationUpdated.AddListener(MotivationHandler);
            characterStatusController.OnMoneyUpdated.AddListener(MoneyHandler);
            characterStatusController.ValidateDisplay();
        }

    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.MENU && gameManager.CurrentGameScene == GameManager.GameScene.Menu_Bag)
        {
            SetName(_bagName);
        }
        else if (current == GameManager.GameState.MENU && gameManager.CurrentGameScene == GameManager.GameScene.Menu_Characters)
        {
            SetName(_status);
        }
        else if (current == GameManager.GameState.MENU && gameManager.CurrentGameScene == GameManager.GameScene.Menu_Ideas)
        {
            SetName(_ideas);
        }
        else if (current == GameManager.GameState.MENU && gameManager.CurrentGameScene == GameManager.GameScene.Menu_Exit)
        {
            SetName(_exit);
        }
    }


    private void SetName(string name)
    {
        _menuName.text = name;
    }

    private void MoneyHandler()
    {
        money.text = characterStatusController.CurrentMoney.ToString();
    }

    private void MotivationHandler()
    {
        motivation_bar.fillAmount = CalculateFillAmountMotivation();
        motivation.text = string.Format("{0:n0} / {1:n0}", characterStatusController.CurrentMotivation, characterStatusController.Default_maxMotivation);
    }

    private float CalculateFillAmountMotivation()
    {
        return (float)characterStatusController.CurrentMotivation / characterStatusController.Default_maxMotivation;
    }

    private void EnergyHandler()
    {
        energy_bar.fillAmount = CalculateFillAmountEnergy();
        energy.text = string.Format("{0:n0} / {1:n0}", characterStatusController.CurrentEnergy, characterStatusController.Default_maxEnergy);
    }

    private float CalculateFillAmountEnergy()
    {
        return (float)characterStatusController.CurrentEnergy / characterStatusController.Default_maxEnergy;
    }

    private void HandlerTimeChange(bool isDay)
    {
        if (isDay)
        {
            icon.sprite = image_day;
        }
        else
        {
            icon.sprite = image_night;
        }
    }

    private void HandleOnTimeCalendar(string time)
    {
        timeCalendar.text = timeManager.GetOnTime().ToUpper();
    }

    private void HandleOnDateCalendar(string date)
    {
        dateCalendar.text = timeManager.GetOnDate().ToUpper();
    }

}
