using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{
    List<Schedule_Template> schedules;
    private int scheduleDay;
    private int scheduleMount;

    public Schedule(int index)
    {
        schedules = new List<Schedule_Template>();
        scheduleMount = (index / 28) + 1;
        scheduleDay = (index - (28 * (scheduleMount - 1))) + 1;
    }

    public List<Schedule_Template> Schedules { get => schedules; }

    public void AddSchedule(Schedule_Template schedule)
    {
        schedules.Add(schedule);
    }
}
