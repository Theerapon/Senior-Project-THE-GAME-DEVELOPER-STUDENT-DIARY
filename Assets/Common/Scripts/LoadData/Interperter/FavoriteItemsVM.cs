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

    public Dictionary<string, FavortieItems_Template> Interpert()
    {
        if (!ReferenceEquals(favoriteItems_Loading, null))
        {
            Dictionary<string, FavortieItems_Template> favoriteItemsDic = new Dictionary<string, FavortieItems_Template>();

            foreach (KeyValuePair<string, string> line in favoriteItems_Loading.textLists)
            {
                FavortieItems_Template dialogueExploration = null;
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

    private FavortieItems_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        List<DialogueFavoriteItem> itemLikeId = new List<DialogueFavoriteItem>();
        List<DialogueFavoriteItem> itemUnLikeId = new List<DialogueFavoriteItem>();
        List<DialogueFavoriteItem> itemExceptId = new List<DialogueFavoriteItem>();

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
                    itemLikeId.Add(new DialogueFavoriteItem(entries[++i], entries[++i], ConvertType.CheckFeel(entries[++i])));
                    break;
                case INST_SET_Unlike:
                    itemUnLikeId.Add(new DialogueFavoriteItem(entries[++i], entries[++i], ConvertType.CheckFeel(entries[++i])));
                    break;
                case INST_SET_Except:
                    itemExceptId.Add(new DialogueFavoriteItem(entries[++i], entries[++i], ConvertType.CheckFeel(entries[++i])));
                    break;

            }

        }

        return new FavortieItems_Template(id, itemLikeId, itemUnLikeId, itemExceptId);
    }
}
