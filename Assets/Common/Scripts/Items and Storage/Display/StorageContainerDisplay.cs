using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageContainerDisplay : MonoBehaviour
{
    #region Events
    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;
    #endregion

    protected GameObject found_obj_storage;
    protected StorageContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseInvSlot> StorageItemSlots;

    private void Start()
    {
        //fonud inventory container in main Scene
        found_obj_storage = GameObject.FindGameObjectWithTag("obj_storage");
        container = found_obj_storage.GetComponentInChildren<StorageContainer>();

        container.OnStorageUpdated.AddListener(OnStorageUpdatedHandler);

        //set Item Slots
        StorageItemSlots = new List<BaseInvSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: StorageItemSlots);

        //add Event each slots
        for (int index = 0; index < StorageItemSlots.Count; index++)
        {
            StorageItemSlots[index].OnRightClickEvent += slot => OnRightClickEvent(slot);
            StorageItemSlots[index].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
            StorageItemSlots[index].OnEndDragEvent += slot => OnEndDragEvent(slot);
            StorageItemSlots[index].OnDragEvent += slot => OnDragEvent(slot);
            StorageItemSlots[index].OnDropEvent += slot => OnDropEvent(slot);
            StorageItemSlots[index].INDEX = index;
        }

        //display all item
        DisplayedStorage();
    }

    private void OnStorageUpdatedHandler()
    {
        DisplayedStorage();
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
}
