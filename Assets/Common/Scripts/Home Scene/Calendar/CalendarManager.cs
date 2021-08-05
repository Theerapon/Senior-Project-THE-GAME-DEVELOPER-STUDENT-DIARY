using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static BaseEventSlot;

public class CalendarManager : MonoBehaviour
{
    private ScheduleController scheduleController;
    Schedule[] characterCalendar = null;
    private int _currentDay;
    private int _currentMount;

    [SerializeField] private GameObject _nameEventGameObject;
    [SerializeField] private TMP_Text _nameEventTMP;
    [SerializeField] private TMP_Text _mountTMP;

    [SerializeField] private Transform itemsParent;
    private List<BaseDaySlot> baseDaySlots;

    [Header("default color event")]
    [SerializeField] private Color _foodColor;
    [SerializeField] private Color _classActicityColor;
    [SerializeField] private Color _clothingColor;
    [SerializeField] private Color _mysticColor;
    [SerializeField] private Color _birthDayColor;

    private void Awake()
    {
        scheduleController = ScheduleController.Instance;
        baseDaySlots = new List<BaseDaySlot>();
    }

    private void Start()
    {
        ActiveEventName(false);

        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: baseDaySlots);

        for (int j = 0; j < baseDaySlots.Count; j++)
        {
            baseDaySlots[j].OnPointEnterEventSlot.AddListener(OnPointEnterEventSlotHandler);
            baseDaySlots[j].OnPointExitEventSlot.AddListener(OnPointExitEventSlotHandler);
        }

        //0-27
        //28-55
        //56-83
        //84-111
        //index = (วัน - 1) + (28 * (เดือน - 1))
        //start index = 28 * (mount - 1)
        characterCalendar = scheduleController.GameCalendar;
        int index = scheduleController.GetIndexCurrentDay();
        _currentMount = (index / 28) + 1; // 1 2 3 4 > 0 1 2 3
        _currentDay = (index - (28 * (_currentMount - 1))) + 1; //1-28 
        int startIndex = 28 * (_currentMount - 1);
        int endIndex = startIndex + 28;

        
        int count = 0;
        for(int i = startIndex; i < endIndex; i++)
        {
            List<EventSlotInfo> eventSlotInfos = new List<EventSlotInfo>();
            List<Schedule_Template> schedules = new List<Schedule_Template>();
            schedules = characterCalendar[i].Schedules;
            
            for (int k = 0; k < schedules.Count; k++)
            {
                string _name = schedules[k].ScheduleName;
                ScheduleEvent _event = schedules[k].ScheduleEvents;
                Color _color = GetColorBySchedule(_event);
                eventSlotInfos.Add(new EventSlotInfo(_name, _event, _color));
            }

            baseDaySlots[count].Initializing(eventSlotInfos);
            
            if(i == index)
            {
                baseDaySlots[count].SetBackgroundForIsDay(true);
            }
            else
            {
                baseDaySlots[count].SetBackgroundForIsDay(false);
            }

            count++;
        }

        _mountTMP.text = TimeManager.Instance.CurrentMonth.ToString();

    }

    private void OnPointExitEventSlotHandler(BaseEventSlot slot)
    {
        ActiveEventName(false);
    }

    private void OnPointEnterEventSlotHandler(BaseEventSlot slot)
    {
        ActiveEventName(true);
        _nameEventTMP.text = slot.EVENTSLOT.EventName;
    }

    private void ActiveEventName(bool active)
    {
        if(_nameEventGameObject.activeSelf != active)
        {
            _nameEventGameObject.SetActive(active);
        }
    }

    private Color GetColorBySchedule(ScheduleEvent scheduleEvent)
    {
        Color color = Color.white;
        switch (scheduleEvent)
        {
            case ScheduleEvent.Project:
                color = _classActicityColor;
                break;
            case ScheduleEvent.Class:
                color = _classActicityColor;
                break;
            case ScheduleEvent.Birthday:
                color = _birthDayColor;
                break;
            case ScheduleEvent.ClothingFestival101:
                color = _clothingColor;
                break;
            case ScheduleEvent.ClothingFestival202:
                color = _clothingColor;
                break;
            case ScheduleEvent.ClothingFestival303:
                color = _clothingColor;
                break;
            case ScheduleEvent.ClothingFestival404:
                color = _clothingColor;
                break;
            case ScheduleEvent.DiscountFoodStore:
                color = _foodColor;
                break;
            case ScheduleEvent.MysticFestival1st:
                color = _mysticColor;
                break;
            case ScheduleEvent.MysticFestival2nd:
                color = _mysticColor;
                break;
            case ScheduleEvent.MysticFestival3rd:
                color = _mysticColor;
                break;
            case ScheduleEvent.MysticFestival4th:
                color = _mysticColor;
                break;


        }

        return color;
    }

    public void CloseCalendar()
    {
        SwitchScene.Instance.DispleyCalendar(false);
    }
}
