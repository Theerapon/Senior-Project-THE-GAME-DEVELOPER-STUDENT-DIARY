using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New database", menuName = "Database/Item Database/New database", order = 0)]
public class ItemDatabase : Database_SO
{
	[SerializeField] ItemPickUp_Template[] itemPickUps_SOs;

	public ItemPickUp_Template GetItemReference(string itemID)
	{
		foreach (ItemPickUp_Template item in itemPickUps_SOs)
		{
			if (item.ID() == itemID)
			{
				return item;
			}
		}
		return null;
	}

	public ItemPickUp_Template GetItemCopy(string itemID)
	{
		ItemPickUp_Template item = GetItemReference(itemID);
		if (item != null)
		{
			return item.GetCopy();
		}
		else
		{
			return null;
		}
	}

	protected override void LoadItems()
	{
		//itemPickUps_SOs = FindAssetsByType<ItemPickUp_Template>("Assets/Common/Resources/Items");
	}

}
