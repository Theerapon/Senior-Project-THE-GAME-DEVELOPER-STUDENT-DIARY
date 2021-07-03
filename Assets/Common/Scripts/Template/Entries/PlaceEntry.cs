using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceEntry : MonoBehaviour
{
    [System.Serializable]
    public class Arriver
    {
        public string arriverId;
        public Sprite arriverIcon;
        public Sprite arriverProfilePicture;
        public string arriverName;

        public Arriver(string arriverId, Sprite arriverIcon, Sprite arriverProfilePicture, string arriverName)
        {
            this.arriverId = arriverId;
            this.arriverIcon = arriverIcon;
            this.arriverProfilePicture = arriverProfilePicture;
            this.arriverName = arriverName;
        }
    }

    private Place_Template definition;
    private bool isStore;
    private List<string> residentsID;
    private bool isOpen;
    private Dictionary<string, Arriver> arrivers;

    public bool IsStore { get => isStore; }
    public List<string> ResidentsID { get => residentsID; }
    public bool IsOpen { get => isOpen; }
    public Dictionary<string, Arriver> Arrivers { get => arrivers; }
    public string Id { get => definition.Id; }
    public string PlaceName { get => definition.PlaceName; }
    public int OpenTimeHour { get => definition.OpenTimeHour; }
    public int OpenTimeMinute { get => definition.OpenTimeMinute; }
    public int CloseTimeHour { get => definition.CloseTimeHour; }
    public int CloseTimeMinute { get => definition.CloseTimeMinute; }
    public OnClickSwitchScene SwitchScene { get => definition.SwitchScene; }
    public bool[] DayOpen { get => definition.DayOpen; }
    public string StoreId { get => definition.StoreId; }
    public int TransportIndex { get => definition.TransportIndex; }
    public PlaceType PlaceType { get => definition.PlaceType; }

    public PlaceEntry(Place_Template place_Template)
    {
        definition = place_Template;
        residentsID = new List<string>();
        arrivers = new Dictionary<string, Arriver>();
        Initializing();
    }

    public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }

    private void Initializing()
    {
        isOpen = false;
        if (definition.StoreId.Equals(string.Empty))
        {
            isStore = false;
        }
        else
        {
            isStore = true;
        }
    }

    public void Arrived(Arriver arriver)
    {
        if (!arrivers.ContainsKey(arriver.arriverId))
        {
            arrivers.Add(arriver.arriverId, arriver);
        }
    }

    public void Leave(string arriverId)
    {
        if (arrivers.ContainsKey(arriverId))
        {
            arrivers.Remove(arriverId);
        }
    }

    public void IsResidents(string npcId)
    {
        if (!residentsID.Contains(npcId))
        {
            residentsID.Add(npcId);
        }
    }
}
