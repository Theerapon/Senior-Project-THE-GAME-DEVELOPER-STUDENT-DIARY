using System.Collections.Generic;
using UnityEngine;

public class ItemsVM : MonoBehaviour
{
    private const string INST_SET_ItemID = "ID";
    private const string INST_SET_ItemName = "itemName";
    private const string INST_SET_ItemDescription = "itemDescription";
    private const string INST_SET_ItemDefinitionsType = "itemDefinitionsType";
    private const string INST_SET_ItemEquipmentType = "itemEquipmentType";
    private const string INST_SET_PurchasePrice = "PurchasePrice";
    private const string INST_SET_SellingPrice = "SellingPrice";
    private const string INST_SET_ItemIconPath = "itemIconPath";
    private const string INST_SET_IsEquipped = "isEquipped";
    private const string INST_SET_IsStorable = "isStorable";
    private const string INST_SET_IsUseable = "isUseable";
    private const string INST_SET_IsDestroyOnUse = "isDestroyOnUse"; 
    private const string INST_SET_IsGiftable = "isGiftable";
    private const string INST_SET_ItemProperty = "ItemProperty";


    [SerializeField] private ItemsData_Loading itemsDataLoading;


    public Dictionary<string, ItemPickUp_Template> Interpert()
    {
        if (!ReferenceEquals(itemsDataLoading, null))
        {
            Dictionary<string, ItemPickUp_Template> itemDic = new Dictionary<string, ItemPickUp_Template>();
            
            foreach (KeyValuePair<string, string> line in itemsDataLoading.textLists)
            {
                ItemPickUp_Template item = null;
                string key = line.Key;
                string value = line.Value;

                item = CreateTemplate(value);

                if (!ReferenceEquals(item, null))
                {
                    itemDic.Add(key, item);
                }

            }
            if (!ReferenceEquals(itemDic, null))
            {
                return itemDic;
            }

        }

        return null;
        
    }

    private ItemPickUp_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        string itemName = "New Item";
        string itemDescription = "Item Desctioption";
        ItemDefinitionsType itemType = ItemDefinitionsType.Treasure;
        ItemEquipmentType subType = ItemEquipmentType.NONE;
        int purchasePrice = 0;
        int sellingPrice = 0;

        Sprite itemIcon = null;

        bool isEquipped = false;
        bool isStorable = false;
        bool isUseable = false;
        bool isDestroyOnUse = false;
        bool isGiftable = false;

        List<ItemPropertyAmount> itemProperties = new List<ItemPropertyAmount>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ItemID:
                    id = entries[++i];
                    break;
                case INST_SET_ItemName:
                    itemName = (entries[++i]);
                    break; 
                case INST_SET_ItemDescription:
                    itemDescription = (entries[++i]);
                    break;
                case INST_SET_ItemDefinitionsType:
                    itemType = ConvertType.CheckDefinitionsType((entries[++i]));
                    break;
                case INST_SET_ItemEquipmentType:
                    subType = ConvertType.CheckEquipmentType((entries[++i]));
                    break;
                case INST_SET_PurchasePrice:
                    purchasePrice = int.Parse(entries[++i]);
                    break;
                case INST_SET_SellingPrice:
                    sellingPrice = int.Parse(entries[++i]);
                    break;
                case INST_SET_ItemIconPath:
                    itemIcon = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_IsEquipped:
                    isEquipped = bool.Parse(entries[++i]);
                    break;
                case INST_SET_IsStorable:
                    isStorable = bool.Parse(entries[++i]);
                    break;
                case INST_SET_IsUseable:
                    isUseable = bool.Parse(entries[++i]);
                    break;
                case INST_SET_IsDestroyOnUse:
                    isDestroyOnUse = bool.Parse(entries[++i]);
                    break;
                case INST_SET_IsGiftable:
                    isGiftable = bool.Parse(entries[++i]);
                    break;
                case INST_SET_ItemProperty:
                    itemProperties.Add(new ItemPropertyAmount(ConvertType.CheckItemProperty(entries[++i]), float.Parse(entries[++i])));
                    break;

            }

        }

        return new ItemPickUp_Template(id, itemName, itemDescription, itemType, subType, purchasePrice, sellingPrice, itemIcon, isEquipped, isStorable, isUseable, isDestroyOnUse, isGiftable, itemProperties);
    }

}
