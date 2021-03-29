public interface IItemContainer
{
    bool CanAddItem(ItemPickUp item, int amount = 1);
    bool AddItem(ItemPickUp itemPickUp);
    ItemPickUp RemoveItem(string itemID);
    bool RemoveItem(ItemPickUp item);
    int ItemAmount(string itemId);
    void ClearItemSlots();


}
