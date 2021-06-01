using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Template : MonoBehaviour
{
    private string id = string.Empty;
    private string npcName = "Npc Name";
    private Sprite icon = null;
    private Sprite happinessImage = null;
    private Sprite sadnessImage = null;
    private Sprite fearImage = null;
    private Sprite disgusImage = null;
    private Sprite angerImage = null;
    private Sprite surpriseImage = null;
    private Sprite normalImage = null;
    private List<string> descriptionRelationship = null;
    private string favoriteItemSetId = string.Empty;
    private Place originHome = Place.Null;
    private string birthday = "Unknown";
    private int dayBirthday = 0;
    private int mounthBirthday = 0;
    private int yearBirthday = 0;
    private List<string> registerId = null;

    public string Id { get => id; }
    public string NpcName { get => npcName; }
    public Sprite Icon { get => icon; }
    public Sprite HappinessImage { get => happinessImage; }
    public Sprite SadnessImage { get => sadnessImage; }
    public Sprite FearImage { get => fearImage; }
    public Sprite DisgusImage { get => disgusImage; }
    public Sprite AngerImage { get => angerImage; }
    public Sprite SurpriseImage { get => surpriseImage; }
    public Sprite NormalImage { get => normalImage; }
    public List<string> DescriptionRelationship { get => descriptionRelationship; }
    public string FavoriteItemSetId { get => favoriteItemSetId; }
    public Place OriginHome { get => originHome; }
    public string Birthday { get => birthday; }
    public int DayBirthday { get => dayBirthday; }
    public int MounthBirthday { get => mounthBirthday; }
    public int YearBirthday { get => yearBirthday; }
    public List<string> RegisterId { get => registerId; }

    public Npc_Template(string id, string npcName, Sprite icon, Sprite happinessImage, Sprite sadnessImage, Sprite fearImage, Sprite disgusImage, Sprite angerImage, Sprite surpriseImage, Sprite normalImage, List<string> descriptionRelationship, string favoriteItemSetId, Place originHome, string birthday, int dayBirthday, int mounthBirthday, int yearBirthday, List<string> registerId)
    {
        this.id = id;
        this.npcName = npcName;
        this.icon = icon;
        this.happinessImage = happinessImage;
        this.sadnessImage = sadnessImage;
        this.fearImage = fearImage;
        this.disgusImage = disgusImage;
        this.angerImage = angerImage;
        this.surpriseImage = surpriseImage;
        this.normalImage = normalImage;
        this.descriptionRelationship = descriptionRelationship;
        this.favoriteItemSetId = favoriteItemSetId;
        this.originHome = originHome;
        this.birthday = birthday;
        this.dayBirthday = dayBirthday;
        this.mounthBirthday = mounthBirthday;
        this.yearBirthday = yearBirthday;
        this.registerId = registerId;
    }
}
