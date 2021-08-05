using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BaseEventSlot;

public class BaseDaySlot : MonoBehaviour
{
    public Events.EventOnPointEnterEventSlot OnPointEnterEventSlot;
    public Events.EventOnPointExitEventSlot OnPointExitEventSlot;

    [SerializeField] private EventSlotGenerator _eventSlotGenerator;

    [SerializeField] private Image _image;
    [Header("Color")]
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _dayColor;

    [SerializeField] private Transform itemsParent;
    private List<BaseEventSlot> baseEventSlots;

    private void Awake()
    {
        baseEventSlots = new List<BaseEventSlot>();
    }

    public void Initializing(List<EventSlotInfo> eventSlotInfos)
    {
        _eventSlotGenerator.CreateEventSlotGenerator(eventSlotInfos);

        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: baseEventSlots);

        for (int index = 0; index < baseEventSlots.Count; index++)
        {
            baseEventSlots[index].OnPointEnterEventSlot.AddListener(OnPointEnterEventSlotHandler);
            baseEventSlots[index].OnPointExitEventSlot.AddListener(OnPointExitEventSlotHandler);
        }
    }

    public void SetBackgroundForIsDay(bool isDay)
    {
        if (isDay)
        {
            _image.color = _dayColor;
        }
        else
        {
            _image.color = _normalColor;
        }
    }

    private void OnPointExitEventSlotHandler(BaseEventSlot slot)
    {
        OnPointExitEventSlot?.Invoke(slot);
    }

    private void OnPointEnterEventSlotHandler(BaseEventSlot slot)
    {
        OnPointEnterEventSlot?.Invoke(slot);        
    }

    private void OnValidate()
    {
        if(_eventSlotGenerator == null)
        {
            _eventSlotGenerator = transform.GetComponentInChildren<EventSlotGenerator>();
        }

        if(itemsParent == null)
        {
            itemsParent = transform.GetChild(2).transform;
        }

        if(_image == null)
        {
            _image = transform.GetChild(0).GetComponent<Image>();
        }
    }
}
