using System;
using System.Collections.Generic;
using UnityEngine;

public class PlacesVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Name = "Name";
    private const string INST_SET_Open = "Open";
    private const string INST_SET_Close = "Close";
    private const string INST_SET_OnClick = "OnClick";
    private const string INST_SET_Mon = "Mon";
    private const string INST_SET_Tue = "Tue";
    private const string INST_SET_Wed = "Wed";
    private const string INST_SET_Thu = "Thu";
    private const string INST_SET_Fri = "Fri";
    private const string INST_SET_Sat = "Sat";
    private const string INST_SET_Sun = "Sun";
    private const string INST_SET_StoreID = "StoreID";
    private const string INST_SET_TranIndex = "TranIndex";
    private const string INST_SET_PlaceType = "PlaceType";

    #endregion

    [SerializeField] private Places_Loading places_Loading;

    public Dictionary<string, Place_Template> Interpert()
    {
        if (!ReferenceEquals(places_Loading, null))
        {
            Dictionary<string, Place_Template> placeDic = new Dictionary<string, Place_Template>();

            foreach (KeyValuePair<string, string> line in places_Loading.textLists)
            {
                Place_Template place = null;
                string key = line.Key;
                string value = line.Value;

                place = CreateTemplate(value);

                if (!ReferenceEquals(place, null))
                {
                    placeDic.Add(key, place);
                }

            }
            if (!ReferenceEquals(placeDic, null))
            {
                return placeDic;
            }
        }

        return null;
    }

    private Place_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        string placeName = "Place Name";
        int openTimeHour = 0;
        int openTimeMinute = 0;
        int closeTimeHour = 0;
        int closeTimeMinute = 0;
        OnClickSwitchScene switchScene = OnClickSwitchScene.None;
        bool[] dayOpen = new bool[7];
        string storeId = string.Empty;
        int transportIndex = -1;
        PlaceType placeType = PlaceType.None;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_Name:
                    placeName = entries[++i];
                    break;
                case INST_SET_Open:
                    string openTime = ConvertType.CheckString(entries[++i]);
                    if (!openTime.Equals(string.Empty))
                    {
                        string[] time_entries = openTime.Split(':');
                        openTimeHour = int.Parse(time_entries[0]);
                        openTimeMinute = int.Parse(time_entries[1]);
                    }
                    break;
                case INST_SET_Close:
                    string closeTime = ConvertType.CheckString(entries[++i]);
                    if (!closeTime.Equals(string.Empty))
                    {
                        string[] closeTime_entries = closeTime.Split(':');
                        closeTimeHour = int.Parse(closeTime_entries[0]);
                        closeTimeMinute = int.Parse(closeTime_entries[1]);
                    }
                    break;
                case INST_SET_OnClick:
                    switchScene = ConvertType.CheckOnClickSwitchScene(entries[++i]);
                    break;
                case INST_SET_Mon:
                    dayOpen[0] = bool.Parse(entries[++i]);
                    break;
                case INST_SET_Tue:
                    dayOpen[1] = bool.Parse(entries[++i]);
                    break;
                case INST_SET_Wed:
                    dayOpen[2] = bool.Parse(entries[++i]);
                    break;
                case INST_SET_Thu:
                    dayOpen[3] = bool.Parse(entries[++i]);
                    break;
                case INST_SET_Fri:
                    dayOpen[4] = bool.Parse(entries[++i]);
                    break;
                case INST_SET_Sat:
                    dayOpen[5] = bool.Parse(entries[++i]);
                    break;
                case INST_SET_Sun:
                    dayOpen[6] = bool.Parse(entries[++i]);
                    break;
                case INST_SET_StoreID:
                    storeId = ConvertType.CheckString(entries[++i]);
                    break;
                case INST_SET_TranIndex:
                    transportIndex = int.Parse(entries[++i]);
                    break;
                case INST_SET_PlaceType:
                    placeType = ConvertType.ConvertPlaceType(entries[++i]);
                    break;


            }

        }

        return new Place_Template(id, placeName, openTimeHour, openTimeMinute, closeTimeHour, closeTimeMinute, switchScene, dayOpen, storeId, transportIndex, placeType);
    }
}
