using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_IdeaType = "ideaType";
    private const string INST_SET_IdeaName = "ideaName";
    private const string INST_SET_IdeaDescription = "ideaDescription";
    private const string INST_SET_IconPath = "iconPath";
    private const string INST_SET_DefaultCollected = "defaultCollected";
    #endregion

    [SerializeField] private Ideas_Loading ideas_Loading;

    public Dictionary<string, Idea_Template> Interpert()
    {
        if (!ReferenceEquals(ideas_Loading, null))
        {
            Dictionary<string, Idea_Template> ideasDic = new Dictionary<string, Idea_Template>();

            foreach (KeyValuePair<string, string> line in ideas_Loading.textLists)
            {
                Idea_Template idea = null;
                string key = line.Key;
                string value = line.Value;

                idea = CreateTemplate(value);

                if (!ReferenceEquals(idea, null))
                {
                    ideasDic.Add(key, idea);
                }

            }
            if (!ReferenceEquals(ideasDic, null))
            {
                return ideasDic;
            }
        }

        return null;
    }

    private Idea_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        IdeaType ideaType = IdeaType.None;
        string ideaName = string.Empty;
        string description = string.Empty;
        Sprite icon = null;
        bool collected = false;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_IdeaType:
                    ideaType = ConvertType.CheckIdeaType(entries[++i]);
                    break;
                case INST_SET_IdeaName:
                    ideaName = entries[++i];
                    break;
                case INST_SET_IdeaDescription:
                    description = entries[++i];
                    break;
                case INST_SET_IconPath:
                    icon = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_DefaultCollected:
                    collected = bool.Parse(entries[++i]);
                    break;

            }

        }

        return new Idea_Template(id, ideaType, ideaName, description, icon, collected);
    }
}
