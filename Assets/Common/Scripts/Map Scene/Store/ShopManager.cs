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

    [Header("Item Prefab")]
    [SerializeField] private GameObject _itemPrefab;
    private GameObject _itemTemp;

    private CharacterStatusController _characterStatusController;
    private NotificationController _notificationController;
    private InventoryContainer _inventoryContainer;
    private StoreContoller _storeContoller;
    private ItemTemplateController _itemTemplateController;

    [SerializeField] private Transform itemsParent;
    private List<BaseItemShopSlot> baseItemShopSlots;

    private void Awake()
    {
        baseItemShopSlots = new List<BaseItemShopSlot>();
        _itemTemplateController = ItemTemplateController.Instance;
        _notificationController = NotificationController.Instance;
        _inventoryContainer = InventoryContainer.Instance;
        _characterStatusController = CharacterStatusController.Instance;

        _storeContoller = StoreContoller.Instance;
        _storeId = ConvertType.GetStoreId(_storeType);

        _itemTemp = _itemPrefab;
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
        if (_inventoryContainer.CanStore())
        {
            if(_characterStatusController.CurrentMoney >= baseItemShopSlot.ITEMSHOP.ItemPrice)
            {
                int index = baseItemShopSlot.ITEMSHOP.ItemSetIdIndex;
                _storeContoller.StoreDic[_storeId].Purchase(index);
                baseItemShopSlot.Purchase();
                _characterStatusController.TakeMoney(baseItemShopSlot.ITEMSHOP.ItemPrice);
                GetItem(baseItemShopSlot);
            }
            else
            {
                _notificationController.MoneyNotEnough(baseItemShopSlot);
            }
            
        }
        else
        {
            _notificationController.InventoryFull();
        }
    }

    private void GetItem(BaseItemShopSlot baseItemShopSlot)
    {
        GameObject item_copy = Instantiate(_itemTemp);
        ItemPickUp item = item_copy.GetComponent<ItemPickUp>();
        item.itemDefinition = _itemTemplateController.ItemTemplateDic[baseItemShopSlot.ITEMSHOP.ItemId];
        item.PurchaseItem();
    }
}
