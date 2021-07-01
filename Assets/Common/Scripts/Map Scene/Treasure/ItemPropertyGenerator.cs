using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPropertyGenerator : MonoBehaviour
{
    private ItemTemplateController itemTemplateController;
    [SerializeField] private GameObject _itemReceivePropertyTemplatePrefab;
    [SerializeField] private GameObject _line;
    [SerializeField] private GameObject _properties;

    private void Awake()
    {
        itemTemplateController = ItemTemplateController.Instance;
    }

    private void CreateValue(ItemPropertyAmount itemProperty)
    {
        ActiveProperties(true);
        float amount = itemProperty.Amount;
        ItemPropertyType type = itemProperty.PropertyType;
        GameObject copy;
        copy = Instantiate(_itemReceivePropertyTemplatePrefab, transform);
        copy.transform.GetChild(0).GetComponent<Image>().sprite = GetItempropertyIcon(type); //property icon
        copy.transform.GetChild(1).GetComponent<TMP_Text>().text = GetItempropertyName(type); //property name
        TMP_Text value = copy.transform.GetChild(2).GetComponent<TMP_Text>(); //property value
        if (CheckAmountIsFloat(amount))
        {
            value.text = string.Format("{0:p2}", amount);
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
        if(type != ItemPropertyType.None)
        {
            return itemTemplateController.ItemPropertyDic[type].Icon;
        }
        else
        {
            return null;
        }

        
    }
    private string GetItempropertyName(ItemPropertyType type)
    {
        if (type != ItemPropertyType.None)
        {
            return itemTemplateController.ItemPropertyDic[type].ItemPropertyName;
        }
        else
        {
            return "บางอย่างที่ลึกลับ";
        }
        
    }

    private bool CheckAmountIsFloat(float amount)
    {
        int amountAsInt = (int) amount;
        float result = amount - amountAsInt;
        return result != 0f; 
    }

    public void ClearTemplate()
    {
        ActiveProperties(false);
        if (transform.childCount > 0)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public void ActiveProperties(bool active)
    {
        if(_line != null && _line.activeSelf != active)
        {
            _line.SetActive(active);
            
        }

        if(_properties != null && _properties.activeSelf != active)
        {
            _properties.SetActive(active);
        }
    }
}
