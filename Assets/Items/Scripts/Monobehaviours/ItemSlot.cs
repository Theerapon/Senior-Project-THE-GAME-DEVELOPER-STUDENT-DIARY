using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : BaseItemSlot
{
	public override bool CanAddStack(ItemPickUp item, int amount = 1)
	{
		return base.CanAddStack(item, amount) && Amount + amount <= item.itemDefinition.MaximumStacks;
	}
}
