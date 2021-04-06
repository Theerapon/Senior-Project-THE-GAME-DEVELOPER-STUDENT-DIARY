
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public enum StatusType {None, Coding, Design, Testing, Art, Sound}
public enum CharactersSubType { Status, Bonus, HardSkill, SoftSkill}

public class BaseStatusSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Events.EventOnPointEnterStatusSlot OnPointEnterStatusSlot;
    public Events.EventOnPointExitStatusSlot OnPointExitStatusSlot;
    public Events.EventOnLeftClickStatusSlot OnLeftClickStatusSlot;

    [SerializeField] protected Image _image;
    [SerializeField] protected Image _border;
    [SerializeField] protected TMP_Text _text_value;
    [SerializeField] protected TMP_Text _text_Status_type;

    [SerializeField] protected StatusType _statusType;
    [SerializeField] protected CharactersSubType _characters_type;
    
    protected string _description;
    protected int _value;

    protected bool isPointerOver;

    private void Start()
    {
        if (_border != null)
            _border.enabled = false;
    }

    public int VALUE
    {
        get { return _value; }
        set 
        {
            _value = value;
            if(_value < 0)
            {
                _text_value.text = "0";
            }
            else
            {
                _text_value.text = value.ToString();
            }

        }
    }

    public string DESCRIPTION
    {
        get { return _description; }
        set { _description = value; }
    }
    public StatusType TYPE
    {
        get { return _statusType; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClickStatusSlot?.Invoke(this);
            Debug.Log(_statusType);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;

        if (_border != null)
            _border.enabled = true;

        OnPointEnterStatusSlot?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;

        if (_border != null)
            _border.enabled = false;

        OnPointExitStatusSlot?.Invoke(this);
    }
    protected virtual void OnDisable()
    {
        if (isPointerOver)
        {
            OnPointerExit(null);
        }
    }

    protected virtual void OnValidate()
    {
        if (_border == null)
            _border = transform.GetChild(1).GetComponent<Image>();

        if (_image == null)
            _image = transform.GetChild(0).GetComponent<Image>();

        if (_text_value == null)
            _text_value = transform.GetChild(2).GetComponent<TMP_Text>();

        if (_text_Status_type == null)
            _text_Status_type = transform.GetChild(3).GetComponentInChildren<TMP_Text>();

        _characters_type = CharactersSubType.Status;
        _text_Status_type.text = _statusType.ToString();
        //ITEM = _itemPickUp;
    }
}
