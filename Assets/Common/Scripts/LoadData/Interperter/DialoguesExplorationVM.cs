using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialoguesExploration_Template;

public class DialoguesExplorationVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Dialogue = "Dia";
    private const string INST_SET_SpawnItemSetID = "SpawnItemSetID";
    #endregion

    [SerializeField] private DialoguesExploration_Loading dialoguesExploration_Loading;

    public Dictionary<string, DialoguesExploration_Template> Interpert()
    {
        if (!ReferenceEquals(dialoguesExploration_Loading, null))
        {
            Dictionary<string, DialoguesExploration_Template> dialoguesExplorationDic = new Dictionary<string, DialoguesExploration_Template>();

            foreach (KeyValuePair<string, string> line in dialoguesExploration_Loading.textLists)
            {
                DialoguesExploration_Template dialogueExploration = null;
                string key = line.Key;
                string value = line.Value;

                dialogueExploration = CreateTemplate(value);

                if (!ReferenceEquals(dialogueExploration, null))
                {
                    dialoguesExplorationDic.Add(key, dialogueExploration);
                }

            }
            if (!ReferenceEquals(dialoguesExplorationDic, null))
            {
                return dialoguesExplorationDic;
            }
        }

        return null;
    }

    private DialoguesExploration_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        List<Dialogue> dialoguesList = new List<Dialogue>();
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
                case INST_SET_Dialogue:
                    dialoguesList.Add(new Dialogue(entries[++i], ConvertType.CheckFeel(entries[++i])));
                    break;
                case INST_SET_SpawnItemSetID:
                    spawnItemId = entries[++i];
                    break;
                
            }

        }

        return new DialoguesExploration_Template(id, dialoguesList, spawnItemId);
    }
}
