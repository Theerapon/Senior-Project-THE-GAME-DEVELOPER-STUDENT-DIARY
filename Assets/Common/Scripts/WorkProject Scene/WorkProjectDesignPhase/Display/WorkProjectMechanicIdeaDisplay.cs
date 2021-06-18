using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseIdeaSlot;

public class WorkProjectMechanicIdeaDisplay : WorkProjectIdeasDisplay
{
    [SerializeField] private WorkProjectMechanicIdeaContainer workProjectMechanicIdeaContainer;
    private IdeasController ideasController;

    protected override void Awake()
    {
        base.Awake();
        workProjectMechanicIdeaContainer.OnMechanicIeasContainerCompleted.AddListener(MechanicIeasContainerCompletedHanlder);
        ideasController = FindObjectOfType<IdeasController>();
    }

    private void MechanicIeasContainerCompletedHanlder()
    {
        baseIdeaSlots.Clear();
        if (workProjectMechanicIdeaContainer.transform != null)
        {
            workProjectMechanicIdeaContainer.transform.GetComponentsInChildren(includeInactive: true, result: baseIdeaSlots);
        }
        for (int index = 0; index < baseIdeaSlots.Count; index++)
        {
            baseIdeaSlots[index].OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotEventHandler);
            baseIdeaSlots[index].OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotEventHandler);
            baseIdeaSlots[index].OnClickWorkProjectIdeaSlot.AddListener(OnClickWorkProjectIdeaSlotEventHandler);
        }

        DisplayedMechanicIdeas();
    }

    private void DisplayedMechanicIdeas()
    {
        int i = 1;

        if (!ReferenceEquals(ideasController.MechanicIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in ideasController.MechanicIdeas)
            {
                if (idea.Value.Collected)
                {
                    baseIdeaSlots[i].IDEASLOT = new IdeaSlot(idea.Key, idea.Value.IdeaType, idea.Value.Icon, idea.Value.IdeaName, idea.Value.Description, idea.Value.Collected);
                    i++;
                }
            }
        }

    }
}
