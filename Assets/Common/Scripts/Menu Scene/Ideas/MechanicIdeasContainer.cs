using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicIdeasContainer : IdeaContainer
{
    public Events.EventOnMechanicIeasContainerCompleted OnMechanicIeasContainerCompleted;

    protected override void CreateIdeasSlot()
    {
        GameObject copy = null;
        if (!ReferenceEquals(IdeasController.Instance.MechanicIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in IdeasController.Instance.MechanicIdeas)
            {
                copy = Instantiate(_template, transform);
            }
            _template.SetActive(false);
            OnMechanicIeasContainerCompleted?.Invoke();
        }
    }
}
