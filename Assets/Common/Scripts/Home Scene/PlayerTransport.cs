using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlaceEntry;

public class PlayerTransport : Manager<PlayerTransport>
{
    private string playerId;
    private const Place orginPlace = Place.Home;
    private string originPlaceId;
    private Arriver arriver; 

    [SerializeField] private PlacesController placesController;
    [SerializeField] private CharacterStatusController characterStatusController;
    private Place currentPlace;
    private string currentPlaceId;


    protected override void Awake()
    {
        base.Awake();
        playerId = characterStatusController.Character_ID;
        arriver = new Arriver(playerId, characterStatusController.CharacterIcon, characterStatusController.CharacterProfile, characterStatusController.Character_Name);
        originPlaceId = ConvertType.GetPlaceId(orginPlace);
        currentPlaceId = originPlaceId;
        currentPlace = orginPlace;
    }

    private void Start()
    {
        BackHome();
    }

    private void BackHome()
    {
        if (!ReferenceEquals(placesController, null) && !ReferenceEquals(placesController.PlacesDic, null))
        {
            //home
            if (placesController.PlacesDic.ContainsKey(originPlaceId) && placesController.PlacesDic.ContainsKey(currentPlaceId))
            {
                if (currentPlace != Place.Home)
                {
                    placesController.PlacesDic[currentPlaceId].Leave(playerId);
                }

                placesController.PlacesDic[originPlaceId].Arrived(arriver);
                currentPlaceId = originPlaceId;
                currentPlace = Place.Home;
            }
        }
    }

    public void Transport(Place targetPlace)
    {
        if (targetPlace != Place.Null)
        {
            if (currentPlace != targetPlace)
            {
                string currentTargetPlaceID = ConvertType.GetPlaceId(targetPlace);
                string currentPlaceID = currentPlaceId;
                if (currentPlace != Place.Null && currentPlace != Place.NotAtPlace)
                {
                    if (placesController.PlacesDic.ContainsKey(currentPlaceID) && placesController.PlacesDic.ContainsKey(currentTargetPlaceID))
                    {
                        placesController.PlacesDic[currentPlaceID].Leave(playerId);
                        placesController.PlacesDic[currentTargetPlaceID].Arrived(arriver);
                    }
                }

                currentPlace = targetPlace;
            }

        }
    }
}
