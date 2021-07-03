using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private const float _normalDiscount = 1f;
    private const float _eventDiscount = 0.7f;

    private StoreContoller _storeContoller;

    private Store_Template _definition;
    private bool _isEvent;
    private ScheduleEvent _scheduleEvent;
    private string _currentStoreItemSetId;
    private List<StoreItemSet> _currentItemSet;
    private float _discount;
    public Store(Store_Template store_Template)
    {
        _storeContoller = StoreContoller.Instance;
        _currentItemSet = new List<StoreItemSet>();

        _definition = store_Template;
        _isEvent = false;
        _scheduleEvent = ScheduleEvent.None;
        _currentStoreItemSetId = _definition.DefaultStoreItemId;
    }

    public string Id { get => _definition.Id; }
    public StoreType StoreType { get => _definition.StoreType; }
    public bool IsEvent { get => _isEvent; }
    public List<StoreItemSet> CurrentItemSet { get => _currentItemSet; }
    public float Discount { get => _discount; }

    public void EnableEvent(ScheduleEvent scheduleEvent)
    {
        _isEvent = true;
        _scheduleEvent = scheduleEvent;
    }
    public void DisableEvent()
    {
        _isEvent = false;
        _scheduleEvent = ScheduleEvent.None;
    }
    public void SetDiscount()
    {
        if(_isEvent && StoreType == StoreType.FoodStore)
        {
            _discount = _eventDiscount;
        }
        else
        {
            _discount = _normalDiscount;
        }
    }
    public void SetUpStoreOnNewDay(Day day)
    {
        SetStoreItem(day);
    }
    private void SetStoreItem(Day day)
    {
        _currentStoreItemSetId = _definition.DefaultStoreItemId;
        StoreType _storeType = StoreType;

        //mystic store item chance on event
        if ((_storeType == StoreType.MysticStore || _storeType == StoreType.ClothingStore) && _isEvent)
        {
            _currentStoreItemSetId = _definition.StoreItemSetIdOnEvent[_scheduleEvent];
        }
        else
        {
            //normal day
            switch (day)
            {
                case Day.Mon:
                    List<string> storeItemSetIdMon = _definition.StoreItemSetIdOnMon;
                    _currentStoreItemSetId = RandomStoreItemId(storeItemSetIdMon);
                    break;
                case Day.Tue:
                    List<string> storeItemSetIdTue = _definition.StoreItemSetIdOnTue;
                    _currentStoreItemSetId = RandomStoreItemId(storeItemSetIdTue);
                    break;
                case Day.Wed:
                    List<string> storeItemSetIdWed = _definition.StoreItemSetIdOnWed;
                    _currentStoreItemSetId = RandomStoreItemId(storeItemSetIdWed);
                    break;
                case Day.Thu:
                    List<string> storeItemSetIdThu = _definition.StoreItemSetIdOnThu;
                    _currentStoreItemSetId = RandomStoreItemId(storeItemSetIdThu);
                    break;
                case Day.Fri:
                    List<string> storeItemSetIdFri = _definition.StoreItemSetIdOnFri;
                    _currentStoreItemSetId = RandomStoreItemId(storeItemSetIdFri);
                    break;
                case Day.Sat:
                    List<string> storeItemSetIdSat = _definition.StoreItemSetIdOnSat;
                    _currentStoreItemSetId = RandomStoreItemId(storeItemSetIdSat);
                    break;
                case Day.Sun:
                    List<string> storeItemSetIdSun = _definition.StoreItemSetIdOnSun;
                    _currentStoreItemSetId = RandomStoreItemId(storeItemSetIdSun);
                    break;
                default:
                    _currentStoreItemSetId = _definition.DefaultStoreItemId;
                    break;
            }
        }

        List<StoreItemSet> copy = _storeContoller.StoreItemSetDic[_currentStoreItemSetId].StoreItemSets;
        _currentItemSet.Clear();
        for (int i = 0; i < _storeContoller.StoreItemSetDic[_currentStoreItemSetId].StoreItemSets.Count; i++)
        {
            _currentItemSet.Add(new StoreItemSet(copy[i].ItemId, copy[i].AmountItem));
        }
    }
    private string RandomStoreItemId(List<string> storeItemSetId)
    {
        if (storeItemSetId.Count > 0)
        {
            int rndIndex = Random.Range(0, storeItemSetId.Count); 
            return storeItemSetId[rndIndex];
        }
        else
        {
            return _definition.DefaultStoreItemId;
        }
        
    }
    
    public void Purchase(int index)
    {
        CurrentItemSet[index].Purchasse();
    }
}
