using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseEventSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Events.EventOnPointEnterEventSlot OnPointEnterEventSlot;
    public Events.EventOnPointExitEventSlot OnPointExitEventSlot;

    [System.Serializable]
    public class EventSlotInfo
    {
        private string _eventName;
        private ScheduleEvent scheduleEvent;
        private Color _nomalColor;

        public EventSlotInfo(string eventName, ScheduleEvent scheduleEvent, Color color)
        {
            _eventName = eventName;
            this.scheduleEvent = scheduleEvent;
            _nomalColor = color;
        }

        public string EventName { get => _eventName; }
        public ScheduleEvent ScheduleEvent { get => scheduleEvent; }
        public Color NomalColor { get => _nomalColor; }
    }

    [SerializeField] private Image _image;

    protected bool isPointerOver;


    public EventSlotInfo _eventSlotInfo;

    public EventSlotInfo EVENTSLOT
    {
        get { return _eventSlotInfo; }
        set 
        {
            _eventSlotInfo = value;
            _image.color = _eventSlotInfo.NomalColor;
        }
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

        if(_image != null)
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0.3f);
        }

        OnPointEnterEventSlot?.Invoke(this);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;

        if (_image != null)
        {
            _image.color = _eventSlotInfo.NomalColor;
        }

        OnPointExitEventSlot?.Invoke(this);
    }
}
