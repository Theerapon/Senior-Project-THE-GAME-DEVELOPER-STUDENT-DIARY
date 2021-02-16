using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum ItemTypeDefinitions { ENERGY, COIN, EQUIPMENT, EMPTY};
public enum ItemSubType { NONE, HAT, ACCESSORY_LEFT, ACCESSORY_RIGHT, NOTEBOOK_BAG, DRESS, GAME_WEAPON, SHOES}

[CreateAssetMenu(fileName = "New Item", menuName = "Spawnable Item/New Item")]
public class ItemPickUps_SO : ScriptableObject
{
    [SerializeField] string id;

    public string ID { get { return id; } }
    public string itemName = "New Item";
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.EMPTY;
    public ItemSubType subType = ItemSubType.NONE;
    public int itemAmount = 0;
    public int spawnChanceWeight = 0;
    [Range(1, 999)]
    public int MaximumStacks = 1;

    public Material itemMaterial = null;
    public Sprite itemIcon = null;
    public Rigidbody itemSpawnObject = null;
    //public Weapon weaponSlotObject = null;

    public bool isEquipped = false;
    public bool isInteractable = false;
    public bool isStorable = false;
    public bool isUnique = false;
    public bool isDestructible = false;
    public bool isQuestItem = false;
    public bool isStackable = false;
    public bool destroyOnUse = false;

    public virtual ItemPickUps_SO GetCopy()
    {
        return this;
    }

    #if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);

        if (destroyOnUse)
            isDestructible = !destroyOnUse;
    }
    #endif

    public virtual void Destroy()
    {

    }

    public void Equip(Player player)
    {
       
    }

    public void Unequip(Player player)
    {
        
    }

    public void UseItem()
    {

    }

}
