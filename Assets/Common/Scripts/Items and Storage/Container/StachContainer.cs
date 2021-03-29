using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StachContainer : ItemContainer<StachContainer>
{
    InventoryContainer inventoryContainer;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        inventoryContainer = InventoryContainer.Instance;
    }

    public override bool StoreItem(ItemPickUp item_pickup)
    {
        if (inventoryContainer.CanStore())
        {
            inventoryContainer.StoreItem(item_pickup);
            return true;
        }
        else
        {
            if (CanStore())
            {
                for (int index = 0; index < container_item_entry.Length; index++)
                {
                    bool isEmpty = container_item_entry[index] == null;
                    if (isEmpty)
                    {
                        container_item_entry[index] = new ItemEntry(item_pickup, index);
                        break;
                    }
                }
                return true;
            }
            else
            {
                Debug.Log("Full");
                return false;
            }
            
        }

    }
}
