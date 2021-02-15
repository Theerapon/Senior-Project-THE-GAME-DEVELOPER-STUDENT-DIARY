using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlot
{
	public ItemSubType EquipmentType;

	protected override void OnValidate()
	{
		base.OnValidate();
		gameObject.name = EquipmentType.ToString() + " Slot";
	}

	public override bool CanReceiveItem(ItemPickUp item)
	{
		if (item == null)
			return true;

		ItemPickUp equippableItem = item as ItemPickUp;
		return equippableItem != null && equippableItem.itemDefinition.subType == EquipmentType;
	}
}
