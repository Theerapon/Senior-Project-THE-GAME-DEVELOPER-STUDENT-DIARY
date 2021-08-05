using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProjectThemeIdeaContainer : IdeaContainer
{
    public Events.EventOnWorkProjectThemeIdeasContainerCompleted OnThemeIdeasContainerCompleted;

    protected override void CreateIdeasSlot()
    {
        GameObject copy = null;
        if (!ReferenceEquals(IdeasController.Instance.ThemeIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in IdeasController.Instance.ThemeIdeas)
            {
                if (idea.Value.Collected)
                {
                    copy = Instantiate(_template, transform);
                }

            }
            _template.SetActive(false);
            OnThemeIdeasContainerCompleted?.Invoke();
        }
    }
}
