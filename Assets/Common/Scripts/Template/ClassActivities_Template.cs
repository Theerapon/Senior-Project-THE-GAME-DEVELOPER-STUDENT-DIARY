using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassActivities_Template : MonoBehaviour
{
    private string id;
    private ClassActivityType activityType;
    private string activity_name;
    private Sprite icon;
    private Day day;
    private int start_time_hour;
    private int start_time_minute;
    private int end_time_hour;
    private int end_time_minute;
    private List<string> registerId = null;

    public ClassActivities_Template(string id, ClassActivityType activityType, string activity_name, Sprite icon, Day day, int start_time_hour, int start_time_minute, int end_time_hour, int end_time_minute, List<string> registerId)
    {
        this.id = id;
        this.activityType = activityType;
        this.activity_name = activity_name;
        this.icon = icon;
        this.day = day;
        this.start_time_hour = start_time_hour;
        this.start_time_minute = start_time_minute;
        this.end_time_hour = end_time_hour;
        this.end_time_minute = end_time_minute;
        this.registerId = registerId;
    }

    public string Id { get => id; }
    public ClassActivityType ActivityType { get => activityType; }
    public string Activity_name { get => activity_name; }
    public Sprite Icon { get => icon; }
    public Day Day { get => day; }
    public int Start_time_hour { get => start_time_hour; }
    public int Start_time_minute { get => start_time_minute; }
    public int End_time_hour { get => end_time_hour; }
    public int End_time_minute { get => end_time_minute; }
    public List<string> RegisterId { get => registerId; }
}
