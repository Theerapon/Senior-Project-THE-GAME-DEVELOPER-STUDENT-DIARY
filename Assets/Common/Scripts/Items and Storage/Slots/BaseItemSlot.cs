using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class BaseItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Image border;

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;
    public event Action<BaseItemSlot> OnRightClickEvent;

    protected bool isPointerOver;

    protected Color normalColor = Color.white;
    protected Color disabledColor = new Color(1, 1, 1, 0);
    protected Color selectedColor = new Color(0, 0, 0, 0.5f);

    protected ItemPickUp _itemPickUp;
    public ItemPickUp ITEM
    {
        get { return _itemPickUp; }
        set
        {
            _itemPickUp = value;

            if (_itemPickUp == null)
            {
                image.sprite = null;
                image.color = disabledColor;
                if (border != null)
                {
                    border.enabled = false;
                    border.color = selectedColor;
                }
            } else
            {
                image.sprite = _itemPickUp.itemDefinition.GetItemIcon();
                image.color = normalColor;
            }

            if (isPointerOver)
            {
                OnPointerExit(null);
                OnPointerEnter(null);
            }

        }
    }

    protected int _index;
    public int INDEX
    {
        get { return _index; }
        set { _index = value; }
    }


    public virtual bool CanReceiveItem(ItemPickUp item)
    {
        return false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (OnRightClickEvent != null)
                OnRightClickEvent(this);
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();

        ITEM = _itemPickUp;
    }

    protected virtual void OnDisable()
    {
        if (isPointerOver)
        {
            OnPointerExit(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;

        if (border != null)
            border.enabled = true;

        if (OnPointerEnterEvent != null)
            OnPointerEnterEvent(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        if(border != null)
            border.enabled = false;

        if (OnPointerExitEvent != null)
            OnPointerExitEvent(this);
    }
}
