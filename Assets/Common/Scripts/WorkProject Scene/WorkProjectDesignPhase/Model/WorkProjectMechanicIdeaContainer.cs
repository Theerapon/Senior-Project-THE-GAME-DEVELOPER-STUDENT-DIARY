using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProjectMechanicIdeaContainer : IdeaContainer
{
    public Events.EventOnWorkProjectMechanicIeasContainerCompleted OnMechanicIeasContainerCompleted;

    protected override void CreateIdeasSlot()
    {
        GameObject copy = null;
        if (!ReferenceEquals(IdeasController.Instance.MechanicIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in IdeasController.Instance.MechanicIdeas)
            {
                if (idea.Value.Collected)
                {
                    copy = Instantiate(_template, transform);
                }

            }
            _template.SetActive(false);
            OnMechanicIeasContainerCompleted?.Invoke();
        }
    }
}
