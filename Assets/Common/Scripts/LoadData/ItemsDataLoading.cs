﻿using System.Collections.Generic;
using UnityEngine;

public class ItemsDataLoading : DatasLoading
{
    public static ItemsDataLoading instance;
    private const string SPECIFICATION_PATH = "/Resources/Files/items.csv";
    private const string SPECIFICATION_ID = "itemID";

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
        path = Application.dataPath + SPECIFICATION_PATH;
        textID = SPECIFICATION_ID;
        Instance = this;
        LoadedDataFromCSV();
    }



}



