using UnityEngine;
using static BaseItemShopSlot;

public class ItemSellingGenerator : ItemShopGenerator
{
    protected override void CreateItem(ItemShop itemShop)
    {
        GameObject copy;
        copy = Instantiate(_itemTemplate, transform);
        copy.GetComponent<BaseItemSellingSlot>().ITEMSHOP = itemShop;

    }

}
