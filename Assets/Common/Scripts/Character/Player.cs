using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : Manager<Player>
{
    [Header("Public")]
    public InventoryContainerOld ItemContainer;
	public EquipmentContainerOld Equipment;

	[SerializeField] Image draggableItem;

	private BaseItemSlot dragItemSlot;

    protected override void Awake()
    {
		base.Awake();
		ItemContainer = InventoryContainerOld.Instance;
		Equipment = EquipmentContainerOld.instance;
	}

    protected void Start()
    {
		// Setup Events:
		// Right Click
		ItemContainer.OnRightClickEvent += InventoryRightClick;
		Equipment.OnRightClickEvent += EquipmentPanelRightClick;

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
	}

    private void HideTooltip(BaseItemSlot obj)
    {
        
    }

    private void ShowTooltip(BaseItemSlot obj)
    {
        
    }

    private void AddStacks(BaseItemSlot dropItemSlot)
	{
		int numAddableStacks = dropItemSlot.ITEM.itemDefinition.GetMaxStackable() - dropItemSlot.Amount;
		int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

		dropItemSlot.Amount += stacksToAdd;
		dragItemSlot.Amount -= stacksToAdd;
	}

	private void Drop(BaseItemSlot dropItemSlot)
    {
		if (dragItemSlot == null) return;

		if (dropItemSlot.CanAddStack(dragItemSlot.ITEM))
		{
			AddStacks(dropItemSlot);
		}
		else if (dropItemSlot.CanReceiveItem(dragItemSlot.ITEM) && dragItemSlot.CanReceiveItem(dropItemSlot.ITEM))
		{
			SwapItems(dropItemSlot);
		}
	}

	private void SwapItems(BaseItemSlot dropItemSlot)
	{
		ItemPickUp dragEquipItem = dragItemSlot.ITEM as ItemPickUp;
		ItemPickUp dropEquipItem = dropItemSlot.ITEM as ItemPickUp;

		if (dropItemSlot is Slot_Equipment)
		{
			if (dragEquipItem != null) dragEquipItem.Equip(this);
			if (dropEquipItem != null) dropEquipItem.Unequip(this);
		}
		if (dragItemSlot is Slot_Equipment)
		{
			if (dragEquipItem != null) dragEquipItem.Unequip(this);
			if (dropEquipItem != null) dropEquipItem.Equip(this);
		}

		ItemPickUp draggedItem = dragItemSlot.ITEM;
		int draggedItemAmount = dragItemSlot.Amount;

		dragItemSlot.ITEM = dropItemSlot.ITEM;
		dragItemSlot.Amount = dropItemSlot.Amount;

		dropItemSlot.ITEM = draggedItem;
		dropItemSlot.Amount = draggedItemAmount;
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
			draggableItem.sprite = itemSlot.ITEM.itemDefinition.GetItemIcon();
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.gameObject.SetActive(true);
		}
	}

    private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM is ItemPickUp && itemSlot.ITEM.itemDefinition.GetIsEquipped())
		{
			Unequip((ItemPickUp)itemSlot.ITEM);
		}
	}

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM != null && itemSlot.ITEM.itemDefinition.GetIsEquipped())
		{
			Equip((ItemPickUp)itemSlot.ITEM);
		} else if (itemSlot.ITEM != null && itemSlot.Amount != 0)
        {
			ItemPickUp copy = Instantiate(itemSlot.ITEM);
			copy.itemDefinition = itemSlot.ITEM.itemDefinition; 
			copy.UseItem();
			ItemContainer.RemoveItem(itemSlot.ITEM);
		}
		
	}

    public void Equip(ItemPickUp item)
	{
		if (ItemContainer.RemoveItem(item))
		{
			ItemPickUp previousItem;
			if (Equipment.AddItem(item, out previousItem))
			{
				
				if (previousItem != null)
				{
					ItemContainer.AddItem(previousItem);
					previousItem.Unequip(this);
				}
				item.Equip(this);
			}
			else
			{
				ItemContainer.AddItem(item);
			}
		}
	}

	public void Unequip(ItemPickUp item)
	{
		if (ItemContainer.CanAddItem(item) && Equipment.RemoveItem(item))
		{
			item.Unequip(this);
			ItemContainer.AddItem(item);
		}
	}
}
