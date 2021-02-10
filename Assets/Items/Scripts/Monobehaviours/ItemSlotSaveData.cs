[System.Serializable]
public class ItemSlotSaveData
{
    public string ItemID;
    public int stackSize;
    public int inventorySlot;
    public int hotBarSlot;

    public ItemSlotSaveData(string id, int stack, int invtSlot, int hbSlot)
    {
        ItemID = id;
        stackSize = stack;
        inventorySlot = invtSlot;
        hotBarSlot = hbSlot;
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
