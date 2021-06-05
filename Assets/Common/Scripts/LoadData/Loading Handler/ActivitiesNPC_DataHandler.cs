using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesNPC_DataHandler : MonoBehaviour
{
    protected Dictionary<string, ActivitiesNpc_Template> activitiesDic;
    [SerializeField] private ActivitiesNpcVM activitiesNpcVM;
    [SerializeField] private InterpretHandler interpretHandler;

    public Dictionary<string, ActivitiesNpc_Template> GetActivitiesDic
    {
        get { return activitiesDic; }
    }

    private void Awake()
    {
        activitiesDic = new Dictionary<string, ActivitiesNpc_Template>();
    }

    private void Start()
    {
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }

    private void EventInterpretHandler()
    {
        activitiesDic = activitiesNpcVM.Interpert();
        //Debug.Log("activities NPC interpret completed");
        //foreach(KeyValuePair<string, ActivitiesNpc_Template> npc in activitiesDic)
        //{
        //    foreach (KeyValuePair<Day, List<Activity>> day in npc.Value.GetActivitiesDic())
        //    {
        //        List<Activity> activities = day.Value;
        //        for (int i = 0; i < activities.Count; i++)
        //        {
        //            Debug.Log(string.Format("NPC ID = {0} , Day = {1} , {2:00}:{3:00} - {4:00}:{5:00} , Place = {6}",
        //                npc.Key, activities[i].day, activities[i].start_time_hour, activities[i].start_time_minute,
        //                activities[i].end_time_hour, activities[i].end_time_minute, activities[i].place));
        //        }
        //    } 
        //    
        //}
    }
}
