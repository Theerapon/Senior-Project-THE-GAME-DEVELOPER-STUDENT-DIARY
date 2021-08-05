using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPurchaseButton : MonoBehaviour
{
    private ShopManager _shopManager;
    private BaseItemShopSlot _baseItemShopSlot;

    private void Awake()
    {
        _shopManager = FindObjectOfType<ShopManager>();
        _baseItemShopSlot = gameObject.GetComponentInParent<BaseItemShopSlot>();
    }

    public void Purchase()
    {
        if(!ReferenceEquals(_shopManager, null))
        {
            _shopManager.Purchase(_baseItemShopSlot);
        }
    }

}
