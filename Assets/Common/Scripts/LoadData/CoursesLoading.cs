using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoursesLoading : DatasLoading
{
    public static CoursesLoading instance;
    private const string SPECIFICATION_PATH = "/Resources/Files/courses.csv";
    private const string SPECIFICATION_ID = "courseID";

    public static CoursesLoading Instance
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
