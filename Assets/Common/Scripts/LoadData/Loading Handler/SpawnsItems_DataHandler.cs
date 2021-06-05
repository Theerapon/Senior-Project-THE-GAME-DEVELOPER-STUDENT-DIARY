using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsItems_DataHandler : DataHandler
{
    protected Dictionary<string, SpawnsItems_Template> spawnsItemsDic;
    [SerializeField] private SpawnsItemsVM spawnsItemsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, SpawnsItems_Template> GetSpawnsItemsDic
    {
        get { return spawnsItemsDic; }
    }

    protected void Awake()
    {
        spawnsItemsDic = new Dictionary<string, SpawnsItems_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        spawnsItemsDic = spawnsItemsVM.Interpert();
        if (!ReferenceEquals(spawnsItemsDic, null))
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
