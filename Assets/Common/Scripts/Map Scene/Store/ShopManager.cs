using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseItemShopSlot;

public class ShopManager : MonoBehaviour
{
    public Events.EventOnPointEnterItemShop OnPointEnterEvent;
    public Events.EventOnPointExitItemShop OnPointExitEvent;

    [SerializeField] private ItemShopGenerator _itemShopGenerator;
    [SerializeField] private StoreType _storeType;
    private string _storeId;
    

    private StoreContoller _storeContoller;
    private ItemTemplateController _itemTemplateController;

    [SerializeField] private Transform itemsParent;
    private List<BaseItemShopSlot> baseItemShopSlots;

    private void Awake()
    {
        baseItemShopSlots = new List<BaseItemShopSlot>();
        _itemTemplateController = ItemTemplateController.Instance;
        _storeContoller = StoreContoller.Instance;
        _storeId = ConvertType.GetStoreId(_storeType);
    }

    private void Start()
    {
        Initializing();
    }

    private void Initializing()
    {
        List<StoreItemSet> _storeItemSets = new List<StoreItemSet>();
        _storeItemSets = _storeContoller.StoreDic[_storeId].CurrentItemSet;
        for(int index = 0; index < _storeItemSets.Count; index++)
        {
            string itemId = _storeItemSets[index].ItemId;
            int itemAmount = _storeItemSets[index].AmountItem;
            if(itemAmount > 0)
            {
                ItemPickUp_Template itemPickUp_Template = _itemTemplateController.ItemTemplateDic[itemId];
                string itemName = itemPickUp_Template.ItemName;
                Sprite itemIcon = itemPickUp_Template.ItemIcon;
                string itemType = ConvertType.GetStringItemType(itemPickUp_Template.ItemType, itemPickUp_Template.SubType);
                int itemSellingPrice = itemPickUp_Template.SellingPrice;
                string itemDescription = itemPickUp_Template.ItemDescription;
                List<ItemPropertyAmount> itemPropertyAmounts = itemPickUp_Template.ItemProperties;

                _itemShopGenerator.CreateTemplate(new ItemShop(itemId, itemAmount, itemName, index, itemIcon, itemType, itemSellingPrice, itemDescription, itemPropertyAmounts));
            }
        }

        if (itemsParent != null && itemsParent.childCount > 0)
        {
            itemsParent.GetComponentsInChildren(includeInactive: true, result: baseItemShopSlots);

            for (int index = 0; index < baseItemShopSlots.Count; index++)
            {
                baseItemShopSlots[index].OnPointEnterEvent.AddListener(OnPointEnterHandler);
                baseItemShopSlots[index].OnPointExitEvent.AddListener(OnPointExitEventHandler);
            }
        }
            

    }

    private void OnPointEnterHandler(BaseItemShopSlot itemShopSlot)
    {
        OnPointEnterEvent?.Invoke(itemShopSlot);
    }

    private void OnPointExitEventHandler(BaseItemShopSlot itemShopSlot)
    {
        OnPointExitEvent?.Invoke(itemShopSlot);
    }

    public void Purchase(BaseItemShopSlot baseItemShopSlot)
    {
        Debug.Log("Base item shop slot เริ่มต้นมี " + baseItemShopSlot.ITEMSHOP.ItemAmount);
        int index = baseItemShopSlot.ITEMSHOP.ItemSetIdIndex;
        Debug.Log("store item amount " + _storeContoller.StoreDic[_storeId].CurrentItemSet[index].AmountItem);
        _storeContoller.StoreDic[_storeId].Purchase(index);
        baseItemShopSlot.Purchase();
        Debug.Log("after purchase store item amount " + _storeContoller.StoreDic[_storeId].CurrentItemSet[index].AmountItem);
        Debug.Log("after purchaes Base item shop slot  " + baseItemShopSlot.ITEMSHOP.ItemAmount);
    }
}
