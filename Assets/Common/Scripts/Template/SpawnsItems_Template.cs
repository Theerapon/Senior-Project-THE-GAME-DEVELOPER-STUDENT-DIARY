using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsItems_Template : MonoBehaviour
{
    private string id = string.Empty;
    private List<SpawnItem> spawnItems = null;

    public string Id { get => id; }
    public List<SpawnItem> SpawnItems { get => spawnItems; }
    public SpawnsItems_Template(string id, List<SpawnItem> spawnItems)
    {
        this.id = id;
        this.spawnItems = spawnItems;
    }
}
