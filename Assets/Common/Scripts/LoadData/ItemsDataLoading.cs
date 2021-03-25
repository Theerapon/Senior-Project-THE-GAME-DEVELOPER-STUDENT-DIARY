using System.Collections.Generic;
using UnityEngine;

public class ItemsDataLoading : DatasLoading
{
    public static ItemsDataLoading instance; 

    public static ItemsDataLoading Instance
    {
        get { return instance; }
        set
        {
            if (null == instance)
            {
                instance = value;

            }
            else if (instance != value)
            {
                Destroy(value.gameObject);
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        path = Application.dataPath + "/Resources/Files/items.csv";
        textID = "itemID";
        Instance = this;
    }

    protected override void Start()
    {
        base.Start();
        LoadedDataFromCSV();

    }



}



