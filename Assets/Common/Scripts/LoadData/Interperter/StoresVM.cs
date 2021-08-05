using System.Collections.Generic;
using UnityEngine;

public class StoresVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_ItemSetOnMon = "Mon";
    private const string INST_SET_ItemSetOnTue = "Tue";
    private const string INST_SET_ItemSetOnWed = "Wed";
    private const string INST_SET_ItemSetOnThu = "Thu";
    private const string INST_SET_ItemSetOnFri = "Fri";
    private const string INST_SET_ItemSetOnSat = "Sat";
    private const string INST_SET_ItemSetOnSun = "Sun";
    private const string INST_SET_Event = "Event";
    private const string INST_SET_Default = "default";
    private const string INST_SET_StoreType = "StoreType";
    #endregion

    [SerializeField] private Stores_Loading stores_Loading;

    public Dictionary<string, Store_Template> Interpert()
    {
        if (!ReferenceEquals(stores_Loading, null))
        {
            Dictionary<string, Store_Template> storeDic = new Dictionary<string, Store_Template>();

            foreach (KeyValuePair<string, string> line in stores_Loading.textLists)
            {
                Store_Template store = null;
                string key = line.Key;
                string value = line.Value;

                store = CreateTemplate(value);

                if (!ReferenceEquals(store, null))
                {
                    storeDic.Add(key, store);
                }

            }
            if (!ReferenceEquals(storeDic, null))
            {
                return storeDic;
            }
        }

        return null;
    }

    private Store_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        List<string> storeItemSetOnMon = new List<string>();
        List<string> storeItemSetOnTue = new List<string>();
        List<string> storeItemSetOnWed = new List<string>();
        List<string> storeItemSetOnThu = new List<string>();
        List<string> storeItemSetOnFri = new List<string>();
        List<string> storeItemSetOnSat = new List<string>();
        List<string> storeItemSetOnSun = new List<string>();
        Dictionary<ScheduleEvent, string> storeItemSetOnEvent = new Dictionary<ScheduleEvent, string>();
        string defaultStoreId = string.Empty;
        StoreType storeType = StoreType.None;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_ItemSetOnMon:
                    storeItemSetOnMon.Add(entries[++i]);
                    break;
                case INST_SET_ItemSetOnTue:
                    storeItemSetOnTue.Add(entries[++i]);
                    break;
                case INST_SET_ItemSetOnWed:
                    storeItemSetOnWed.Add(entries[++i]);
                    break;
                case INST_SET_ItemSetOnThu:
                    storeItemSetOnThu.Add(entries[++i]);
                    break;
                case INST_SET_ItemSetOnFri:
                    storeItemSetOnFri.Add(entries[++i]);
                    break;
                case INST_SET_ItemSetOnSat:
                    storeItemSetOnSat.Add(entries[++i]);
                    break;
                case INST_SET_ItemSetOnSun:
                    storeItemSetOnSun.Add(entries[++i]);
                    break;
                case INST_SET_Event:
                    storeItemSetOnEvent.Add(ConvertType.CheckScheuleEvent(entries[++i]), entries[++i]);
                    break;
                case INST_SET_Default:
                    defaultStoreId = entries[++i];
                    break;
                case INST_SET_StoreType:
                    storeType = ConvertType.ConvertStoreType(entries[++i]);
                    break;

            }

        }

        return new Store_Template(id, storeItemSetOnMon, storeItemSetOnTue, storeItemSetOnWed, storeItemSetOnThu, storeItemSetOnFri, storeItemSetOnSat, storeItemSetOnSun, storeItemSetOnEvent, defaultStoreId, storeType);
    }
}
