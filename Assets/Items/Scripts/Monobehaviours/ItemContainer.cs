using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour, IItemContainer
{
    public List<ItemSlot> ItemSlots;
    public event Action<BaseItemSlot> OnRightClickEvent;
    private void Start()
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            ItemSlots[i].OnRightClickEvent += slot => EventHelper(slot, OnRightClickEvent);
        }
    }

    protected void EventHelper(BaseItemSlot slot, Action<BaseItemSlot> action)
    {
        if (action != null)
            action(slot);
    }

    protected virtual void OnValidate()
    {
        GetComponentsInChildren(includeInactive: true, result: ItemSlots);
    }

    

    public virtual bool AddItem(ItemPickUp item)
    {
        
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].CanAddStack(item))
            {
                //ItemSlots[i].ITEM = item;
                ItemSlots[i].Amount++;
                Destroy(item.gameObject);
                return true;
            }
        }

        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].ITEM == null)
            {
                ItemSlots[i].ITEM = item;
                ItemSlots[i].Amount++;
                return true;
            }
        }
        return false;
    }

    public virtual bool CanAddItem(ItemPickUp item, int amount = 1)
    {
        int freeSpaces = 0;

        foreach (ItemSlot itemSlot in ItemSlots)
        {
            if (itemSlot.ITEM == null || itemSlot.ITEM.itemDefinition.ID == item.itemDefinition.ID)
            {
                freeSpaces += item.itemDefinition.MaximumStacks - itemSlot.Amount;
            }
        }
        return freeSpaces >= amount;
    }

    public virtual void ClearItemSlots()
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].ITEM != null && Application.isPlaying)
            {
                ItemSlots[i].ITEM.itemDefinition.Destroy();
            }
            ItemSlots[i].ITEM = null;
            ItemSlots[i].Amount = 0;
        }
    }

    public virtual int ItemAmount(string itemId)
    {
        int number = 0;

        for (int i = 0; i < ItemSlots.Count; i++)
        {
            ItemPickUp item = ItemSlots[i].ITEM;
            if (item != null && item.itemDefinition.ID == itemId)
            {
                number += ItemSlots[i].Amount;
            }
        }
        return number;
    }

    public virtual ItemPickUp RemoveItem(string itemID)
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            ItemPickUp item = ItemSlots[i].ITEM;
            if (item != null && item.itemDefinition.ID == itemID)
            {
                ItemSlots[i].Amount--;
                return item;
            }
        }
        return null;
    }

    public virtual bool RemoveItem(ItemPickUp item)
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].ITEM == item)
            {
                ItemSlots[i].Amount--;
                return true;
            }
        }
        return false;
    }
}
