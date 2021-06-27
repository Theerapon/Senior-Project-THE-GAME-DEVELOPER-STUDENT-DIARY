using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconPlayerTransportController : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;
    PlayerTransport playerTransport;

    private void Awake()
    {
        playerTransport = PlayerTransport.Instance;
    }

    private void Start()
    {
        playerTransport.OnPlayerUpdatePlacePosition.AddListener(OnPlayerUpdatePlacePositionHandler);
        Initializing();
    }

    private void OnPlayerUpdatePlacePositionHandler(Place place)
    {
        SetIconCurrentPlace(place);
    }


    private void Initializing()
    {
        SetIconCurrentPlace(playerTransport.CurrentPlace);
    }

    private void SetIconCurrentPlace(Place place)
    {
        for(int i = 0; i < _gameObjects.Length; i++)
        {
            PlaceInfo placeInfo = _gameObjects[i].GetComponent<PlaceInfo>();
            if(placeInfo != null)
            {
                if (placeInfo.Place == place)
                {
                    _gameObjects[i].SetActive(true);
                }
                else
                {
                    _gameObjects[i].SetActive(false);
                }
            }
        }
    }
}
