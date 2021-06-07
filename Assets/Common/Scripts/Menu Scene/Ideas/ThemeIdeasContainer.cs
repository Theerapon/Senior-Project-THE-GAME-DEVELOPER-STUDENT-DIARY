using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeIdeasContainer : IdeaContainer
{
    public Events.EventOnThemeIdeasContainerCompleted OnThemeIdeasContainerCompleted;    

    protected override void CreateIdeasSlot()
    {
        GameObject copy = null;
        if (!ReferenceEquals(IdeasController.ThemeIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in IdeasController.ThemeIdeas)
            {
                copy = Instantiate(_template, transform);
            }
            _template.SetActive(false);
            OnThemeIdeasContainerCompleted?.Invoke();
        } 
    }
}
