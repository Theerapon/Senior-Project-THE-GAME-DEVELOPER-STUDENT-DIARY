using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static PlaceEntry;

public class MapMenuHandler : MonoBehaviour
{

    [Header("Show Arriver")]
    [SerializeField] private GameObject showMenuArriver;
    [SerializeField] private TMP_Text placeName;
    [SerializeField] private ArriverGenerator arriverGenerator;
    [SerializeField] private GameObject arriverObject;
    [SerializeField] private GameObject placeNameObject;
    
    [SerializeField] private GameObject currentPlaceName;
    [SerializeField] private GameObject transportInfo;
    private PlacesController placesController;
    private NpcsController npcsController;
    private PlayerTransport playerTransport;

    private string lastPlaceID;


    private void Start()
    {
        placesController = PlacesController.Instance;
        playerTransport = PlayerTransport.Instance;
        npcsController = NpcsController.Instance;
        ActivePlaceNameGameObject(true);
        ActiveArriverGameObject(false);
        ActiveShowMenuArriver(false);
        npcsController.OnHasPlaceArriverUpdate.AddListener(OnHasPlaceArriverUpdateHandler);
        lastPlaceID = string.Empty;
    }


    public void OnPlaceTriger(string placeId)
    {
        if(!ReferenceEquals(placesController.PlacesDic, null) && !ReferenceEquals(placesController, null))
        {
            if (placesController.PlacesDic.ContainsKey(placeId))
            {
                Dictionary<string, Arriver> arrivers = placesController.PlacesDic[placeId].Arrivers;
                if (arrivers.Count > 0)
                {
                    arriverGenerator.CreateTemplate(arrivers);
                    placeName.text = placesController.PlacesDic[placeId].PlaceName;
                    ActiveArriverGameObject(true);
                }
                else
                {
                    placeName.text = placesController.PlacesDic[placeId].PlaceName;
                    ActiveArriverGameObject(false);
                }
                ActiveShowMenuArriver(true);
                lastPlaceID = placeId;
            }
        }
    }

    public void OnExitTriger()
    {
        lastPlaceID = string.Empty;
        ActiveShowMenuArriver(false);    
    }

    private void ActiveShowMenuArriver(bool active)
    {
        if(showMenuArriver.activeSelf != active)
        {
            showMenuArriver.SetActive(active);
        }
    }

    private void ActiveArriverGameObject(bool active)
    {
        if(arriverObject.activeSelf != active)
        {
            arriverObject.SetActive(active);
        }
            
    }
    private void ActivePlaceNameGameObject(bool active)
    {
        if (placeNameObject.activeSelf != active)
        {
            placeNameObject.SetActive(active);
        }

    }
    private void OnHasPlaceArriverUpdateHandler()
    {
        if(lastPlaceID != string.Empty)
        {
            OnPlaceTriger(lastPlaceID);
        }
    }
}
