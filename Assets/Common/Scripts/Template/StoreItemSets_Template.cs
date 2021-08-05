using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemSets_Template : MonoBehaviour
{
    private string id = string.Empty;
    private List<StoreItemSet> storeItemSets = null;

    public string Id { get => id; }
    public List<StoreItemSet> StoreItemSets { get => storeItemSets; }

    public StoreItemSets_Template(string id, List<StoreItemSet> storeItemSets)
    {
        this.id = id;
        this.storeItemSets = storeItemSets;
    }
}
