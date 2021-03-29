using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipContainerHandler : MonoBehaviour
{
    #region Events
    public event Action<BaseItemSlot> OnRightClickEvent;
    #endregion

    protected GameObject found_player;
    protected EquipmentContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseEquipmentSlot> ItemSlots;

    // Start is called before the first frame update
    void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        container = found_player.GetComponentInChildren<EquipmentContainer>();

        container.OnEquipmentUpdated.AddListener(OnEquipmentUpdatedHandler);

        //set Item Slots
        ItemSlots = new List<BaseEquipmentSlot>();
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

    private void OnEquipmentUpdatedHandler()
    {
        DisplayedEquipment();
    }

    private void Reset()
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
                ItemSlots[i].ITEM = itemEntry.item_pickup;
            }
            else
            {
                ItemSlots[i].ITEM = null;
            }
        }

    }

    protected void EventHelper(BaseItemSlot slot, Action<BaseItemSlot> action)
    {
        if (action != null)
            action(slot);
    }
}
