using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseIdeaSlot;

public class GoalIdeaDisplay : MonoBehaviour
{
    #region Events
    public Events.EventOnPointEnterIdeaSlot OnPointEnterIdeaSlotEvent;
    public Events.EventOnPointExitIdeaSlot OnPointExitIdeaSlotEvent;
    #endregion

    [SerializeField] private GoalIdeaContainer goalIdeaContainer;
    private List<BaseIdeaSlot> baseIdeaSlots;
    protected IdeasController ideasController;

    private void Awake()
    {
        ideasController = FindObjectOfType<IdeasController>();
        baseIdeaSlots = new List<BaseIdeaSlot>();
        goalIdeaContainer.OnGoalIdeasContainerCompleted.AddListener(GoalIdeasCompletedHandler);
    }

    private void GoalIdeasCompletedHandler()
    {
        Debug.Log("GoalIdeasCompletedHandler");
        if (goalIdeaContainer.transform != null)
        {
            goalIdeaContainer.transform.GetComponentsInChildren(includeInactive: true, result: baseIdeaSlots);
            Debug.Log("Transform " + baseIdeaSlots.Count);
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
        int i = 1;
        if(!ReferenceEquals(ideasController.GoalIdeas, null))
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
            Debug.Log("Displayed");
        }

    }

    private void OnPointExitIdeaSlotEventHandler(BaseIdeaSlot baseIdeaSlot)
    {
        OnPointEnterIdeaSlotEvent?.Invoke(baseIdeaSlot);   
    }

    private void OnPointEnterIdeaSlotEventHandler(BaseIdeaSlot baseIdeaSlot)
    {
        OnPointEnterIdeaSlotEvent?.Invoke(baseIdeaSlot);
    }
}
