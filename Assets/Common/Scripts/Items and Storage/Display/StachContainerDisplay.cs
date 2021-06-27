using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StachContainerDisplay : MonoBehaviour
{
    #region Events
    public Events.EventOnBeginDrag OnBeginDragEvent;
    public Events.EventOnEndDrag OnEndDragEvent;
    public Events.EventOnDrag OnDragEvent;
    public Events.EventOnDrop OnDropEvent;
    public Events.EventOnPointEnter OnPointEnterEvent;
    public Events.EventOnPointExit OnPointExitEvent;
    public Events.EventOnRightClick OnRightClickEvent;
    public Events.EventOnLeftClick OnLeftClickEvent;
    #endregion

    protected GameObject found_player;
    protected StachContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseStachSlot> StachItemSlots;

    bool displayed = false;

    private void Awake()
    {
        //set Item Slots
        StachItemSlots = new List<BaseStachSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: StachItemSlots);
    }

    

    private void Update()
    {
        if (!displayed)
        {
            DisplayedStach();
            displayed = true;
        }
    }

    private void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        container = found_player.GetComponentInChildren<StachContainer>();

        container.OnStachUpdated.AddListener(OnStachUpdatedHandler);

        for (int index = 0; index < StachItemSlots.Count; index++)
        {
            StachItemSlots[index].OnLeftClickEvent.AddListener(OnLeftClickEventHandler);
            StachItemSlots[index].OnRightClickEvent.AddListener(OnRightClickEventHandler);
            StachItemSlots[index].OnBeginDragEvent.AddListener(OnBeginDragEventHandler);
            StachItemSlots[index].OnEndDragEvent.AddListener(OnEndDragEventHandler);
            StachItemSlots[index].OnDragEvent.AddListener(OnDragEventHandler);
            StachItemSlots[index].OnDropEvent.AddListener(OnDropEventHandler);
            StachItemSlots[index].OnPointEnterEvent.AddListener(OnPointEnterEventHandler);
            StachItemSlots[index].OnPointExitEvent.AddListener(OnPointExitEventHandler);
            StachItemSlots[index].INDEX = index;

        }

        displayed = false;

    }
    public void DisplayedStach()
    {
        for (int index = 0; index < container.container_item_entry.Length; index++)
        {
            ItemEntry itemEntry = container.container_item_entry[index];
            if (!ReferenceEquals(itemEntry, null))
            {
                StachItemSlots[index].ITEM = itemEntry.item_pickup;
            }
            else
            {
                StachItemSlots[index].ITEM = null;
            }
        }

    }
    private void OnPointExitEventHandler(BaseItemSlot itemSlot)
    {
        OnPointExitEvent?.Invoke(itemSlot);
    }

    private void OnPointEnterEventHandler(BaseItemSlot itemSlot)
    {
        OnPointEnterEvent?.Invoke(itemSlot);
    }

    private void OnDropEventHandler(BaseItemSlot itemSlot)
    {
        OnDropEvent?.Invoke(itemSlot);
    }

    private void OnDragEventHandler(BaseItemSlot itemSlot)
    {
        OnDragEvent?.Invoke(itemSlot);
    }

    private void OnEndDragEventHandler(BaseItemSlot itemSlot)
    {
        OnEndDragEvent?.Invoke(itemSlot);
    }

    private void OnBeginDragEventHandler(BaseItemSlot itemSlot)
    {
        OnBeginDragEvent?.Invoke(itemSlot);
    }

    private void OnRightClickEventHandler(BaseItemSlot itemSlot)
    {
        OnRightClickEvent?.Invoke(itemSlot);
    }
    private void OnLeftClickEventHandler(BaseItemSlot itemSlot)
    {
        OnLeftClickEvent?.Invoke(itemSlot);
    }
    private void OnStachUpdatedHandler()
    {
        DisplayedStach();
    }
}
