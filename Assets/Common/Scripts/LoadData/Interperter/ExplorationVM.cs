using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_DefaultLocked = "DefaultLocked";
    private const string INST_SET_MaxLevel = "MaxLevel";
    private const string INST_SET_ExpRequire = "ExpRequire";
    private const string INST_SET_CreateDialogueSetPerLevel = "CDiaLevel";
    #endregion

    [SerializeField] private Exploration_Loading exploration_Loading;

    public Dictionary<string, Exploration_Template> Interpert()
    {
        if (!ReferenceEquals(exploration_Loading, null))
        {
            Dictionary<string, Exploration_Template> explorationDic = new Dictionary<string, Exploration_Template>();

            foreach (KeyValuePair<string, string> line in exploration_Loading.textLists)
            {
                Exploration_Template exploration = null;
                string key = line.Key;
                string value = line.Value;

                exploration = CreateTemplate(value);

                if (!ReferenceEquals(exploration, null))
                {
                    explorationDic.Add(key, exploration);
                }

            }
            if (!ReferenceEquals(explorationDic, null))
            {
                return explorationDic;
            }
        }

        return null;
    }

    private Exploration_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        bool locked = false;
        int maxLevel = 5;
        string explorationIdRequired = string.Empty;
        int levelRequired = 0;
        List<int> expRequired = new List<int>();
        Dictionary<int, List<string>> explodialogueIdList = new Dictionary<int, List<string>>();

        int countDialoguePerLevel = 0;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_DefaultLocked:
                    locked = bool.Parse(entries[++i]);
                    if (locked)
                    {
                        explorationIdRequired = entries[++i];
                        levelRequired = int.Parse(entries[++i]);
                    }
                    break;
                case INST_SET_MaxLevel:
                    maxLevel = int.Parse(entries[++i]);
                    break;
                case INST_SET_ExpRequire:
                    for(int j = 0; j < maxLevel; j++)
                    {
                        expRequired.Add(int.Parse(entries[++i]));
                    }
                    break;
                case INST_SET_CreateDialogueSetPerLevel:
                    countDialoguePerLevel++;
                    List<string> explorationDialogueIds = new List<string>();
                    int count = int.Parse(entries[++i]);
                    for(int k = 0; k < count; k++)
                    {
                        explorationDialogueIds.Add(entries[++i]);
                    }
                    explodialogueIdList.Add(countDialoguePerLevel, explorationDialogueIds);
                    break;

            }

        }

        return new Exploration_Template(id, locked, maxLevel, explorationIdRequired, levelRequired, expRequired, explodialogueIdList);
    }
}
