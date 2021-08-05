using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseIdeaSlot;

public class ThemeIdeasDisplay : IdeasDisplay
{
    [SerializeField] private ThemeIdeasContainer themeIdeasContainer;
    private IdeasController ideasController;

    protected override void Awake()
    {
        base.Awake();
        themeIdeasContainer.OnThemeIdeasContainerCompleted.AddListener(ThemeIdeasContainerCompletedHandler);
        ideasController = FindObjectOfType<IdeasController>();
    }


    private void ThemeIdeasContainerCompletedHandler()
    {
        baseIdeaSlots.Clear();
        if (themeIdeasContainer.transform != null)
        {
            themeIdeasContainer.transform.GetComponentsInChildren(includeInactive: true, result: baseIdeaSlots);
        }

        for (int index = 0; index < baseIdeaSlots.Count; index++)
        {
            baseIdeaSlots[index].OnPointEnterIdeaSlotEvent.AddListener(OnPointEnterIdeaSlotEventHandler);
            baseIdeaSlots[index].OnPointExitIdeaSlotEvent.AddListener(OnPointExitIdeaSlotEventHandler);
        }

        DisplayedThemeIdeas();
    }

    private void DisplayedThemeIdeas()
    {
        int i = 0;
        if (ideasController.ThemeIdeas.Count + 1 == themeIdeasContainer.transform.childCount)
        {
            i = 1;
        }
        else
        {
            i = ideasController.ThemeIdeas.Count + 1;
        }

        if (!ReferenceEquals(ideasController.ThemeIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in ideasController.ThemeIdeas)
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
