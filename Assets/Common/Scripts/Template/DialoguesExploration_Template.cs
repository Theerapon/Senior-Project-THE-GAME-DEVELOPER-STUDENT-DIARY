using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesExploration_Template : MonoBehaviour
{
    private string id = string.Empty;
    private List<Dialogue> dialoguesList = null;
    private string spawnItemId = string.Empty;

    public string Id { get => id; }
    public List<Dialogue> DialoguesList { get => dialoguesList; }
    public string SpawnItemId { get => spawnItemId; }

    public DialoguesExploration_Template(string id, List<Dialogue> dialoguesList, string spawnItemId)
    {
        this.id = id;
        this.dialoguesList = dialoguesList;
        this.spawnItemId = spawnItemId;
    }
}
