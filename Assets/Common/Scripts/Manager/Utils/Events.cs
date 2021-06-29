using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events
{
    #region Dara Preparing
    [System.Serializable] public class EventOnLoadComplete : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class EventLoadFileDataCompleted : UnityEvent { }
    [System.Serializable] public class EventOnInterpretData : UnityEvent { }
    [System.Serializable] public class EventOnInterpretDataComplete : UnityEvent { }
    [System.Serializable] public class EventOnPreparingInterpretData : UnityEvent { }
    #endregion

    #region Game Manager
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }
    [System.Serializable] public class EventOnHomeDisplay : UnityEvent<bool> { }
    #endregion

    #region Player Transport
    [System.Serializable] public class EventOnPlayerUpdatePlacePosition : UnityEvent<Place> { }
    #endregion

    #region Npc Controller
    [System.Serializable] public class EventOnTenMinute : UnityEvent { }
    #endregion

    #region Time manager
    [System.Serializable] public class EventDateCalendar : UnityEvent<string> { }
    [System.Serializable] public class EventTimeCalendar : UnityEvent<string> { }
    [System.Serializable] public class EventTimeDayOrNight : UnityEvent<bool> { }
    [System.Serializable] public class EventOnGodenTime : UnityEvent<bool> { }   
    [System.Serializable] public class EventOnTimeSkilpValidation : UnityEvent<GameManager.GameState> { }
    [System.Serializable] public class EventOnStartNewDayComplete : UnityEvent { }
    #endregion

    #region Map Arriver
    [System.Serializable] public class EventOnHasPlaceArriverUpdate : UnityEvent { }
    #endregion

    #region Mouse Manager
    [System.Serializable] public class EventGameObjectOnClick : UnityEvent<GameObject> { }
    [System.Serializable] public class EventGameObjectOnTriger : UnityEvent<GameObject> { }
    [System.Serializable] public class EventGameObjectOnExitTriger : UnityEvent<GameObject> { }
    #endregion

    #region Save
    [System.Serializable] public class EventSaveInitiated : UnityEvent { }
    #endregion

    #region Character Status Menu
    [System.Serializable] public class EventOnOpenMenu : UnityEvent<GameManager.GameScene> { }
    #endregion

    #region Storage 
    [System.Serializable] public class EventOnStachUpdated : UnityEvent { }
    [System.Serializable] public class EventOnInventoryUpdated : UnityEvent { }
    [System.Serializable] public class EventOnEquipmentUpdated : UnityEvent { }
    [System.Serializable] public class EventOnStorageUpdated : UnityEvent { }
    #endregion

    #region Shop
    [System.Serializable] public class EventOnPointEnterItemShopSelling : UnityEvent<BaseItemSellingSlot> { }
    [System.Serializable] public class EventOnPointExitItemShopSelling : UnityEvent<BaseItemSellingSlot> { }
    [System.Serializable] public class EventOnPointEnterItemShop : UnityEvent<BaseItemShopSlot> { }
    [System.Serializable] public class EventOnPointExitItemShop : UnityEvent<BaseItemShopSlot> { }
    #endregion

    #region EventSystem Handler
    [System.Serializable] public class EventOnPointEnter : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnPointExit : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnRightClick : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnLeftClick : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnBeginDrag : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnEndDrag : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnDrag : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnDrop : UnityEvent<BaseItemSlot> { }
    [System.Serializable] public class EventOnPointEnterStatusSlot : UnityEvent<BaseStatusSlot> { }
    [System.Serializable] public class EventOnPointExitStatusSlot : UnityEvent<BaseStatusSlot> { }
    [System.Serializable] public class EventOnLeftClickStatusSlot : UnityEvent<BaseStatusSlot, bool> { }
    [System.Serializable] public class EventOnPointEnterBonusSlot : UnityEvent<BaseBonusSlot> { }
    [System.Serializable] public class EventOnPointExitBonusSlot : UnityEvent<BaseBonusSlot> { }
    [System.Serializable] public class EventOnPointEnterIdeaSlot : UnityEvent<BaseIdeaSlot> { }
    [System.Serializable] public class EventOnPointExitIdeaSlot : UnityEvent<BaseIdeaSlot> { }
    [System.Serializable] public class EventOnPointEnterWorkProjectIdeaSlot : UnityEvent<BaseWorkingProjectIdeaSlot> { }
    [System.Serializable] public class EventOnPointExitWorkProjectIdeaSlot : UnityEvent<BaseWorkingProjectIdeaSlot> { }
    [System.Serializable] public class EventOnClickWorkProjectIdeaSlot : UnityEvent<BaseWorkingProjectIdeaSlot> { }
    [System.Serializable] public class EventOnLeftClickBonusSlot : UnityEvent<BaseBonusSlot, bool> { }
    [System.Serializable] public class EventOnPointEnterHardSkillSlot : UnityEvent<BaseHardSkillSlot> { }
    [System.Serializable] public class EventOnPointExitHardSkillSlot : UnityEvent<BaseHardSkillSlot> { }
    [System.Serializable] public class EventOnLeftClickHardSkillSlot : UnityEvent<BaseHardSkillSlot, bool> { }
    [System.Serializable] public class EventOnPointEnterSoftSkillSlot : UnityEvent<BaseSoftSkillSlot> { }
    [System.Serializable] public class EventOnPointExitSoftSkillSlot : UnityEvent<BaseSoftSkillSlot> { }
    [System.Serializable] public class EventOnLeftClickSoftSkillSlot : UnityEvent<BaseSoftSkillSlot, bool> { }

    #endregion

    #region Ideas
    [System.Serializable] public class EventOnGoalIdeasContainerCompleted : UnityEvent { }
    [System.Serializable] public class EventOnMechanicIeasContainerCompleted : UnityEvent { }
    [System.Serializable] public class EventOnThemeIdeasContainerCompleted : UnityEvent { }
    [System.Serializable] public class EventOnWorkProjectGoalIdeasContainerCompleted : UnityEvent { }
    [System.Serializable] public class EventOnWorkProjectMechanicIeasContainerCompleted : UnityEvent { }
    [System.Serializable] public class EventOnWorkProjectThemeIdeasContainerCompleted : UnityEvent { }
    #endregion

    #region Typing Game
    [System.Serializable] public class EventOnCheckedWordUpdate : UnityEvent { }
    [System.Serializable] public class EventOnAlphaTypingGameStateChanged : UnityEvent<AlphaTypingManager.TypingGameState> { }
    [System.Serializable] public class EventOnBetaTypingGameStateChanged : UnityEvent<BetaTypingManager.TypingGameState> { }
    [System.Serializable] public class EventOnWorkTypingGameStateChanged : UnityEvent<WorkTypingManager.TypingGameState> { }
    [System.Serializable] public class EventOnBetaTypingTimerUpdate : UnityEvent { }
    [System.Serializable] public class EventOnAlphaTypingTimerUpdate : UnityEvent { }
    [System.Serializable] public class EventOnWorkTypingTimerUpdate : UnityEvent { }
    [System.Serializable] public class EventOnBetaTypingBossUpdate : UnityEvent { }
    [System.Serializable] public class EventOnBetaTypingBossStateChange : UnityEvent<BetaTypingGameBossManager.BossState> { }
    [System.Serializable] public class EventOnBetaTypingPlayerUpdate : UnityEvent { }
    [System.Serializable] public class EventOnBetaTypingPlayerStateChange : UnityEvent<BetaTypingPlayerManager.BetaPlayerState> { }
    [System.Serializable] public class EventOnAlphaTypingPlayerUpdate : UnityEvent { }
    [System.Serializable] public class EventOnAlphaTypingPlayerStateChange : UnityEvent<AlphaTypingPlayerManager.AlphaPlayerState> { }
    [System.Serializable] public class EventOnWorkTypingPlayerUpdate : UnityEvent { }
    [System.Serializable] public class EventOnWorkTypingPlayerGeneratorBoxStateChange : UnityEvent { }
    [System.Serializable] public class EventOnWorkTypingPlayerStateChange : UnityEvent<WorkTypingPlayerManager.WorkPlayerState> { }
#endregion

    #region Work Project Summary
    [System.Serializable] public class EventOnOneMiniuteTimePassed : UnityEvent<GameManager.GameState> { }
    #endregion

    #region Porject
    [System.Serializable] public class EventOnProjectUpdate : UnityEvent { }
    #endregion

    #region Character Status
    [System.Serializable] public class EventOnEnergyUpdated : UnityEvent { }
    [System.Serializable] public class EventOnMotivationUpdated : UnityEvent { }
    [System.Serializable] public class EventOnMoneyUpdated : UnityEvent { }
    [System.Serializable] public class EventOnExpUpdated : UnityEvent { }
    [System.Serializable] public class EventOnStatusUpdated : UnityEvent { }
    #endregion
}
