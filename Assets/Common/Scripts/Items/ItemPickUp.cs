using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUp_Template itemDefinition;

    ItemContainer charInventory;

    #region Constructors
    public ItemPickUp()
    {
        charInventory = ItemContainer.Instance;
    }
    public ItemPickUp(ItemPickUp_Template itemPickUp_Template)
    {
        itemDefinition = itemPickUp_Template;
    }
    #endregion


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (itemDefinition.GetIsStorable())
            {
                StoreItem();
            }
            else
            {
                UseItem();
            }
        }
    }

    public void UseItem()
    {
        DestroyItemPickUp();
    }

    private void StoreItem()
    {
        charInventory.StoreItem(this);
        
    }

    public void Equip(Player player)
    {
        itemDefinition.Equip(player);
    }

    public void Unequip(Player player)
    {
        itemDefinition.Unequip(player);
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
    public Material GetItemMaterial()
    {
        return itemDefinition.GetItemMaterial();
    }
    public Sprite GetItemIcon()
    {
        return itemDefinition.GetItemIcon();
    }
    public Rigidbody GetItemRigidbody()
    {
        return itemDefinition.GetItemRigidbody();
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
