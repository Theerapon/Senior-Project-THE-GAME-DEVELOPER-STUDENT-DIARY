using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : Triggerable
{
    protected override void OnTrigger()
    {
        SpawnItem item = GetComponentInChildren<SpawnItem>();
        item.CreateSpawn();
        Debug.Log("Trigger");
    }
}
