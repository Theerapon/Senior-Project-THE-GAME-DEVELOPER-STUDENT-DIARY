using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicIdeasContainer : IdeaContainer
{
    public Events.EventOnMechanicIeasContainerCompleted OnMechanicIeasContainerCompleted;
    
    protected override void CreateIdeasSlot()
    {
        GameObject copy = null;
        if (!ReferenceEquals(IdeasController.MechanicIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in IdeasController.MechanicIdeas)
            {
                copy = Instantiate(_template, transform);
            }
            _template.SetActive(false);
            OnMechanicIeasContainerCompleted?.Invoke();
        }
    }
}
