using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stores_DataHandler : Manager<Stores_DataHandler>
{
    protected Dictionary<string, Store_Template> storeDic;
    [SerializeField] private StoresVM storesVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, Store_Template> GetStoreDic
    {
        get { return storeDic; }
    }

    protected override void Awake()
    {
        base.Awake();
        storeDic = new Dictionary<string, Store_Template>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        storeDic = storesVM.Interpert();
        Debug.Log("activities interpret completed");
        foreach (KeyValuePair<string, Store_Template> store in storeDic)
        {
            for (int i = 0; i < store.Value.StoreItemSetPerDay.Length; i++)
            {
                Debug.Log(string.Format("Store ID = {0}, Day = {1}, StoreItemSetID = {2}",
                store.Value.Id, i+1, store.Value.StoreItemSetPerDay[i]));
            }

        }
    }
}
