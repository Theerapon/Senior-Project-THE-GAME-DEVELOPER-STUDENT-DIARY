using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActivitiesNpc_Template;
using static PlaceEntry;
using static TimeManager;

public class NpcsController : Manager<NpcsController>
{
    [SerializeField] private PlacesController placesController;
    [SerializeField] private TimeManager timeManager;

    private Npcs_DataHandler npcs_DataHandler;
    private Dictionary<string, Npc> npcsDic;
    private ActivitiesNPC_DataHandler activitiesNPC_DataHandler;
    private Dictionary<string, ActivitiesNpc_Template> activitiesDic;
    
    private static float minute, hour, date, second, month, year;
    private Day currentDay;

    protected override void Awake()
    {
        base.Awake();
        npcs_DataHandler = FindObjectOfType<Npcs_DataHandler>();
        npcsDic = new Dictionary<string, Npc>();
        activitiesNPC_DataHandler = FindObjectOfType<ActivitiesNPC_DataHandler>();
        activitiesDic = new Dictionary<string, ActivitiesNpc_Template>();
        timeManager.OnTenMinute.AddListener(OnTenMinuteHandler);

        //npcs
        if (!ReferenceEquals(npcs_DataHandler.GetNpcsDic, null))
        {
            foreach (KeyValuePair<string, Npc_Template> npc in npcs_DataHandler.GetNpcsDic)
            {
                npcsDic.Add(npc.Key, new Npc(npc.Value));
            }
        }

        //activities npcs
        if (!ReferenceEquals(activitiesNPC_DataHandler.GetActivitiesDic, null))
        {
            foreach (KeyValuePair<string, ActivitiesNpc_Template> activity in activitiesNPC_DataHandler.GetActivitiesDic)
            {
                activitiesDic.Add(activity.Key, activity.Value);
            }
        }
    }

    int a = 0;
    private void OnTenMinuteHandler()
    {
        second = timeManager.Second;
        minute = timeManager.Minute;
        hour = timeManager.Hour;
        date = timeManager.Date;
        month = timeManager.Month;
        year = timeManager.Year;
        currentDay = timeManager.CurrentDays;
        ActivityHandler();   
    }

    private void ActivityHandler()
    {
        if (!ReferenceEquals(npcsDic, null) && !ReferenceEquals(activitiesDic, null))
        {
            //set activity each npc
            foreach (KeyValuePair<string, Npc> npc in npcsDic)
            {
                string npcId = npc.Key;
                if (activitiesDic.ContainsKey(npcId))
                {
                    Dictionary<Day, List<Activity>> activity = new Dictionary<Day, List<Activity>>();
                    List<Activity> activities = new List<Activity>();
                    activity = activitiesDic[npcId].GetActivitiesDicByDay();
                    
                    //get activities in current day
                    if (activity.ContainsKey(currentDay))
                    {
                        activities = activity[currentDay];
                    }

                    //loop all activity in current day
                    int indexCurrentDay = 0;
                    for(int i = 0; i < activities.Count; i++)
                    {
                        Activity thisActivity = activities[i];
                        if(hour >= thisActivity.Start_time_hour && minute >= thisActivity.Start_time_minute)
                        {
                            indexCurrentDay = i;
                        }
                    }

                    Place currentPlaceActivity = activities[indexCurrentDay].Place;
                    Place currentPlaceNpc = npc.Value.CurrentPlace;
                    if(currentPlaceActivity != Place.Null)
                    {
                        if(currentPlaceNpc != currentPlaceActivity)
                        {
                            string currentPlaceActivityID = ConvertType.GetPlaceId(currentPlaceActivity);
                            string currentPlaceNpcID = ConvertType.GetPlaceId(currentPlaceNpc);
                            Arriver arriver = new Arriver(npcId, npc.Value.Icon, npc.Value.NormalImage, npc.Value.NpcName);
                            if (currentPlaceNpc == Place.Null || currentPlaceNpc == Place.Secret)
                            {
                                //if currentPlaceNpc null หรือ Secret
                                //not leave
                                if (placesController.PlacesDic.ContainsKey(currentPlaceActivityID))
                                {
                                    placesController.PlacesDic[currentPlaceActivityID].Arrived(arriver);
                                }
                            }
                            else
                            {
                                //else currentPlaceNpc != null หรือ != secret
                                //leave and arrived
                                if (placesController.PlacesDic.ContainsKey(currentPlaceNpcID) && placesController.PlacesDic.ContainsKey(currentPlaceActivityID)
                                    || currentPlaceActivity == Place.Secret)
                                {
                                    if (currentPlaceActivity == Place.Secret)
                                    {
                                        placesController.PlacesDic[currentPlaceNpcID].Leave(npcId);
                                    }
                                    else
                                    {
                                        placesController.PlacesDic[currentPlaceNpcID].Leave(npcId);
                                        placesController.PlacesDic[currentPlaceActivityID].Arrived(arriver);
                                    }

                                }

                            }
                            npc.Value.CurrentPlace = currentPlaceActivity;


                        }
                        
                    }
                    
                }
            }
        }
    }
}
