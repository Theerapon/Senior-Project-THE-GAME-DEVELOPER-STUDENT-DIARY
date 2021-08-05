using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private string _itemId = string.Empty;
    private float _spawnChance = 0;

    public string ItemId { get => _itemId; }
    public float SpawnChance { get => _spawnChance; }

    public SpawnItem(string itemId, float spawnChance)
    {
        this._itemId = itemId;
        this._spawnChance = spawnChance;
    }
}
