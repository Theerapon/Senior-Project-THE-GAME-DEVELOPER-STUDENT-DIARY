using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureGeneratorController : MonoBehaviour
{
    private TreasureController treasureController;

    [SerializeField] private GameObject[] _treasureGameObjects;

    private void Awake()
    {
        treasureController = TreasureController.Instance;
        Initializing();
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
