using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsItemsVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Item = "Item";
    #endregion

    [SerializeField] private SpawnsItems_Loading spawnsItems_Loading;

    public Dictionary<string, SpawnsItems_Template> Interpert()
    {
        if (!ReferenceEquals(spawnsItems_Loading, null))
        {
            Dictionary<string, SpawnsItems_Template> spawnsItemsDic = new Dictionary<string, SpawnsItems_Template>();

            foreach (KeyValuePair<string, string> line in spawnsItems_Loading.textLists)
            {
                SpawnsItems_Template spawnItem = null;
                string key = line.Key;
                string value = line.Value;

                spawnItem = CreateTemplate(value);

                if (!ReferenceEquals(spawnItem, null))
                {
                    spawnsItemsDic.Add(key, spawnItem);
                }

            }
            if (!ReferenceEquals(spawnsItemsDic, null))
            {
                return spawnsItemsDic;
            }
        }

        return null;
    }

    private SpawnsItems_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        List<SpawnItem> spawnItems = new List<SpawnItem>();

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
                    spawnItems.Add(new SpawnItem(entries[++i], float.Parse(entries[++i]) / 100f));
                    break;


            }

        }

        return new SpawnsItems_Template(id, spawnItems);
    }
}
