using UnityEngine;

public enum ItemDefinitionsType { ENERGY, COIN, EQUIPMENT, EMPTY};
public enum ItemEquipmentType { NONE, HAT, SHIRT, PANT, SHOES}

public class ItemPickUp_Template
{
    private string id;
    private string itemName = "New Item";
    private string itemDescription = "";
    private ItemDefinitionsType itemType = ItemDefinitionsType.EMPTY;
    private ItemEquipmentType subType = ItemEquipmentType.NONE;
    private int itemAmount = 0;
    private int spawnChanceWeight = 0;
    [Range(1, 999)]
    private int MaximumStacks = 1;

    private Sprite itemIcon = null;

    private bool isEquipped = false;
    private bool isStorable = false;
    private bool isUnique = false;
    private bool isDestructible = false;
    private bool isQuestItem = false;
    private bool isStackable = false;
    private bool isDestroyOnUse = false;
    private bool isGiftable = false;



    public ItemPickUp_Template()
    {

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
        return MaximumStacks;
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

    #region Set
    public void SetID(string id)
    {
        this.id = id;
    }
    public void SetItemName(string name)
    {
        itemName = name;
    }
    public void SetItemDescription(string description)
    {
        itemDescription = description;
    }
    public void SetItemDefinitionsType(ItemDefinitionsType type)
    {
        itemType = type;
    }
    public void SetItemEquipmentType(ItemEquipmentType type)
    {
        subType = type;
    }
    public void SetItemAmount(int amount)
    {
        itemAmount = amount;
    }
    public void SetItemSpawnChanceWeight(int weight)
    {
        spawnChanceWeight = weight;
    }
    public void SetMaxStackable(int value)
    {
        MaximumStacks = value;
    }

    public void SetItemIcon(Sprite icon)
    {
        itemIcon = icon;
    }

    public void SetIsEquipped(bool equipped)
    {
        isEquipped = equipped;
    }
    public void SetIsStorable(bool stored)
    {
        isStorable = stored;
    }
    public void SetIsUnique(bool uniqued)
    {
        isUnique = uniqued;
    }
    public void SetIsDestructible(bool destructed)
    {
        isDestructible = destructed;
    }
    public void SetIsQuestItem(bool quested)
    {
        isQuestItem = quested;
    }
    public void SetIsStackable(bool stacked)
    {
        isStackable = stacked;
    }
    public void SetIsDestroyOnUse(bool destroyed)
    {
        isDestroyOnUse = destroyed;
    }
    public void SetIsGiftable(bool value)
    {
        isGiftable = value;
    }
    #endregion
}
