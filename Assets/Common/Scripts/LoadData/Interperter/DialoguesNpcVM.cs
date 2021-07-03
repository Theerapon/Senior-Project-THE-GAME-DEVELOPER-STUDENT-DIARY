using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialoguesNPC_Template;

public class DialoguesNpcVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_NpcID = "NpcID";
    private const string INST_SET_FirstRelationship = "FRelationship";
    private const string INST_SET_EndRelationship = "ERelationship";
    private const string INST_SET_PlaceCondition = "Place";
    private const string INST_SET_Dialogue = "Dia";
    private const string INST_SET_Event = "Event";
    private const string INST_SET_CreateIdea = "Cidea";
    #endregion


    [SerializeField] private DialoguesNPC_Loading dialoguesNPC_Loading;

    public Dictionary<string, List<DialoguesNPC_Template>> Interpert()
    {
        if (!ReferenceEquals(dialoguesNPC_Loading, null))
        {
            Dictionary<string, List<DialoguesNPC_Template>> dic = new Dictionary<string, List<DialoguesNPC_Template>>();

            #region Instace NPC

            #region NPC1
            List<DialoguesNPC_Template> DialogueNpc1List = new List<DialoguesNPC_Template>();
            #endregion

            #region NPC2
            List<DialoguesNPC_Template> DialogueNpc2List = new List<DialoguesNPC_Template>();
            #endregion

            #region NPC3
            List<DialoguesNPC_Template> DialogueNpc3List = new List<DialoguesNPC_Template>();
            #endregion

            #region NPC4
            List<DialoguesNPC_Template> DialogueNpc4List = new List<DialoguesNPC_Template>();
            #endregion

            #region NPC5
            List<DialoguesNPC_Template> DialogueNpc5List = new List<DialoguesNPC_Template>();
            #endregion

            #region NPC6
            List<DialoguesNPC_Template> DialogueNpc6List = new List<DialoguesNPC_Template>();
            #endregion

            #region NPC7
            List<DialoguesNPC_Template> DialogueNpc7List = new List<DialoguesNPC_Template>();
            #endregion

            #region NPC8
            List<DialoguesNPC_Template> DialogueNpc8List = new List<DialoguesNPC_Template>();
            #endregion


            #endregion

            foreach (KeyValuePair<string, string> line in dialoguesNPC_Loading.textLists)
            {
                DialoguesNPC_Template dialogue = null;

                string key = line.Key;
                string value = line.Value;

                dialogue = CreateTemplate(value);

                if (!ReferenceEquals(dialogue, null))
                {

                    if (dialogue.Npc_id.Equals(ConvertType.INST_SET_NpcId001))
                    {
                        DialogueNpc1List.Add(dialogue);
                    } 
                    else if (dialogue.Npc_id.Equals(ConvertType.INST_SET_NpcId002))
                    {
                        DialogueNpc2List.Add(dialogue);
                    }
                    else if (dialogue.Npc_id.Equals(ConvertType.INST_SET_NpcId003))
                    {
                        DialogueNpc3List.Add(dialogue);
                    }
                    else if (dialogue.Npc_id.Equals(ConvertType.INST_SET_NpcId004))
                    {
                        DialogueNpc4List.Add(dialogue);
                    }
                    else if (dialogue.Npc_id.Equals(ConvertType.INST_SET_NpcId005))
                    {
                        DialogueNpc5List.Add(dialogue);
                    }
                    else if (dialogue.Npc_id.Equals(ConvertType.INST_SET_NpcId006))
                    {
                        DialogueNpc6List.Add(dialogue);
                    }
                    else if (dialogue.Npc_id.Equals(ConvertType.INST_SET_NpcId007))
                    {
                        DialogueNpc7List.Add(dialogue);
                    }
                    else if (dialogue.Npc_id.Equals(ConvertType.INST_SET_NpcId008))
                    {
                        DialogueNpc8List.Add(dialogue);
                    }
                }

            }

            dic.Clear();
            dic.Add(ConvertType.INST_SET_NpcId001, DialogueNpc1List);
            dic.Add(ConvertType.INST_SET_NpcId002, DialogueNpc2List);
            dic.Add(ConvertType.INST_SET_NpcId003, DialogueNpc3List);
            dic.Add(ConvertType.INST_SET_NpcId004, DialogueNpc4List);
            dic.Add(ConvertType.INST_SET_NpcId005, DialogueNpc5List);
            dic.Add(ConvertType.INST_SET_NpcId006, DialogueNpc6List);
            dic.Add(ConvertType.INST_SET_NpcId007, DialogueNpc7List);
            dic.Add(ConvertType.INST_SET_NpcId008, DialogueNpc8List);

            if (!ReferenceEquals(dic, null))
            {
                return dic;
            }
        }

        return null;
    }

    private DialoguesNPC_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        string npc_id = string.Empty;
        int first_relationship = 0;
        int end_relationship = 0;
        Place condition_place = Place.Null;
        List<Dialogue> dialoguesList = new List<Dialogue>();
        CreateEvent condition_event = CreateEvent.Null;
        List<string> ideasIdList = new List<string>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_NpcID:
                    npc_id = entries[++i];
                    break;
                case INST_SET_FirstRelationship:
                    first_relationship = int.Parse(entries[++i]);
                    break;
                case INST_SET_EndRelationship:
                    end_relationship = int.Parse(entries[++i]);
                    break;
                case INST_SET_PlaceCondition:
                    condition_place = ConvertType.CheckPlace(entries[++i]);
                    break;
                case INST_SET_Dialogue:
                    dialoguesList.Add(new Dialogue(entries[++i], ConvertType.CheckFeel(entries[++i])));
                    break;
                case INST_SET_Event:
                    condition_event = ConvertType.CheckCreateEvent(entries[++i]);
                    break;
                case INST_SET_CreateIdea:
                    ideasIdList.Add(ConvertType.CheckString(entries[++i]));
                    break;

            }

        }
        return new DialoguesNPC_Template(id, npc_id, first_relationship, end_relationship, condition_place, dialoguesList, condition_event, ideasIdList);
    }
}
