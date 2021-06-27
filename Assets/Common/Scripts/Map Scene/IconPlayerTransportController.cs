using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconPlayerTransportController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private GameObject[] _gameObjects;
    PlayerTransport playerTransport;
    private int _currentIndex;

    private void Awake()
    {
        playerTransport = PlayerTransport.Instance;
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        Initializing();
    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.MAP)
        {
            Initializing();
        }
        else
        {
            _gameObjects[_currentIndex].SetActive(false);
        }
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
                    _currentIndex = i;
                }
                else
                {
                    _gameObjects[i].SetActive(false);
                }
            }
        }
    }
}
