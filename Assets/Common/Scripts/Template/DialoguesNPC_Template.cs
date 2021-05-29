using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesNPC_Template : MonoBehaviour
{
    [System.Serializable]
    public class DialogueNPC
    {
        public string id = string.Empty;
        public string npc_id = string.Empty;
        public bool loop = false;
        public int first_relationship = 0;
        public int end_relationship = 0;
        public string condition_gift = string.Empty;
        public string condition_equip = string.Empty;
        public string condition_time = string.Empty;
        public int firstHour = 0;
        public int firstMinute = 0;
        public int endHour = 0;
        public int endMinute = 0;
        public Place condition_place = Place.Null;
        public List<Dialogue> dialoguesList = null;
        public CreateEvent condition_event = CreateEvent.Null;
        public List<string> ideasIdList = null;
        public List<string> itemIdList = null;

        public DialogueNPC(string id, string npc_id, bool loop, int first_relationship, int end_relationship, string condition_gift, string condition_equip, string condition_time, int firstHour, int firstMinute, int endHour, int endMinute, Place condition_place, List<Dialogue> dialoguesList, CreateEvent condition_event, List<string> ideasIdList, List<string> itemIdList)
        {
            this.id = id;
            this.npc_id = npc_id;
            this.loop = loop;
            this.first_relationship = first_relationship;
            this.end_relationship = end_relationship;
            this.condition_gift = condition_gift;
            this.condition_equip = condition_equip;
            this.condition_time = condition_time;
            this.firstHour = firstHour;
            this.firstMinute = firstMinute;
            this.endHour = endHour;
            this.endMinute = endMinute;
            this.condition_place = condition_place;
            this.dialoguesList = dialoguesList;
            this.condition_event = condition_event;
            this.ideasIdList = ideasIdList;
            this.itemIdList = itemIdList;
        }
    }

    private Dictionary<string, List<DialogueNPC>> dialoguesNpcDic;

    public DialoguesNPC_Template(Dictionary<string, List<DialogueNPC>> dic)
    {
        dialoguesNpcDic = dic;
    }

    public Dictionary<string, List<DialogueNPC>> GetDialoguesNpcDic()
    {
        return dialoguesNpcDic;
    }
}
