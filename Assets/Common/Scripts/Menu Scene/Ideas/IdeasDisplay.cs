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
    [SerializeField] protected GameObject canvas;


    protected virtual void Awake()
    {
        baseIdeaSlots = new List<BaseIdeaSlot>();
    }

    protected void OnPointExitIdeaSlotEventHandler(BaseIdeaSlot baseIdeaSlot)
    {
        OnPointExitIdeaSlotEvent?.Invoke(baseIdeaSlot);
    }

    protected void OnPointEnterIdeaSlotEventHandler(BaseIdeaSlot baseIdeaSlot)
    {
        OnPointEnterIdeaSlotEvent?.Invoke(baseIdeaSlot);
    }

    private void OnValidate()
    {
        if(canvas != null)
        {
            canvas.SetActive(false);
        }
    }
}
