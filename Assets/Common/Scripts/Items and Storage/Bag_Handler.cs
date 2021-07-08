using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bag_Handler : Manager<Bag_Handler>
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
	[SerializeField] private ItemPropertyGenerator itemPropertyGenerator;
	[SerializeField] private GameObject item_description_gameobject;
	[SerializeField] private TMP_Text item_name;
	[SerializeField] private TMP_Text item_type;
	[SerializeField] private TMP_Text item_description;
	[SerializeField] private Image item_icon;
	private bool setItemDescription;

    protected void Start()
    {
		found_player = GameObject.FindGameObjectWithTag("Player");

		if(!ReferenceEquals(found_player, null))
        {
			inv_container = found_player.GetComponentInChildren<InventoryContainer>();
			equip_container = found_player.GetComponentInChildren<EquipmentContainer>();
		}

		if(!ReferenceEquals(inv_container, null))
        {
			inv_container_display.OnLeftClickEvent.AddListener(InventoryLeftClick);
			inv_container_display.OnRightClickEvent.AddListener(InventoryRightClick);
			inv_container_display.OnPointEnterEvent.AddListener(ShowTooltip);
			inv_container_display.OnPointExitEvent.AddListener(HideTooltip);
			inv_container_display.OnBeginDragEvent.AddListener(BeginDrag);
			inv_container_display.OnEndDragEvent.AddListener(EndDrag);
			inv_container_display.OnDragEvent.AddListener(Drag);
			inv_container_display.OnDropEvent.AddListener(Drop);
		}

		if(!ReferenceEquals(equip_container, null))
		{
			equip_container_display.OnLeftClickEvent.AddListener(EquipmentUnequip);
			equip_container_display.OnRightClickEvent.AddListener(EquipmentUnequip);
			equip_container_display.OnPointEnterEvent.AddListener(ShowTooltip);
			equip_container_display.OnPointExitEvent.AddListener(HideTooltip);
			equip_container_display.OnBeginDragEvent.AddListener(BeginDrag);
			equip_container_display.OnEndDragEvent.AddListener(EndDrag);
			equip_container_display.OnDragEvent.AddListener(Drag);
			equip_container_display.OnDropEvent.AddListener(Drop);
		}


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

		item_name.text = itemSlot.ITEM.ItemName;
		item_description.text = itemSlot.ITEM.ItemDescription;
		item_icon.sprite = itemSlot.ITEM.ItemIcon;

		if (itemSlot.ITEM.ItemType == ItemDefinitionsType.Equipment)
		{
			item_type.text = itemSlot.ITEM.SubType.ToString();
		}
		else
		{
			item_type.text = itemSlot.ITEM.ItemType.ToString();
		}

		if (itemSlot.ITEM.ItemProperties.Count > 0)
		{
			for (int i = 0; i < itemSlot.ITEM.ItemProperties.Count; i++)
			{
				ItemPropertyAmount itemproperty = itemSlot.ITEM.ItemProperties[i];
				itemPropertyGenerator.CreateTemplate(itemproperty);
			}
		}
		else
		{
			itemPropertyGenerator.ClearTemplate();

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
			draggableItem.sprite = itemSlot.ITEM.ItemIcon;
			draggableItem.color = dragColor;
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.gameObject.SetActive(true);
		}
	}

	private void EquipmentUnequip(BaseItemSlot itemSlot)
    {
		if (dragItemSlot == null)
        {
			if (itemSlot.ITEM is ItemPickUp && itemSlot.ITEM.itemDefinition.IsEquipped)
			{
				Unequip(itemSlot);
			}

		}
			
	}

	private void InventoryLeftClick(BaseItemSlot itemSlot)
	{
		if(dragItemSlot == null)

		{
			if (itemSlot.ITEM != null && itemSlot.ITEM.itemDefinition.IsEquipped)
			{
				Equip(itemSlot);
			}
		}
	}

	private void InventoryRightClick(BaseItemSlot itemSlot)
    {

		if (dragItemSlot == null)
        {
			if (itemSlot.ITEM != null && itemSlot.ITEM.itemDefinition.IsEquipped)
			{
				Equip(itemSlot);
			}
			else if (itemSlot.ITEM != null && itemSlot.ITEM.IsUseable)
			{
				UseItem(itemSlot);
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

	private void UseItem(BaseItemSlot itemSlot)
    {
		int index = itemSlot.INDEX;
		itemSlot.ITEM.UseItem();
		inv_container.RemoveItem(index);
		
	}
}
