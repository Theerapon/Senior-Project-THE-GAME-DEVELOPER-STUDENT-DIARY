using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemSets_DataHandler : Manager<StoreItemSets_DataHandler>
{
    protected Dictionary<string, StoreItemSets_Template> storeItemSetDic;
    [SerializeField] private StoreItemSetsVM storeItemSetsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, StoreItemSets_Template> GetStoreItemSetDic
    {
        get { return storeItemSetDic; }
    }

    protected override void Awake()
    {
        base.Awake();
        storeItemSetDic = new Dictionary<string, StoreItemSets_Template>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        storeItemSetDic = storeItemSetsVM.Interpert();
        //Debug.Log("Store Item Set interpret completed");
        //foreach (KeyValuePair<string, StoreItemSets_Template> storeItemSet in storeItemSetDic)
        //{
        //    for (int i = 0; i < storeItemSet.Value.StoreItemSets.Count; i++)
        //    {
        //        Debug.Log(string.Format("Spawn ID = {0}, Item Id = {1}, Amount {2}",
        //        storeItemSet.Value.Id, storeItemSet.Value.StoreItemSets[i].ItemId, storeItemSet.Value.StoreItemSets[i].AmountItem));
        //    }

        //}
    }
}
