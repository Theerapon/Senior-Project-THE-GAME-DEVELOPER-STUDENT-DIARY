using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    [SerializeField] private ShopManager shopManager;

    [Header("Item Description")]
    [SerializeField] private ItemPropertyGenerator itemPropertyGenerator;
    [SerializeField] private GameObject item_description_gameobject;
    [SerializeField] private TMP_Text item_name;
    [SerializeField] private TMP_Text item_type;
    [SerializeField] private TMP_Text item_description;
    [SerializeField] private Image item_icon;

    private void Start()
    {
        if(!ReferenceEquals(shopManager, null))
        {
            shopManager.OnPointEnterEvent.AddListener(EnableItemDescription);
            shopManager.OnPointExitEvent.AddListener(DisableItemDescription);
        }

        Reset();
    }

    private void DisableItemDescription(BaseItemShopSlot itemShopSlot)
    {
        Reset();
    }

    private void Reset()
    {
        item_name.text = null;
        item_description.text = null;
        item_icon.sprite = null;
        item_type.text = null;
        item_description_gameobject.SetActive(false);
    }

    private void EnableItemDescription(BaseItemShopSlot itemShopSlot)
    {
        if (itemShopSlot.ITEMSHOP != null)
        {
            SetItemDescription(itemShopSlot);
        }
    }
    private void SetItemDescription(BaseItemShopSlot itemShopSlot)
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
