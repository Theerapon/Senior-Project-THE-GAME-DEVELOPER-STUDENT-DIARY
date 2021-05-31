using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvContainerDisplay : MonoBehaviour
{
    #region Events
    public Events.EventOnBeginDrag OnBeginDragEvent;
    public Events.EventOnEndDrag OnEndDragEvent;
    public Events.EventOnDrag OnDragEvent;
    public Events.EventOnDrop OnDropEvent;
    public Events.EventOnPointEnter OnPointEnterEvent;
    public Events.EventOnPointExit OnPointExitEvent;
    public Events.EventOnRightClick OnRightClickEvent;
    #endregion

    protected GameObject found_player;
    protected InventoryContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseInvSlot> InvItemSlots;

    bool displayed = false;
    protected  void Awake()
    {
        InvItemSlots = new List<BaseInvSlot>();
        if (itemsParent != null)
        {
            itemsParent.GetComponentsInChildren(includeInactive: true, result: InvItemSlots);
        }

    }

    private void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        container = found_player.GetComponentInChildren<InventoryContainer>();

        container.OnInventoryUpdated.AddListener(OnInventoryUpdatedHandler);

        for (int index = 0; index < InvItemSlots.Count; index++)
        {
            InvItemSlots[index].OnRightClickEvent.AddListener(OnRightClickEventHandler);
            InvItemSlots[index].OnBeginDragEvent.AddListener(OnBeginDragEventHandler);
            InvItemSlots[index].OnEndDragEvent.AddListener(OnEndDragEventHandler);
            InvItemSlots[index].OnDragEvent.AddListener(OnDragEventHandler);
            InvItemSlots[index].OnDropEvent.AddListener(OnDropEventHandler);
            InvItemSlots[index].OnPointEnterEvent.AddListener(OnPointEnterEventHandler);
            InvItemSlots[index].OnPointExitEvent.AddListener(OnPointExitEventHandler);
            InvItemSlots[index].INDEX = index;

        }

        displayed = false;
        //display all item
        //Reset();
    }


    private void Update()
    {
        if (!displayed)
        {
            DisplayedInv();
            displayed = true;
        }
    }

    public void DisplayedInv()
    {
        for (int index = 0; index < container.container_item_entry.Length; index++)
        {
            ItemEntry itemEntry = container.container_item_entry[index];
            if (!ReferenceEquals(itemEntry, null))
            {
                InvItemSlots[index].ITEM = itemEntry.item_pickup;
            }
            else
            {
                InvItemSlots[index].ITEM = null;
            }
        }

    }

    protected void EventHelper(BaseItemSlot slot, Action<BaseItemSlot> action)
    {
        if (action != null)
            action(slot);
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
        Debug.Log("Right click " + itemSlot.ITEM.ItemName + " ");
        OnRightClickEvent?.Invoke(itemSlot);
    }

    private void OnInventoryUpdatedHandler()
    {
        DisplayedInv();
    }

}
