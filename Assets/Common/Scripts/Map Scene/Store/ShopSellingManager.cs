using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseItemShopSlot;

public class ShopSellingManager : MonoBehaviour
{
    public Events.EventOnPointEnterItemShopSelling OnPointEnterEvent;
    public Events.EventOnPointExitItemShopSelling OnPointExitEvent;
    public Events.EventOnOutStockItem OnOutStockItem;

    [SerializeField] private ItemSellingGenerator _itemShopGenerator;
    [Header("Lock Background")]
    [SerializeField] private GameObject _lock;

    [Header("Place")]
    [SerializeField] private Place _place;
    private string _placeId;

    private StoreContoller _storeContoller;
    private CharacterStatusController _characterStatusController;
    private InventoryContainer _inventoryContainer;
    private ItemTemplateController _itemTemplateController;
    private NotificationController _notificationController;
    private PlacesController _placesController;

    [SerializeField] private Transform itemsParent;
    private List<BaseItemSellingSlot> baseItemShopSlots;

    private int _totalItem;

    private void Awake()
    {
        _totalItem = 0;
        baseItemShopSlots = new List<BaseItemSellingSlot>();
        _inventoryContainer = InventoryContainer.Instance;
        _characterStatusController = CharacterStatusController.Instance;
        _itemTemplateController = ItemTemplateController.Instance;
        _notificationController = NotificationController.Instance;
        _placesController = PlacesController.Instance;
        _storeContoller = StoreContoller.Instance;

        _placeId = ConvertType.GetPlaceId(_place);
    }

    private void Start()
    {
        Initializing();
    }
    private void Initializing()
    {
        bool isOpen = _placesController.PlacesDic[_placeId].IsOpen;
        if (isOpen)
        {
            ItemEntry[] container_item_entry = new ItemEntry[_inventoryContainer.Container_size];
            container_item_entry = _inventoryContainer.container_item_entry;

            for (int index = 0; index < container_item_entry.Length; index++)
            {
                if (!ReferenceEquals(container_item_entry[index], null))
                {
                    string itemId = container_item_entry[index].item_pickup.Id;
                    int itemAmount = 1;
                    _totalItem += itemAmount;

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
                    baseItemShopSlots[index].OnPointEnterSellingEvent.AddListener(OnPointEnterHandler);
                    baseItemShopSlots[index].OnPointExitSellingEvent.AddListener(OnPointExitEventHandler);
                }
            }
        }

        CheckInvIsEmpty();

    }


    public void Selling(BaseItemSellingSlot baseItemSellingSlot)
    {
        
        int index = baseItemSellingSlot.ITEMSHOP.ItemSetIdIndex;
        if (!ReferenceEquals(_inventoryContainer.container_item_entry[index], null))
        {
            _characterStatusController.IncreaseCurrentMoney(baseItemSellingSlot.ITEMSHOP.ItemPrice);
            _inventoryContainer.SellingItem(index);
            baseItemSellingSlot.Selling();
            _notificationController.SellingItem(baseItemSellingSlot);
            _totalItem--;
            CheckInvIsEmpty();
        }
        
    }

    private void CheckInvIsEmpty()
    {
        if(_totalItem > 0)
        {
            ActiveLockBackground(false);
        }
        else
        {
            ActiveLockBackground(true);
            OnOutStockItem?.Invoke();
        }
    }

    private void ActiveLockBackground(bool active)
    {
        if(_lock.activeSelf != active)
        {
            _lock.SetActive(active);
        }
    }

    private void OnPointEnterHandler(BaseItemSellingSlot itemShopSlot)
    {
        OnPointEnterEvent?.Invoke(itemShopSlot);
    }

    private void OnPointExitEventHandler(BaseItemSellingSlot itemShopSlot)
    {
        OnPointExitEvent?.Invoke(itemShopSlot);
    }

}
