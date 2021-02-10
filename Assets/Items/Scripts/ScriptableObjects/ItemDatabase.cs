using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New database", menuName = "Item Database/New database")]
public class ItemDatabase : ScriptableObject
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


	#if UNITY_EDITOR
	private void OnValidate()
	{
		LoadItems();
	}
	private void OnEnable()
	{
		EditorApplication.projectWindowChanged -= LoadItems;
		EditorApplication.projectWindowChanged += LoadItems;
	}

	private void OnDisable()
	{
		EditorApplication.projectWindowChanged -= LoadItems;
	}

	private void LoadItems()
	{
		itemPickUps_SOs = FindAssetsByType<ItemPickUps_SO>("Assets/Items/Resources");
	}

	public static T[] FindAssetsByType<T>(params string[] folders) where T : Object
	{
		string type = typeof(T).Name;

		string[] guids;
		if (folders == null || folders.Length == 0)
		{
			guids = AssetDatabase.FindAssets("t:" + type);
		}
		else
		{
			guids = AssetDatabase.FindAssets("t:" + type, folders);
		}

		T[] assets = new T[guids.Length];

		for (int i = 0; i < guids.Length; i++)
		{
			string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
			assets[i] = AssetDatabase.LoadAssetAtPath<T>(assetPath);
		}
		return assets;
	}
	#endif
}
