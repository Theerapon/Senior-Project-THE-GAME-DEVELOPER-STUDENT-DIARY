using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsTemplate_DataHandler : DataHandler
{
    protected Dictionary<string, ItemPickUp_Template> itemTemplateDic;
    [SerializeField] private ItemsVM itemsVM;
    [SerializeField] private InterpretHandler interpretHandler;
    public Dictionary<string, ItemPickUp_Template> GetItemTemplateDic
    {
        get { return itemTemplateDic; }
    }

    protected void Awake()
    {
        itemTemplateDic = new Dictionary<string, ItemPickUp_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }



    private void EventInterpretHandler()
    {
        itemTemplateDic = itemsVM.Interpert();
        if (!ReferenceEquals(itemTemplateDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("Items interpret completed");
        //foreach (KeyValuePair<string, ItemPickUp_Template> item in itemTemplateDic)
        //{
        //    Debug.Log(string.Format("ID {0}, Type {1}, Name {2}, ",
        //        item.Value.ID(), item.Value.GetItemDefinitionsType(), item.Value.GetItemName()));

        //}
    }
}
