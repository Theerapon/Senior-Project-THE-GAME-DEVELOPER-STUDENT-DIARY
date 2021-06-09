using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalIdeaContainer : IdeaContainer
{
    public Events.EventOnGoalIdeasContainerCompleted OnGoalIdeasContainerCompleted;


    protected override void CreateIdeasSlot()
    {
        GameObject copy = null;
        if(!ReferenceEquals(IdeasController.Instance.GoalIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in IdeasController.Instance.GoalIdeas)
            {
                copy = Instantiate(_template, transform);
            }
            _template.SetActive(false);
            OnGoalIdeasContainerCompleted?.Invoke();
        }
    }
}
