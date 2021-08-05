using System.Collections.Generic;

public class EquipmentContainer : ItemContainer<EquipmentContainer>
{
    #region
    public Events.EventOnEquipmentUpdated OnEquipmentUpdated;
    #endregion

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
    }

    public bool StoreItem(ItemPickUp item_pickup, out BaseItemSlot previous_item, List<BaseEquipmentSlot> baseEquipmentSlots)
    {
        for (int index = 0; index < container_item_entry.Length; index++)
        {
            if (baseEquipmentSlots[index].EquipmentType == item_pickup.itemDefinition.SubType)
            {
                previous_item = baseEquipmentSlots[index];
                container_item_entry[index] = new ItemEntry(item_pickup, index);
                return true;
            }
        }
        previous_item = null;
        return false;
    }

    public bool StoreItem(ItemPickUp item_pickup, out ItemPickUp previousItem, List<BaseEquipmentSlot> baseEquipmentSlots)
    {
        for (int index = 0; index < baseEquipmentSlots.Count; index++)
        {
            if (baseEquipmentSlots[index].EquipmentType == item_pickup.itemDefinition.SubType)
            {
                if (container_item_entry[index] != null)
                {
                    previousItem = container_item_entry[index].item_pickup;
                    container_item_entry[index] = new ItemEntry(item_pickup, index);
                    NotificationEvents();
                    return true;
                }
                else
                {
                    container_item_entry[index] = new ItemEntry(item_pickup, index);
                    NotificationEvents();
                    previousItem = null;
                    return true;
                }
            }
        }
        previousItem = null;
        return false;
    }


    public bool EquipmentHasItem(ItemPickUp item_pickup)
    {
        foreach (ItemEntry itemEntry in container_item_entry)
        {
            if (itemEntry != null && item_pickup.SubType == itemEntry.item_pickup.SubType)
            {
                return true;
            }
        }
        return false;
    }

    protected override void NotificationEvents()
    {
        base.NotificationEvents();
        OnEquipmentUpdated?.Invoke();
    }


}
