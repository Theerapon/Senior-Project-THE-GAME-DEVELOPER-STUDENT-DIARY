using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlaceEntry;

public class PlayerTransport : Manager<PlayerTransport>
{
    public Events.EventOnPlayerUpdatePlacePosition OnPlayerUpdatePlacePosition;

    private string _playerId;
    private const Place _orginPlace = Place.Home;
    private string _originPlaceId;
    private Arriver _arriver; 

    [SerializeField] private PlacesController _placesController;
    [SerializeField] private CharacterStatusController _characterStatusController;
    private Place _currentPlace;
    private string _currentPlaceId;

    public Place CurrentPlace { get => _currentPlace; }
    public string CurrentPlaceId { get => _currentPlaceId; }

    protected override void Awake()
    {
        base.Awake();
        _playerId = _characterStatusController.Character_ID;
        _arriver = new Arriver(_playerId, _characterStatusController.CharacterIcon, _characterStatusController.CharacterProfile, _characterStatusController.Character_Name);
        _originPlaceId = ConvertType.GetPlaceId(_orginPlace);
        _currentPlaceId = _originPlaceId;
        _currentPlace = _orginPlace;
    }

    private void Start()
    {
        BackHome();
    }

    public void BackHome()
    {
        if (!ReferenceEquals(_placesController, null) && !ReferenceEquals(_placesController.PlacesDic, null))
        {
            //home
            if (_placesController.PlacesDic.ContainsKey(_originPlaceId) && _placesController.PlacesDic.ContainsKey(_currentPlaceId))
            {
                if (_currentPlace != Place.Home)
                {
                    _placesController.PlacesDic[_currentPlaceId].Leave(_playerId);
                }

                _placesController.PlacesDic[_originPlaceId].Arrived(_arriver);
                UpdatePlacePosition(Place.Home);
            }
        }
    }

    public void Transport(Place targetPlace)
    {
        if (targetPlace != Place.Null)
        {
            if (_currentPlace != targetPlace)
            {
                string currentTargetPlaceID = ConvertType.GetPlaceId(targetPlace);
                string currentPlaceID = _currentPlaceId;
                if (_currentPlace != Place.Null && _currentPlace != Place.NotAtPlace)
                {
                    if (_placesController.PlacesDic.ContainsKey(currentPlaceID) && _placesController.PlacesDic.ContainsKey(currentTargetPlaceID))
                    {
                        _placesController.PlacesDic[currentPlaceID].Leave(_playerId);
                        _placesController.PlacesDic[currentTargetPlaceID].Arrived(_arriver);
                    }
                }

                UpdatePlacePosition(targetPlace);
            }

        }
    }

    private void UpdatePlacePosition(Place place)
    {
        _currentPlace = place;
        _currentPlaceId = ConvertType.GetPlaceId(_currentPlace);
        OnPlayerUpdatePlacePosition?.Invoke(_currentPlace);
    }
}
