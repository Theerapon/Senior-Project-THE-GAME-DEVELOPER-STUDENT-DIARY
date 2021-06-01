using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_scheduleEvent = "scheduleEvent";
    private const string INST_SET_Name = "Name";
    private const string INST_SET_Day = "Day";
    #endregion

    [SerializeField] private Schedule_Loading schedule_Loading;
    public Dictionary<string, Schedule_Template> Interpert()
    {
        if (!ReferenceEquals(schedule_Loading, null))
        {
            Dictionary<string, Schedule_Template> scheduleDic = new Dictionary<string, Schedule_Template>();

            foreach (KeyValuePair<string, string> line in schedule_Loading.textLists)
            {
                Schedule_Template schedule = null;
                string key = line.Key;
                string value = line.Value;

                schedule = CreateTemplate(value);

                if (!ReferenceEquals(schedule, null))
                {
                    scheduleDic.Add(key, schedule);
                }

            }
            if (!ReferenceEquals(scheduleDic, null))
            {
                return scheduleDic;
            }
        }

        return null;
    }

    private Schedule_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        ScheduleEvent scheduleEvents = ScheduleEvent.None;
        string scheduleName = string.Empty;
        string time = string.Empty;
        int day = 0;
        int mount = 0;
        int year = 0;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_scheduleEvent:
                    scheduleEvents = ConvertType.CheckScheuleEvent(entries[++i]);
                    break;
                case INST_SET_Name:
                    scheduleName = entries[++i];
                    break;
                case INST_SET_Day:
                    time = ConvertType.CheckString(entries[++i]);
                    if (!time.Equals(string.Empty))
                    {
                        string[] time_entries = time.Split('/');
                        mount = int.Parse(time_entries[0]);
                        day = int.Parse(time_entries[1]);
                        year = int.Parse(time_entries[2]);
                    }
                    break;

            }

        }

        return new Schedule_Template(id, scheduleEvents, scheduleName, time, day, mount, year);
    }
}
