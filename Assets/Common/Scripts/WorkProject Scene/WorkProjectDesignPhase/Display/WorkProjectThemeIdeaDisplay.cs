using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseIdeaSlot;

public class WorkProjectThemeIdeaDisplay : WorkProjectIdeasDisplay
{
    [SerializeField] private WorkProjectThemeIdeaContainer workProjectThemeIdeaContainer;
    private IdeasController ideasController;

    protected override void Awake()
    {
        base.Awake();
        workProjectThemeIdeaContainer.OnThemeIdeasContainerCompleted.AddListener(ThemeIdeasContainerCompletedHanlder);
        ideasController = FindObjectOfType<IdeasController>();
    }

    private void ThemeIdeasContainerCompletedHanlder()
    {
        baseIdeaSlots.Clear();
        if (workProjectThemeIdeaContainer.transform != null)
        {
            workProjectThemeIdeaContainer.transform.GetComponentsInChildren(includeInactive: true, result: baseIdeaSlots);
        }
        for (int index = 0; index < baseIdeaSlots.Count; index++)
        {
            baseIdeaSlots[index].OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotEventHandler);
            baseIdeaSlots[index].OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotEventHandler);
            baseIdeaSlots[index].OnClickWorkProjectIdeaSlot.AddListener(OnClickWorkProjectIdeaSlotEventHandler);
        }

        DisplayedThemeIdeas();
    }


    private void DisplayedThemeIdeas()
    {
        int i = 1;

        if (!ReferenceEquals(ideasController.ThemeIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in ideasController.ThemeIdeas)
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
