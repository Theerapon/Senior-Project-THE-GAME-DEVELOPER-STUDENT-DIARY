using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    [SerializeField] static readonly private int TOTAL_MOUNTS = 4;

    private MountEntry[] mountEntries = new MountEntry[TOTAL_MOUNTS];

    private void Awake()
    {
        for (int i = 0; i < mountEntries.Length; i++)
        {
            mountEntries[i] = new MountEntry(); ;
        }
    }

    private void Start()
    {
        //for (int mount = 0; mount < mountEntries.Length; mount++)
        //{
        //    for (int day = 0; day < mountEntries[mount].Days.Length; day++)
        //    {
        //        List<string> str_list = mountEntries[mount].Days[day].GetActivities;
        //        for (int i = 0; i < str_list.Count; i++)
        //        {
        //            Debug.Log("mount " + mount + " day " + day + " " + str_list[i].ToUpper());
        //        }
        //    }
        //}
    }

    bool check = false;
    private void Update()
    {
        /*
        if (!check)
        {
            for(int mount = 0; mount < mountEntries.Length; mount++)
            {
                for(int day = 0; day < mountEntries[mount].Days.Length; day++)
                {
                    List<string> str_list = mountEntries[mount].Days[day].GetActivities;
                    for(int i = 0; i < str_list.Count; i++)
                    {
                        Debug.Log("mount " + mount + " day " + day + " " + str_list[i].ToUpper());
                    }
                }
            }

            check = true;
        }*/
    }
}
