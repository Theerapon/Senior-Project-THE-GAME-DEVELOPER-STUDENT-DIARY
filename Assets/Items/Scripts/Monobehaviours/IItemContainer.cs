public interface IItemContainer
{
    bool CanAddItem(ItemPickUps_SO item, int amount = 1);
    bool AddItem(ItemPickUps_SO itemPickUp);
    ItemPickUps_SO RemoveItem(string itemID);
    bool RemoveItem(ItemPickUps_SO item);
    int ItemAmount(string itemId);
    void ClearItemSlots();


}
