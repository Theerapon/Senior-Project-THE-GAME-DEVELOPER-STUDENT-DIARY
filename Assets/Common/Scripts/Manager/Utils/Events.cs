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
    [System.Serializable] public class EventGameObject : UnityEvent<GameObject> { }
    [System.Serializable] public class EventSaveInitiated : UnityEvent { }
    [System.Serializable] public class EventProjectValueUpdated : UnityEvent { }
    [System.Serializable] public class EventStatsValueShowed : UnityEvent { }
    [System.Serializable] public class EventSoftSkillsValueShowed : UnityEvent { }
    [System.Serializable] public class EventHardSkillsValueShowed : UnityEvent { }

}
