using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New database", menuName = "Database/Item Database/New database", order = 0)]
public class ItemDatabase : Database_SO
{
	[SerializeField] ItemPickUps_SO[] itemPickUps_SOs;

	public ItemPickUps_SO GetItemReference(string itemID)
	{
		foreach (ItemPickUps_SO item in itemPickUps_SOs)
		{
			if (item.ID == itemID)
			{
				return item;
			}
		}
		return null;
	}

	public ItemPickUps_SO GetItemCopy(string itemID)
	{
		ItemPickUps_SO item = GetItemReference(itemID);
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
		itemPickUps_SOs = FindAssetsByType<ItemPickUps_SO>("Assets/Common/Resources/Items");
	}

}
