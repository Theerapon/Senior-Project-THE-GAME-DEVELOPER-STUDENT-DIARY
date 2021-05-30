using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_Template : MonoBehaviour
{
    private string id;
    private string[] storeItemSetIdPerDay = new string[7];

    public string Id { get => id; }
    public string[] StoreItemSetPerDay { get => storeItemSetIdPerDay; }

    public Store_Template(string id, string[] storeItemSetPerDay)
    {
        this.id = id;
        this.storeItemSetIdPerDay = storeItemSetPerDay;
    }
}
