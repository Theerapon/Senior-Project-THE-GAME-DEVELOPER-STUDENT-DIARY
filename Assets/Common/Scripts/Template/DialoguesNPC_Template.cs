using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesNPC_Template : MonoBehaviour
{
    private string id = string.Empty;
    private string npc_id = string.Empty;
    private bool loop = false;
    private int first_relationship = 0;
    private int end_relationship = 0;
    private string condition_gift = string.Empty;
    private string condition_equip = string.Empty;
    private string condition_time = string.Empty;
    private int firstHour = 0;
    private int firstMinute = 0;
    private int endHour = 0;
    private int endMinute = 0;
    private Place condition_place = Place.Null;
    private List<Dialogue> dialoguesList = null;
    private CreateEvent condition_event = CreateEvent.Null;
    private List<string> ideasIdList = null;
    private List<string> itemIdList = null;

    public DialoguesNPC_Template(string id, string npc_id, bool loop, int first_relationship, int end_relationship, string condition_gift, string condition_equip, string condition_time, int firstHour, int firstMinute, int endHour, int endMinute, Place condition_place, List<Dialogue> dialoguesList, CreateEvent condition_event, List<string> ideasIdList, List<string> itemIdList)
    {
        this.id = id;
        this.npc_id = npc_id;
        this.loop = loop;
        this.first_relationship = first_relationship;
        this.end_relationship = end_relationship;
        this.condition_gift = condition_gift;
        this.condition_equip = condition_equip;
        this.condition_time = condition_time;
        this.firstHour = firstHour;
        this.firstMinute = firstMinute;
        this.endHour = endHour;
        this.endMinute = endMinute;
        this.condition_place = condition_place;
        this.dialoguesList = dialoguesList;
        this.condition_event = condition_event;
        this.ideasIdList = ideasIdList;
        this.itemIdList = itemIdList;
    }

    public string Id { get => id; }
    public string Npc_id { get => npc_id; }
    public bool Loop { get => loop; }
    public int First_relationship { get => first_relationship; }
    public int End_relationship { get => end_relationship; }
    public string Condition_gift { get => condition_gift; }
    public string Condition_equip { get => condition_equip; }
    public string Condition_time { get => condition_time; }
    public int FirstHour { get => firstHour; }
    public int FirstMinute { get => firstMinute; }
    public int EndHour { get => endHour; }
    public int EndMinute { get => endMinute; }
    public Place Condition_place { get => condition_place; }
    public List<Dialogue> DialoguesList { get => dialoguesList; }
    public CreateEvent Condition_event { get => condition_event; }
    public List<string> IdeasIdList { get => ideasIdList; }
    public List<string> ItemIdList { get => itemIdList; }

}
