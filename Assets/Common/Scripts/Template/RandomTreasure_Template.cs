using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreasure_Template : MonoBehaviour
{
    private string id;
    private string spawnItemId;

    public string Id { get => id; }
    public string SpawnItemId { get => spawnItemId; }

    public RandomTreasure_Template(string id, string spawnItemId)
    {
        this.id = id;
        this.spawnItemId = spawnItemId;
    }
}
