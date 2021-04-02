using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkillsLoading : DatasLoading
{
    public static HardSkillsLoading instance;
    private const string SPECIFICATION_PATH = "/Resources/Files/hardskills.csv";
    private const string SPECIFICATION_ID = "hardskillID";

    public static HardSkillsLoading Instance
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
