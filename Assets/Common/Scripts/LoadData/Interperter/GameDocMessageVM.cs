using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDocMessageVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Detail = "Detail";
    private const string INST_SET_Context = "Context";
    private const string INST_SET_nameCheck = "nameCheck";
    private const string INST_SET_goalCheck = "goalCheck";
    private const string INST_SET_mechanic1Check = "mechanic1Check";
    private const string INST_SET_mechanic2Check = "mechanic2Check";
    private const string INST_SET_themeCheck = "themeCheck";
    private const string INST_SET_platformCheck = "platformCheck";
    private const string INST_SET_playerCheck = "playerCheck";
    #endregion

    [SerializeField] private GameDocMessage_Loading gameDocMessage_Loading;

    public GameDocMessage_Template Interpert()
    {
        if (!ReferenceEquals(gameDocMessage_Loading, null))
        {
            GameDocMessage_Template gameDocMessage = null;

            foreach (KeyValuePair<string, string> line in gameDocMessage_Loading.textLists)
            {
                string key = line.Key;
                string value = line.Value;

                gameDocMessage = CreateTemplate(value);

            }
            if (!ReferenceEquals(gameDocMessage, null))
            {
                return gameDocMessage;
            }
        }

        return null;
    }

    private GameDocMessage_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        string detailMessage = string.Empty;
        string contextMessage = string.Empty;
        string nameReplace = string.Empty;
        string goalReplace = string.Empty;
        string mechanic1Replace = string.Empty;
        string mechanic2Replace = string.Empty;
        string themeReplace = string.Empty;
        string platformReplace = string.Empty;
        string playerReplace = string.Empty;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_Detail:
                    detailMessage = entries[++i];
                    break;
                case INST_SET_Context:
                    contextMessage = entries[++i];
                    break;
                case INST_SET_nameCheck:
                    nameReplace = entries[++i];
                    break;
                case INST_SET_goalCheck:
                    goalReplace = entries[++i];
                    break;
                case INST_SET_mechanic1Check:
                    mechanic1Replace = entries[++i];
                    break;
                case INST_SET_mechanic2Check:
                    mechanic2Replace = entries[++i];
                    break;
                case INST_SET_themeCheck:
                    themeReplace = entries[++i];
                    break;
                case INST_SET_platformCheck:
                    platformReplace = entries[++i];
                    break;
                case INST_SET_playerCheck:
                    playerReplace = entries[++i];
                    break;


            }

        }

        return new GameDocMessage_Template(id, detailMessage, contextMessage, nameReplace, goalReplace, mechanic1Replace, mechanic2Replace, themeReplace, platformReplace, playerReplace);
    }
}
