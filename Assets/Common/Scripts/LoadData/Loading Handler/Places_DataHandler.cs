using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places_DataHandler : DataHandler
{
    protected Dictionary<string, Place_Template> placesDic;
    [SerializeField] private PlacesVM placesVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, Place_Template> GetPlacesDic
    {
        get { return placesDic; }
    }

    protected void Awake()
    {
        placesDic = new Dictionary<string, Place_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        placesDic = placesVM.Interpert();
        if (!ReferenceEquals(placesDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Place interpret completed");
        //foreach (KeyValuePair<string, Place_Template> place in placesDic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Open = {2:00}:{3:00}, Sun Open = {4}, Store ID = {5}",
        //        place.Value.Id, place.Value.PlaceName, place.Value.OpenTimeHour, place.Value.OpenTimeMinute, place.Value.DayOpen[6], place.Value.StoreId));

        //}
    }
}
