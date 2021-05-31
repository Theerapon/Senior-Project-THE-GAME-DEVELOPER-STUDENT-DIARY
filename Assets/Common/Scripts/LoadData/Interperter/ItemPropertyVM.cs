using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPropertyVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_Type = "Type";
    private const string INST_SET_Name = "Name";
    private const string INST_SET_Icon = "Icon";
    #endregion

    [SerializeField] private ItemProperty_Loading itemProperty_Loading;

    public Dictionary<ItemPropertyType, ItemProperty_Template> Interpert()
    {
        if (!ReferenceEquals(itemProperty_Loading, null))
        {
            Dictionary<ItemPropertyType, ItemProperty_Template> itemProprttyDic = new Dictionary<ItemPropertyType, ItemProperty_Template>();

            foreach (KeyValuePair<string, string> line in itemProperty_Loading.textLists)
            {
                ItemProperty_Template itemProperty = null;
                string key = line.Key;
                string value = line.Value;

                itemProperty = CreateTemplate(value);

                if (!ReferenceEquals(itemProperty, null))
                {
                    itemProprttyDic.Add(itemProperty.ItemPropertyType, itemProperty);
                }

            }
            if (!ReferenceEquals(itemProprttyDic, null))
            {
                return itemProprttyDic;
            }
        }

        return null;
    }

    private ItemProperty_Template CreateTemplate(string line)
    {
        string typeID = string.Empty;
        ItemPropertyType itemPropertyType = ItemPropertyType.None;
        string itemPropertyName = string.Empty;
        Sprite icon = null;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_Type:
                    typeID = entries[++i];
                    itemPropertyType = ConvertType.CheckItemProperty(typeID);
                    break;
                case INST_SET_Name:
                    itemPropertyName = entries[++i];
                    break;
                case INST_SET_Icon:
                    icon = Resources.Load<Sprite>(entries[++i]);
                    break;

            }

        }

        return new ItemProperty_Template(typeID, itemPropertyType, itemPropertyName, icon);
    }
}
