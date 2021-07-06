using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperty_DataHandler : DataHandler
{
    protected Dictionary<ItemPropertyType, ItemProperty_Template> itemPropertyDic;
    [SerializeField] private ItemPropertyVM itemPropertyVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<ItemPropertyType, ItemProperty_Template> GetItemPropertyDic
    {
        get { return itemPropertyDic; }
    }

    protected void Awake()
    {
        itemPropertyDic = new Dictionary<ItemPropertyType, ItemProperty_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        itemPropertyDic = itemPropertyVM.Interpert();
        if (!ReferenceEquals(itemPropertyDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
    }
}
