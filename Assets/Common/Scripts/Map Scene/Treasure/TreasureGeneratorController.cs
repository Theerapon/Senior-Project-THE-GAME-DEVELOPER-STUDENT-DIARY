using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureGeneratorController : MonoBehaviour
{
    private TreasureController treasureController;
    private GameManager _gameManager;

    [SerializeField] private GameObject[] _treasureGameObjects;

    private void Awake()
    {
        treasureController = TreasureController.Instance;
        _gameManager = GameManager.Instance;
        _gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        //Initializing();
    }

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.MAP)
        {
            Initializing();
        }
    }

    private void Initializing()
    {
        bool explo = true;
        Place place = Place.Null;
        if (!ReferenceEquals(treasureController, null))
        {
            explo = treasureController.Exploration;
            place = treasureController.CurrentPlace;
        }

        if (explo)
        {
            for (int i = 0; i < _treasureGameObjects.Length; i++)
            {
                SetActive(_treasureGameObjects[i], false);
            }
        } 
        else
        {
            for (int i = 0; i < _treasureGameObjects.Length; i++)
            {
                MapPlace mapPlace = _treasureGameObjects[i].GetComponent<MapPlace>();
                if (!ReferenceEquals(mapPlace, null))
                {
                    if(mapPlace.TargetPlace == place)
                    {
                        SetActive(_treasureGameObjects[i], true);
                    }
                    else
                    {
                        SetActive(_treasureGameObjects[i], false);
                    }
                }
                }

                
        }

    }

    private void SetActive(GameObject gameObject, bool active)
    {
        gameObject.SetActive(active);
    }

}
