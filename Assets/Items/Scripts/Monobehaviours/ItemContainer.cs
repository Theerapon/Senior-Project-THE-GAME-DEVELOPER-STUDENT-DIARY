using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour, IItemContainer
{
    public List<ItemSlot> ItemSlots;

    protected virtual void OnValidate()
    {
        GetComponentsInChildren(includeInactive: true, result: ItemSlots);
    }

    private void Update()
    {
        Debug.Log("items " + ItemSlots.Count);
    }

    public virtual bool AddItem(ItemPickUps_SO item)
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].CanAddStack(item))
            {
                ItemSlots[i].ITEM = item;
                ItemSlots[i].Amount++;
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

    public virtual bool CanAddItem(ItemPickUps_SO item, int amount = 1)
    {
        int freeSpaces = 0;

        foreach (ItemSlot itemSlot in ItemSlots)
        {
            if (itemSlot.ITEM == null || itemSlot.ITEM.ID == item.ID)
            {
                freeSpaces += item.MaximumStacks - itemSlot.Amount;
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
                ItemSlots[i].ITEM.Destroy();
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
            ItemPickUps_SO item = ItemSlots[i].ITEM;
            if (item != null && item.ID == itemId)
            {
                number += ItemSlots[i].Amount;
            }
        }
        return number;
    }

    public virtual ItemPickUps_SO RemoveItem(string itemID)
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            ItemPickUps_SO item = ItemSlots[i].ITEM;
            if (item != null && item.ID == itemID)
            {
                ItemSlots[i].Amount--;
                return item;
            }
        }
        return null;
    }

    public virtual bool RemoveItem(ItemPickUps_SO item)
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
