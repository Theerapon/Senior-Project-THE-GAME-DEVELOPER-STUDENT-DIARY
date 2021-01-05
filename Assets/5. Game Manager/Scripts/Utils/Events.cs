using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventLoadComplete : UnityEvent<bool> { }
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class EventDateCalendar : UnityEvent<string> { }
    [System.Serializable] public class EventTimeCalendar : UnityEvent<string> { }
    [System.Serializable] public class EventSeasonCalendar : UnityEvent<string> { }
}
