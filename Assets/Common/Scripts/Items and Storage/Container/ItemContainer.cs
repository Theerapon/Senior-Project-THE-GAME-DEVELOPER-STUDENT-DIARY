using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    
    [SerializeField] private int container_size;
    public ItemEntry[] container_item_entry;
    public static T Instance
    {
        get { return instance; }
        set
        {
            if (null == instance)
            {
                instance = value;

            }
            else if (instance != value)
            {
                Destroy(value.gameObject);
            }
        }
    }

    protected virtual void Awake()
    {
        Instance = this as T;
        container_item_entry = new ItemEntry[container_size];
    }

    protected virtual void Start()
    {
        //container_item_entry = new ItemEntry[container_size];
    }

    public virtual bool StoreItem(ItemPickUp item_pickup)
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
            NotificationEvents();
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public virtual bool StoreItem(ItemPickUp item_pickup, int index)
    {
        container_item_entry[index] = new ItemEntry(item_pickup, index);
        NotificationEvents();
        return true;
    }

    public virtual bool RemoveItem(int index)
    {
        if(container_item_entry[index] != null)
        {
            container_item_entry[index] = null;
            NotificationEvents();
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void Swap(int origin_item_entry, int target_item_entry)
    {
        ItemEntry temp_item_entry =  container_item_entry[origin_item_entry];
        //target to origin
        container_item_entry[origin_item_entry] = container_item_entry[target_item_entry];
        container_item_entry[origin_item_entry].slot_index = container_item_entry[target_item_entry].slot_index;
        //origin to targen
        container_item_entry[target_item_entry] = temp_item_entry;
        container_item_entry[target_item_entry].slot_index = temp_item_entry.slot_index;
    }

    public virtual bool CanStore()
    {
        bool canAdd = false;
        for(int i = 0; i < container_item_entry.Length; i++)
        {
            bool isEmpty = container_item_entry[i] == null;
            if (isEmpty)
            {
                canAdd = true;
            }
        }

        return canAdd;
    }

    protected virtual void NotificationEvents()
    {

    }



}
