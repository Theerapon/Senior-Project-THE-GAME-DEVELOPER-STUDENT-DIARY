using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEntry
{
    public ItemPickUp item_entry;
    public int slot_index;

    public ItemEntry(ItemPickUp inv_entry)
    {
        this.item_entry = inv_entry;
        this.slot_index = 0;
    }

    public ItemEntry(ItemPickUp item_pickup, int slot_index)
    {
        this.item_entry = item_pickup;
        this.slot_index = slot_index;
    }

   
}
