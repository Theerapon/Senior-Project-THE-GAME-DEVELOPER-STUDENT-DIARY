using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalIdeaContainer : MonoBehaviour
{
    public Events.EventOnGoalIdeasContainerCompleted OnGoalIdeasContainerCompleted;

    [SerializeField] protected GameObject _template;
    protected IdeasController ideasController;

    private void Awake()
    {
        ideasController = FindObjectOfType<IdeasController>();
    }
    public void CreateTemplate()
    {
        _template.SetActive(true);
        ClearTmeplate();
        CreateIdeasSlot();
    }

    private void CreateIdeasSlot()
    {
        GameObject copy = null;
        if(!ReferenceEquals(ideasController.GoalIdeas, null))
        {
            foreach (KeyValuePair<string, Idea> idea in ideasController.GoalIdeas)
            {
                copy = Instantiate(_template, transform);
            }
            _template.SetActive(false);
            OnGoalIdeasContainerCompleted?.Invoke();
        }
    }

    private void ClearTmeplate()
    {
        int count = transform.childCount;
        for (int i = 1; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void OnValidate()
    {
        if (_template == null)
        {
            _template = transform.GetChild(0).gameObject;
            _template.SetActive(false);
        }
    }
}
