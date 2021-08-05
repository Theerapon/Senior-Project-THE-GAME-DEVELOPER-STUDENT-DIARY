using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountEntry : MonoBehaviour
{
    [SerializeField] static readonly private int TOTAL_DAYS = 28;

    private DayEntry[] dayEntries = new DayEntry[TOTAL_DAYS];

    public MountEntry()
    {
        for (int i = 0; i < dayEntries.Length; i++)
        {
            List<string> demo = new List<string>();
            demo.Add("Activity 1");

            dayEntries[i] = new DayEntry(demo);
        }
    }

    public DayEntry[] Days
    {
        get { return dayEntries; }
    }



}
