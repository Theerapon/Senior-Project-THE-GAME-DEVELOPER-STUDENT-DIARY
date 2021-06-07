using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseIdeaSlot;

public class IdeasDisplay : MonoBehaviour
{
    #region Events
    public Events.EventOnPointEnterIdeaSlot OnPointEnterIdeaSlotEvent;
    public Events.EventOnPointExitIdeaSlot OnPointExitIdeaSlotEvent;
    #endregion

    protected List<BaseIdeaSlot> baseIdeaSlots;

    protected virtual void Awake()
    {
        baseIdeaSlots = new List<BaseIdeaSlot>();
    }

    protected void OnPointExitIdeaSlotEventHandler(BaseIdeaSlot baseIdeaSlot)
    {
        OnPointEnterIdeaSlotEvent?.Invoke(baseIdeaSlot);
    }

    protected void OnPointEnterIdeaSlotEventHandler(BaseIdeaSlot baseIdeaSlot)
    {
        OnPointEnterIdeaSlotEvent?.Invoke(baseIdeaSlot);
    }
}
