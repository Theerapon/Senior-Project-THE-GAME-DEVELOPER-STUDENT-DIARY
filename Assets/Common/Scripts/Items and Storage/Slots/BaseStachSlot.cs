using UnityEngine;
using UnityEngine.EventSystems;

public class BaseStachSlot : BaseItemSlot, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public Events.EventOnBeginDrag OnBeginDragEvent;
    public Events.EventOnEndDrag OnEndDragEvent;
    public Events.EventOnDrag OnDragEvent;
    public Events.EventOnDrop OnDropEvent;

    protected bool isDragging;
    protected Color dragColor = new Color(1, 1, 1, 0.5f);


    public override bool CanReceiveItem(ItemPickUp item)
    {
        return true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;

        if (ITEM != null)
            image.color = dragColor;

        OnBeginDragEvent?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnDropEvent?.Invoke(this);


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        if (ITEM != null)
            image.color = normalColor;

        OnEndDragEvent?.Invoke(this);

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
