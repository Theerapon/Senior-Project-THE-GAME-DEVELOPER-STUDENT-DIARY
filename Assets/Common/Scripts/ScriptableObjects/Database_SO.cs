using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Database_SO : ScriptableObject
{
#if UNITY_EDITOR
	protected void OnValidate()
	{
		LoadItems();
	}
	protected void OnEnable()
	{
		EditorApplication.projectChanged -= LoadItems;
		EditorApplication.projectChanged += LoadItems;
	}

	protected void OnDisable()
	{
		EditorApplication.projectChanged -= LoadItems;
	}

	protected virtual void LoadItems()
	{
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
