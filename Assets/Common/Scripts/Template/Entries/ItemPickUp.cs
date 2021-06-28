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
    public void PurchaseItem()
    {
        inventory_container.StoreItem(this);
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
        if (!itemDefinition.IsDestructible)
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
    public string Id { get => itemDefinition.Id; }
    public string ItemName { get => itemDefinition.ItemName; }
    public string ItemDescription { get => itemDefinition.ItemDescription; }
    public ItemDefinitionsType ItemType { get => itemDefinition.ItemType; }
    public ItemEquipmentType SubType { get => itemDefinition.SubType; }
    public int PurchasePrice { get => itemDefinition.PurchasePrice; }
    public int SellingPrice1 { get => itemDefinition.SellingPrice; }
    public Sprite ItemIcon { get => itemDefinition.ItemIcon; }
    public bool IsEquipped { get => itemDefinition.IsEquipped; }
    public bool IsStorable { get => itemDefinition.IsStorable; }
    public bool IsUnique { get => itemDefinition.IsUnique; }
    public bool IsDestructible { get => itemDefinition.IsDestructible; }
    public bool IsDestroyOnUse { get => itemDefinition.IsDestroyOnUse; }
    public bool IsGiftable { get => itemDefinition.IsGiftable; }
    public List<ItemPropertyAmount> ItemProperties { get => itemDefinition.ItemProperties; }
    #endregion
}
