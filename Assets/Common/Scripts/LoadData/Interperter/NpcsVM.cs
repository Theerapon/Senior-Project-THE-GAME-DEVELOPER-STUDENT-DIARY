using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcsVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Name = "Name";
    private const string INST_SET_Icon = "Icon";
    private const string INST_SET_HappinessImage = "HappinessImage";
    private const string INST_SET_SadnessImage = "SadnessImage";
    private const string INST_SET_FearImage = "FearImage";
    private const string INST_SET_DisgustImage = "DisgustImage";
    private const string INST_SET_AngerImage = "AngerImage";
    private const string INST_SET_SurpriseImage = "SurpriseImage";
    private const string INST_SET_NormalImage = "NormalImage";
    private const string INST_SET_RelationshipDescription = "RelationshipDescription";
    private const string INST_SET_FavItemID = "FavItemID";
    private const string INST_SET_Home = "Home";
    private const string INST_SET_Birthday = "Birthday";
    private const string Check_Birthday = "Unknown";
    #endregion

    [SerializeField] private NPCs_Loading nPCs_Loading;

    public Dictionary<string, Npc_Template> Interpert()
    {
        if (!ReferenceEquals(nPCs_Loading, null))
        {
            Dictionary<string, Npc_Template> npcDic = new Dictionary<string, Npc_Template>();

            foreach (KeyValuePair<string, string> line in nPCs_Loading.textLists)
            {
                Npc_Template npc = null;
                string key = line.Key;
                string value = line.Value;

                npc = CreateTemplate(value);

                if (!ReferenceEquals(npc, null))
                {
                    npcDic.Add(key, npc);
                }

            }
            if (!ReferenceEquals(npcDic, null))
            {
                return npcDic;
            }
        }

        return null;
    }

    private Npc_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        string npcName = "Npc Name";
        Sprite icon = null;
        Sprite happinessImage = null;
        Sprite sadnessImage = null;
        Sprite fearImage = null;
        Sprite disgusImage = null;
        Sprite angerImage = null;
        Sprite surpriseImage = null;
        Sprite normalImage = null;
        List<string> descriptionRelationship = new List<string>();
        string favoriteItemSetId = string.Empty;
        Place originHome = Place.Null;
        string birthday = "Unknown";
        int dayBirthday = 0;
        int mounthBirthday = 0;
        int yearBirthday = 0;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_Name:
                    npcName = entries[++i];
                    break;
                case INST_SET_Icon:
                    icon = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_HappinessImage:
                    happinessImage = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_SadnessImage:
                    sadnessImage = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_FearImage:
                    fearImage = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_DisgustImage:
                    disgusImage = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_AngerImage:
                    angerImage = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_SurpriseImage:
                    surpriseImage = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_NormalImage:
                    normalImage = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_RelationshipDescription:
                    int rount = int.Parse(entries[++i]);
                    for(int j = 0; j < rount; j++)
                    {
                        descriptionRelationship.Add(entries[++i]);
                    }
                    break;
                case INST_SET_FavItemID:
                    favoriteItemSetId = entries[++i];
                    break;
                case INST_SET_Home:
                    originHome = ConvertType.CheckPlace(entries[++i]);
                    break;
                case INST_SET_Birthday:
                    birthday = entries[++i];
                    if (!birthday.Equals(Check_Birthday))
                    {
                        string[] birthday_entries = birthday.Split('/');
                        mounthBirthday = int.Parse(birthday_entries[0]);
                        dayBirthday = int.Parse(birthday_entries[1]);
                        yearBirthday = int.Parse(birthday_entries[2]);
                    }

                    break;

            }

        }

        return new Npc_Template(id, npcName, icon, happinessImage, sadnessImage, fearImage, disgusImage, angerImage, surpriseImage, normalImage, descriptionRelationship, favoriteItemSetId, originHome, birthday, dayBirthday, mounthBirthday, yearBirthday);
    }
}
