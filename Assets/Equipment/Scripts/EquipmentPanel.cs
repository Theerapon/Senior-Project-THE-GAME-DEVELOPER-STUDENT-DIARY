using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
	public static EquipmentPanel instance;


	[SerializeField] Transform equipmentSlotsParent;
    public EquipmentSlot[] EquipmentSlots;

	public event Action<BaseItemSlot> OnPointerEnterEvent;
	public event Action<BaseItemSlot> OnPointerExitEvent;
	public event Action<BaseItemSlot> OnRightClickEvent;
	public event Action<BaseItemSlot> OnBeginDragEvent;
	public event Action<BaseItemSlot> OnEndDragEvent;
	public event Action<BaseItemSlot> OnDragEvent;
	public event Action<BaseItemSlot> OnDropEvent;

	protected void Awake()
    {
		instance = this;
    }

	protected void Start()
	{
		instance = this;

		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			EquipmentSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
			EquipmentSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
			EquipmentSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
			EquipmentSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
			EquipmentSlots[i].OnEndDragEvent += slot => OnEndDragEvent(slot);
			EquipmentSlots[i].OnDragEvent += slot => OnDragEvent(slot);
			EquipmentSlots[i].OnDropEvent += slot => OnDropEvent(slot);
		}
	}

    protected void OnValidate()
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
