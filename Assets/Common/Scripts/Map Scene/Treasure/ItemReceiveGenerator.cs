using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemReceiveGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _itemReceiveTemplatePrefab;

    private void CreateValue(ItemPickUp_Template itemPickUp_Template)
    {
        GameObject copy;
        copy = Instantiate(_itemReceiveTemplatePrefab, transform);
        copy.transform.GetChild(0).GetComponent<TMP_Text>().text = itemPickUp_Template.ItemName; //item name
        copy.transform.GetChild(1).GetComponentInChildren<TMP_Text>().text = GetItemType(itemPickUp_Template); //item type
        copy.transform.GetChild(2).GetComponent<Image>().sprite = itemPickUp_Template.ItemIcon; //item icon
        copy.transform.GetChild(3).GetComponentInChildren<TMP_Text>().text = itemPickUp_Template.ItemDescription; //description

        for(int i = 0; i < itemPickUp_Template.ItemProperties.Count; i++)
        {
            ItemPropertyAmount itemproperty = itemPickUp_Template.ItemProperties[i];
            copy.transform.GetComponentInChildren<ItemPropertyGenerator>().CreateTemplate(itemproperty);
        }
        
    }

    public void CreateTemplate(ItemPickUp_Template itemPickUp_Template)
    {
        _itemReceiveTemplatePrefab.SetActive(true);
        if(transform.childCount > 0)
        {
            ClearItem();
        }
        CreateValue(itemPickUp_Template);
    }

    private string GetItemType(ItemPickUp_Template itemPickUp_Template)
    {
        if(itemPickUp_Template.ItemType == ItemDefinitionsType.Equipment)
        {
            return itemPickUp_Template.SubType.ToString();
        }
        else
        {
            return itemPickUp_Template.ItemType.ToString();
        }

    }

    private void ClearItem()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        } 
    }
}
