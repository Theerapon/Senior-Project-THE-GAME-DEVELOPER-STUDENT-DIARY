using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule_Template : MonoBehaviour
{
    private string id;
    private ScheduleEvent scheduleEvents;
    private string scheduleName;
    private string time;
    private int day;
    private int mount;
    private int year;

    public string Id { get => id; }
    public ScheduleEvent ScheduleEvents { get => scheduleEvents; }
    public string ScheduleName { get => scheduleName; }
    public string Time { get => time; }
    public int Day { get => day; }
    public int Mount { get => mount; }
    public int Year { get => year; }

    public Schedule_Template(string id, ScheduleEvent scheduleEvents, string scheduleName, string time, int day, int mount, int year)
    {
        this.id = id;
        this.scheduleEvents = scheduleEvents;
        this.scheduleName = scheduleName;
        this.time = time;
        this.day = day;
        this.mount = mount;
        this.year = year;
    }
}
