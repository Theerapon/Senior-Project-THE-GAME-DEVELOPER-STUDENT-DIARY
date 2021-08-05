using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectDialogueController : Manager<ProjectDialogueController>
{
    private ProjectDialogue_DataHandler _projectDialogue_DataHandler;
    private Dictionary<ProjectPhase, ProjectDialogue_Template> _projectDialogueDic;

    public Dictionary<ProjectPhase, ProjectDialogue_Template> ProjectDialogueDic { get => _projectDialogueDic; }

    protected override void Awake()
    {
        base.Awake();
        _projectDialogue_DataHandler = FindObjectOfType<ProjectDialogue_DataHandler>();
        _projectDialogueDic = new Dictionary<ProjectPhase, ProjectDialogue_Template>();

        if(!ReferenceEquals(_projectDialogue_DataHandler.ProjectDialogueDic, null))
        {
            foreach(KeyValuePair<ProjectPhase, ProjectDialogue_Template> dialogue in _projectDialogue_DataHandler.ProjectDialogueDic)
            {
                _projectDialogueDic.Add(dialogue.Key, dialogue.Value);
            }
        }
    }
}
