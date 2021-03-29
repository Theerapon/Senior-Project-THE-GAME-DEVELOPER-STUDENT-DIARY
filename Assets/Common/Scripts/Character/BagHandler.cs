using System;
using UnityEngine;
using UnityEngine.UI;

public class BagHandler : Manager<BagHandler>
{
    //[Header("Public")]
    public InvContainerHandler inv_container_handler;
	public EquipContainerHandler equip_container_handler;

	private GameObject found_player;
	private InventoryContainer inv_container;
	protected EquipmentContainer equip_container;

	[SerializeField] Image draggableItem;

	private Color dragColor = new Color(1, 1, 1, 0.7f);
	private BaseItemSlot dragItemSlot;

    protected override void Awake()
    {
		base.Awake();
	}

    protected void Start()
    {
		found_player = GameObject.FindGameObjectWithTag("Player");
		inv_container = found_player.GetComponentInChildren<InventoryContainer>();
		equip_container = found_player.GetComponentInChildren<EquipmentContainer>();

		// Setup Events:
		// Right Click
		inv_container_handler.OnRightClickEvent += InventoryRightClick;
		equip_container_handler.OnRightClickEvent += EquipmentRightClick;

		/*
		// Pointer Enter
		ItemContainer.OnPointerEnterEvent += ShowTooltip;
		Equipment.OnPointerEnterEvent += ShowTooltip;
		// Pointer Exit
		ItemContainer.OnPointerExitEvent += HideTooltip;
		Equipment.OnPointerExitEvent += HideTooltip;
		*/

		inv_container_handler.OnBeginDragEvent += BeginDrag;
		equip_container_handler.OnBeginDragEvent += BeginDrag;
		// End Drag
		inv_container_handler.OnEndDragEvent += EndDrag;
		equip_container_handler.OnEndDragEvent += EndDrag;
		// Drag
		inv_container_handler.OnDragEvent += Drag;
		equip_container_handler.OnDragEvent += Drag;
		// Drop
		inv_container_handler.OnDropEvent += Drop;
		equip_container_handler.OnDropEvent += Drop;
		//dropItemArea.OnDropEvent += DropItemOutsideUI;

		draggableItem.gameObject.SetActive(false);


	}

    private void HideTooltip(BaseItemSlot obj)
    {
        
    }

    private void ShowTooltip(BaseItemSlot obj)
    {
        
    }

	private void Drop(BaseItemSlot tranferItemSlot)
    {
		Debug.Log("dragItemslot == null");
		if (dragItemSlot == null) return;

		Debug.Log("swap");
		if (tranferItemSlot.CanReceiveItem(dragItemSlot.ITEM) && dragItemSlot.CanReceiveItem(tranferItemSlot.ITEM))
		{
			Debug.Log("swap");
			SwapItems(tranferItemSlot);
		}
	}

	private void SwapItems(BaseItemSlot tranferItemSlot)
	{
		ItemPickUp dragItem = dragItemSlot.ITEM as ItemPickUp;
		int dragIndex = dragItemSlot.INDEX;

		ItemPickUp tranferItem = tranferItemSlot.ITEM as ItemPickUp;
		int tranferIndex = tranferItemSlot.INDEX;

		//swap between Equipment and Inventory
		if(dragItemSlot is BaseEquipmentSlot || tranferItemSlot is BaseEquipmentSlot)
        {
			//swap from inventory to equipment
			if (tranferItemSlot is BaseEquipmentSlot)
			{
				if (dragItem != null) dragItem.Equip();
				if (tranferItem != null) tranferItem.Unequip();
				Equip(dragItemSlot);
			}

			//swap from equipment to inventory
			if (dragItemSlot is BaseEquipmentSlot && tranferItemSlot.ITEM != null) //inventory is not null
			{
				if (dragItem != null) dragItem.Unequip();
				if (tranferItem != null) tranferItem.Equip();
				Equip(tranferItemSlot);
            }
			else if (dragItemSlot is BaseEquipmentSlot && tranferItemSlot.ITEM == null) //inventory is null
            {
				if (dragItem != null) dragItem.Unequip();
				inv_container.StoreItem(dragItem, tranferIndex);
				equip_container.RemoveItem(dragIndex);
			}

        }
        else //swap in inventory
        {
			inv_container.Swap(dragIndex, tranferIndex);
        }

		//ItemPickUp draggedItem = dragItemSlot.ITEM;

		//dragItemSlot.ITEM = dropItemSlot.ITEM;

		//dropItemSlot.ITEM = draggedItem;
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

    private void EquipmentRightClick(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM is ItemPickUp && itemSlot.ITEM.itemDefinition.GetIsEquipped())
		{
			Unequip(itemSlot);
		}
	}

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM != null && itemSlot.ITEM.itemDefinition.GetIsEquipped())
		{
			Equip(itemSlot);
		} else if (itemSlot.ITEM != null)
        {
			Debug.Log(itemSlot.ITEM.GetItemName());
			//ItemPickUp copy = Instantiate(itemSlot.ITEM);
			//copy.itemDefinition = itemSlot.ITEM.itemDefinition; 
			//copy.UseItem();
			//display_item_container.RemoveItem(itemSlot.ITEM);
		}
		
	}

    public void Equip(BaseItemSlot itemSlot)
	{
		ItemPickUp copy_item_pickup = itemSlot.ITEM; // copy item
		int copy_item_index = itemSlot.INDEX; // copy index

		//remove item from inventory
        if (inv_container.RemoveItem(itemSlot.INDEX))
        {
			ItemPickUp previousItem;
			if (equip_container.StoreItem(copy_item_pickup, out previousItem, equip_container_handler.EquipItemSlots))
			{
				copy_item_pickup.Equip();
				if (previousItem != null)
				{
					inv_container.StoreItem(previousItem, copy_item_index);
					previousItem.Unequip();
				}
			}
		}
	}

	public void Unequip(BaseItemSlot itemSlot)
	{
		ItemPickUp copy_item_pickup = itemSlot.ITEM; // copy item

		if (inv_container.CanStore() && equip_container.RemoveItem(itemSlot.INDEX))
		{
			inv_container.StoreItem(copy_item_pickup);
			copy_item_pickup.Unequip();
		}
	}
}
