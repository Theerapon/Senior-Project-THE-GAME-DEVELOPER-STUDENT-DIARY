using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesController : Manager<PlacesController>
{
    private Places_DataHandler places_DataHandler;
    private Dictionary<string, PlaceEntry> placesDic;

    public Dictionary<string, PlaceEntry> PlacesDic { get => placesDic;}

    protected override void Awake()
    {
        base.Awake();
        placesDic = new Dictionary<string, PlaceEntry>();
        places_DataHandler = FindObjectOfType<Places_DataHandler>();

        //place
        if (!ReferenceEquals(places_DataHandler.GetPlacesDic, null))
        {
            foreach (KeyValuePair<string, Place_Template> place in places_DataHandler.GetPlacesDic)
            {
                placesDic.Add(place.Key, new PlaceEntry(place.Value));
            }
        }
    }
}
