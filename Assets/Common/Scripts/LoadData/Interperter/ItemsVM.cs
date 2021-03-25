using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsVM : MonoBehaviour
{
    private const string INST_SET_ItemID = "itemID";
    private const string INST_SET_ItemName = "itemName";
    private const string INST_SET_ItemDefinitionsType = "itemDefinitionsType";
    private const string INST_SET_ItemEquipmentType = "itemEquipmentType";
    private const string INST_SET_ItemAmount = "itemAmount";
    private const string INST_SET_ItemSpawnChanceWeight = "itemSpawnChanceWeight";
    private const string INST_SET_MaxStacks = "maxStacks";
    private const string INST_SET_ItemMaterialPath = "itemMaterialPath";
    private const string INST_SET_ItemIconPath = "itemIconPath";
    private const string INST_SET_ItemRigidbodyPath = "itemRigidbodyPath";
    private const string INST_SET_IsEquipped = "isEquipped";
    private const string INST_SET_IsStorable = "isStorable";
    private const string INST_SET_IsUnique = "isUnique";
    private const string INST_SET_IsDestructible = "isDestructible";
    private const string INST_SET_IsQuestItem = "isQuestItem";
    private const string INST_SET_IsStackable = "isStackable";
    private const string INST_SET_IsDestroyOnUse = "isDestroyOnUse";
    private const string INST_SET_IsGiftable = "isGiftable";

    [SerializeField] private GameObject itemPrefab;

    private ItemsDataLoading itemsDataLoading;

    private void Start()
    {
        itemsDataLoading = ItemsDataLoading.instance;
    }

    public ItemPickUp_Template Interpert(string id)
    {
        ItemPickUp_Template copy = new ItemPickUp_Template();

        string row = itemsDataLoading.textLists[id];
        string[] entries = row.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ItemID:
                    copy.SetID(entries[++i]);
                    break;
                case INST_SET_ItemName:
                    copy.SetItemName(entries[++i]);
                    break;
                case INST_SET_ItemDefinitionsType:
                    copy.SetItemDefinitionsType(SetDefinitionsType(entries[++i]));
                    break;
                case INST_SET_ItemEquipmentType:
                    copy.SetItemEquipmentType(SetEquipmentType(entries[++i]));
                    break;
                case INST_SET_ItemAmount:
                    copy.SetItemAmount(int.Parse(entries[++i]));
                    break;
                case INST_SET_ItemSpawnChanceWeight:
                    copy.SetItemSpawnChanceWeight(int.Parse(entries[++i]));
                    break;
                case INST_SET_MaxStacks:
                    copy.SetMaxStackable(int.Parse(entries[++i]));
                    break;
                case INST_SET_ItemMaterialPath:
                    Material material = Resources.Load<Material>(entries[++i]);
                    copy.SetItemMaterial(material);
                    break;
                case INST_SET_ItemIconPath:
                    Sprite icon = Resources.Load<Sprite>(entries[++i]);
                    copy.SetItemIcon(icon);
                    break;
                case INST_SET_ItemRigidbodyPath:
                    copy.SetItemRigidbody(itemPrefab.GetComponent<Rigidbody>());
                    break;
                case INST_SET_IsEquipped:
                    copy.SetIsEquipped(bool.Parse(entries[++i]));
                    break;
                case INST_SET_IsStorable:
                    copy.SetIsStorable(bool.Parse(entries[++i]));
                    break;
                case INST_SET_IsUnique:
                    copy.SetIsUnique(bool.Parse(entries[++i]));
                    break;
                case INST_SET_IsDestructible:
                    copy.SetIsDestructible(bool.Parse(entries[++i]));
                    break;
                case INST_SET_IsQuestItem:
                    copy.SetIsQuestItem(bool.Parse(entries[++i]));
                    break;
                case INST_SET_IsStackable:
                    copy.SetIsStackable(bool.Parse(entries[++i]));
                    break;
                case INST_SET_IsDestroyOnUse:
                    copy.SetIsDestroyOnUse(bool.Parse(entries[++i]));
                    break;
                case INST_SET_IsGiftable:
                    copy.SetIsGiftable(bool.Parse(entries[++i]));
                    break;

            }
                
        }
        return copy;
    }

    private ItemEquipmentType SetEquipmentType(string type)
    {
        ItemEquipmentType subType = ItemEquipmentType.NONE;
        switch (type)
        {
            case "ENERGY":
                subType = ItemEquipmentType.NONE;
                break;
            case "HAT":
                subType = ItemEquipmentType.HAT;
                break;
            case "ACCESSORY":
                subType = ItemEquipmentType.ACCESSORY;
                break;
            case "BAG":
                subType = ItemEquipmentType.BAG;
                break;
            case "NOTEBOOK_BAG":
                subType = ItemEquipmentType.NOTEBOOK_BAG;
                break;
            case "DRESS":
                subType = ItemEquipmentType.DRESS;
                break;
            case "GAME_WEAPON":
                subType = ItemEquipmentType.GAME_WEAPON;
                break;
            case "SHOES":
                subType = ItemEquipmentType.SHOES;
                break;
        }
        return subType;
    }
    private ItemDefinitionsType SetDefinitionsType(string type)
    {
        ItemDefinitionsType itemType = ItemDefinitionsType.EMPTY;
        switch (type)
        {
            case "ENERGY":
                itemType = ItemDefinitionsType.ENERGY;
                break;
            case "COIN":
                itemType = ItemDefinitionsType.COIN;
                break;
            case "EQUIPMENT":
                itemType = ItemDefinitionsType.EQUIPMENT;
                break;
            case "EMPTY":
                itemType = ItemDefinitionsType.EMPTY;
                break;
        }
        return itemType;
    }
}
