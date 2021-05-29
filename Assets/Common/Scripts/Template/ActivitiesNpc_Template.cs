using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesNpc_Template : MonoBehaviour
{

    [System.Serializable]
    public class Activity
    {
        public string id;
        public string npc_id;
        public Day day;
        public int start_time_hour;
        public int start_time_minute;
        public int end_time_hour;
        public int end_time_minute;
        public Place place;
        public bool can_chat;
        public string chat;

        public Activity(string id, string npc_id, Day day, int sTimeHour, int sTimeMinute, int eTimeHour, int eTimeMinute, Place place, bool canChat, string chat)
        {
            this.id = id;
            this.npc_id = npc_id;
            this.day = day;
            this.start_time_hour = sTimeHour;
            this.start_time_minute = sTimeMinute;
            this.end_time_hour = eTimeHour;
            this.end_time_minute = eTimeMinute;
            this.place = place;
            this.can_chat = canChat;
            this.chat = chat;
        }
    }

    private Dictionary<Day, List<Activity>> dic_activity_byDay;

    public ActivitiesNpc_Template(Dictionary<Day, List<Activity>> dic)
    {
        dic_activity_byDay = dic;
    }

    public Dictionary<Day, List<Activity>> GetActivitiesDic()
    {
        return dic_activity_byDay;
    }
}
