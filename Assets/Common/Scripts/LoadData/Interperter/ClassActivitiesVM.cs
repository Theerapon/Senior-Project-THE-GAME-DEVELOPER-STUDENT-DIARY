using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassActivitiesVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Type = "Type";
    private const string INST_SET_Name = "Name";
    private const string INST_SET_Icon = "Icon";
    private const string INST_SET_Day = "Day";
    private const string INST_SET_StartTime = "StartTime";
    private const string INST_SET_EndTime = "EndTime";
    private const string INST_SET_Register = "Register";
    #endregion

    [SerializeField] private ClassActivities_Loading classActivities_Loading;

    public Dictionary<string, ClassActivities_Template> Interpert()
    {
        if (!ReferenceEquals(classActivities_Loading, null))
        {
            Dictionary<string, ClassActivities_Template> classActivities_dic = new Dictionary<string, ClassActivities_Template>();

            foreach (KeyValuePair<string, string> line in classActivities_Loading.textLists)
            {
                ClassActivities_Template classActivity = null;
                string key = line.Key;
                string value = line.Value;

                classActivity = CreateTemplate(value);

                if (!ReferenceEquals(classActivity, null))
                {
                    classActivities_dic.Add(classActivity.Id, classActivity);
                }

            }
            if (!ReferenceEquals(classActivities_dic, null))
            {
                return classActivities_dic;
            }
        }

        return null;
    }

    private ClassActivities_Template CreateTemplate(string line)
    {
        string id = "";
        ClassActivityType class_activity_type = ClassActivityType.Class;
        string name = "";
        Sprite icon = null;
        Day day = Day.None;
        int startTimeHour = 0;
        int startTimeMinute = 0;
        int endTimeHour = 0;
        int endTimeMinute = 0;
        List<string> registerId = new List<string>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_Type:
                    class_activity_type = ConvertType.CheckClassType(entries[++i]);
                    break;
                case INST_SET_Name:
                    name = entries[++i];
                    break;
                case INST_SET_Icon:
                    icon = Resources.Load<Sprite>(entries[++i]);
                    break;
                case INST_SET_Day:
                    day = ConvertType.CheckDay(entries[++i]);
                    break;
                case INST_SET_StartTime:
                    string start_time = entries[++i];
                    string[] startTime_entries = start_time.Split(':');
                    startTimeHour = int.Parse(startTime_entries[0]);
                    startTimeMinute = int.Parse(startTime_entries[1]);
                    break;
                case INST_SET_EndTime:
                    string end_time = entries[++i];
                    string[] endTime_entries = end_time.Split(':');
                    endTimeHour = int.Parse(endTime_entries[0]);
                    endTimeMinute = int.Parse(endTime_entries[1]);
                    break;
                case INST_SET_Register:
                    registerId.Add(entries[++i]);
                    break;

            }

        }
        return new ClassActivities_Template(id, class_activity_type, name, icon, day, startTimeHour, startTimeMinute, endTimeHour, endTimeMinute, registerId);
    }
}
