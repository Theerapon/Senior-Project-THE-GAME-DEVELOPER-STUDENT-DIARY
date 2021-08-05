using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipContainerDisplay : MonoBehaviour
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
    protected EquipmentContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseEquipmentSlot> EquipItemSlots;

    bool displayed = false;

    private void Awake()
    {
        //set Item Slots
        EquipItemSlots = new List<BaseEquipmentSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: EquipItemSlots);
    }

    // Start is called before the first frame update
    void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        container = found_player.GetComponentInChildren<EquipmentContainer>();

        container.OnEquipmentUpdated.AddListener(OnEquipmentUpdatedHandler);



        //add Event each slots
        for (int index = 0; index < EquipItemSlots.Count; index++)
        {
            EquipItemSlots[index].OnLeftClickEvent.AddListener(OnLeftClickEventHandler);
            EquipItemSlots[index].OnRightClickEvent.AddListener(OnRightClickEventHandler);
            EquipItemSlots[index].OnBeginDragEvent.AddListener(OnBeginDragEventHandler);
            EquipItemSlots[index].OnEndDragEvent.AddListener(OnEndDragEventHandler);
            EquipItemSlots[index].OnDragEvent.AddListener(OnDragEventHandler);
            EquipItemSlots[index].OnDropEvent.AddListener(OnDropEventHandler);
            EquipItemSlots[index].OnPointEnterEvent.AddListener(OnPointEnterEventHandler);
            EquipItemSlots[index].OnPointExitEvent.AddListener(OnPointExitEventHandler);
            EquipItemSlots[index].INDEX = index;
        }

        displayed = false;
        //display all item
        //DisplayedEquipment();
    }

    private void Update()
    {
        if (!displayed)
        {
            DisplayedEquipment();
            displayed = true;
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
    private void OnEquipmentUpdatedHandler()
    {
        DisplayedEquipment();
    }

    public void DisplayedEquipment()
    {
        for (int i = 0; i < container.container_item_entry.Length; i++)
        {
            ItemEntry itemEntry = container.container_item_entry[i];
            if (itemEntry != null)
            {
                EquipItemSlots[i].ITEM = itemEntry.item_pickup;
            }
            else
            {
                EquipItemSlots[i].ITEM = null;
            }
        }

    }

    protected void EventHelper(BaseItemSlot slot, Action<BaseItemSlot> action)
    {
        if (action != null)
            action(slot);
    }
}
