using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarInvHandler : MonoBehaviour
{
    [SerializeField] private InvContainerDisplay inv_container_display;

    private GameObject found_player;
    private InventoryContainer inv_container;

    [Header("Draggable Item")]
    [SerializeField] GameObject drag_gameobject;
    [SerializeField] Image draggableItem;
    private Color dragColor = new Color(1, 1, 1, 0.7f);
    private BaseItemSlot dragItemSlot;

	protected void Start()
	{
		found_player = GameObject.FindGameObjectWithTag("Player");

		if (!ReferenceEquals(found_player, null))
		{
			inv_container = found_player.GetComponentInChildren<InventoryContainer>();
		}

		if (!ReferenceEquals(inv_container, null))
		{

			inv_container_display.OnRightClickEvent.AddListener(RightClickHandler);
			inv_container_display.OnBeginDragEvent.AddListener(BeginDrag);
			inv_container_display.OnEndDragEvent.AddListener(EndDrag);
			inv_container_display.OnDragEvent.AddListener(Drag);
			inv_container_display.OnDropEvent.AddListener(Drop);
		}

		draggableItem.gameObject.SetActive(false);

	}

    private void RightClickHandler(BaseItemSlot itemSlot)
    {
		if (dragItemSlot == null)
		{
			if (itemSlot.ITEM != null && itemSlot.ITEM.IsUseable)
			{
				UseItem(itemSlot);
			}
		}
	}

    private void Drop(BaseItemSlot tranferItemSlot)
	{
		if (dragItemSlot == null) return;

		if (tranferItemSlot.CanReceiveItem(dragItemSlot.ITEM) && dragItemSlot.CanReceiveItem(tranferItemSlot.ITEM))
		{
			SwapItems(tranferItemSlot);
		}
	}
	private void SwapItems(BaseItemSlot tranferItemSlot)
	{
		int dragIndex = dragItemSlot.INDEX;
		int tranferIndex = tranferItemSlot.INDEX;

		inv_container.Swap(dragIndex, tranferIndex);

	}
	private void Drag(BaseItemSlot itemSlot)
	{
		draggableItem.transform.position = Input.mousePosition;
	}
	private void EndDrag(BaseItemSlot itemSlot)
	{
		dragItemSlot = null;
		draggableItem.gameObject.SetActive(false);
	}
	private void BeginDrag(BaseItemSlot itemSlot)
	{
		if (itemSlot.ITEM != null)
		{
			dragItemSlot = itemSlot;
			draggableItem.sprite = itemSlot.ITEM.ItemIcon;
			draggableItem.color = dragColor;
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.gameObject.SetActive(true);
		}
	}
	private void UseItem(BaseItemSlot itemSlot)
	{
		int index = itemSlot.INDEX;
		itemSlot.ITEM.UseItem();
		inv_container.RemoveItem(index);
	}
}
