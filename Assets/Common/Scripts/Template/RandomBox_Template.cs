using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox_Template : MonoBehaviour
{
    private string id;
    private string spawnItemId;

    public string Id { get => id; }
    public string SpawnItemId { get => spawnItemId; }

    public RandomBox_Template(string id, string spawnItemId)
    {
        this.id = id;
        this.spawnItemId = spawnItemId;
    }
}
