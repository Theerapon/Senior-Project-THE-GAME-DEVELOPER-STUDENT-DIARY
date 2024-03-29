﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseItemShopSlot;

public class ItemShopGenerator : MonoBehaviour
{
    [SerializeField] protected GameObject _itemTemplate;

    protected virtual void CreateItem(ItemShop itemShop)
    {
        GameObject copy;
        copy = Instantiate(_itemTemplate, transform);
        copy.GetComponent<BaseItemShopSlot>().ITEMSHOP = itemShop;

    }

    public virtual void CreateTemplate(ItemShop itemShop)
    {
        _itemTemplate.SetActive(true);
        CreateItem(itemShop);
    }

    public void ClearTemplate()
    {
        if(transform.childCount > 0)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
