[System.Serializable]
public class ItemSlotSaveData
{
    public string ItemID;
    public int Amount;
    public int inventorySlot;
    public int hotBarSlot;

    public ItemSlotSaveData(string id, int stack, int invtSlot, int hbSlot)
    {
        ItemID = id;
        Amount = stack;
        inventorySlot = invtSlot;
        hotBarSlot = hbSlot;
    }
    public ItemSlotSaveData(string id, int stack)
    {
        ItemID = id;
        Amount = stack;
        inventorySlot = 0;
        hotBarSlot = 0;
    }
}

[System.Serializable]
public class ItemContainerSaveData
{
    public ItemSlotSaveData[] SavedSlots;

    public ItemContainerSaveData(int countTotolItems)
    {
        SavedSlots = new ItemSlotSaveData[countTotolItems];
    }
}
