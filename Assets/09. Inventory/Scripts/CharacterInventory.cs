using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterInventory : ItemContainer
{

    #region Variable Declarations
    public static CharacterInventory instance;

    //public CharacterStats charStats;
    //GameObject foundStats;

    bool addedItem = true;
    ItemPickUp itemEntry;

    Queue<ItemPickUp> queueItemsToAdd;
    #endregion

    #region Initializations
    protected void Awake()
    {

        instance = this;
        queueItemsToAdd = new Queue<ItemPickUp>();

        //foundStats = GameObject.FindGameObjectWithTag("Player");
        //charStats = foundStats.GetComponent<CharacterStats>();


    }
    #endregion

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerItemUse(101);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerItemUse(102);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerItemUse(103);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerItemUse(104);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TriggerItemUse(105);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TriggerItemUse(106);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TriggerItemUse(107);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TriggerItemUse(108);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TriggerItemUse(109);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TriggerItemUse(110);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            TriggerItemUse(111);
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            TriggerItemUse(112);
        }

        if (queueItemsToAdd.Count > 0)
        {
            DequeueItemsToAdd();
            if (!addedItem)
            {
                addedItem = TryPickUp();
            }
        }


    }

    public void StoreItem(ItemPickUp itemToStore)
    {
        queueItemsToAdd.Enqueue(itemToStore);
    }

    private void DequeueItemsToAdd()
    {
        addedItem = false;
        itemEntry = queueItemsToAdd.Dequeue();
    }

    private bool TryPickUp()
    {
        //dequeue
        bool added = false;

        //Check to see if the item to be stored was properly submitted to the inventory - Continue if Yes otherwise do nothing
        if (itemEntry)
        {
            added = AddItem(itemEntry);
        }
        return added;
    }

    public void TriggerItemUse(int itemToUseID)
    {
        
    }


    [SerializeField] protected Transform itemsParent;
    protected override void OnValidate()
    {
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);


    }
}
