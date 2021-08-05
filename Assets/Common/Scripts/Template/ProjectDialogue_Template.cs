using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectDialogue_Template : MonoBehaviour
{
    private ProjectPhase _projectPhase;
    private string _npcId;
    private List<Dialogue> _dialogues;

    public ProjectDialogue_Template(ProjectPhase projectPhase, string npcId, List<Dialogue> dialogues)
    {
        _projectPhase = projectPhase;
        _npcId = npcId;
        _dialogues = dialogues;
    }

    public ProjectPhase ProjectPhase { get => _projectPhase; }
    public string NpcId { get => _npcId; }
    public List<Dialogue> Dialogues { get => _dialogues; }
}
