using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageContainerDisplay : MonoBehaviour
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

    protected GameObject found_obj_storage;
    protected StorageContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseStorageSlot> StorageItemSlots;

    bool displayed = false;

    private void Awake()
    {
        //set Item Slots
        StorageItemSlots = new List<BaseStorageSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: StorageItemSlots);
    }

    private void Start()
    {
        //fonud inventory container in main Scene
        found_obj_storage = GameObject.FindGameObjectWithTag("obj_storage");
        container = found_obj_storage.GetComponentInChildren<StorageContainer>();

        container.OnStorageUpdated.AddListener(OnStorageUpdatedHandler);


        //add Event each slots
        for (int index = 0; index < StorageItemSlots.Count; index++)
        {
            StorageItemSlots[index].OnRightClickEvent.AddListener(OnRightClickEventHandler);
            StorageItemSlots[index].OnBeginDragEvent.AddListener(OnBeginDragEventHandler);
            StorageItemSlots[index].OnEndDragEvent.AddListener(OnEndDragEventHandler);
            StorageItemSlots[index].OnDragEvent.AddListener(OnDragEventHandler);
            StorageItemSlots[index].OnDropEvent.AddListener(OnDropEventHandler);
            StorageItemSlots[index].OnPointEnterEvent.AddListener(OnPointEnterEventHandler);
            StorageItemSlots[index].OnPointExitEvent.AddListener(OnPointExitEventHandler);
            StorageItemSlots[index].INDEX = index;
        }

        displayed = false;

    }

    private void Update()
    {
        if (!displayed)
        {
            DisplayedStorage();
            displayed = true;
        }
    }

    public void DisplayedStorage()
    {
        for (int index = 0; index < container.container_item_entry.Length; index++)
        {
            ItemEntry itemEntry = container.container_item_entry[index];
            if (itemEntry != null)
            {
                StorageItemSlots[index].ITEM = itemEntry.item_pickup;
            }
            else
            {
                StorageItemSlots[index].ITEM = null;
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
        OnRightClickEvent?.Invoke(itemSlot);
    }
    private void OnStorageUpdatedHandler()
    {
        DisplayedStorage();
    }
}
