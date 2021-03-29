using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvContainerHandler : MonoBehaviour
{
    #region Events
    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;
    #endregion

    protected GameObject found_player;
    protected InventoryContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseInvSlot> InvItemSlots;

    private void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        container = found_player.GetComponentInChildren<InventoryContainer>();

        container.OnInventoryUpdated.AddListener(OnInventoryUpdatedHandler);

        //set Item Slots
        InvItemSlots = new List<BaseInvSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: InvItemSlots);

        //add Event each slots
        for (int index = 0; index < InvItemSlots.Count; index++)
        {
            InvItemSlots[index].OnRightClickEvent += slot => OnRightClickEvent(slot);
            InvItemSlots[index].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
            InvItemSlots[index].OnEndDragEvent += slot => OnEndDragEvent(slot);
            InvItemSlots[index].OnDragEvent += slot => OnDragEvent(slot);
            InvItemSlots[index].OnDropEvent += slot => OnDropEvent(slot);
            InvItemSlots[index].INDEX = index;
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

}
