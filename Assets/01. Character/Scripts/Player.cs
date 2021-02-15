using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Public")]
    public CharacterInventory Inventory;
	public EquipmentPanel Equipment;

	[SerializeField] Image draggableItem;

	private BaseItemSlot dragItemSlot;

	private void Start()
    {
        Inventory = CharacterInventory.instance;
		Equipment = EquipmentPanel.instance;


		// Setup Events:
		// Right Click
		Inventory.OnRightClickEvent += InventoryRightClick;
		Equipment.OnRightClickEvent += EquipmentPanelRightClick;

		// Pointer Enter
		Inventory.OnPointerEnterEvent += ShowTooltip;
		Equipment.OnPointerEnterEvent += ShowTooltip;
		// Pointer Exit
		Inventory.OnPointerExitEvent += HideTooltip;
		Equipment.OnPointerExitEvent += HideTooltip;

		// Begin Drag
		Inventory.OnBeginDragEvent += BeginDrag;
		Equipment.OnBeginDragEvent += BeginDrag;
		// End Drag
		Inventory.OnEndDragEvent += EndDrag;
		Equipment.OnEndDragEvent += EndDrag;
		// Drag
		Inventory.OnDragEvent += Drag;
		Equipment.OnDragEvent += Drag;
		// Drop
		Inventory.OnDropEvent += Drop;
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
		int numAddableStacks = dropItemSlot.ITEM.itemDefinition.MaximumStacks - dropItemSlot.Amount;
		int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

		dropItemSlot.Amount += stacksToAdd;
		dragItemSlot.Amount -= stacksToAdd;
	}

	private void Drop(BaseItemSlot dropItemSlot)
    {
		Debug.Log("Drop");
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
		Debug.Log("SwapItems");
		ItemPickUp dragEquipItem = dragItemSlot.ITEM as ItemPickUp;
		ItemPickUp dropEquipItem = dropItemSlot.ITEM as ItemPickUp;

		if (dropItemSlot is EquipmentSlot)
		{
			if (dragEquipItem != null) dragEquipItem.Equip(this);
			if (dropEquipItem != null) dropEquipItem.Unequip(this);
		}
		if (dragItemSlot is EquipmentSlot)
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
		Debug.Log("Drag");
		draggableItem.transform.position = Input.mousePosition;
	}

    private void EndDrag(BaseItemSlot itemSlot)
    {
		Debug.Log("EndDrag");
		dragItemSlot = null;
		draggableItem.gameObject.SetActive(false);
	}

    private void BeginDrag(BaseItemSlot itemSlot)
    {
		Debug.Log("BeginDrag");
		if (itemSlot.ITEM != null)
		{
			dragItemSlot = itemSlot;
			draggableItem.sprite = itemSlot.ITEM.itemDefinition.itemIcon;
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.gameObject.SetActive(true);
		}
	}

    private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM is ItemPickUp && itemSlot.ITEM.itemDefinition.isEquipped)
		{
			Unequip((ItemPickUp)itemSlot.ITEM);
		}
	}

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
		if (itemSlot.ITEM != null && itemSlot.ITEM.itemDefinition.isEquipped)
		{
			Equip((ItemPickUp)itemSlot.ITEM);
		} else if (itemSlot.ITEM != null && itemSlot.Amount != 0)
        {
			Instantiate(itemSlot.ITEM).UseItem();
			Inventory.RemoveItem(itemSlot.ITEM);
        }
		
	}

    public void Equip(ItemPickUp item)
	{
		if (Inventory.RemoveItem(item))
		{
			ItemPickUp previousItem;
			if (Equipment.AddItem(item, out previousItem))
			{
				
				if (previousItem != null)
				{
					Inventory.AddItem(previousItem);
					previousItem.Unequip(this);
				}
				item.Equip(this);
			}
			else
			{
				Inventory.AddItem(item);
			}
		}
	}

	public void Unequip(ItemPickUp item)
	{
		if (Inventory.CanAddItem(item) && Equipment.RemoveItem(item))
		{
			item.Unequip(this);
			Inventory.AddItem(item);
		}
	}
}
