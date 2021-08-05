using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreasureVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_SpawnItemSetID = "SpawnItemSetID";
    #endregion

    [SerializeField] private RandomBoxs_Loading randomBoxs_Loading;

    public Dictionary<string, RandomTreasure_Template> Interpert()
    {
        if (!ReferenceEquals(randomBoxs_Loading, null))
        {
            Dictionary<string, RandomTreasure_Template> randomboxDic = new Dictionary<string, RandomTreasure_Template>();

            foreach (KeyValuePair<string, string> line in randomBoxs_Loading.textLists)
            {
                RandomTreasure_Template randombox = null;
                string key = line.Key;
                string value = line.Value;

                randombox = CreateTemplate(value);

                if (!ReferenceEquals(randombox, null))
                {
                    randomboxDic.Add(key, randombox);
                }

            }
            if (!ReferenceEquals(randomboxDic, null))
            {
                return randomboxDic;
            }
        }

        return null;
    }

    private RandomTreasure_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        string spawnItemId = string.Empty;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_SpawnItemSetID:
                    spawnItemId = entries[++i];
                    break;

            }

        }

        return new RandomTreasure_Template(id, spawnItemId);
    }
}
