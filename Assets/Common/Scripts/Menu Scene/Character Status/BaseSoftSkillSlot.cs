﻿using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseSoftSkillSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    #region Events
    public Events.EventOnPointEnterSoftSkillSlot OnPointEnterSoftSkillSlotEvent;
    public Events.EventOnPointExitSoftSkillSlot OnPointExitSoftSkillSlotEvent;
    public Events.EventOnLeftClickSoftSkillSlot OnLeftClickSoftSkillSlotEvent;
    #endregion

    [SerializeField] protected Image _border;
    [SerializeField] protected Image _select;
    [SerializeField] protected Image _image;
    [SerializeField] protected TMP_Text _level;

    private int _index;

    protected bool isPointerOver;
    protected bool isSelected;
    protected bool otherSelected;
    [SerializeField] protected CharactersSubType _characters_type;

    [SerializeField] Color borderColorLevelZero;
    [SerializeField] Color borderColorLevelUp;

    protected Color normalColor = new Color(1, 1, 1, 1);
    protected Color disabledColor = new Color(1, 1, 1, 0);
    protected Color level_Zero_Color = new Color(1, 1, 1, 0.5f);



    protected SoftSkill _softSkill;
    public SoftSkill SOFTSKILL
    {
        get { return _softSkill; }
        set
        {
            _softSkill = value;

            if (ReferenceEquals(_softSkill, null))
            {
                _image.sprite = null;
                _image.color = disabledColor;
                _border.color = borderColorLevelZero;

            }
            else
            {
                _image.sprite = _softSkill.GetIconSoftSkill();
                _level.text = _softSkill.GetCurrentSoftSkillLevel().ToString();

                if (_softSkill.GetCurrentSoftSkillLevel() <= 0)
                {
                    _image.color = level_Zero_Color;
                    _border.color = borderColorLevelZero;
                }
                else
                {
                    _image.color = normalColor;
                    _border.color = borderColorLevelUp;
                }
            }
        }
    }

    public int Index { get => _index; set => _index = value; }

    void Start()
    {
        if (_select != null)
            _select.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (!otherSelected || isSelected)
        {
            isPointerOver = true;

            if (_select != null)
            {
                _select.enabled = true;
            }

            OnPointEnterSoftSkillSlotEvent?.Invoke(this);
        }


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isPointerOver)
        {
            if (!isSelected)
            {
                isPointerOver = false;
                if (_select != null)
                    _select.enabled = false;
                OnPointExitSoftSkillSlotEvent?.Invoke(this);
            }

        }


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClickSoftSkillSlotEvent?.Invoke(this, isSelected);
        }
    }

    protected virtual void OnValidate()
    {
        if (_select == null)
            _select = transform.GetChild(0).GetComponent<Image>();

        if (_image == null)
            _image = transform.GetChild(1).GetComponent<Image>();


        if (_level == null)
            _level = transform.GetChild(4).GetComponentInChildren<TMP_Text>();

        
        _characters_type = CharactersSubType.SoftSkill;
    }

    public void SetBorderEnabled(bool actived)
    {
        _select.enabled = actived;
    }
    public void IsSelected(bool selected)
    {
        isSelected = selected;
        _select.enabled = selected;
        isPointerOver = selected;
    }
    public void SetOtherSelected(bool selected)
    {
        otherSelected = selected;
    }
}
