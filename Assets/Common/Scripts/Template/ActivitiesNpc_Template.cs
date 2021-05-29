using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesNpc_Template : MonoBehaviour
{

    [System.Serializable]
    public class Activity
    {
        private string id;
        private string npc_id;
        private Day day;
        private int start_time_hour;
        private int start_time_minute;
        private int end_time_hour;
        private int end_time_minute;
        private Place place;
        private bool can_chat;
        private string chat;

        public string Id { get => id; }
        public string Npc_id { get => npc_id; }
        public Day Day { get => day; }
        public int Start_time_hour { get => start_time_hour; }
        public int Start_time_minute { get => start_time_minute; }
        public int End_time_hour { get => end_time_hour; }
        public int End_time_minute { get => end_time_minute; }
        public Place Place { get => place; }
        public bool Can_chat { get => can_chat; }
        public string Chat { get => chat; }

        public Activity(string id, string npc_id, Day day, int start_time_hour, int start_time_minute, int end_time_hour, int end_time_minute, Place place, bool can_chat, string chat)
        {
            this.id = id;
            this.npc_id = npc_id;
            this.day = day;
            this.start_time_hour = start_time_hour;
            this.start_time_minute = start_time_minute;
            this.end_time_hour = end_time_hour;
            this.end_time_minute = end_time_minute;
            this.place = place;
            this.can_chat = can_chat;
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
