using UnityEngine;

public class CharactersLoading : DatasLoading
{
    public static CharactersLoading instance;
    private const string SPECIFICATION_PATH = "/Resources/Files/characters.csv";
    private const string SPECIFICATION_ID = "charID";

    public static CharactersLoading Instance
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
