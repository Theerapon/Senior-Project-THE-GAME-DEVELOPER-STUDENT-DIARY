using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxs_DataHandler : DataHandler
{
    protected Dictionary<string, RandomBox_Template> randomboxDic;
    [SerializeField] private RandomBoxsVM randomBoxsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, RandomBox_Template> GetRandomBoxsDic
    {
        get { return randomboxDic; }
    }

    protected void Awake()
    {
        randomboxDic = new Dictionary<string, RandomBox_Template>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        randomboxDic = randomBoxsVM.Interpert();
        if (!ReferenceEquals(randomboxDic, null))
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
