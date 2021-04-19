using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventOnLoadComplete : UnityEvent<GameManager.GameState> { }
    [System.Serializable] public class EventOnHomeDisplay : UnityEvent<bool> { }
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class EventDateCalendar : UnityEvent<string> { }
    [System.Serializable] public class EventTimeCalendar : UnityEvent<string> { }
    [System.Serializable] public class EventTimeDayOrNight : UnityEvent<bool> { }
    [System.Serializable] public class EventGameObject : UnityEvent<GameObject> { }
    [System.Serializable] public class EventSaveInitiated : UnityEvent { }
    [System.Serializable] public class EventProjectValueUpdated : UnityEvent { }
    [System.Serializable] public class EventStatsValueShowed : UnityEvent { }
    [System.Serializable] public class EventSoftSkillsValueShowed : UnityEvent { }
    [System.Serializable] public class EventHardSkillsValueShowed : UnityEvent { }
    [System.Serializable] public class EventOnTimeSkilpValidation : UnityEvent<GameManager.GameState> { }
    [System.Serializable] public class EventOnEnergyUpdated : UnityEvent { }
    [System.Serializable] public class EventOnMotivationUpdated : UnityEvent { }
    [System.Serializable] public class EventOnMoneyUpdated : UnityEvent { }
    [System.Serializable] public class EventOnCheckedWordUpdate : UnityEvent { }
    [System.Serializable] public class EventOnTypingGameStateChanged : UnityEvent<TypingGame2Manager.TypingGameState> { }
    [System.Serializable] public class EventOnInventoryUpdated : UnityEvent { }
    [System.Serializable] public class EventOnEquipmentUpdated : UnityEvent { }
    [System.Serializable] public class EventOnStorageUpdated : UnityEvent { }
    [System.Serializable] public class EventOnOpenMenu : UnityEvent<GameManager.GameScene> { }
    [System.Serializable] public class EventOnPointEnter : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnPointExit : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnRightClick : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnBeginDrag : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnEndDrag : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnDrag : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnDrop : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnPointEnterStatusSlot : UnityEvent<BaseStatusSlot> { }
    [System.Serializable] public class EventOnPointExitStatusSlot : UnityEvent<BaseStatusSlot> { }
    [System.Serializable] public class EventOnLeftClickStatusSlot : UnityEvent<BaseStatusSlot, bool> { }
    [System.Serializable] public class EventOnPointEnterBonusSlot : UnityEvent<BaseBonusSlot> { }
    [System.Serializable] public class EventOnPointExitBonusSlot : UnityEvent<BaseBonusSlot> { }
    [System.Serializable] public class EventOnLeftClickBonusSlot : UnityEvent<BaseBonusSlot, bool> { }
    [System.Serializable] public class EventOnPointEnterHardSkillSlot : UnityEvent<BaseHardSkillSlot> { }
    [System.Serializable] public class EventOnPointExitHardSkillSlot : UnityEvent<BaseHardSkillSlot> { }
    [System.Serializable] public class EventOnLeftClickHardSkillSlot : UnityEvent<BaseHardSkillSlot, bool> { }
    [System.Serializable] public class EventOnPointEnterSoftSkillSlot : UnityEvent<BaseSoftSkillSlot> { }
    [System.Serializable] public class EventOnPointExitSoftSkillSlot : UnityEvent<BaseSoftSkillSlot> { }
    [System.Serializable] public class EventOnLeftClickSoftSkillSlot : UnityEvent<BaseSoftSkillSlot, bool> { }
    

}
