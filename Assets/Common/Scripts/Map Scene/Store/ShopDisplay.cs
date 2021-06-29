using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    [SerializeField] protected ShopManager _shopManager;

    [Header("Item Description")]
    [SerializeField] protected ItemPropertyGenerator itemPropertyGenerator;
    [SerializeField] protected GameObject item_description_gameobject;
    [SerializeField] protected TMP_Text item_name;
    [SerializeField] protected TMP_Text item_type;
    [SerializeField] protected TMP_Text item_description;
    [SerializeField] protected Image item_icon;

    protected virtual void Start()
    {
        if(!ReferenceEquals(_shopManager, null))
        {
            _shopManager.OnPointEnterEvent.AddListener(EnableItemDescription);
            _shopManager.OnPointExitEvent.AddListener(DisableItemDescription);
        }

        Initializing();
    }

    private void DisableItemDescription(BaseItemShopSlot itemShopSlot)
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

    private  void EnableItemDescription(BaseItemShopSlot itemShopSlot)
    {
        if (itemShopSlot.ITEMSHOP != null)
        {
            SetItemDescription(itemShopSlot);
        }
    }
    protected virtual void SetItemDescription(BaseItemShopSlot itemShopSlot)
    {
        item_description_gameobject.SetActive(true);

        item_name.text = itemShopSlot.ITEMSHOP.ItemName;
        item_description.text = itemShopSlot.ITEMSHOP.ItemDescription;
        item_icon.sprite = itemShopSlot.ITEMSHOP.ItemIcon;
        item_type.text = itemShopSlot.ITEMSHOP.ItemType;



        for (int i = 0; i < itemShopSlot.ITEMSHOP.ItemProperties.Count; i++)
        {
            ItemPropertyAmount itemproperty = itemShopSlot.ITEMSHOP.ItemProperties[i];
            itemPropertyGenerator.CreateTemplate(itemproperty);
        }

    }

}
