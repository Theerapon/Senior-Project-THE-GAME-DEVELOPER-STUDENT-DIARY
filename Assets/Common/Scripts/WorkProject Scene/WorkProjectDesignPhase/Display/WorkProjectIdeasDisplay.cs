using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkProjectIdeasDisplay : MonoBehaviour
{
    #region Events
    public Events.EventOnPointEnterWorkProjectIdeaSlot OnPointEnterWorkProjectIdeaSlot;
    public Events.EventOnPointExitWorkProjectIdeaSlot OnPointExitWorkProjectIdeaSlot;
    public Events.EventOnClickWorkProjectIdeaSlot OnClickWorkProjectIdeaSlot;
    #endregion

    [SerializeField] private GameObject canvas;
    protected List<BaseWorkingProjectIdeaSlot> baseIdeaSlots;
    public List<BaseWorkingProjectIdeaSlot> GetBaseIdeaSlots { get { return baseIdeaSlots; } }

    protected virtual void Awake()
    {
        baseIdeaSlots = new List<BaseWorkingProjectIdeaSlot>();
    }

    protected void OnPointExitIdeaSlotEventHandler(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        OnPointExitWorkProjectIdeaSlot?.Invoke(baseIdeaSlot);
    }

    protected void OnPointEnterIdeaSlotEventHandler(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        OnPointEnterWorkProjectIdeaSlot?.Invoke(baseIdeaSlot);
        
    }

    protected void OnClickWorkProjectIdeaSlotEventHandler(BaseWorkingProjectIdeaSlot baseIdeaSlot)
    {
        OnClickWorkProjectIdeaSlot?.Invoke(baseIdeaSlot);

    }

    private void OnValidate()
    {
        if(canvas != null)
        {
            canvas.SetActive(false);
        }
        
    }
}
