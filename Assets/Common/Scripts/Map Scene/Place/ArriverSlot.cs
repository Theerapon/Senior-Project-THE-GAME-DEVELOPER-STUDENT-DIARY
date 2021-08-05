using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static PlaceEntry;

public class ArriverSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Events.EventOnPointerEnterNpcSlot OnPointerEnterNpcSlot;
    public Events.EventOnPointerExitNpcSlot OnPointerExitNpcSlot;
    public Events.EventOnPointerLeftClickNpcSlot OnPointerLeftClickNpcSlot;

    [SerializeField] private Image _npcBg;
    [SerializeField] private Image _npcIcon;

    private Color highlightColorBg = Color.white;
    private Color highlightColorIcon = Color.white;
    
    private Color selectedColorBg = new Color(0f, 0f, 0f, 0.8f);
    private Color selectedColorIcon = Color.white;


    private Color normalColorBg = new Color(1f, 1f, 1f, 0.6f);
    private Color normalColorIcon = new Color(1f, 1f, 1f, 0.6f);

    protected bool isPointerOver;
    protected bool isSelected;

    private int lastIndex;

    private Arriver _arriver;
    public Arriver ARRIVER
    {
        get { return _arriver; }
        set
        {
            _arriver = value;
            Unselected();
            if(_arriver != null && _npcIcon != null)
            {
                _npcIcon.sprite = _arriver.arriverIcon;
            }
            else
            {
                _npcIcon.sprite = null;
            }
            SetColor(true);
        }
    }

    public int LastIndex { get => lastIndex; set => lastIndex = value; }

    public void Selected()
    {
        isSelected = true;
        SetColor(false);
    }

    private void SetColor(bool _default)
    {
        if (_default)
        {
            _npcBg.color = normalColorBg;
            _npcIcon.color = normalColorIcon;
        }
        else
        {
            if (isSelected)
            {
                _npcBg.color = selectedColorBg;
                _npcIcon.color = selectedColorIcon;
            }
            else
            {
                _npcBg.color = highlightColorBg;
                _npcIcon.color = highlightColorIcon;
            }
            
        }
        
    }

    public void Unselected()
    {
        isSelected = false;
        SetColor(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;

        if (!isSelected && _npcIcon != null)
        {
            SetColor(false);
        }

        OnPointerEnterNpcSlot?.Invoke(this);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;

        if (!isSelected && _npcIcon != null)
        {
            SetColor(true);
        }

        OnPointerExitNpcSlot?.Invoke(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isSelected)
            {
                OnPointerLeftClickNpcSlot?.Invoke(this);
            }
        }
    }

    private void OnValidate()
    {
        if(_npcBg == null)
        {
            _npcBg = transform.GetChild(0).GetComponent<Image>();
        }

        if (_npcIcon == null)
        {
            _npcIcon = transform.GetChild(1).GetComponent<Image>();
        }
    }
}
