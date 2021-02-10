using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum ItemTypeDefinitions { ENERGY, COIN, COMBAT, EMPTY};
public enum ItemCombatSubType { NONE, WEAPON}

[CreateAssetMenu(fileName = "New Item", menuName = "Spawnable Item/New Item")]
public class ItemPickUps_SO : ScriptableObject
{
    [SerializeField] string id;

    public string ID { get { return id; } }
    public string itemName = "New Item";
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.EMPTY;
    public ItemCombatSubType subType = ItemCombatSubType.NONE;
    public int itemAmount = 0;
    public int spawnChanceWeight = 0;

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
    }
    #endif
}
