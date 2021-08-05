using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarInvHandler : Manager<HotbarInvHandler>
{
    [SerializeField] private InvContainerDisplay inv_container_display;

    private GameObject found_player;
    private InventoryContainer inv_container;
	private GameManager _gameManager;

    [Header("Draggable Item")]
    [SerializeField] GameObject drag_gameobject;
    [SerializeField] Image draggableItem;
    private Color dragColor = new Color(1, 1, 1, 0.7f);
    private BaseItemSlot dragItemSlot;

	[Header("Gift Area")]
	[SerializeField] private GiftManager _giftManager;
	[SerializeField] private GameObject _giftAreaPark;
	[SerializeField] private BaseGiftArea _baseGiftAreaPark;
	[SerializeField] private GameObject _giftAreaShop;
	[SerializeField] private BaseGiftArea _baseGiftAreaShop;
	private string _currentNpcId;

    protected override void Awake()
    {
        base.Awake();
		_gameManager = GameManager.Instance;
		_gameManager.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
		ActiveGiftAreaShop(false);
		ActiveGiftAreaPark(false);
	}

    private void OnGameStateChangedHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.PLACE 
			&& (_gameManager.CurrentGameScene == GameManager.GameScene.Place_Park || _gameManager.CurrentGameScene == GameManager.GameScene.Place_Teacher_Home))
        {
			//if at park or teacher's home this active
			ActiveGiftAreaPark(true);
		}
		else if(current == GameManager.GameState.PLACE)
        {
			//if at place but not Park or Teacher's home this active
			ActiveGiftAreaShop(true);

		}
        else
        {
			//if not all above not active all
			ActiveGiftAreaShop(false);
			ActiveGiftAreaPark(false);
		}
	}

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

		if (_baseGiftAreaPark != null)
		{
			_baseGiftAreaPark.OnDropItemToGiftArea.AddListener(OnGift);
		}

		if (_baseGiftAreaShop != null)
		{
			_baseGiftAreaShop.OnDropItemToGiftArea.AddListener(OnGift);
		}


		draggableItem.gameObject.SetActive(false);

	}

    private void OnGift()
    {
		if (dragItemSlot == null) return;

		if (!ReferenceEquals(_giftManager, null) && !_currentNpcId.Equals(string.Empty))
		{
			//gift success
			if (_giftManager.Gift(dragItemSlot.ITEM.Id, _currentNpcId))
            {

				inv_container.Gift(dragItemSlot.INDEX);
				dragItemSlot = null;

			}
		}

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

	public void SetCurrentNpc(string id)
    {
		_currentNpcId = id;
    }

	private void ActiveGiftAreaShop(bool active)
    {
		if(_giftAreaShop.activeSelf != active)
        {
			_giftAreaShop.SetActive(active);
        }
    }

	private void ActiveGiftAreaPark(bool active)
    {
		if(_giftAreaPark.activeSelf != active)
        {
			_giftAreaPark.SetActive(active);
        }
    }
}
