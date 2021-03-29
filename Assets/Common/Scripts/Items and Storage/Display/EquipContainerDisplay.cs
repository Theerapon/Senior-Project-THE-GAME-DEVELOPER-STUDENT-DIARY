using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipContainerDisplay : MonoBehaviour
{
    #region Events
    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    #endregion

    protected GameObject found_player;
    protected EquipmentContainer container;
    [SerializeField] private Transform itemsParent;

    public List<BaseEquipmentSlot> EquipItemSlots;

    // Start is called before the first frame update
    void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        container = found_player.GetComponentInChildren<EquipmentContainer>();

        container.OnEquipmentUpdated.AddListener(OnEquipmentUpdatedHandler);

        //set Item Slots
        EquipItemSlots = new List<BaseEquipmentSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: EquipItemSlots);

        //add Event each slots
        for (int index = 0; index < EquipItemSlots.Count; index++)
        {
            EquipItemSlots[index].OnRightClickEvent += slot => OnRightClickEvent(slot);
            EquipItemSlots[index].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
            EquipItemSlots[index].OnEndDragEvent += slot => OnEndDragEvent(slot);
            EquipItemSlots[index].OnDragEvent += slot => OnDragEvent(slot);
            EquipItemSlots[index].OnDropEvent += slot => OnDropEvent(slot);
            EquipItemSlots[index].INDEX = index;
        }

        //display all item
        DisplayedEquipment();
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
