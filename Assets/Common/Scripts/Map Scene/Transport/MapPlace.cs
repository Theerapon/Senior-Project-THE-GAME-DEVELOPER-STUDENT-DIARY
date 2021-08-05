using System;
using System.Collections.Generic;
using UnityEngine;

public class MapPlace : MonoBehaviour
{
    [Header("Initializing Place")]
    [SerializeField] private Place _targetPlace;
    private string _targetPlaceId;
    private float _energyToConsume;
    private int _totalSecond;

    [Header("Controller")]
    private PlayerAction _playerAction;
    private PlacesController _placesController;
    private PlayerTransport _playerTransport;
    private TimeManager _timeManager;
    private GameManager _gameManager;
    private NotificationController _notificationController;
    [SerializeField] MapMenuDisplayHandler _menuHandler;
    [SerializeField] TransportController _transportController;

    public Place TargetPlace { get => _targetPlace; }

    private void Awake()
    {
        _placesController = PlacesController.Instance;
        _playerTransport = PlayerTransport.Instance;
        _timeManager = TimeManager.Instance;
        _playerAction = PlayerAction.Instance;
        _gameManager = GameManager.Instance;
        _notificationController = FindObjectOfType<NotificationController>();

        _targetPlaceId = ConvertType.GetPlaceId(_targetPlace);
        
                
    }

    public void OnClick()
    {
        Place currentPlace = _playerTransport.CurrentPlace;
        if (!ReferenceEquals(_placesController, null))
        {
            Dictionary<string, PlaceEntry> places = _placesController.PlacesDic;
            if (!ReferenceEquals(places, null))
            {
                int originIndex = places[ConvertType.GetPlaceId(currentPlace)].TransportIndex;
                int destinationIndex = places[ConvertType.GetPlaceId(_targetPlace)].TransportIndex;
                _totalSecond = _transportController.GetTotalTimeToTransport(originIndex, destinationIndex);
                
                if (_timeManager.HasTimeEnough(_totalSecond))
                {
                    int minute;
                    minute = _totalSecond / 60;
                     _energyToConsume = _transportController.GetEnergyToTransport(minute);
                    if (_playerAction.EnergyIsEnough(_energyToConsume))
                    {
                        Transporting(false);
                    }
                    else
                    {
                        if(_targetPlace == Place.Home)
                        {
                            Transporting(true);
                        }
                        else
                        {
                            // energy not enough
                            _notificationController.EnergyNotEnoughForTransport();
                            return;
                        }

                        
                    }
                }
                else
                {
                    if (_targetPlace == Place.Home)
                    {
                        Transporting(true);
                    }
                    else
                    {
                        // time not enough
                        _notificationController.TimeNotEnoughForTransport();
                        return;
                    }

                }
            }
        }
    }
    public void OnTriger()
    {
        if (!_targetPlaceId.Equals(string.Empty))
        {

            if (_placesController.PlacesDic.ContainsKey(_targetPlaceId))
            {
                _menuHandler.OnPlaceTrigerShowArriver(_targetPlaceId);
                _menuHandler.OnPlaceTrigerShowTransportInfo(_targetPlaceId);
            }
        }
    }

    public void OnExitTriger()
    {
        _menuHandler.OnExitTriger();
    }

    private void Transporting(bool outOfControl)
    {
        if (_playerTransport.CurrentPlace == _targetPlace)
        {
            _transportController.Transporting(_energyToConsume, _totalSecond, _targetPlace, _targetPlaceId, outOfControl);
            _transportController.TransportFinished();
        }
        else
        {
            _gameManager.Transporting();
            _timeManager.SkilpTime(_totalSecond, 3);
            _transportController.Transporting(_energyToConsume, _totalSecond, _targetPlace, _targetPlaceId, outOfControl);
        }
        
    }


}
