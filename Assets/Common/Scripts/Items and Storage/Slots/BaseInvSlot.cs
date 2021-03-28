using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseInvSlot : BaseItemSlot, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	public event Action<BaseItemSlot> OnBeginDragEvent;
	public event Action<BaseItemSlot> OnEndDragEvent;
	public event Action<BaseItemSlot> OnDragEvent;
	public event Action<BaseItemSlot> OnDropEvent;

    private bool isDragging;
    private Color dragColor = new Color(1, 1, 1, 0.5f);

    public override bool CanReceiveItem(ItemPickUp item)
    {
        return true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;

        if (ITEM != null)
            image.color = dragColor;

        if (OnBeginDragEvent != null)
            OnBeginDragEvent(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
            OnDragEvent(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
            OnDropEvent(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        if (ITEM != null)
            image.color = normalColor;

        if (OnEndDragEvent != null)
            OnEndDragEvent(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (isDragging)
        {
            OnEndDrag(null);
        }
    }
}
