using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProjectGoalIdeaContainer : IdeaContainer
{
    public Events.EventOnWorkProjectGoalIdeasContainerCompleted OnGoalIdeasContainerCompleted;
    protected override void CreateIdeasSlot()
    {
        GameObject copy = null;
        if (!ReferenceEquals(IdeasController.Instance.GoalIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in IdeasController.Instance.GoalIdeas)
            {
                if (idea.Value.Collected)
                {
                    copy = Instantiate(_template, transform);
                }

            }
            _template.SetActive(false);
            OnGoalIdeasContainerCompleted?.Invoke();
        }
    }
}
