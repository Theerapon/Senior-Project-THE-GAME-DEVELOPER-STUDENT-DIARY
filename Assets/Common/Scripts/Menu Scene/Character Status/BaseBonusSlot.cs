using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseBonusSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Events.EventOnPointEnterBonusSlot OnPointEnterBonusSlotEvent;
    public Events.EventOnPointExitBonusSlot OnPointExitBonusSlotEvent;
    public Events.EventOnLeftClickBonusSlot OnLeftClickBonusSlotEvent;

    private const string INST_TITLE = "สถานะตัวละครปัจจุบัน";

    [SerializeField] protected string _Title;
    [SerializeField] protected Image _border;
    [SerializeField] protected Image _image;

    protected bool isPointerOver;
    protected bool isSelected;
    protected bool otherSelected;


    [SerializeField] protected CharactersSubType _characters_type;

    public string TITLE
    {
        get { return _Title; }
    }

    private void Start()
    {
        if(_border != null)
            _border.enabled = false;
    }

    protected virtual void OnDisable()
    {
        if (isPointerOver)
        {
            OnPointerExit(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!otherSelected || isSelected)
        {
            isPointerOver = true;

            if (_border != null)
            {
                _border.enabled = true;
            }

            OnPointEnterBonusSlotEvent?.Invoke(this);
        }



    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isPointerOver)
        {
            if (!isSelected)
            {
                isPointerOver = false;
                if (_border != null)
                    _border.enabled = false;

                OnPointExitBonusSlotEvent?.Invoke(this);
            }

        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClickBonusSlotEvent?.Invoke(this, isSelected);
        }
    }

    protected virtual void OnValidate()
    {
        if (_border == null)
            _border = transform.GetChild(0).GetComponent<Image>();

        if (_image == null)
            _image = transform.GetChild(1).GetComponent<Image>();


        _characters_type = CharactersSubType.Bonus;
        _Title = INST_TITLE;
    }

    public void SetBorderEnabled(bool actived)
    {
        _border.enabled = actived;
    }

    public void IsSelected(bool selected)
    {
        isSelected = selected;
        _border.enabled = selected;
        isPointerOver = selected;
    }
    public void SetOtherSelected(bool selected)
    {
        otherSelected = selected;
    }
}
