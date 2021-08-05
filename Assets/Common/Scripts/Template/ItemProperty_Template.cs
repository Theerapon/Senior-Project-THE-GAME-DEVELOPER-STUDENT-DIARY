using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperty_Template : MonoBehaviour
{
    private string typeID = string.Empty;
    private ItemPropertyType itemPropertyType = ItemPropertyType.None;
    private string itemPropertyName = string.Empty;
    private Sprite icon = null;

    public string TypeID { get => typeID; }
    public ItemPropertyType ItemPropertyType { get => itemPropertyType; }
    public string ItemPropertyName { get => itemPropertyName; }
    public Sprite Icon { get => icon; }

    public ItemProperty_Template(string typeID, ItemPropertyType itemPropertyType, string itemPropertyName, Sprite icon)
    {
        this.typeID = typeID;
        this.itemPropertyType = itemPropertyType;
        this.itemPropertyName = itemPropertyName;
        this.icon = icon;
    }
}
