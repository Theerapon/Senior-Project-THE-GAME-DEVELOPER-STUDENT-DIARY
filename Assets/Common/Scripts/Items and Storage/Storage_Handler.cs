using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Storage_Handler : Manager<Storage_Handler>
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

	[Header("Item Description")]
	[SerializeField] private GameObject item_description_gameobject;
	[SerializeField] private TMP_Text item_name;
	[SerializeField] private TMP_Text item_type;
	[SerializeField] private TMP_Text item_description;
	[SerializeField] private Image item_icon;
	private bool setItemDescription;

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


		// Pointer Enter
		inv_container_display.OnPointerEnterEvent += ShowTooltip;
		storage_container_display.OnPointerEnterEvent += ShowTooltip;
		// Pointer Exit
		inv_container_display.OnPointerExitEvent += HideTooltip;
		storage_container_display.OnPointerExitEvent += HideTooltip;
		

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

		Reset();
		draggableItem.gameObject.SetActive(false);


	}

    private void HideTooltip(BaseItemSlot itemSlot)
    {
		Reset();
	}

    private void ShowTooltip(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM != null)
		{
			SetItemDescription(itemSlot);
			setItemDescription = true;
		}
	}

    private void Reset()
    {
		item_name.text = null;
		item_description.text = null;
		item_icon.sprite = null;
		item_type.text = null;
		item_description_gameobject.SetActive(false);
		setItemDescription = false;
	}

	private void SetItemDescription(BaseItemSlot itemSlot)
	{
		item_description_gameobject.SetActive(true);

		item_name.text = itemSlot.ITEM.GetItemName();
		item_description.text = itemSlot.ITEM.GetItemDescription();
		item_icon.sprite = itemSlot.ITEM.GetItemIcon();

		if (itemSlot.ITEM.GetItemDefinitionsType().ToString() == "EQUIPMENT")
		{
			item_type.text = itemSlot.ITEM.GetItemEquipmentType().ToString();
		}
		else
		{
			item_type.text = itemSlot.ITEM.GetItemDefinitionsType().ToString();
		}
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
			if (dragItemSlot is BaseInvSlot)
			{
				if (tranferItemSlot.ITEM != null)
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
			else
			{
				//storage to inv
				if (dragItemSlot is BaseStorageSlot)
				{
					//has item
					if (tranferItemSlot.ITEM != null)
					{
						inv_container.StoreItem(dragItem, tranferIndex);
						storage_container.StoreItem(tranferItem, dragIndex);
					}
					else//hasn't item
					{
						if (storage_container.RemoveItem(dragIndex))
						{
							inv_container.StoreItem(dragItem, tranferIndex);
						}
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
