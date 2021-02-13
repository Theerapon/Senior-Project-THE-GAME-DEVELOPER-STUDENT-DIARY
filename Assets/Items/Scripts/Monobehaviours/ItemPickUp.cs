using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUps_SO itemDefinition;

    public CharacterStats characterStats;
    CharacterInventory charInventory;

    GameObject foundStats;

    #region Constructors
    public ItemPickUp()
    {
        charInventory = CharacterInventory.instance;
    }
    #endregion

    private void Start()
    {
        foundStats = GameObject.FindGameObjectWithTag("Player");
        characterStats = foundStats.GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (itemDefinition.isStorable)
            {
                StoreItem();
            }
            else
            {
                UseItem();
            }
        }
    }

    public void UseItem()
    {
        
        if (!itemDefinition.isDestructible)
        {
            Destroy(this.gameObject);
        }
    }

    private void StoreItem()
    {
        charInventory.StoreItem(this);
        
    }

    public void Equip(Player player)
    {
        itemDefinition.Equip(player);
    }

    public void Unequip(Player player)
    {
        itemDefinition.Unequip(player);
    }

}
