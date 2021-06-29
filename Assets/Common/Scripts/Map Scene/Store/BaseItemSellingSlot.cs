using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseItemSellingSlot : BaseItemShopSlot
{
    public Events.EventOnPointEnterItemShopSelling OnPointEnterSellingEvent;
    public Events.EventOnPointExitItemShopSelling OnPointExitSellingEvent;

    public void Selling()
    {
        ITEMSHOP.ItemAmount--;
        UpdateInfo();
    }

    protected override void UpdateInfo()
    {
        if (_itemShop.ItemAmount > 0)
        {
            _itemImage.sprite = _itemShop.ItemIcon;
            _itemNameTMP.text = _itemShop.ItemName;
            _itemTypeTMP.text = _itemShop.ItemType;
            _itemPrice.text = _itemShop.ItemPrice.ToString();
        }
        else
        {
            ActiveItemTemplate(false);
        }
    }

    protected override void OnValidate()
    {
        if (_template == null)
        {
            _template = this.gameObject;
            ActiveItemTemplate(true);
        }

        if (_itemImage == null)
        {
            _itemImage = _template.transform.GetChild(1).GetComponentInChildren<Image>();
        }

        if (_itemNameTMP == null)
        {
            _itemNameTMP = _template.transform.GetChild(2).GetChild(0).GetComponentInChildren<TMP_Text>();
        }

        if (_itemTypeTMP == null)
        {
            _itemTypeTMP = _template.transform.GetChild(2).GetChild(1).GetComponentInChildren<TMP_Text>();
        }

        if (_itemPrice == null)
        {
            _itemPrice = _template.transform.GetChild(3).GetChild(0).GetComponentInChildren<TMP_Text>();
        }

        if (_button == null)
        {
            _button = _template.transform.GetChild(3).GetChild(1).gameObject;
        }
    }
}
