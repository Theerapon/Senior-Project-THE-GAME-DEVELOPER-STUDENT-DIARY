using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DatasLoading : MonoBehaviour
{
    public Dictionary<string, string> textLists;
    protected string textID;
    protected string path;

    protected virtual void Awake()
    {
        textLists = new Dictionary<string, string>();
    }

    protected virtual void Start()
    {
          
    }

    protected virtual void LoadedDataFromCSV()
    {
        if (SaveExists())
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            foreach (string line in lines)
            {
                string id = null;
                string[] entries = line.Split(',');
                for (int i = 0; i < entries.Length; i++)
                {
                    if (entries[i].Equals(this.textID))
                    {

                        id = entries[++i];
                    }
                    break;
                }

                if (id != null)
                    textLists.Add(id, line);
            }
        }

    }

    protected bool SaveExists()
    {
        return File.Exists(path);
    }



}
