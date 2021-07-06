using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectDialogue_Template : MonoBehaviour
{
    private ProjectPhase _projectPhase;
    private string _npcId;
    private Dictionary<string, Dialogue> _dialogues;

    public ProjectDialogue_Template(ProjectPhase projectPhase, string npcId, Dictionary<string, Dialogue> dialogues)
    {
        _projectPhase = projectPhase;
        _npcId = npcId;
        _dialogues = dialogues;
    }

    public ProjectPhase ProjectPhase { get => _projectPhase; }
    public string NpcId { get => _npcId; }
    public Dictionary<string, Dialogue> Dialogues { get => _dialogues; }
}
