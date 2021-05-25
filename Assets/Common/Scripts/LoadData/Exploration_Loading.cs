using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploration_Loading : DataLoading
{
    public static Exploration_Loading instance;
    [SerializeField] private string SPECIFICATION_PATH = "/Resources/Files/Exploration.csv";
    [SerializeField] private string SPECIFICATION_ID = "ID";

    public static Exploration_Loading Instance
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

    }
    private void Start()
    {
        hasFinished = LoadedDataFromCSV();
        if (hasFinished)
        {
            Notification();
        }
    }
}
