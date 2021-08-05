using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreasure_DataHandler : DataHandler
{
    protected Dictionary<string, RandomTreasure_Template> _randomTreasureDic;
    [SerializeField] private RandomTreasureVM _randomTreasureVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, RandomTreasure_Template> GetRandomTreasureDic
    {
        get { return _randomTreasureDic; }
    }

    protected void Awake()
    {
        _randomTreasureDic = new Dictionary<string, RandomTreasure_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        _randomTreasureDic = _randomTreasureVM.Interpert();
        if (!ReferenceEquals(_randomTreasureDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("RandomBox interpret completed");
        //foreach (KeyValuePair<string, RandomBox_Template> randombox in randomboxDic)
        //{
        //    Debug.Log(string.Format("ID = {0}, SoawnId = {1}",
        //        randombox.Value.Id, randombox.Value.SpawnItemId));

        //}
    }
}
