using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectDialogue_DataHandler : DataHandler
{
    protected Dictionary<ProjectPhase, ProjectDialogue_Template> _projectDialogueDic;
    [SerializeField] private ProjectDialogueVM _projectDialogueVM;
    [SerializeField] private InterpretHandler _interpretHandler;


    public Dictionary<ProjectPhase, ProjectDialogue_Template> ProjectDialogueDic
    {
        get { return _projectDialogueDic; }
    }

    protected void Awake()
    {
        _projectDialogueDic = new Dictionary<ProjectPhase, ProjectDialogue_Template>();
        _interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        _projectDialogueDic = _projectDialogueVM.Interpert();
        if (!ReferenceEquals(_projectDialogueDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
    }
}
