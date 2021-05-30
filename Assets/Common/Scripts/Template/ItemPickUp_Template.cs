using UnityEngine;

public class ItemPickUp_Template
{
    private string id = string.Empty;
    private string itemName = "New Item";
    private string itemDescription = "Item Desctioption";
    private ItemDefinitionsType itemType = ItemDefinitionsType.EMPTY;
    private ItemEquipmentType subType = ItemEquipmentType.NONE;
    private int itemAmount = 0;
    private int spawnChanceWeight = 0;
    [Range(1, 999)]
    private int maximumStacks = 1;

    private Sprite itemIcon = null;

    private bool isEquipped = false;
    private bool isStorable = false;
    private bool isUnique = false;
    private bool isDestructible = false;
    private bool isQuestItem = false;
    private bool isStackable = false;
    private bool isDestroyOnUse = false;
    private bool isGiftable = false;

    public ItemPickUp_Template(string id, string itemName, string itemDescription, ItemDefinitionsType itemType, ItemEquipmentType subType, int itemAmount, int spawnChanceWeight, int maximumStacks, Sprite itemIcon, bool isEquipped, bool isStorable, bool isUnique, bool isDestructible, bool isQuestItem, bool isStackable, bool isDestroyOnUse, bool isGiftable)
    {
        this.id = id;
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemType = itemType;
        this.subType = subType;
        this.itemAmount = itemAmount;
        this.spawnChanceWeight = spawnChanceWeight;
        this.maximumStacks = maximumStacks;
        this.itemIcon = itemIcon;
        this.isEquipped = isEquipped;
        this.isStorable = isStorable;
        this.isUnique = isUnique;
        this.isDestructible = isDestructible;
        this.isQuestItem = isQuestItem;
        this.isStackable = isStackable;
        this.isDestroyOnUse = isDestroyOnUse;
        this.isGiftable = isGiftable;
    }

    public virtual ItemPickUp_Template GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }

    public void UseItem()
    {

    }

    public void Equip()
    {
        Debug.Log(itemName + " Equiped");
    }

    public void Unequip()
    {
        Debug.Log(itemName + " Unequiped");
    }

    #region Get
    public string ID()
    {
        return id;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public string GetItemDescription()
    {
        return itemDescription;
    }
    public ItemDefinitionsType GetItemDefinitionsType()
    {
        return itemType;
    }
    public ItemEquipmentType GetItemEquipmentType()
    {
        return subType;
    }
    public int GetItemAmount()
    {
        return itemAmount;
    }
    public int GetItemSpawnChanceWeight()
    {
        return spawnChanceWeight;
    }
    public int GetMaxStackable()
    {
        return maximumStacks;
    }

    public Sprite GetItemIcon()
    {
        return itemIcon;
    }

    public bool GetIsEquipped()
    {
        return isEquipped;
    }
    public bool GetIsStorable()
    {
        return isStorable;
    }
    public bool GetIsUnique()
    {
        return isUnique;
    }
    public bool GetIsDestructible()
    {
        return isDestructible;
    }
    public bool GetIsQuestItem()
    {
        return isQuestItem;
    }
    public bool GetIsStackable()
    {
        return isStackable;
    }
    public bool GetIsDestroyOnUse()
    {
        return isDestroyOnUse;
    }
    public bool GetIsGiftable()
    {
        return isGiftable;
    }
    #endregion
}
