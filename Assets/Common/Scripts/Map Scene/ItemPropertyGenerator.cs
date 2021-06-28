using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPropertyGenerator : MonoBehaviour
{
    private ItemTemplateController itemTemplateController;
    [SerializeField] private GameObject _itemReceivePropertyTemplatePrefab;

    private void Awake()
    {
        itemTemplateController = ItemTemplateController.Instance;
    }

    private void CreateValue(ItemPropertyAmount itemProperty)
    {
        float amount = itemProperty.Amount;
        ItemPropertyType type = itemProperty.ItemPropertyType;
        GameObject copy;
        copy = Instantiate(_itemReceivePropertyTemplatePrefab, transform);
        copy.transform.GetChild(0).GetComponent<Image>().sprite = GetItempropertyIcon(type); //property icon
        copy.transform.GetChild(1).GetComponent<TMP_Text>().text = GetItempropertyName(type); //property name
        TMP_Text value = copy.transform.GetChild(2).GetComponent<TMP_Text>(); //property value
        if (CheckAmountIsFloat(amount))
        {
            value.text = string.Format("{0:n2}", amount);
        }
        else
        {
            value.text = string.Format("{0:n0}", amount);
        }
    }

    public void CreateTemplate(ItemPropertyAmount itemProperty)
    {
        _itemReceivePropertyTemplatePrefab.SetActive(true);
        ClearTemplate();
        CreateValue(itemProperty);
    }

    private Sprite GetItempropertyIcon(ItemPropertyType type)
    {
        return itemTemplateController.ItemPropertyDic[type].Icon;
    }
    private string GetItempropertyName(ItemPropertyType type)
    {
        return itemTemplateController.ItemPropertyDic[type].ItemPropertyName;
    }

    private bool CheckAmountIsFloat(float amount)
    {
        int amountAsInt = (int) amount;
        float result = amount - amountAsInt;
        return result != 0f; 
    }

    private void ClearTemplate()
    {
        if(transform.childCount > 0)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
