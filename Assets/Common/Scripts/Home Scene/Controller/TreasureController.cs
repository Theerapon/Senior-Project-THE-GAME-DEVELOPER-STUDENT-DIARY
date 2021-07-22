using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureController : Manager<TreasureController>
{
    private RandomTreasure_DataHandler _randomBoxs_DataHandler;
    private Dictionary<string, RandomTreasure_Template> _randomboxDic;
    private List<string> _randomTrasureIds;

    [SerializeField] private SpawnItemsController _spawnItemsController;
    [SerializeField] private TimeManager _timeManager;

    #region Field
    private readonly Place[] INST_TREASURES_POSITION = { Place.Treasure1, Place.Treasure2, Place.Treasure3, Place.Treasure4, Place.Treasure5 };
    private Place _currentPlace; //random place on new day
    private string _currentRandomTreasureId; //random treasure on new day
    private List<SpawnItem> _currentSpawnItems; //get from random treasure
    private bool _exploration;
    #endregion

    #region Get
    public Dictionary<string, RandomTreasure_Template> RandomboxDic { get => _randomboxDic; }
    public Place CurrentPlace { get => _currentPlace; }
    public List<SpawnItem> SpawnItems { get => _currentSpawnItems; }
    public bool Exploration { get => _exploration; }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        _randomboxDic = new Dictionary<string, RandomTreasure_Template>();
        _randomBoxs_DataHandler = FindObjectOfType<RandomTreasure_DataHandler>();
        _timeManager.OnStartNewDayComplete.AddListener(StartNewDayHandler);
        _randomTrasureIds = new List<string>();
        _currentSpawnItems = new List<SpawnItem>();
        

        //set treasure
        if (!ReferenceEquals(_randomBoxs_DataHandler.GetRandomTreasureDic, null))
        {
            foreach (KeyValuePair<string, RandomTreasure_Template> treasure in _randomBoxs_DataHandler.GetRandomTreasureDic)
            {
                string id = treasure.Key;
                _randomboxDic.Add(id, treasure.Value);
                _randomTrasureIds.Add(id);
            }
            Debug.Log("ssssssssssssssssssssss");
            
        }
    }

    private void StartNewDayHandler()
    {
        //place
        int indexPlace = UnityEngine.Random.Range(0, INST_TREASURES_POSITION.Length);
        _currentPlace = INST_TREASURES_POSITION[indexPlace];

        //trasure
        int indexTreasure = UnityEngine.Random.Range(0, _randomTrasureIds.Count);
        _currentRandomTreasureId = _randomTrasureIds[indexTreasure];

        //spawn
        string spawnId = _randomboxDic[_currentRandomTreasureId].SpawnItemId;
        _currentSpawnItems.Clear();
        Debug.Log(spawnId);
        _currentSpawnItems = _spawnItemsController.SpawnsItemsDic[spawnId].SpawnItems;

        _exploration = false;

    }

    public void Explore()
    {
        if (!_exploration)
        {
            _exploration = true;
        }
    }
}
