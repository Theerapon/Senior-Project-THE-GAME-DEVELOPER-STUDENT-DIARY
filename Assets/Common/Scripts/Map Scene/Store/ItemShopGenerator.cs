using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseItemShopSlot;

public class ItemShopGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _itemTemplate;
    private StoreContoller _storeContoller;
    private ItemTemplateController _itemTemplateController;

    private void Awake()
    {
        _storeContoller = StoreContoller.Instance;
        _itemTemplateController = ItemTemplateController.Instance;
    }

    private void CreateItem(ItemShop itemShop)
    {
        GameObject copy;
        copy = Instantiate(_itemTemplate, transform);
        copy.GetComponent<BaseItemShopSlot>().ITEMSHOP = itemShop;

    }

    public void CreateTemplate(ItemShop itemShop)
    {
        _itemTemplate.SetActive(true);
        CreateItem(itemShop);
    }
}
