using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Public")]
    public CharacterInventory Inventory;
	public EquipmentPanel Equipment;

	private void Start()
    {
        Inventory = CharacterInventory.instance;
		Equipment = EquipmentPanel.instance;


		// Setup Events:
		// Right Click
		Inventory.OnRightClickEvent += InventoryRightClick;
		Equipment.OnRightClickEvent += EquipmentPanelRightClick;

	}

    private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM is ItemPickUp && itemSlot.ITEM.itemDefinition.isEquipped)
		{
			Unequip((ItemPickUp)itemSlot.ITEM);
		}
	}

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM is ItemPickUp && itemSlot.ITEM.itemDefinition.isEquipped)
		{
			Equip((ItemPickUp)itemSlot.ITEM);
		} else if (itemSlot.ITEM is ItemPickUp && itemSlot.Amount != 0)
        {
			Inventory.RemoveItem(itemSlot.ITEM);
        }
		
	}

    public void Equip(ItemPickUp item)
	{
		if (Inventory.RemoveItem(item))
		{
			ItemPickUp previousItem;
			if (Equipment.AddItem(item, out previousItem))
			{
				
				if (previousItem != null)
				{
					Inventory.AddItem(previousItem);
					previousItem.Unequip(this);
					//statPanel.UpdateStatValues();
				}
				item.Equip(this);
				//statPanel.UpdateStatValues();
			}
			else
			{
				Inventory.AddItem(item);
			}
		}
	}

	public void Unequip(ItemPickUp item)
	{
		if (Inventory.CanAddItem(item) && Equipment.RemoveItem(item))
		{
			item.Unequip(this);
			//statPanel.UpdateStatValues();
			Inventory.AddItem(item);
		}
	}
}
