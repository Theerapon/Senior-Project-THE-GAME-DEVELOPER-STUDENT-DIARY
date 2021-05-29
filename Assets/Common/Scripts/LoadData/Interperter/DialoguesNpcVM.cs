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
    private const string INST_SET_Loop = "Loop";
    private const string INST_SET_FirstRelationship = "FRelationship";
    private const string INST_SET_EndRelationship = "ERelationship";
    private const string INST_SET_GiftCondition = "Gift";
    private const string INST_SET_EquipCondition = "Equip";
    private const string INST_SET_TimeCondition = "Time";
    private const string INST_SET_PlaceCondition = "Place";
    private const string INST_SET_Dialogue = "Dia";
    private const string INST_SET_Event = "Event";
    private const string INST_SET_CreateIdea = "Cidea";
    private const string INST_SET_CreateItem = "Citem";
    #endregion

    #region Instance NPC ID
    private const string INST_SET_Npc1 = "npc001";
    private const string INST_SET_Npc2 = "npc002";
    private const string INST_SET_Npc3 = "npc003";
    private const string INST_SET_Npc4 = "npc004";
    private const string INST_SET_Npc5 = "npc005";
    private const string INST_SET_Npc6 = "npc006";
    private const string INST_SET_Npc7 = "npc007";
    private const string INST_SET_Npc8 = "npc008";
    private const string INST_SET_Npc9 = "npc009";
    #endregion

    [SerializeField] private DialoguesNPC_Loading dialoguesNPC_Loading;

    public Dictionary<string, List<DialogueNPC>> Interpert()
    {
        if (!ReferenceEquals(dialoguesNPC_Loading, null))
        {
            Dictionary<string, List<DialogueNPC>> dic = new Dictionary<string, List<DialogueNPC>>();

            #region Instace NPC

            #region NPC1
            List<DialogueNPC> DialogueNpc1List = new List<DialogueNPC>();
            #endregion

            #region NPC2
            List<DialogueNPC> DialogueNpc2List = new List<DialogueNPC>();
            #endregion

            #region NPC3
            List<DialogueNPC> DialogueNpc3List = new List<DialogueNPC>();
            #endregion

            #region NPC4
            List<DialogueNPC> DialogueNpc4List = new List<DialogueNPC>();
            #endregion

            #region NPC5
            List<DialogueNPC> DialogueNpc5List = new List<DialogueNPC>();
            #endregion

            #region NPC6
            List<DialogueNPC> DialogueNpc6List = new List<DialogueNPC>();
            #endregion

            #region NPC7
            List<DialogueNPC> DialogueNpc7List = new List<DialogueNPC>();
            #endregion

            #region NPC8
            List<DialogueNPC> DialogueNpc8List = new List<DialogueNPC>();
            #endregion

            #region NPC9
            List<DialogueNPC> DialogueNpc9List = new List<DialogueNPC>();
            #endregion

            #endregion

            foreach (KeyValuePair<string, string> line in dialoguesNPC_Loading.textLists)
            {
                DialogueNPC dialogue = null;

                string key = line.Key;
                string value = line.Value;

                dialogue = CreateTemplate(value);

                if (!ReferenceEquals(dialogue, null))
                {

                    if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId001))
                    {
                        DialogueNpc1List.Add(dialogue);
                    } 
                    else if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId002))
                    {
                        DialogueNpc2List.Add(dialogue);
                    }
                    else if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId003))
                    {
                        DialogueNpc3List.Add(dialogue);
                    }
                    else if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId004))
                    {
                        DialogueNpc4List.Add(dialogue);
                    }
                    else if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId005))
                    {
                        DialogueNpc5List.Add(dialogue);
                    }
                    else if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId006))
                    {
                        DialogueNpc6List.Add(dialogue);
                    }
                    else if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId007))
                    {
                        DialogueNpc7List.Add(dialogue);
                    }
                    else if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId008))
                    {
                        DialogueNpc8List.Add(dialogue);
                    }
                    else if (dialogue.npc_id.Equals(ConvertType.INST_SET_NpcId009))
                    {
                        DialogueNpc9List.Add(dialogue);
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
            dic.Add(ConvertType.INST_SET_NpcId009, DialogueNpc9List);

            if (!ReferenceEquals(dic, null))
            {
                return dic;
            }
        }

        return null;
    }

    private DialogueNPC CreateTemplate(string line)
    {
        string id = string.Empty;
        string npc_id = string.Empty;
        bool loop = false;
        int first_relationship = 0;
        int end_relationship = 0;
        string condition_gift = string.Empty;
        string condition_equip = string.Empty;
        string condition_time = string.Empty;
        int firstHour = 0;
        int firstMinute = 0;
        int endHour = 0;
        int endMinute = 0;
        Place condition_place = Place.Null;
        List<Dialogue> dialoguesList = new List<Dialogue>();
        CreateEvent condition_event = CreateEvent.Null;
        List<string> ideasIdList = new List<string>();
        List<string> itemIdList = new List<string>();

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
                case INST_SET_Loop:
                    loop = bool.Parse(entries[++i]);
                    break;
                case INST_SET_FirstRelationship:
                    first_relationship = int.Parse(entries[++i]);
                    break;
                case INST_SET_EndRelationship:
                    end_relationship = int.Parse(entries[++i]);
                    break;
                case INST_SET_GiftCondition:
                    condition_gift = ConvertType.CheckString(entries[++i]);
                    break;
                case INST_SET_EquipCondition:
                    condition_equip = ConvertType.CheckString(entries[++i]);
                    break;
                case INST_SET_TimeCondition:
                    condition_time = ConvertType.CheckString(entries[++i]);
                    if (!condition_time.Equals(string.Empty))
                    {
                        string[] time_entries = condition_time.Split('-');
                        string[] firstTime_entries = time_entries[0].Split(':');
                        string[] endTime_entries = time_entries[1].Split(':');
                        firstHour = int.Parse(firstTime_entries[0]);
                        firstMinute = int.Parse(firstTime_entries[1]);
                        endHour = int.Parse(endTime_entries[0]);
                        endMinute = int.Parse(endTime_entries[1]);
                    }
                    break;
                case INST_SET_PlaceCondition:
                    condition_place = ConvertType.CheckPlace(entries[++i]);
                    break;
                case INST_SET_Dialogue:
                    Debug.Log("Create Dialogue");
                    dialoguesList.Add(new Dialogue(entries[++i], ConvertType.CheckFeel(entries[++i])));
                    break;
                case INST_SET_Event:
                    condition_event = ConvertType.CheckCreateEvent(entries[++i]);
                    break;
                case INST_SET_CreateIdea:
                    ideasIdList.Add(ConvertType.CheckString(entries[++i]));
                    break;
                case INST_SET_CreateItem:
                    itemIdList.Add(ConvertType.CheckString(entries[++i]));
                    break;


            }

        }
        return new DialogueNPC(id, npc_id, loop, first_relationship, end_relationship, condition_gift, condition_equip, condition_time, firstHour, firstMinute, endHour, endMinute, condition_place, dialoguesList, condition_event, ideasIdList, itemIdList);
    }
}
