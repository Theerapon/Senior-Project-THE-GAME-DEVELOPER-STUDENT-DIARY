using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    private string itemId = string.Empty;
    private float chanceSpawn = 0;

    public string ItemId { get => itemId; }
    public float ChanceSpawn { get => chanceSpawn; }

    public SpawnItem(string itemId, float chanceSpawn)
    {
        this.itemId = itemId;
        this.chanceSpawn = chanceSpawn;
    }
}
