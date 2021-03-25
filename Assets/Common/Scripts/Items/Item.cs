﻿using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "Items", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] private string itemID;

    public string GetItemID()
    {
        return itemID;
    }
}
