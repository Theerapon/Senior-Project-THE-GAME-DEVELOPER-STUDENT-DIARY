using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
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
        Initializing();
        Debug.Log(string.Format("Name {0} form {1}", NpcName, OriginHome));
    }

    private Npc_Template definition;
    private Place currentPlace;
    private bool isBirthday;
    private int relationship;
    private bool canChat;
    private string chat;

    private void Initializing()
    {
        relationshipPhase = RelationshipPhase.Phase1;
        currentPlace = Place.Null;
        isBirthday = false;
        relationship = 0;
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
    public bool CanChat { get => canChat; set => canChat = value; }
    public string Chat { get => chat; set => chat = value; }
    public void IncreaseRelationship(int amount)
    {
        relationship += amount;
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
}
