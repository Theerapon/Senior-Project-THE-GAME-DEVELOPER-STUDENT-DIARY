using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseIdeaSlot;

public class MechanicIdeasDisplay : IdeasDisplay
{
    [SerializeField] private MechanicIdeasContainer mechanicIdeasContainer;
    private IdeasController ideasController;

    protected override void Awake()
    {
        base.Awake();
        mechanicIdeasContainer.OnMechanicIeasContainerCompleted.AddListener(MechanicIeasContainerCompletedHandler);
        ideasController = FindObjectOfType<IdeasController>();
    }


    private void MechanicIeasContainerCompletedHandler()
    {
        baseIdeaSlots.Clear();
        if (mechanicIdeasContainer.transform != null)
        {
            mechanicIdeasContainer.transform.GetComponentsInChildren(includeInactive: true, result: baseIdeaSlots);
        }


        for (int index = 0; index < baseIdeaSlots.Count; index++)
        {
            baseIdeaSlots[index].OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotEventHandler);
            baseIdeaSlots[index].OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotEventHandler);
        }

        DisplayedMechanicIdeas();
    }

    private void DisplayedMechanicIdeas()
    {
        int i = 0;
        if (ideasController.MechanicIdeas.Count + 1 == mechanicIdeasContainer.transform.childCount)
        {
            i = 1;
        }
        else
        {
            i = ideasController.MechanicIdeas.Count + 1;
        }

        if (!ReferenceEquals(ideasController.MechanicIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in ideasController.MechanicIdeas)
            {
                if (idea.Value.Collected)
                {
                    baseIdeaSlots[i].IDEASLOT = new IdeaSlot(idea.Key, idea.Value.IdeaType, idea.Value.Icon, idea.Value.IdeaName, idea.Value.Description, idea.Value.Collected);
                }
                else
                {
                    baseIdeaSlots[i].IDEASLOT = new IdeaSlot(idea.Key, idea.Value.IdeaType, idea.Value.IdeaName, idea.Value.Collected);
                    
                }
                i++;
            }
        }

    }
}
