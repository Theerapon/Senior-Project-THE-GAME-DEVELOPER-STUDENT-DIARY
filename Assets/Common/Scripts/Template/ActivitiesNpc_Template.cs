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
        private Place place;

        public string Id { get => id; }
        public string Npc_id { get => npc_id; }
        public Day Day { get => day; }
        public float Start_time_hour { get => start_time_hour; }
        public float Start_time_minute { get => start_time_minute; }
        public Place Place { get => place; }

        public Activity(string id, string npc_id, Day day, int start_time_hour, int start_time_minute,  Place place)
        {
            this.id = id;
            this.npc_id = npc_id;
            this.day = day;
            this.start_time_hour = start_time_hour;
            this.start_time_minute = start_time_minute;
            this.place = place;
        }
    }

    private Dictionary<Day, List<Activity>> dic_activity_byDay;

    public ActivitiesNpc_Template(Dictionary<Day, List<Activity>> dic)
    {
        dic_activity_byDay = dic;
    }

    public Dictionary<Day, List<Activity>> GetActivitiesDicByDay()
    {
        return dic_activity_byDay;
    }
}
