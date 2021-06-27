using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsItems_DataHandler : DataHandler
{
    protected Dictionary<string, SpawnsItems_Template> _spawnsItemsDic;
    [SerializeField] private SpawnsItemsVM _spawnsItemsVM;
    [SerializeField] private InterpretHandler _interpretHandler;


    public Dictionary<string, SpawnsItems_Template> GetSpawnsItemsDic
    {
        get { return _spawnsItemsDic; }
    }

    protected void Awake()
    {
        _spawnsItemsDic = new Dictionary<string, SpawnsItems_Template>();
        _interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        _spawnsItemsDic = _spawnsItemsVM.Interpert();
        if (!ReferenceEquals(_spawnsItemsDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("SpawnsItem interpret completed");
        //foreach (KeyValuePair<string, SpawnsItems_Template> spawnItem in spawnsItemsDic)
        //{
        //    for(int i = 0; i < spawnItem.Value.SpawnItems.Count; i++)
        //    {
        //        Debug.Log(string.Format("Spawn ID = {0}, Item Id = {1}, Chance {2}",
        //        spawnItem.Value.Id, spawnItem.Value.SpawnItems[i].ItemId, spawnItem.Value.SpawnItems[i].ChanceSpawn));
        //    }

        //}
    }
}
