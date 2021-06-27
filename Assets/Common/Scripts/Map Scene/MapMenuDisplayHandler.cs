using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static PlaceEntry;

public class MapMenuDisplayHandler : MonoBehaviour
{
    [Header("Initializing Icon Place")]
    [SerializeField] private Sprite _iconClothing;
    [SerializeField] private Sprite _iconFood;
    [SerializeField] private Sprite _iconHome;
    [SerializeField] private Sprite _iconSell;
    [SerializeField] private Sprite _iconMystic;
    [SerializeField] private Sprite _iconPark;
    [SerializeField] private Sprite _iconTeacher;
    [SerializeField] private Sprite _iconUniversity;

    [Header("Time Skip Animation")]
    [SerializeField] private GameObject _timeAnimationGameObject;
    [SerializeField] private TMP_Text _dateTMP;
    [SerializeField] private TMP_Text _timeTMP;

    [Header("Show Arriver")]
    [SerializeField] private GameObject _showMenuArriverGameObject;
    [SerializeField] private TMP_Text _placeNameTMP;
    [SerializeField] private ArriverGenerator _arriverGenerator;
    [SerializeField] private GameObject _arriverGeneratorGameObject;

    [Header("Transporting")]
    [SerializeField] private GameObject _trasportingGameObject;

    [Header("Place Menu")]
    [SerializeField] private GameObject _placeMenuNameGameObject;
    [SerializeField] private TMP_Text _placeMenuNameTMP;
    [SerializeField] private Image _placeMenuImage;
    
    [Header("Transport Info")]
    [SerializeField] private GameObject _transportInfoObject;
    [SerializeField] private TMP_Text _energyTMP;
    [SerializeField] private TMP_Text _minuteTMP;
    [SerializeField] private TMP_Text _secondTMP;

    [Header("TransportController")]
    [SerializeField] private TransportController _transportController;
    private PlacesController _placesController;
    private NpcsController _npcsController;
    private PlayerTransport _playerTransport;
    private TimeManager _timeManager;
    private GameManager _gameManager;

    private string lastPlaceID;



    private void Start()
    {
        _placesController = PlacesController.Instance;
        _npcsController = NpcsController.Instance;
        _playerTransport = PlayerTransport.Instance;
        _timeManager = TimeManager.Instance;
        _gameManager = GameManager.Instance;
        _npcsController.OnHasPlaceArriverUpdate.AddListener(OnHasPlaceArriverUpdateHandler);
        _timeManager.OnTimeCalendar.AddListener(OnTimeCalendarHandler);
        _timeManager.OnDateCalendar.AddListener(OnDateCalendarHandler);
        _timeManager.ValidationInitializing();
        _gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        lastPlaceID = string.Empty;
        Initializing();
    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.TRANSPORTING && previous == GameManager.GameState.MAP)
        {
            Initializing();
            ActiveTrasportingGameObject(true);
            ActiveTimeSkipAnimationGameObject(true);
        }
        else if(current == GameManager.GameState.PLACE && (previous == GameManager.GameState.TRANSPORTING || previous == GameManager.GameState.MAP))
        {
            Initializing();
            ActivePlaceNameGameObject(true);     
            SetNamePlaceMenu();
        }
        else if(current == GameManager.GameState.MAP && previous == GameManager.GameState.PLACE)
        {
            Initializing();
        }
        else if (current == GameManager.GameState.OPENINGTREASURE && previous == GameManager.GameState.TRANSPORTING)
        {
            Initializing();
        }
    }

    private void Initializing()
    {
        ActiveTrasportingGameObject(false);
        ActivePlaceNameGameObject(false);
        ActiveArriverGameObject(false);
        ActiveShowMenuArriverGameObject(false);
        ActiveTransportInfoGameObject(false);
        ActiveTimeSkipAnimationGameObject(false);
    }

    public void OnPlaceTrigerShowArriver(string placeTargetId)
    {
        if(!ReferenceEquals(_placesController.PlacesDic, null) && !ReferenceEquals(_placesController, null))
        {
            //show arriver
            if (_placesController.PlacesDic.ContainsKey(placeTargetId))
            {
                Dictionary<string, Arriver> arrivers = _placesController.PlacesDic[placeTargetId].Arrivers;
                if (arrivers.Count > 0)
                {
                    _arriverGenerator.CreateTemplate(arrivers);
                    _placeNameTMP.text = _placesController.PlacesDic[placeTargetId].PlaceName;
                    ActiveArriverGameObject(true);
                }
                else
                {
                    _placeNameTMP.text = _placesController.PlacesDic[placeTargetId].PlaceName;
                    ActiveArriverGameObject(false);
                }
                ActiveShowMenuArriverGameObject(true);
                lastPlaceID = placeTargetId;
            }
        }
    }
    public void OnPlaceTrigerShowTransportInfo(string placeTargetId)
    {
        string currentPlacePlayerId = _playerTransport.CurrentPlaceId;
        if (placeTargetId != currentPlacePlayerId)
        {
            if (!ReferenceEquals(_placesController.PlacesDic, null) && !ReferenceEquals(_placesController, null))
            {
                //show arriver
                if (_placesController.PlacesDic.ContainsKey(placeTargetId) && _placesController.PlacesDic.ContainsKey(currentPlacePlayerId))
                {
                    int indexDestination = _placesController.PlacesDic[placeTargetId].TransportIndex;
                    int indexOrigin = _placesController.PlacesDic[currentPlacePlayerId].TransportIndex;
                    int totalSecond = _transportController.GetTotalTimeToTransport(indexOrigin, indexDestination);
                    int minuteFullTime;
                    int secondFullTime;
                    secondFullTime = totalSecond % 60;
                    minuteFullTime = totalSecond / 60;
                    _minuteTMP.text = minuteFullTime.ToString();
                    _secondTMP.text = secondFullTime.ToString();
                    _energyTMP.text = string.Format("{0:n0}", _transportController.GetEnergyToTransport(minuteFullTime));
                    ActiveTransportInfoGameObject(true);
                }
            }
        }
    }

    public void OnExitTriger()
    {
        lastPlaceID = string.Empty;
        ActiveShowMenuArriverGameObject(false);
        ActiveTransportInfoGameObject(false);
    }

    private void ActiveShowMenuArriverGameObject(bool active)
    {
        if(_showMenuArriverGameObject.activeSelf != active)
        {
            _showMenuArriverGameObject.SetActive(active);
        }
    }

    private void ActiveArriverGameObject(bool active)
    {
        if(_arriverGeneratorGameObject.activeSelf != active)
        {
            _arriverGeneratorGameObject.SetActive(active);
        }
            
    }
    private void ActivePlaceNameGameObject(bool active)
    {
        if (_placeMenuNameGameObject.activeSelf != active)
        {
            _placeMenuNameGameObject.SetActive(active);
        }

    }
    private void ActiveTrasportingGameObject(bool active)
    {
        if (_trasportingGameObject.activeSelf != active)
        {
            _trasportingGameObject.SetActive(active);
        }

    }
    private void OnHasPlaceArriverUpdateHandler()
    {
        if(lastPlaceID != string.Empty)
        {
            OnPlaceTrigerShowArriver(lastPlaceID);
        }
    }
    private void ActiveTransportInfoGameObject(bool active)
    {
        if (_transportInfoObject.activeSelf != active)
        {
            _transportInfoObject.SetActive(active);
        }
    }
    private void ActiveTimeSkipAnimationGameObject(bool active)
    {
        if (_timeAnimationGameObject.activeSelf != active)
        {
            _timeAnimationGameObject.SetActive(active);
        }
    }
    private void SetNamePlaceMenu()
    {
        if(!ReferenceEquals(_playerTransport, null) && !ReferenceEquals(_placesController, null))
        {
            Dictionary<string, PlaceEntry> places = _placesController.PlacesDic;
            if(!ReferenceEquals(places, null))
            {
                Place currentPlace = _playerTransport.CurrentPlace;
                string placeId = _playerTransport.CurrentPlaceId;
                if (places.ContainsKey(placeId))
                {
                    _placeMenuNameTMP.text = places[placeId].PlaceName;
                    _placeMenuImage.sprite = GetSpritePlace(currentPlace);
                }
            }
        }
        
    }
    private Sprite GetSpritePlace(Place place)
    {
        Sprite icon = null;
        switch (place)
        {
            case Place.Clothing:
                icon = _iconClothing;
                break;
            case Place.Food:
                icon = _iconFood;
                break;
            case Place.Home:
                icon = _iconHome;
                break;
            case Place.Mystic:
                icon = _iconMystic;
                break;
            case Place.Park:
                icon = _iconPark;
                break;
            case Place.Sell:
                icon = _iconSell;
                break;
            case Place.Teacher:
                icon = _iconTeacher;
                break;
            case Place.University:
                icon = _iconUniversity;
                break;
        }
        return icon;
    }

    #region Time Manager
    private void OnDateCalendarHandler(string date)
    {
        _dateTMP.text = date;
    }

    private void OnTimeCalendarHandler(string time)
    {
        _timeTMP.text = time;
    }
    #endregion

}
