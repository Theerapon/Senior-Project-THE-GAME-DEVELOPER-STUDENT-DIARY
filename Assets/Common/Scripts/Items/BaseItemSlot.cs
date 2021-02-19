using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class BaseItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected TMP_Text amountText;

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;
    public event Action<BaseItemSlot> OnRightClickEvent;

    protected bool isPointerOver;

    protected Color normalColor = Color.white;
    protected Color grayColor = Color.gray;
    protected Color disabledColor = new Color(1, 1, 1, 0);

    protected ItemPickUp _itemPickUp;
    public ItemPickUp ITEM
    {
        get { return _itemPickUp; }
        set
        {
            _itemPickUp = value;
            if (_itemPickUp == null && Amount != 0)
                Amount = 0;

            if (_itemPickUp == null)
            {
                image.sprite = null;
                image.color = grayColor;
            } else
            {
                image.sprite = _itemPickUp.itemDefinition.itemIcon;
                image.color = normalColor;
            }
                
        }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            if (_amount < 0) _amount = 0;
            if (_amount == 0 && ITEM != null)
            {
                if(ITEM.itemDefinition.destroyOnUse)
                    ITEM.DestroyItemPickUp();
                ITEM = null;
            }

            if (amountText != null)
            {
                amountText.enabled = _itemPickUp != null && _amount > 1;
                if (amountText.enabled)
                {
                    amountText.text = _amount.ToString();
                }
            }
        }
    }

    public virtual bool CanAddStack(ItemPickUp item, int amount = 1)
    {
        return ITEM != null && ITEM.itemDefinition.ID == item.itemDefinition.ID;
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

        if (amountText == null)
            amountText = GetComponentInChildren<TMP_Text>();
        
        ITEM = _itemPickUp;
        Amount = _amount;
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

        if (OnPointerEnterEvent != null)
            OnPointerEnterEvent(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;

        if (OnPointerExitEvent != null)
            OnPointerExitEvent(this);
    }
}
