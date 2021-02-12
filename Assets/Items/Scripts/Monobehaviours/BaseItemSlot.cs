using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseItemSlot : MonoBehaviour
{
    [SerializeField] protected Image image;
    [SerializeField] protected TMP_Text amountText;


    protected Color normalColor = Color.white;
    protected Color disabledColor = new Color(1, 1, 1, 0);

    protected ItemPickUps_SO _itemPickUpSO;
    public ItemPickUps_SO ITEM
    {
        get { return _itemPickUpSO; }
        set
        {
            _itemPickUpSO = value;
            if (_itemPickUpSO == null && Amount != 0)
                Amount = 0;

            if (_itemPickUpSO == null)
            {
                image.sprite = null;
                image.color = disabledColor;
            } else
            {
                image.sprite = _itemPickUpSO.itemIcon;
                image.color = normalColor;
            }
                
        }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            if (_amount < 0) _amount = 0;
            if (_amount == 0 && ITEM != null) 
                ITEM = null;

            if (amountText != null)
            {
                amountText.enabled = _itemPickUpSO != null && _amount > 1;
                if (amountText.enabled)
                {
                    amountText.text = _amount.ToString();
                }
            }
        }
    }

    public virtual bool CanAddStack(ItemPickUps_SO item, int amount = 1)
    {
        return ITEM != null && ITEM.ID == item.ID;
    }
}
