using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BagHandler : MonoBehaviour
{

    public InvContainerDisplay inv_container_display;
	public EquipContainerDisplay equip_container_display;

	private GameObject found_player;
	private InventoryContainer inv_container;
	protected EquipmentContainer equip_container;

	[Header("Draggable Item")]
	[SerializeField] GameObject drag_gameobject;
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
		found_player = GameObject.FindGameObjectWithTag("Player");
		inv_container = found_player.GetComponentInChildren<InventoryContainer>();
		equip_container = found_player.GetComponentInChildren<EquipmentContainer>();

		// Setup Events:
		// Right Click
		inv_container_display.OnRightClickEvent += InventoryRightClick;
		equip_container_display.OnRightClickEvent += EquipmentRightClick;

		// Pointer Enter
		inv_container_display.OnPointerEnterEvent += ShowTooltip;
		equip_container_display.OnPointerEnterEvent += ShowTooltip;
		// Pointer Exit
		inv_container_display.OnPointerExitEvent += HideTooltip;
		equip_container_display.OnPointerExitEvent += HideTooltip;
		

		inv_container_display.OnBeginDragEvent += BeginDrag;
		equip_container_display.OnBeginDragEvent += BeginDrag;
		// End Drag
		inv_container_display.OnEndDragEvent += EndDrag;
		equip_container_display.OnEndDragEvent += EndDrag;
		// Drag
		inv_container_display.OnDragEvent += Drag;
		equip_container_display.OnDragEvent += Drag;
		// Drop
		inv_container_display.OnDropEvent += Drop;
		equip_container_display.OnDropEvent += Drop;
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
		if(itemSlot.ITEM != null)
        {
			SetItemDescription(itemSlot);
			setItemDescription = true;
		}
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


    private void Reset()
    {
		item_name.text = null;
		item_description.text = null;
		item_icon.sprite = null;
		item_type.text = null;
		item_description_gameobject.SetActive(false);
		setItemDescription = false;
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

	}

	private void Drag(BaseItemSlot itemSlot)
    {
		draggableItem.transform.position = Input.mousePosition;

        if (!setItemDescription && itemSlot.ITEM != null)
        {
			SetItemDescription(itemSlot);
			setItemDescription = true;
		}
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
			draggableItem.sprite = itemSlot.ITEM.GetItemIcon();
			draggableItem.color = dragColor;
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.gameObject.SetActive(true);
		}
	}

    private void EquipmentRightClick(BaseItemSlot itemSlot)
    {
		if (dragItemSlot == null)
        {
			if (itemSlot.ITEM is ItemPickUp && itemSlot.ITEM.itemDefinition.GetIsEquipped())
			{
				Unequip(itemSlot);
			}

		}
			
	}

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
		if (dragItemSlot == null)
        {
			if (itemSlot.ITEM != null && itemSlot.ITEM.itemDefinition.GetIsEquipped())
			{
				Equip(itemSlot);
			}
			else if (itemSlot.ITEM != null)
			{
				Debug.Log(itemSlot.ITEM.GetItemName());
				//ItemPickUp copy = Instantiate(itemSlot.ITEM);
				//copy.itemDefinition = itemSlot.ITEM.itemDefinition; 
				//copy.UseItem();
				//display_item_container.RemoveItem(itemSlot.ITEM);
			}
		}
			

	}

    private void Equip(BaseItemSlot itemSlot)
	{
		ItemPickUp copy_item_pickup = itemSlot.ITEM; // copy item
		int copy_item_index = itemSlot.INDEX; // copy index

		//remove item from inventory
        if (inv_container.RemoveItem(itemSlot.INDEX))
        {
			ItemPickUp previousItem;
			if (equip_container.StoreItem(copy_item_pickup, out previousItem, equip_container_display.EquipItemSlots))
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

	private void Unequip(BaseItemSlot itemSlot)
	{
		ItemPickUp copy_item_pickup = itemSlot.ITEM; // copy item

		if (inv_container.CanStore() && equip_container.RemoveItem(itemSlot.INDEX))
		{
			inv_container.StoreItem(copy_item_pickup);
			copy_item_pickup.Unequip();
		}
	}
}
