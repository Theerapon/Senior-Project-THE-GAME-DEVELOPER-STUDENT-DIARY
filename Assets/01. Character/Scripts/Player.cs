using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Public")]
    public CharacterInventory Inventory;

    private void Awake()
    {
        Inventory = CharacterInventory.instance;
    }

}
