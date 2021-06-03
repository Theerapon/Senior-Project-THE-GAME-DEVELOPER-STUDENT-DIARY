using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemSet : MonoBehaviour
{
    private string itemId;
    private int amountItem;

    public string ItemId { get => itemId; }
    public int AmountItem { get => amountItem; }

    public StoreItemSet(string itemId, int amountItem)
    {
        this.itemId = itemId;
        this.amountItem = amountItem;
    }
}
