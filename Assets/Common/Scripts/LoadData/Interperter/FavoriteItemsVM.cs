using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteItemsVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Like = "Clike";
    private const string INST_SET_Unlike = "Cunlike";
    private const string INST_SET_Except = "Cexcept";
    #endregion

    [SerializeField] private FavoriteItems_Loading favoriteItems_Loading;

    public Dictionary<string, FavoriteItems_Template> Interpert()
    {
        if (!ReferenceEquals(favoriteItems_Loading, null))
        {
            Dictionary<string, FavoriteItems_Template> favoriteItemsDic = new Dictionary<string, FavoriteItems_Template>();

            foreach (KeyValuePair<string, string> line in favoriteItems_Loading.textLists)
            {
                FavoriteItems_Template dialogueExploration = null;
                string key = line.Key;
                string value = line.Value;

                dialogueExploration = CreateTemplate(value);

                if (!ReferenceEquals(dialogueExploration, null))
                {
                    favoriteItemsDic.Add(key, dialogueExploration);
                }

            }
            if (!ReferenceEquals(favoriteItemsDic, null))
            {
                return favoriteItemsDic;
            }
        }

        return null;
    }

    private FavoriteItems_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        Dictionary<String, DialogueFavoriteItem> itemLikeIdDictionary = new Dictionary<String, DialogueFavoriteItem>();
        Dictionary<String, DialogueFavoriteItem> itemUnLikeIdDictionary = new Dictionary<String, DialogueFavoriteItem>();
        Dictionary<String, DialogueFavoriteItem> itemExceptIdDictionary = new Dictionary<String, DialogueFavoriteItem>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_Like:
                    string itemId = entries[++i];
                    string itemDialogue = entries[++i];
                    Feel itemFeel = ConvertType.CheckFeel(entries[++i]);
                    itemLikeIdDictionary.Add(itemId, new DialogueFavoriteItem(itemId, itemDialogue, itemFeel));
                    break;
                case INST_SET_Unlike:
                    string itemUnlikeId = entries[++i];
                    string itemUnlikeDialogue = entries[++i];
                    Feel itemUnlikeFeel = ConvertType.CheckFeel(entries[++i]);
                    itemUnLikeIdDictionary.Add(itemUnlikeId, new DialogueFavoriteItem(itemUnlikeId, itemUnlikeDialogue, itemUnlikeFeel));
                    break;
                case INST_SET_Except:
                    string itemExceptId = entries[++i];
                    string itemDialogueExceptId = entries[++i];
                    Feel itemExceptFeel = ConvertType.CheckFeel(entries[++i]);
                    itemExceptIdDictionary.Add(itemExceptId, new DialogueFavoriteItem(itemExceptId, itemDialogueExceptId, itemExceptFeel));
                    break;

            }

        }

        return new FavoriteItems_Template(id, itemLikeIdDictionary, itemUnLikeIdDictionary, itemExceptIdDictionary);
    }
}
