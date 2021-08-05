using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlaceEntry;

public class Npc : MonoBehaviour
{
    private const int INST_MAX_RELATIONSHIOP = 100;
    private const int INST_MAX_CHAT = 2;
    private const int INST_MAX_GIFT = 1;

    private PlacesController placesController;
    private Arriver arriver;
    private int countChat;
    private int countGift;

    public enum RelationshipPhase
    {
        Phase1,
        Phase2,
        Phase3,
        Phase4
    }
    private RelationshipPhase relationshipPhase;

    public Npc(Npc_Template npc_Template)
    {
        definition = npc_Template;
        placesController = PlacesController.Instance;
        arriver = new Arriver(definition.Id, definition.Icon, definition.NormalImage, definition.NpcName);
        Initializing();
    }

    private Npc_Template definition;
    private Place currentPlace;
    private bool isBirthday;
    private int relationship;

    private void Initializing()
    {
        relationshipPhase = RelationshipPhase.Phase1;
        currentPlace = definition.OriginHome;
        isBirthday = false;
        relationship = 0;
        countChat = 0;
        countGift = 0;
        string placeID = ConvertType.GetPlaceId(currentPlace);
        if(placesController.PlacesDic != null)
        {
            if (placesController.PlacesDic.ContainsKey(placeID))
            {
                placesController.PlacesDic[placeID].IsResidents(Id);
                placesController.PlacesDic[placeID].Arrived(arriver);
            }
        }
        
    }

    public string Id { get => definition.Id; }
    public string NpcName { get => definition.NpcName; }
    public Sprite Icon { get => definition.Icon; }
    public Sprite HappinessImage { get => definition.HappinessImage; }
    public Sprite SadnessImage { get => definition.SadnessImage; }
    public Sprite FearImage { get => definition.FearImage; }
    public Sprite DisgusImage { get => definition.DisgusImage; }
    public Sprite AngerImage { get => definition.AngerImage; }
    public Sprite SurpriseImage { get => definition.SurpriseImage; }
    public Sprite NormalImage { get => definition.NormalImage; }
    public List<string> DescriptionRelationship { get => definition.DescriptionRelationship; }
    public string FavoriteItemSetId { get => definition.FavoriteItemSetId; }
    public Place OriginHome { get => definition.OriginHome; }
    public string Birthday { get => definition.Birthday; }
    public int DayBirthday { get => definition.DayBirthday; }
    public int MounthBirthday { get => definition.MounthBirthday; }
    public int YearBirthday { get => definition.YearBirthday; }
    public List<string> RegisterId { get => definition.RegisterId; }
    public Place CurrentPlace { get => currentPlace; set => currentPlace = value; }
    public bool IsBirthday { get => isBirthday; set => isBirthday = value; }
    public int Relationship { get => relationship; }
    public Arriver Arriver { get => arriver; }

    public void SetOnNewDay()
    {
        countChat = 0;
        countGift = 0;
    }

    public void IncreaseRelationship(int amount)
    {
        if(relationship + amount >= INST_MAX_RELATIONSHIOP)
        {
            relationship = INST_MAX_RELATIONSHIOP;
        }
        else
        {
            relationship += amount;
        }
    }
    public void DecreaseRelationship(int amount)
    {
        if (relationship - amount <= 0)
        {
            relationship = 0;
        }
        else
        {
            relationship -= amount;
        }
    }
    public void CountGift()
    {
        countGift++;
    }
    public bool CanGift()
    {
        return countGift < INST_MAX_GIFT;
    }
    public void CountChat()
    {
        countChat++;
    }
    public bool CanChat()
    {
        return countChat < INST_MAX_CHAT;
    }
}
