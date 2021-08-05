using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemsController : Manager<SpawnItemsController>
{
    private SpawnsItems_DataHandler _spawnsItems_DataHandler;
    private Dictionary<string, SpawnsItems_Template> _spawnsItemsDic;

    public Dictionary<string, SpawnsItems_Template> SpawnsItemsDic { get => _spawnsItemsDic; }

    protected override void Awake()
    {
        base.Awake();
        _spawnsItemsDic = new Dictionary<string, SpawnsItems_Template>();
        _spawnsItems_DataHandler = FindObjectOfType<SpawnsItems_DataHandler>();

        //set spawns item
        if (!ReferenceEquals(_spawnsItems_DataHandler.GetSpawnsItemsDic, null))
        {
            foreach (KeyValuePair<string, SpawnsItems_Template> spawnItem in _spawnsItems_DataHandler.GetSpawnsItemsDic)
            {
                _spawnsItemsDic.Add(spawnItem.Key, spawnItem.Value);
            }
        }
    }
}
