using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseIdeaSlot;

public class GoalIdeaDisplay : IdeasDisplay
{ 
    [SerializeField] private GoalIdeaContainer goalIdeaContainer;
    private IdeasController ideasController;

    protected override void Awake()
    {
        base.Awake();
        goalIdeaContainer.OnGoalIdeasContainerCompleted.AddListener(GoalIdeasCompletedHandler);
        ideasController = FindObjectOfType<IdeasController>();
    }


    private void GoalIdeasCompletedHandler()
    {
        baseIdeaSlots.Clear();
        if (goalIdeaContainer.transform != null)
        {
            goalIdeaContainer.transform.GetComponentsInChildren(includeInactive: true, result: baseIdeaSlots);
        }

        for (int index = 0; index < baseIdeaSlots.Count; index++)
        {
            baseIdeaSlots[index].OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotEventHandler);
            baseIdeaSlots[index].OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotEventHandler);
        }

        DisplayedGoalIdeas();
    }

    private void DisplayedGoalIdeas()
    {
        int i = 0;
        if(ideasController.GoalIdeas.Count + 1 == goalIdeaContainer.transform.childCount)
        {
            i = 1;
        }
        else
        {
            i = ideasController.GoalIdeas.Count + 1;
        }

        if (!ReferenceEquals(ideasController.GoalIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in ideasController.GoalIdeas)
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
