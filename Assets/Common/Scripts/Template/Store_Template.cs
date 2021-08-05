using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_Template : MonoBehaviour
{
    private string id;
    private StoreType _storeType;
    private List<string> _storeItemSetIdOnMon = new List<string>();
    private List<string> _storeItemSetIdOnTue = new List<string>();
    private List<string> _storeItemSetIdOnWed = new List<string>();
    private List<string> _storeItemSetIdOnThu = new List<string>();
    private List<string> _storeItemSetIdOnFri = new List<string>();
    private List<string> _storeItemSetIdOnSat = new List<string>();
    private List<string> _storeItemSetIdOnSun = new List<string>();
    private Dictionary<ScheduleEvent, string> _storeItemSetIdOnEvent = new Dictionary<ScheduleEvent, string>();
    private string _defaultStoreItemId;

    public string Id { get => id; }
    public List<string> StoreItemSetIdOnMon { get => _storeItemSetIdOnMon; }
    public List<string> StoreItemSetIdOnTue { get => _storeItemSetIdOnTue; }
    public List<string> StoreItemSetIdOnWed { get => _storeItemSetIdOnWed; }
    public List<string> StoreItemSetIdOnThu { get => _storeItemSetIdOnThu; }
    public List<string> StoreItemSetIdOnFri { get => _storeItemSetIdOnFri; }
    public List<string> StoreItemSetIdOnSat { get => _storeItemSetIdOnSat; }
    public List<string> StoreItemSetIdOnSun { get => _storeItemSetIdOnSun; }
    public Dictionary<ScheduleEvent, string> StoreItemSetIdOnEvent { get => _storeItemSetIdOnEvent; }
    public string DefaultStoreItemId { get => _defaultStoreItemId; }
    public StoreType StoreType { get => _storeType; }

    public Store_Template(string id, List<string> storeItemSetOnMon, List<string> storeItemSetOnTue, List<string> storeItemSetOnWed, List<string> storeItemSetOnThu, List<string> storeItemSetOnFri, List<string> storeItemSetOnSat, List<string> storeItemSetOnSun, Dictionary<ScheduleEvent, string> storeItemSetOnEvent, string defaultId, StoreType storeType)
    {
        this.id = id;
        this._storeItemSetIdOnMon = storeItemSetOnMon;
        this._storeItemSetIdOnTue = storeItemSetOnTue;
        this._storeItemSetIdOnWed = storeItemSetOnWed;
        this._storeItemSetIdOnThu = storeItemSetOnThu;
        this._storeItemSetIdOnFri = storeItemSetOnFri;
        this._storeItemSetIdOnSat = storeItemSetOnSat;
        this._storeItemSetIdOnSun = storeItemSetOnSun;
        this._storeItemSetIdOnEvent = storeItemSetOnEvent;
        _defaultStoreItemId = defaultId;
        this._storeType = storeType;
    }
}
