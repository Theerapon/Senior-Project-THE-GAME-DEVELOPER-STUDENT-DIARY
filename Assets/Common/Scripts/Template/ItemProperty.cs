using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperty : MonoBehaviour
{
    private ItemPropertyType itemPropertyType = ItemPropertyType.None;
    private float amount = 0;

    public ItemPropertyType ItemPropertyType { get => itemPropertyType; }
    public float Amount { get => amount; }

    public ItemProperty(ItemPropertyType itemPropertyType, float amount)
    {
        this.itemPropertyType = itemPropertyType;
        this.amount = amount;
    }
}
