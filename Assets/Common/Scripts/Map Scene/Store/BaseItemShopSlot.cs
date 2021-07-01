using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BaseItemShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Events.EventOnPointEnterItemShop OnPointEnterEvent;
    public Events.EventOnPointExitItemShop OnPointExitEvent;

    [System.Serializable]
    public class ItemShop
    {
        private string _itemId;
        private int _itemAmount;
        private string _itemName;
        private int _itemSetIdIndex;
        private Sprite _itemIcon;
        private string _itemType;
        private int _itemPrice;
        private string _itemDescription;
        private List<ItemPropertyAmount> _itemProperties;

        public ItemShop(string itemId, int itemAmount, string itemName, int itemSetIdIndex, Sprite itemIcon, string itemType, int itemPrice, string itemDescription, List<ItemPropertyAmount> itemProperties)
        {
            _itemId = itemId;
            _itemAmount = itemAmount;
            _itemSetIdIndex = itemSetIdIndex;
            _itemIcon = itemIcon;
            _itemType = itemType;
            _itemPrice = itemPrice;
            _itemName = itemName;
            _itemDescription = itemDescription;
            _itemProperties = itemProperties;
        }

        public string ItemId { get => _itemId; }
        public int ItemAmount { get => _itemAmount; set => _itemAmount = value; }
        public int ItemSetIdIndex { get => _itemSetIdIndex; }
        public Sprite ItemIcon { get => _itemIcon; }
        public string ItemType { get => _itemType; }
        public int ItemPrice { get => _itemPrice; }
        public string ItemName { get => _itemName; }
        public string ItemDescription { get => _itemDescription; }
        public List<ItemPropertyAmount> ItemProperties { get => _itemProperties; }
    }

    [SerializeField] protected GameObject _template;
    [SerializeField] protected Image _itemImage;
    [SerializeField] protected TMP_Text _itemNameTMP;
    [SerializeField] protected TMP_Text _itemTypeTMP;
    [SerializeField] private TMP_Text _itemAmountTMP;
    [SerializeField] protected TMP_Text _itemPrice;
    [SerializeField] protected GameObject _button;
    
    protected bool isPointerOver;

    protected ItemShop _itemShop;
    public ItemShop ITEMSHOP
    {
        get { return _itemShop; }
        set
        {
            _itemShop = value;
            UpdateInfo();
        }
    }

    protected virtual void UpdateInfo()
    {
        if (_itemShop.ItemAmount > 0)
        {
            _itemImage.sprite = _itemShop.ItemIcon;
            _itemNameTMP.text = _itemShop.ItemName;
            _itemTypeTMP.text = _itemShop.ItemType;
            _itemAmountTMP.text = _itemShop.ItemAmount.ToString();
            _itemPrice.text = _itemShop.ItemPrice.ToString();
        }
        else
        {
            ActiveItemTemplate(false);
        }
    }

    public void Purchase()
    {
        ITEMSHOP.ItemAmount--;
        UpdateInfo();
    }

    protected virtual void ActiveItemTemplate(bool active)
    {
        if(_template.activeSelf != active)
        {
            _template.SetActive(active);
        }
    }
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
        OnPointEnterEvent?.Invoke(this);

    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        OnPointExitEvent?.Invoke(this);
    }
    protected virtual void OnValidate()
    {
        if(_template == null)
        {
            _template = this.gameObject;
            ActiveItemTemplate(true);
        }

        if(_itemImage == null)
        {
            _itemImage = _template.transform.GetChild(1).GetComponentInChildren<Image>();
        }

        if(_itemNameTMP == null)
        {
            _itemNameTMP = _template.transform.GetChild(2).GetChild(0).GetComponentInChildren<TMP_Text>();
        }

        if (_itemTypeTMP == null)
        {
            _itemTypeTMP = _template.transform.GetChild(2).GetChild(1).GetComponentInChildren<TMP_Text>();
        }

        if (_itemAmountTMP == null)
        {
            _itemAmountTMP = _template.transform.GetChild(3).GetChild(0).GetChild(0).GetComponentInChildren<TMP_Text>();
        }

        if (_itemPrice == null)
        {
            _itemPrice = _template.transform.GetChild(4).GetChild(0).GetComponentInChildren<TMP_Text>();
        }

        if (_button == null)
        {
            _button = _template.transform.GetChild(4).GetChild(1).gameObject;
        }
    }
}
