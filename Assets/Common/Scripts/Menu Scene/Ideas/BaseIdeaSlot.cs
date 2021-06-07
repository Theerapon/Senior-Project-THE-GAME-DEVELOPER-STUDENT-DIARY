using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseIdeaSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Events
    public Events.EventOnPointEnterIdeaSlot OnPointEnterIdeaSlotEvent;
    public Events.EventOnPointExitIdeaSlot OnPointExitIdeaSlotEvent;
    #endregion

    [SerializeField] protected Image _border;
    [SerializeField] protected Image _uncollected;
    [SerializeField] protected Image _image;

    protected Color normalColor = Color.white;
    protected Color disabledColor = new Color(1, 1, 1, 0);

    protected bool isPointerOver;

    [System.Serializable]
    public class IdeaSlot
    {
        private string id;
        private IdeaType ideaType;
        private Sprite ideaImage;
        private string ideaName;
        private string description;
        private bool collected;

        public string Id { get => id; }
        public IdeaType IdeaType { get => ideaType; }
        public Sprite IdeaImage { get => ideaImage; }
        public string IdeaName { get => ideaName; }
        public string Description { get => description; }
        public bool Collected { get => collected; }

        public IdeaSlot(string id, IdeaType ideaType, Sprite ideaImage, string ideaName, string description, bool collected)
        {
            this.id = id;
            this.ideaType = ideaType;
            this.ideaImage = ideaImage;
            this.ideaName = ideaName;
            this.description = description;
            this.collected = collected;
        }

        public IdeaSlot(string id, IdeaType ideaType, string ideaName, bool collected)
        {
            this.id = id;
            this.ideaType = ideaType;
            this.ideaImage = null;
            this.ideaName = ideaName;
            this.description = null;
            this.collected = collected;
        }

        
    }

    private IdeaSlot ideaSlot;
    public IdeaSlot IDEASLOT
    {
        get { return ideaSlot; }
        set
        {
            ideaSlot = value;

            if (ReferenceEquals(ideaSlot, null))
            {
                UnDisplay();
            }
            else
            {
                if (ideaSlot.Collected)
                {
                    Display();
                    Debug.Log("sdfsdf");
                }
                else
                {
                    UnDisplay();
                }
                
            }

            if (isPointerOver)
            {
                OnPointerExit(null);
                OnPointerEnter(null);
            }

        }
    }

    private void UnDisplay()
    {
        if (_image != null)
        {
            _image.color = disabledColor;
            _image.enabled = false;
            _image.sprite = null;
        }

        if (_uncollected != null)
        {
            _uncollected.enabled = true;
        }
        if (_border != null)
        {
            _border.enabled = false;
        }
    }

    private void Display()
    {
        if (_uncollected != null)
        {
            _uncollected.enabled = false;
        }

        if (_image != null)
        {
            _image.enabled = true;
            _image.sprite = ideaSlot.IdeaImage;
            _image.color = normalColor;
        }
    }

    private void Start()
    {
        if (_border != null)
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
        isPointerOver = true;

        if (_border != null)
        {
            _border.enabled = true;
        }

        OnPointEnterIdeaSlotEvent?.Invoke(this);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
        if (_border != null)
            _border.enabled = false;

        OnPointExitIdeaSlotEvent?.Invoke(this);

    }


    protected virtual void OnValidate()
    {
        if (_uncollected == null)
            _uncollected = transform.GetChild(0).GetComponent<Image>();

        if (_image == null)
            _image = transform.GetChild(1).GetComponent<Image>();

        if (_border == null)
            _border = transform.GetChild(2).GetComponent<Image>();
    }
}
