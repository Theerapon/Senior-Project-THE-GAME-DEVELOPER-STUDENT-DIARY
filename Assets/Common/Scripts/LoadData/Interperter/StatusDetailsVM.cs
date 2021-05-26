using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDetailsVM : MonoBehaviour
{
    private const string INST_SET_statusID = "ID";
    private const string INST_SET_statusName = "statusName";
    private const string INST_SET_iconImage = "iconImage";
    private const string INST_SET_color = "color";

    [SerializeField] private StatusDetail_Loading statusDetailLoading;

    public Dictionary<string, Status> Interpert()
    {
        if (!ReferenceEquals(statusDetailLoading, null))
        {
            Dictionary<string, Status> status_dic = new Dictionary<string, Status>();

            foreach (KeyValuePair<string, string> line in statusDetailLoading.textLists)
            {
                Status status = null;
                string key = line.Key;
                string value = line.Value;

                status = CreateTemplate(value);

                if (!ReferenceEquals(status, null))
                {
                    status_dic.Add(status.StatusID, status);
                }

            }
            if (!ReferenceEquals(status_dic, null))
            {
                return status_dic;
            }
        }

        return null;
    }

    public Status CreateTemplate(string line)
    {
        string id = "";
        string name = "";
        Sprite icon = null;
        Color32 color = new Color32(255, 255, 255, 255);

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_statusID:
                    id = entries[++i];
                    break;
                case INST_SET_statusName:
                    name = entries[++i];
                    break;
                case INST_SET_iconImage:
                    icon = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_color:
                    color = new Color32(byte.Parse(entries[++i]), byte.Parse(entries[++i]), byte.Parse(entries[++i]), byte.Parse(entries[++i]));
                    break;

            }

        }
        return new Status(id, name, icon, color);
    }
}
