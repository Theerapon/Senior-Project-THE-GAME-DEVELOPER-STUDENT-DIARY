using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static BaseIdeaSlot;

public class BaseWorkingProjectIdeaSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    #region Events
    public Events.EventOnPointEnterWorkProjectIdeaSlot OnPointEnterIdeaSlotEvent;
    public Events.EventOnPointExitWorkProjectIdeaSlot OnPointExitIdeaSlotEvent;
    public Events.EventOnClickWorkProjectIdeaSlot OnClickWorkProjectIdeaSlot;
    #endregion

    [Header("Image")]
    [SerializeField] protected Image _bg;
    [SerializeField] protected Image _icon;
    [SerializeField] protected TMP_Text _name;
    [SerializeField] protected Image _select;

    [Header("Color")]
    [SerializeField] protected Color normalColor;
    [SerializeField] protected Color highlightColor;
    [SerializeField] protected Color selectedColor;

    protected bool isPointerOver;
    protected bool isSelected;    

    private IdeaSlot ideaSlot;
    public IdeaSlot IDEASLOT
    {
        get { return ideaSlot; }
        set
        {
            ideaSlot = value;

            if (!ReferenceEquals(ideaSlot, null))
            {
                if (ideaSlot.Collected)
                {
                    Display();
                }
            }

            if (isPointerOver)
            {
                OnPointerExit(null);
                OnPointerEnter(null);
            }


        }
    }

    private void Display()
    {
        _icon.sprite = ideaSlot.IdeaImage;
        _name.text = ideaSlot.IdeaName;
        _select.color = normalColor;

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
        isPointerOver = true;

        if (_bg != null)
        {
            _bg.color = highlightColor;
        }

        OnPointEnterIdeaSlotEvent?.Invoke(this);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        if (_bg != null)
        {
            _bg.color = normalColor;
        }

        OnPointExitIdeaSlotEvent?.Invoke(this);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null)
        {
            OnClickWorkProjectIdeaSlot?.Invoke(this);
        }
    }

    protected virtual void OnValidate()
    {
        if (_icon == null)
            _icon = transform.GetChild(1).GetComponent<Image>();

        if (_bg == null)
            _bg = transform.GetChild(0).GetComponentInChildren<Image>();

        if (_name == null)
            _name = transform.GetChild(2).GetComponentInChildren<TMP_Text>();

        if(_select == null)
            _select = transform.GetChild(3).GetComponentInChildren<Image>();
    }

    public void SelecteIdea(bool select)
    {
        isSelected = select;
        if (isSelected)
        {
            _select.color = selectedColor;
        }
        else
        {
            _select.color = normalColor;
        }
    }

    public bool GetSelectIdea()
    {
        return isSelected;
    }

}
