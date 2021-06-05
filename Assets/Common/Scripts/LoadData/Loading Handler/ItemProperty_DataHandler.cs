using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperty_DataHandler : MonoBehaviour
{
    protected Dictionary<ItemPropertyType, ItemProperty_Template> itemPropertyDic;
    [SerializeField] private ItemPropertyVM itemPropertyVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<ItemPropertyType, ItemProperty_Template> GetStoreDic
    {
        get { return itemPropertyDic; }
    }

    protected void Awake()
    {
        itemPropertyDic = new Dictionary<ItemPropertyType, ItemProperty_Template>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        itemPropertyDic = itemPropertyVM.Interpert();
        //Debug.Log("Item property interpret completed");
        //foreach (KeyValuePair<ItemPropertyType, ItemProperty_Template> itemProperty in itemPropertyDic)
        //{
        //    Debug.Log(string.Format("Type = {0}, Name = {1}, Icon = {2}",
        //        itemProperty.Value.ItemPropertyType, itemProperty.Value.ItemPropertyName, itemProperty.Value.Icon));

        //}
    }
}
