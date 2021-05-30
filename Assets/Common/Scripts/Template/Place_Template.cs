using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Template : MonoBehaviour
{
    private string id = string.Empty;
    private string placeName = "Place Name";
    private int openTimeHour = 0;
    private int openTimeMinute = 0;
    private int closeTimeHour = 0;
    private int closeTimeMinute = 0;
    private OnClickSwitchScene switchScene = OnClickSwitchScene.None;
    private bool[] dayOpen = new bool[7];
    private string storeId = string.Empty;

    public Place_Template(string id, string placeName, int openTimeHour, int openTimeMinute, int closeTimeHour, int closeTimeMinute, OnClickSwitchScene switchScene, bool[] dayOpen, string storeId)
    {
        this.id = id;
        this.placeName = placeName;
        this.openTimeHour = openTimeHour;
        this.openTimeMinute = openTimeMinute;
        this.closeTimeHour = closeTimeHour;
        this.closeTimeMinute = closeTimeMinute;
        this.switchScene = switchScene;
        this.dayOpen = dayOpen;
        this.storeId = storeId;
    }

    public string Id { get => id; }
    public string PlaceName { get => placeName; }
    public int OpenTimeHour { get => openTimeHour; }
    public int OpenTimeMinute { get => openTimeMinute; }
    public int CloseTimeHour { get => closeTimeHour; }
    public int CloseTimeMinute { get => closeTimeMinute; }
    public OnClickSwitchScene SwitchScene { get => switchScene; }
    public bool[] DayOpen { get => dayOpen; }
    public string StoreId { get => storeId; }
}
