using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialoguesNPC_Template;

public class DialoguesNPC_DataHandler : Manager<DialoguesNPC_DataHandler>
{
    protected Dictionary<string, List<DialoguesNPC_Template>> dialoguesNpcDic;
    [SerializeField] private DialoguesNpcVM dialoguesNpcVM;
    [SerializeField] private InterpretHandler interpretHandler;
    public Dictionary<string, List<DialoguesNPC_Template>> GetDialoguesNpcDic
    {
        get { return dialoguesNpcDic; }
    }

    protected override void Awake()
    {
        base.Awake();
        dialoguesNpcDic = new Dictionary<string, List<DialoguesNPC_Template>>();
    }

    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        dialoguesNpcDic = dialoguesNpcVM.Interpert();
        //Debug.Log("activities interpret completed");
        //foreach (KeyValuePair<string, List<DialogueNPC>> npc in dialoguesNpcDic)
        //{

        //    for (int i = 0; i < npc.Value.Count; i++)
        //    {
                
        //        for(int j = 0; j < npc.Value[i].dialoguesList.Count; j++)
        //        {
        //            Debug.Log(string.Format("NPC ID = {0} , Relationship = {1}-{2}  , Dialogue {3} = {4} {5} , Loop {6}",
        //                npc.Key, npc.Value[i].first_relationship, npc.Value[i].end_relationship, (j + 1), npc.Value[i].dialoguesList[j].GetTextDialogue(), npc.Value[i].dialoguesList[j].GetFeelDialogue(), npc.Value[i].loop));
        //        }
        //    }

        //}
    }
}
