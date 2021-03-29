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

	//[SerializeField] Image draggableItem;

	private BaseItemSlot dragItemSlot;

    protected override void Awake()
    {
		base.Awake();
		//ItemContainer = InventoryContainerOld.Instance;
		//Equipment = EquipmentContainerOld.instance;
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

		// Begin Drag
		ItemContainer.OnBeginDragEvent += BeginDrag;
		Equipment.OnBeginDragEvent += BeginDrag;
		// End Drag
		ItemContainer.OnEndDragEvent += EndDrag;
		Equipment.OnEndDragEvent += EndDrag;
		// Drag
		ItemContainer.OnDragEvent += Drag;
		Equipment.OnDragEvent += Drag;
		// Drop
		ItemContainer.OnDropEvent += Drop;
		Equipment.OnDropEvent += Drop;
		//dropItemArea.OnDropEvent += DropItemOutsideUI;
		*/
	}

    private void HideTooltip(BaseItemSlot obj)
    {
        
    }

    private void ShowTooltip(BaseItemSlot obj)
    {
        
    }

    private void AddStacks(BaseItemSlot dropItemSlot)
	{
		//int numAddableStacks = dropItemSlot.ITEM.itemDefinition.GetMaxStackable() - dropItemSlot.Amount;
		//int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

		//dropItemSlot.Amount += stacksToAdd;
		//dragItemSlot.Amount -= stacksToAdd;
	}

	private void Drop(BaseItemSlot dropItemSlot)
    {
		/*
		if (dragItemSlot == null) return;

		if (dropItemSlot.CanAddStack(dragItemSlot.ITEM))
		{
			AddStacks(dropItemSlot);
		}
		else if (dropItemSlot.CanReceiveItem(dragItemSlot.ITEM) && dragItemSlot.CanReceiveItem(dropItemSlot.ITEM))
		{
			SwapItems(dropItemSlot);
		}*/
	}

	private void SwapItems(BaseItemSlot dropItemSlot)
	{
		ItemPickUp dragEquipItem = dragItemSlot.ITEM as ItemPickUp;
		ItemPickUp dropEquipItem = dropItemSlot.ITEM as ItemPickUp;

		if (dropItemSlot is BaseEquipmentSlot)
		{
			if (dragEquipItem != null) dragEquipItem.Equip(this);
			if (dropEquipItem != null) dropEquipItem.Unequip(this);
		}
		if (dragItemSlot is BaseEquipmentSlot)
		{
			if (dragEquipItem != null) dragEquipItem.Unequip(this);
			if (dropEquipItem != null) dropEquipItem.Equip(this);
		}

		ItemPickUp draggedItem = dragItemSlot.ITEM;
		//int draggedItemAmount = dragItemSlot.Amount;

		dragItemSlot.ITEM = dropItemSlot.ITEM;
		//dragItemSlot.Amount = dropItemSlot.Amount;

		dropItemSlot.ITEM = draggedItem;
		//dropItemSlot.Amount = draggedItemAmount;
	}

	private void Drag(BaseItemSlot itemSlot)
    {
		//draggableItem.transform.position = Input.mousePosition;
	}

    private void EndDrag(BaseItemSlot itemSlot)
    {
		dragItemSlot = null;
		//draggableItem.gameObject.SetActive(false);
	}

    private void BeginDrag(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM != null)
		{
			dragItemSlot = itemSlot;
			//draggableItem.sprite = itemSlot.ITEM.itemDefinition.GetItemIcon();
			//draggableItem.transform.position = Input.mousePosition;
			//draggableItem.gameObject.SetActive(true);
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
			if (equip_container.StoreItem(copy_item_pickup, out previousItem, equip_container_handler.ItemSlots))
			{
				if (previousItem != null)
				{
					inv_container.StoreItem(previousItem, copy_item_index);
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
		}
	}
}
