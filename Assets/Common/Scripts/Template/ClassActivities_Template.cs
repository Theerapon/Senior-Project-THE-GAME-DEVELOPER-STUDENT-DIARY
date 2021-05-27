using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClassActivityType { Project, Class}
public class ClassActivities_Template : MonoBehaviour
{
    private string id;
    public string ID { get { return id; } }

    private ClassActivityType activityType;
    private string activity_name;
    private Sprite icon;
    private Day day;
    private int start_time_hour;
    private int start_time_minute;
    private int end_time_hour;
    private int end_time_minute;

    public ClassActivities_Template(string id, ClassActivityType classActivityType, string name,
        Sprite icon, Day day, int sTime_hour, int sTime_minute, int eTime_hour, int eTime_minute)
    {
        this.id = id;
        this.activityType = classActivityType;
        this.activity_name = name;
        this.icon = icon;
        this.day = day;
        this.start_time_hour = sTime_hour;
        this.start_time_minute = sTime_minute;
        this.end_time_hour = eTime_hour;
        this.end_time_minute = eTime_minute;
    }

    #region Reporter
    public ClassActivityType GetClassType()
    {
        return activityType;
    }
    public string GetClassName()
    {
        return activity_name;
    }
    public Sprite GetClassIcon()
    {
        return icon;
    }
    public Day GetClassDay()
    {
        return day;
    }
    public int GetStartTimeHour()
    {
        return start_time_hour;
    }
    public int GetStartTimeMinute()
    {
        return start_time_minute;
    }
    public int GetEndTimeHour()
    {
        return end_time_hour;
    }
    public int GetEndTimeMinute()
    {
        return end_time_minute;
    }
    #endregion
}
