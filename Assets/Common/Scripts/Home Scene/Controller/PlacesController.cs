using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesController : Manager<PlacesController>
{
    [SerializeField] private TimeManager _timeManager;

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

        _timeManager.OnTenMinute.AddListener(OnTenMinuteHandler);
    }

    private void OnTenMinuteHandler()
    {
        if (!ReferenceEquals(placesDic, null))
        {
            float currentHour = _timeManager.Hour;
            float currentMinute = _timeManager.Minute;
            Day currentDay = _timeManager.CurrentDays;
            int indexDay = ConvertType.ConvertDayToIne(currentDay);

            foreach (KeyValuePair<string, PlaceEntry> place in placesDic)
            {
                
                PlaceEntry placeEntry = place.Value;
                bool currentDayIsOpen = placeEntry.DayOpen[indexDay];
                bool isOpen = placeEntry.IsOpen;
                float openHour = placeEntry.OpenTimeHour;
                float openMinute = placeEntry.OpenTimeMinute;
                float closeHour = placeEntry.CloseTimeHour;
                float closeMinute = placeEntry.CloseTimeMinute;


                if (currentDayIsOpen)
                {
                    if ((currentHour >= openHour && currentHour <= closeHour))
                    {
                        if (currentHour == closeHour)
                        {
                            if (currentMinute < closeMinute)
                            {
                                placeEntry.Open();
                            }
                            else
                            {
                                placeEntry.Close();
                            }
                        }
                        else
                        {
                            placeEntry.Open();
                        }


                    }
                    else
                    {

                        placeEntry.Close();
                    }
                }
                else
                {
                    placeEntry.Close();
                }
                
            }

            
        }
    }
}
