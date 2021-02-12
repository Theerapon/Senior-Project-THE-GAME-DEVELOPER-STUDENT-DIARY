using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : BaseItemSlot
{
	public override bool CanAddStack(ItemPickUps_SO item, int amount = 1)
	{
		return base.CanAddStack(item, amount) && Amount + amount <= item.MaximumStacks;
	}
}
