using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp_Template
{
    private string id = string.Empty;
    private string itemName = "New Item";
    private string itemDescription = "Item Desctioption";
    private ItemDefinitionsType itemType = ItemDefinitionsType.Treasure;
    private ItemEquipmentType subType = ItemEquipmentType.NONE;
    private int purchasePrice = 0; 
    private int sellingPrice = 0;
    private Sprite itemIcon = null;

    private bool isEquipped = false;
    private bool isStorable = false;
    private bool isUseable = false;
    private bool isDestroyOnUse = false;
    private bool isGiftable = false;

    private List<ItemPropertyAmount> itemProperties = null;

    public string Id { get => id; }
    public string ItemName { get => itemName; }
    public string ItemDescription { get => itemDescription; }
    public ItemDefinitionsType ItemType { get => itemType; }
    public ItemEquipmentType SubType { get => subType; }
    public int PurchasePrice { get => purchasePrice; }
    public int SellingPrice { get => sellingPrice; }
    public Sprite ItemIcon { get => itemIcon; }
    public bool IsEquipped { get => isEquipped; }
    public bool IsStorable { get => isStorable; }
    public bool IsDestroyOnUse { get => isDestroyOnUse; }
    public bool IsGiftable { get => isGiftable; }
    public List<ItemPropertyAmount> ItemProperties { get => itemProperties; }
    public bool IsUseable { get => isUseable; }

    public ItemPickUp_Template(string id, string itemName, string itemDescription, ItemDefinitionsType itemType, ItemEquipmentType subType, int purchasePrice, int sellingPrice, Sprite itemIcon, bool isEquipped, bool isStorable, bool isUseable, bool isDestroyOnUse, bool isGiftable, List<ItemPropertyAmount> itemProperties)
    {
        this.id = id;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemType = itemType;
        this.subType = subType;
        this.purchasePrice = purchasePrice;
        this.sellingPrice = sellingPrice;
        this.itemIcon = itemIcon;
        this.isEquipped = isEquipped;
        this.isStorable = isStorable;
        this.isUseable = isUseable;
        this.isDestroyOnUse = isDestroyOnUse;
        this.isGiftable = isGiftable;
        this.itemProperties = itemProperties;
    }

    public virtual ItemPickUp_Template GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }
    
}
