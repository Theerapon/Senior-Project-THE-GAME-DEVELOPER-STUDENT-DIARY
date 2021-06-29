using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSellingDisplay : ShopDisplay
{
    [SerializeField] private ShopSellingManager _shopSellingManager;

    protected override void Start()
    {
        if (!ReferenceEquals(_shopSellingManager, null))
        {
            _shopSellingManager.OnPointEnterEvent.AddListener(EnableItemDescription);
            _shopSellingManager.OnPointExitEvent.AddListener(DisableItemDescription);
        }

        Initializing();
    }

    private void DisableItemDescription(BaseItemSellingSlot itemShopSlot)
    {
        Initializing();
    }

    private void EnableItemDescription(BaseItemSellingSlot itemShopSlot)
    {
        if(itemShopSlot.ITEMSHOP != null)
        {
            SetItemDescription(itemShopSlot);
        }
    }
}
