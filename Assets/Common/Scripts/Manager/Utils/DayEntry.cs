using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEntry : MonoBehaviour
{
    private List<string> activities;

    private void Awake()
    {
        activities = new List<string>();
    }

    public DayEntry(List<string> activities)
    {
        this.activities = activities;
    }

    public List<string> GetActivities {
        get { return activities; }
        set 
        {
            activities.Clear();
            activities = value; 
        }
    }

}
