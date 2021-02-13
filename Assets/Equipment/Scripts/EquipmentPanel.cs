using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
	public static EquipmentPanel instance;


	[SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] EquipmentSlots;

	public event Action<BaseItemSlot> OnRightClickEvent;

	private void Start()
	{
		instance = this;

		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			EquipmentSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
		}
	}

    private void OnValidate()
    {
        EquipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

	public bool AddItem(ItemPickUp item, out ItemPickUp previousItem)
	{
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			if (EquipmentSlots[i].EquipmentType == item.itemDefinition.subType)
			{
				previousItem = (ItemPickUp)EquipmentSlots[i].ITEM;
				EquipmentSlots[i].ITEM = item;
				EquipmentSlots[i].Amount = 1;
				
				return true;
			}
		}
		previousItem = null;
		return false;
	}

	public bool RemoveItem(ItemPickUp item)
	{
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			if (EquipmentSlots[i].ITEM == item)
			{
				EquipmentSlots[i].ITEM = null;
				EquipmentSlots[i].Amount = 0;
				return true;
			}
		}
		return false;
	}
}
