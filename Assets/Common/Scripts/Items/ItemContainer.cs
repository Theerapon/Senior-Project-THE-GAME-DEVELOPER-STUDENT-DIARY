using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour, IItemContainer
{
    public List<ItemSlot> ItemSlots;

    [Header("Hotbar")]
    [SerializeField] Transform hotBarSlotsParent;
    public Image[] hotBarDisplayHolders;

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;
    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;


    protected void Start()
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            ItemSlots[i].OnRightClickEvent += slot => EventHelper(slot, OnRightClickEvent);
            ItemSlots[i].OnBeginDragEvent += slot => EventHelper(slot, OnBeginDragEvent);
            ItemSlots[i].OnEndDragEvent += slot => EventHelper(slot, OnEndDragEvent);
            ItemSlots[i].OnDragEvent += slot => EventHelper(slot, OnDragEvent);
            ItemSlots[i].OnDropEvent += slot => EventHelper(slot, OnDropEvent);
        }
        hotBarDisplayHolders = hotBarSlotsParent.GetComponentsInChildren<Image>();
        UpdatedItemToHotBar();
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
                ItemSlots[i].Amount++;
                Destroy(item.gameObject);
                UpdatedItemToHotBar();
                return true; //add pass but same item in inventory so that destroy for don't have gameobject too much
            }
        }

        for (int i = 0; i < ItemSlots.Count; i++)
        {
            if (ItemSlots[i].ITEM == null)
            {
                ItemSlots[i].ITEM = item;
                ItemSlots[i].Amount++;
                ItemSlots[i].ITEM.SetGameObjectToFalse();
                UpdatedItemToHotBar();
                return true; //add pass and set gameobject active to false for don't show item in game scene
            }
        }
        return false; //add fail
    }

    public virtual void UpdatedItemToHotBar()
    {
        for (int i = 0; i < hotBarDisplayHolders.Length; i++)
        {
            if (ItemSlots[i].ITEM != null)
            {
                hotBarDisplayHolders[i].sprite = ItemSlots[i].ITEM.itemDefinition.itemIcon;
                hotBarDisplayHolders[i].GetComponentInChildren<TMP_Text>().text = ItemSlots[i].Amount.ToString();
            }
            else
            {
                hotBarDisplayHolders[i].sprite = null;
                hotBarDisplayHolders[i].GetComponentInChildren<TMP_Text>().text = ItemSlots[i].Amount.ToString();
            }
        }
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
        UpdatedItemToHotBar();
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
                UpdatedItemToHotBar();
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
                UpdatedItemToHotBar();
                return true;
            }
        }
        return false;
    }
}
