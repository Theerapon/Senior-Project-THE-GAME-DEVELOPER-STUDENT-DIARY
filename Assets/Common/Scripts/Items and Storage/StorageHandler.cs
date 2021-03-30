using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageHandler : Manager<StorageHandler>
{
    public StorageContainerDisplay storage_container_display;
    public InvContainerDisplay inv_container_display;

    private GameObject found_obj_storage;
	private GameObject found_player;
	private StorageContainer storage_container;
    private InventoryContainer inv_container;

    [SerializeField] Image draggableItem;
    private Color dragColor = new Color(1, 1, 1, 0.7f);
    private BaseItemSlot dragItemSlot;


	protected void Start()
	{
		found_obj_storage = GameObject.FindGameObjectWithTag("obj_storage");
		found_player = GameObject.FindGameObjectWithTag("Player");
		inv_container = found_player.GetComponentInChildren<InventoryContainer>();
		storage_container = found_obj_storage.GetComponentInChildren<StorageContainer>();

		// Setup Events:
		// Right Click
		inv_container_display.OnRightClickEvent += InventoryRightClick;
		storage_container_display.OnRightClickEvent += StorageRightClick;

		/*
		// Pointer Enter
		ItemContainer.OnPointerEnterEvent += ShowTooltip;
		Equipment.OnPointerEnterEvent += ShowTooltip;
		// Pointer Exit
		ItemContainer.OnPointerExitEvent += HideTooltip;
		Equipment.OnPointerExitEvent += HideTooltip;
		*/

		inv_container_display.OnBeginDragEvent += BeginDrag;
		storage_container_display.OnBeginDragEvent += BeginDrag;
		// End Drag
		inv_container_display.OnEndDragEvent += EndDrag;
		storage_container_display.OnEndDragEvent += EndDrag;
		// Drag
		inv_container_display.OnDragEvent += Drag;
		storage_container_display.OnDragEvent += Drag;
		// Drop
		inv_container_display.OnDropEvent += Drop;
		storage_container_display.OnDropEvent += Drop;
		//dropItemArea.OnDropEvent += DropItemOutsideUI;

		draggableItem.gameObject.SetActive(false);


	}

    private void StorageRightClick(BaseItemSlot itemSlot)
    {
		if (dragItemSlot == null)
        {
			ReceiveItem(itemSlot);
		}

	}

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
		if (dragItemSlot == null)
		{
			StoreItem(itemSlot);
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
		ItemPickUp dragItem = dragItemSlot.ITEM as ItemPickUp;
		int dragIndex = dragItemSlot.INDEX;

		ItemPickUp tranferItem = tranferItemSlot.ITEM as ItemPickUp;
		int tranferIndex = tranferItemSlot.INDEX;
		

		if (dragItemSlot.GetType() != tranferItemSlot.GetType())
        {
			//inv to storage
			if(dragItemSlot is BaseInvSlot)
            {
				if(tranferItemSlot.ITEM != null)
                {
					inv_container.StoreItem(tranferItem, dragIndex);
					storage_container.StoreItem(dragItem, tranferIndex);
				}
                else
                {
                    if (inv_container.RemoveItem(dragIndex))
                    {
						storage_container.StoreItem(dragItem, tranferIndex);
                    }
                }
            }

			//storage to inv
			if (dragItemSlot is BaseStorageSlot)
			{

				if (tranferItemSlot.ITEM != null)
				{
					inv_container.StoreItem(dragItem, dragIndex);
					storage_container.StoreItem(tranferItem, tranferIndex);
				}
				else
				{
					if (storage_container.RemoveItem(dragIndex))
					{
						inv_container.StoreItem(dragItem, tranferIndex);
					}
				}
			}
		}
        else
        {
			if(dragItemSlot is BaseInvSlot && dragItemSlot != null)
            {
				Debug.Log("BaseInvSlot");
				inv_container.Swap(dragIndex, tranferIndex);
			}
            
			if(dragItemSlot is BaseStorageSlot && dragItemSlot != null)
            {
				Debug.Log("BaseStorageSlot");
				storage_container.Swap(dragIndex, tranferIndex);
            }

		}
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
			draggableItem.gameObject.SetActive(true);
			draggableItem.sprite = itemSlot.ITEM.GetItemIcon();
			draggableItem.color = dragColor;
			draggableItem.transform.position = Input.mousePosition;

		}
	}

	private void StoreItem(BaseItemSlot itemSlot)
    {
		ItemPickUp copy_item_pickup = itemSlot.ITEM;

		if (storage_container.CanStore())
        {
            if (inv_container.RemoveItem(itemSlot.INDEX))
            {
				storage_container.StoreItem(copy_item_pickup);
            }
        }
        else
        {
			Debug.Log("Storage Full");
        }
    }

	private void ReceiveItem(BaseItemSlot itemSlot)
    {
		ItemPickUp copy_item_pickup = itemSlot.ITEM;

		if (inv_container.CanStore())
		{
			if (storage_container.RemoveItem(itemSlot.INDEX))
			{
				inv_container.StoreItem(copy_item_pickup);
			}
		}
		else
		{
			Debug.Log("Inventory Full");
		}
	}
    
}
