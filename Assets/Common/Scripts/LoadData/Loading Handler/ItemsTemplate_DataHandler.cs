using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsTemplate_DataHandler : Manager<ItemsTemplate_DataHandler>
{
    protected Dictionary<string, ItemPickUp_Template> itemTemplateDic;
    [SerializeField] private ItemsVM itemsVM;
    [SerializeField] private InterpretHandler interpretHandler;
    public Dictionary<string, ItemPickUp_Template> GetItemTemplateDic
    {
        get { return itemTemplateDic; }
    }

    protected override void Awake()
    {
        base.Awake();
        itemTemplateDic = new Dictionary<string, ItemPickUp_Template>();
    }

    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        itemTemplateDic = itemsVM.Interpert();
        Debug.Log("activities interpret completed");
        foreach (KeyValuePair<string, ItemPickUp_Template> item in itemTemplateDic)
        {
            Debug.Log(string.Format("ID {0}, Type {1}, Name {2}, ",
                item.Value.ID(), item.Value.GetItemDefinitionsType(), item.Value.GetItemName()));

        }
    }
}
