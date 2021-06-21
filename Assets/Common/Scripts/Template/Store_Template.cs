using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store_Template : MonoBehaviour
{
    private string id;
    private List<string> storeItemSetOnMon = new List<string>();
    private List<string> storeItemSetOnTue = new List<string>();
    private List<string> storeItemSetOnWed = new List<string>();
    private List<string> storeItemSetOnThu = new List<string>();
    private List<string> storeItemSetOnFri = new List<string>();
    private List<string> storeItemSetOnSat = new List<string>();
    private List<string> storeItemSetOnSun = new List<string>();
    private Dictionary<string, string> storeItemSetOnEvent = new Dictionary<string, string>();
    private string defaultStoreItemId;

    public string Id { get => id; }
    public List<string> StoreItemSetOnMon { get => storeItemSetOnMon; }
    public List<string> StoreItemSetOnTue { get => storeItemSetOnTue; }
    public List<string> StoreItemSetOnWed { get => storeItemSetOnWed; }
    public List<string> StoreItemSetOnThu { get => storeItemSetOnThu; }
    public List<string> StoreItemSetOnFri { get => storeItemSetOnFri; }
    public List<string> StoreItemSetOnSat { get => storeItemSetOnSat; }
    public List<string> StoreItemSetOnSun { get => storeItemSetOnSun; }
    public Dictionary<string, string> StoreItemSetOnEvent { get => storeItemSetOnEvent; }
    public string DefaultStoreItemId { get => defaultStoreItemId; }

    public Store_Template(string id, List<string> storeItemSetOnMon, List<string> storeItemSetOnTue, List<string> storeItemSetOnWed, List<string> storeItemSetOnThu, List<string> storeItemSetOnFri, List<string> storeItemSetOnSat, List<string> storeItemSetOnSun, Dictionary<string, string> storeItemSetOnEvent, string defaultId)
    {
        this.id = id;
        this.storeItemSetOnMon = storeItemSetOnMon;
        this.storeItemSetOnTue = storeItemSetOnTue;
        this.storeItemSetOnWed = storeItemSetOnWed;
        this.storeItemSetOnThu = storeItemSetOnThu;
        this.storeItemSetOnFri = storeItemSetOnFri;
        this.storeItemSetOnSat = storeItemSetOnSat;
        this.storeItemSetOnSun = storeItemSetOnSun;
        this.storeItemSetOnEvent = storeItemSetOnEvent;
        defaultStoreItemId = defaultId;
    }
}
