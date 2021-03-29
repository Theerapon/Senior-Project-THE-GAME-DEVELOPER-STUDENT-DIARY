using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvContainerHandler : MonoBehaviour
{
    #region Events
    public event Action<BaseItemSlot> OnRightClickEvent;
    #endregion

    protected GameObject found_player;
    protected InventoryContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseInvSlot> ItemSlots;

    private void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        container = found_player.GetComponentInChildren<InventoryContainer>();

        container.OnInventoryUpdated.AddListener(OnInventoryUpdatedHandler);

        //set Item Slots
        ItemSlots = new List<BaseInvSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

        //add Event each slots
        for (int index = 0; index < ItemSlots.Count; index++)
        {
            ItemSlots[index].OnRightClickEvent += slot => EventHelper(slot, OnRightClickEvent);
            ItemSlots[index].INDEX = index;
        }

        //display all item
        Reset();
    }

    private void OnInventoryUpdatedHandler()
    {
        DisplayedInv();
    }

    private void Reset()
    {
        DisplayedInv();
    }

    public void DisplayedInv()
    {
        for (int index = 0; index < container.container_item_entry.Length; index++)
        {
            ItemEntry itemEntry = container.container_item_entry[index];
            if (itemEntry != null)
            {
                ItemSlots[index].ITEM = itemEntry.item_pickup;
            }
            else
            {
                ItemSlots[index].ITEM = null;
            }
        }

    }

    protected void EventHelper(BaseItemSlot slot, Action<BaseItemSlot> action)
    {
        if (action != null)
            action(slot);
    }

}
