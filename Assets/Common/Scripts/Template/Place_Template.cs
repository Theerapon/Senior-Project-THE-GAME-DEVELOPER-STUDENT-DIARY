using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Template : MonoBehaviour
{
    private string _id = string.Empty;
    private string _placeName = "Place Name";
    private int _openTimeHour = 0;
    private int _openTimeMinute = 0;
    private int _closeTimeHour = 0;
    private int _closeTimeMinute = 0;
    private OnClickSwitchScene _switchScene = OnClickSwitchScene.None;
    private bool[] _dayOpen = new bool[7];
    private string _storeId = string.Empty;
    private int _transportIndex = -1;
    private PlaceType _placeType = PlaceType.None;

    public Place_Template(string id, string placeName, int openTimeHour, int openTimeMinute, int closeTimeHour, int closeTimeMinute, OnClickSwitchScene switchScene, bool[] dayOpen, string storeId, int transportIndex, PlaceType placeType)
    {
        _id = id;
        _placeName = placeName;
        _openTimeHour = openTimeHour;
        _openTimeMinute = openTimeMinute;
        _closeTimeHour = closeTimeHour;
        _closeTimeMinute = closeTimeMinute;
        _switchScene = switchScene;
        _dayOpen = dayOpen;
        _storeId = storeId;
        _transportIndex = transportIndex;
        _placeType = placeType;
    }

    public string Id { get => _id; }
    public string PlaceName { get => _placeName; }
    public int OpenTimeHour { get => _openTimeHour; }
    public int OpenTimeMinute { get => _openTimeMinute; }
    public int CloseTimeHour { get => _closeTimeHour; }
    public int CloseTimeMinute { get => _closeTimeMinute; }
    public OnClickSwitchScene SwitchScene { get => _switchScene; }
    public bool[] DayOpen { get => _dayOpen; }
    public string StoreId { get => _storeId; }
    public int TransportIndex { get => _transportIndex; }
    public PlaceType PlaceType { get => _placeType; }
}
