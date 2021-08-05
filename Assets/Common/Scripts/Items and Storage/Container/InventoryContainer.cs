using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : ItemContainer<InventoryContainer>
{
    #region
    public Events.EventOnInventoryUpdated OnInventoryUpdated;
    #endregion

    protected override void NotificationEvents()
    {
        base.NotificationEvents();
        OnInventoryUpdated?.Invoke();

    }

    public override void Swap(int origin_item_entry, int target_item_entry)
    {
        base.Swap(origin_item_entry, target_item_entry);

        ItemEntry temp_item_entry = container_item_entry[origin_item_entry];
        //target to origin
        if (container_item_entry[target_item_entry] != null)
        {
            container_item_entry[origin_item_entry] = container_item_entry[target_item_entry];
            container_item_entry[origin_item_entry].slot_index = container_item_entry[target_item_entry].slot_index;
        }
        else
        {
            container_item_entry[origin_item_entry] = null;
        }
        //origin to targen
        container_item_entry[target_item_entry] = temp_item_entry;
        container_item_entry[target_item_entry].slot_index = temp_item_entry.slot_index;
        NotificationEvents();
    }
}
