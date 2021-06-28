using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreContoller : Manager<StoreContoller>
{
    private Stores_DataHandler _stores_DataHandler;
    private StoreItemSets_DataHandler _storeItemSets_DataHandler;

    private Dictionary<string, Store> _storeDic;
    private Dictionary<string, StoreItemSets_Template> _storeItemSetDic;

    public Dictionary<string, Store> StoreDic { get => _storeDic; }
    public Dictionary<string, StoreItemSets_Template> StoreItemSetDic { get => _storeItemSetDic; }

    protected override void Awake()
    {
        base.Awake();
        _storeDic = new Dictionary<string, Store>();
        _storeItemSetDic = new Dictionary<string, StoreItemSets_Template>();

        _stores_DataHandler = FindObjectOfType<Stores_DataHandler>();
        _storeItemSets_DataHandler = FindObjectOfType<StoreItemSets_DataHandler>();

        //set Store
        if (!ReferenceEquals(_stores_DataHandler.GetStoreDic, null))
        {
            foreach (KeyValuePair<string, Store_Template> store in _stores_DataHandler.GetStoreDic)
            {
                string id = store.Key;
                _storeDic.Add(id, new Store(store.Value));
            }

        }

        //set Store
        if (!ReferenceEquals(_storeItemSets_DataHandler.GetStoreItemSetDic, null))
        {
            foreach (KeyValuePair<string, StoreItemSets_Template> itemSet in _storeItemSets_DataHandler.GetStoreItemSetDic)
            {
                string id = itemSet.Key;
                _storeItemSetDic.Add(id, itemSet.Value);
            }

        }
    }

    public void RegisterEvent(StoreType storeType, ScheduleEvent scheduleEvent)
    {
        string storeId = ConvertType.GetStoreId(storeType);
        _storeDic[storeId].EnableEvent(scheduleEvent);
    }

    public void ClearEvent()
    {
        foreach(KeyValuePair<string, Store> store in _storeDic)
        {
            store.Value.DisableEvent();
        }
    }

    public void SetItemSetOnNewDay(Day day)
    {
        foreach (KeyValuePair<string, Store> store in _storeDic)
        {
            store.Value.SetUpStoreOnNewDay(day);
        }
    }
}
