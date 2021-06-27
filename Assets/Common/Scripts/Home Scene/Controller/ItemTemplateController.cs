using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTemplateController : Manager<ItemTemplateController>
{
    private ItemsTemplate_DataHandler _itemsTemplate_DataHandler;
    private ItemProperty_DataHandler _itemProperty_DataHandler;

    private Dictionary<string, ItemPickUp_Template> _itemTemplateDic;
    private Dictionary<ItemPropertyType, ItemProperty_Template> _itemPropertyDic;

    public Dictionary<string, ItemPickUp_Template> ItemTemplateDic { get => _itemTemplateDic; }
    public Dictionary<ItemPropertyType, ItemProperty_Template> ItemPropertyDic { get => _itemPropertyDic; }

    protected override void Awake()
    {
        base.Awake();
        _itemTemplateDic = new Dictionary<string, ItemPickUp_Template>();
        _itemPropertyDic = new Dictionary<ItemPropertyType, ItemProperty_Template>();

        _itemsTemplate_DataHandler = FindObjectOfType<ItemsTemplate_DataHandler>();
        _itemProperty_DataHandler = FindObjectOfType<ItemProperty_DataHandler>();

        //set Item template
        if (!ReferenceEquals(_itemsTemplate_DataHandler.GetItemTemplateDic, null))
        {
            foreach (KeyValuePair<string, ItemPickUp_Template> item in _itemsTemplate_DataHandler.GetItemTemplateDic)
            {
                string id = item.Key;
                _itemTemplateDic.Add(id, item.Value);
            }

        }

        //set Item Property
        if (!ReferenceEquals(_itemProperty_DataHandler.GetItemPropertyDic, null))
        {
            foreach (KeyValuePair<ItemPropertyType, ItemProperty_Template> item in _itemProperty_DataHandler.GetItemPropertyDic)
            {
                ItemPropertyType id = item.Key;
                _itemPropertyDic.Add(id, item.Value);
            }

        }
    }
}
