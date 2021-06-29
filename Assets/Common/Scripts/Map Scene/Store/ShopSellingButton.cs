using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSellingButton : MonoBehaviour
{
    private ShopSellingManager _shopManager;
    private BaseItemSellingSlot _baseItemSellingSlot;

    private void Awake()
    {
        _shopManager = FindObjectOfType<ShopSellingManager>();
        _baseItemSellingSlot = gameObject.GetComponentInParent<BaseItemSellingSlot>();
    }

    public void Selling()
    {
        if (!ReferenceEquals(_shopManager, null))
        {
            _shopManager.Selling(_baseItemSellingSlot);
        }
    }
}
