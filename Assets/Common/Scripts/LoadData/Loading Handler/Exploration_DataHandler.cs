using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploration_DataHandler : MonoBehaviour
{
    protected Dictionary<string, Exploration_Template> explorationDic;
    [SerializeField] private ExplorationVM explorationVM;
    [SerializeField] private InterpretHandler interpretHandler;
    public Dictionary<string, Exploration_Template> GetExplorationDic
    {
        get { return explorationDic; }
    }

    protected void Awake()
    {
        explorationDic = new Dictionary<string, Exploration_Template>();
    }

    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        explorationDic = explorationVM.Interpert();
        //Debug.Log("Exploration interpret completed");
        //foreach (KeyValuePair<string, Exploration_Template> exploration in explorationDic)
        //{
        //    foreach (KeyValuePair<int, List<string>> explorationDialogueIdLists in exploration.Value.ExplodialogueIdList)
        //    {
        //        for(int i = 0; i < explorationDialogueIdLists.Value.Count; i++)
        //        {
        //            Debug.Log(string.Format("ID {0}, Round {1}, Dialogue {2} = {3}",
        //            exploration.Key, explorationDialogueIdLists.Key, i, explorationDialogueIdLists.Value[i]));
        //        }

        //    }

        //}
    }
}
