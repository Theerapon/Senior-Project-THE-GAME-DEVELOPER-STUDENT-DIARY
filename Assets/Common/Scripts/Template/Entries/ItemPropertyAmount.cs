using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPropertyAmount : MonoBehaviour
{
    private ItemPropertyType itemPropertyType = ItemPropertyType.None;
    private float amount = 0;

    public ItemPropertyType PropertyType { get => itemPropertyType; }
    public float Amount { get => amount; }

    public ItemPropertyAmount(ItemPropertyType itemPropertyType, float amount)
    {
        this.itemPropertyType = itemPropertyType;
        this.amount = amount;
    }
}
