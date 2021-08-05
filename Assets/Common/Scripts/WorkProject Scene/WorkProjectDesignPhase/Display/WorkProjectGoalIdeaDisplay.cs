using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseIdeaSlot;

public class WorkProjectGoalIdeaDisplay : WorkProjectIdeasDisplay
{
    [SerializeField] private WorkProjectGoalIdeaContainer workProjectGoalIdeaContainer;
    private IdeasController ideasController;

    protected override void Awake()
    {
        base.Awake();
        workProjectGoalIdeaContainer.OnGoalIdeasContainerCompleted.AddListener(GoalIdeasCompletedHandler);
        ideasController = FindObjectOfType<IdeasController>();
    }

    private void GoalIdeasCompletedHandler()
    {
        baseIdeaSlots.Clear();
        if(!ReferenceEquals(workProjectGoalIdeaContainer, null))
        {
            workProjectGoalIdeaContainer.transform.GetComponentsInChildren(includeInactive: true, result: baseIdeaSlots);
        }

        for (int index = 0; index < baseIdeaSlots.Count; index++)
        {
            baseIdeaSlots[index].OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotEventHandler);
            baseIdeaSlots[index].OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotEventHandler);
            baseIdeaSlots[index].OnClickWorkProjectIdeaSlot.AddListener(OnClickWorkProjectIdeaSlotEventHandler);
        }

        DisplayedGoalIdeas();
    }

    private void DisplayedGoalIdeas()
    {
        int i = 1;

        if (!ReferenceEquals(ideasController.GoalIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in ideasController.GoalIdeas)
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
