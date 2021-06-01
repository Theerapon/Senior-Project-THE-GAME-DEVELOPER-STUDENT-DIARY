using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxs_DataHandler : Manager<RandomBoxs_DataHandler>
{
    protected Dictionary<string, RandomBox_Template> randomboxDic;
    [SerializeField] private RandomBoxsVM randomBoxsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, RandomBox_Template> GetRandomBoxsDic
    {
        get { return randomboxDic; }
    }

    protected override void Awake()
    {
        base.Awake();
        randomboxDic = new Dictionary<string, RandomBox_Template>();
    }
    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        randomboxDic = randomBoxsVM.Interpert();
        //Debug.Log("RandomBox interpret completed");
        //foreach (KeyValuePair<string, RandomBox_Template> randombox in randomboxDic)
        //{
        //    Debug.Log(string.Format("ID = {0}, SoawnId = {1}",
        //        randombox.Value.Id, randombox.Value.SpawnItemId));

        //}
    }
}
