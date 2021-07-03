using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesNPC_Template : MonoBehaviour
{
    private string id = string.Empty;
    private string npc_id = string.Empty;
    private int first_relationship = 0;
    private int end_relationship = 0;
    private Place condition_place = Place.Null;
    private List<Dialogue> dialoguesList = null;
    private CreateEvent condition_event = CreateEvent.Null;
    private string ideaId;

    public DialoguesNPC_Template(string id, string npc_id, int first_relationship, int end_relationship, Place condition_place, List<Dialogue> dialoguesList, CreateEvent condition_event, string ideaId)
    {
        this.id = id;
        this.npc_id = npc_id;
        this.first_relationship = first_relationship;
        this.end_relationship = end_relationship;
        this.condition_place = condition_place;
        this.dialoguesList = dialoguesList;
        this.condition_event = condition_event;
        this.ideaId = ideaId;
    }

    public string Id { get => id; }
    public string Npc_id { get => npc_id; }
    public int First_relationship { get => first_relationship; }
    public int End_relationship { get => end_relationship; }
    public Place Condition_place { get => condition_place; }
    public List<Dialogue> DialoguesList { get => dialoguesList; }
    public CreateEvent Condition_event { get => condition_event; }
    public string IdeaId { get => ideaId; }
}
