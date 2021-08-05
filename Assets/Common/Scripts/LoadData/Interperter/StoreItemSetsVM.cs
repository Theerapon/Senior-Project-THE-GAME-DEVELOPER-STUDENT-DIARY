using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItemSetsVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Item = "Item";
    #endregion

    [SerializeField] private StoreItemSets_Loading storeItemSets_Loading;

    public Dictionary<string, StoreItemSets_Template> Interpert()
    {
        if (!ReferenceEquals(storeItemSets_Loading, null))
        {
            Dictionary<string, StoreItemSets_Template> storeItemSetDic = new Dictionary<string, StoreItemSets_Template>();

            foreach (KeyValuePair<string, string> line in storeItemSets_Loading.textLists)
            {
                StoreItemSets_Template storeItemSet = null;
                string key = line.Key;
                string value = line.Value;

                storeItemSet = CreateTemplate(value);

                if (!ReferenceEquals(storeItemSet, null))
                {
                    storeItemSetDic.Add(key, storeItemSet);
                }

            }
            if (!ReferenceEquals(storeItemSetDic, null))
            {
                return storeItemSetDic;
            }
        }

        return null;
    }

    private StoreItemSets_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        List<StoreItemSet> storeItemSets = new List<StoreItemSet>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_Item:
                    storeItemSets.Add(new StoreItemSet(entries[++i], int.Parse(entries[++i])));
                    break;

            }

        }

        return new StoreItemSets_Template(id, storeItemSets);
    }
}
