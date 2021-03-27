using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("Calendar");
    }
    
}
