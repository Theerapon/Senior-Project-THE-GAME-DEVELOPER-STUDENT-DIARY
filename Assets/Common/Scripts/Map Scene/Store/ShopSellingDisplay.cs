using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSellingDisplay : MonoBehaviour
{
    [SerializeField] private ShopSellingManager _shopSellingManager;

    [Header("Item Description")]
    [SerializeField] protected ItemPropertyGenerator itemPropertyGenerator;
    [SerializeField] protected GameObject item_description_gameobject;
    [SerializeField] protected TMP_Text item_name;
    [SerializeField] protected TMP_Text item_type;
    [SerializeField] protected TMP_Text item_description;
    [SerializeField] protected Image item_icon;

    protected void Start()
    {
        if (!ReferenceEquals(_shopSellingManager, null))
        {
            _shopSellingManager.OnPointEnterEvent.AddListener(EnableItemDescription);
            _shopSellingManager.OnPointExitEvent.AddListener(DisableItemDescription);
            _shopSellingManager.OnOutStockItem.AddListener(Initializing);
        }

        Initializing();
    }

    private void DisableItemDescription(BaseItemSellingSlot itemShopSlot)
    {
        Initializing();
    }
    protected virtual void Initializing()
    {
        item_name.text = null;
        item_description.text = null;
        item_icon.sprite = null;
        item_type.text = null;
        item_description_gameobject.SetActive(false);
    }

    private void EnableItemDescription(BaseItemSellingSlot itemShopSlot)
    {
        if(itemShopSlot.ITEMSHOP != null)
        {
            SetItemDescription(itemShopSlot);
        }
    }

    protected void SetItemDescription(BaseItemSellingSlot itemShopSlot)
    {
        item_description_gameobject.SetActive(true);

        item_name.text = itemShopSlot.ITEMSHOP.ItemName;
        item_description.text = itemShopSlot.ITEMSHOP.ItemDescription;
        item_icon.sprite = itemShopSlot.ITEMSHOP.ItemIcon;
        item_type.text = itemShopSlot.ITEMSHOP.ItemType;

        if (itemShopSlot.ITEMSHOP.ItemProperties.Count > 0)
        {
            for (int i = 0; i < itemShopSlot.ITEMSHOP.ItemProperties.Count; i++)
            {
                ItemPropertyAmount itemproperty = itemShopSlot.ITEMSHOP.ItemProperties[i];
                itemPropertyGenerator.CreateTemplate(itemproperty);
            }
        }
        else
        {
            itemPropertyGenerator.ClearTemplate();

        }

    }
}
