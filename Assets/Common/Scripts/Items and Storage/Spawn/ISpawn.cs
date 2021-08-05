using UnityEngine;

public interface ISpawns
{
    //ItemPickUps_SO[] itemDefinitions { get; set; }
    GameObject itemTemplate { get; set; }
    ItemPickUp itemType { get; set; }

    void CreateSpawn();
}