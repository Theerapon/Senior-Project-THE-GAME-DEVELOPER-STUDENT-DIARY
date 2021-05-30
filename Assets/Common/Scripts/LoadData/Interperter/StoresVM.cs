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
        string[] storeItemSetIdPerDay = new string[7];

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
                    storeItemSetIdPerDay[0] = entries[++i];
                    break;
                case INST_SET_ItemSetOnTue:
                    storeItemSetIdPerDay[1] = entries[++i];
                    break;
                case INST_SET_ItemSetOnWed:
                    storeItemSetIdPerDay[2] = entries[++i];
                    break;
                case INST_SET_ItemSetOnThu:
                    storeItemSetIdPerDay[3] = entries[++i];
                    break;
                case INST_SET_ItemSetOnFri:
                    storeItemSetIdPerDay[4] = entries[++i];
                    break;
                case INST_SET_ItemSetOnSat:
                    storeItemSetIdPerDay[5] = entries[++i];
                    break;
                case INST_SET_ItemSetOnSun:
                    storeItemSetIdPerDay[6] = entries[++i];
                    break;

            }

        }

        return new Store_Template(id, storeItemSetIdPerDay);
    }
}
