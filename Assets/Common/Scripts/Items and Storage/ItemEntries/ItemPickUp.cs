using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUp_Template itemDefinition;

    StachContainer stach_container;
    InventoryContainer inventory_container;

    #region Constructors
    public ItemPickUp()
    {
        stach_container = StachContainer.Instance;
        inventory_container = InventoryContainer.Instance;
    }
    public ItemPickUp(ItemPickUp_Template itemPickUp_Template)
    {
        itemDefinition = itemPickUp_Template;
    }
    #endregion

    public void UseItem()
    {
        DestroyItemPickUp();
    }

    public void StoreItem()
    {
        stach_container.StoreItem(this);

    }

    public void Equip()
    {
        itemDefinition.Equip();
    }

    public void Unequip()
    {
        itemDefinition.Unequip();
    }

    public virtual void DestroyItemPickUp()
    {
        if (!itemDefinition.GetIsDestructible())
        {
            Destroy(this.gameObject);
        }
    }

    public void SetGameObjectToTrue()
    {
        this.gameObject.SetActive(true);
    }

    public void SetGameObjectToFalse()
    {
        this.gameObject.SetActive(false);
    }

    #region Get
    public string ID()
    {
        return itemDefinition.ID();
    }
    public string GetItemName()
    {
        return itemDefinition.GetItemName();
    }
    public ItemDefinitionsType GetItemDefinitionsType()
    {
        return itemDefinition.GetItemDefinitionsType();
    }
    public ItemEquipmentType GetItemEquipmentType()
    {
        return itemDefinition.GetItemEquipmentType();
    }
    public int GetItemAmount()
    {
        return itemDefinition.GetItemAmount();
    }
    public int GetItemSpawnChanceWeight()
    {
        return itemDefinition.GetItemSpawnChanceWeight();
    }
    public int GetMaxStackable()
    {
        return itemDefinition.GetMaxStackable();
    }

    public Sprite GetItemIcon()
    {
        return itemDefinition.GetItemIcon();
    }

    public bool GetIsEquipped()
    {
        return itemDefinition.GetIsEquipped();
    }
    public bool GetIsStorable()
    {
        return itemDefinition.GetIsStorable();
    }
    public bool GetIsQuestItem()
    {
        return itemDefinition.GetIsQuestItem();
    }
    public bool GetIsStackable()
    {
        return itemDefinition.GetIsStackable();
    }
    public bool GetIsDestroyOnUse()
    {
        return itemDefinition.GetIsDestroyOnUse();
    }
    public bool GetIsGiftable()
    {
        return itemDefinition.GetIsGiftable();
    }
    #endregion
}
