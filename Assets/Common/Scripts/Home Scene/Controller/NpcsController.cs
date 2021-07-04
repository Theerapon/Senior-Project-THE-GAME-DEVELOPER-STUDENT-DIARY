using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActivitiesNpc_Template;
using static PlaceEntry;
using static TimeManager;

public class NpcsController : Manager<NpcsController>
{
    public Events.EventOnHasPlaceArriverUpdate OnHasPlaceArriverUpdate;
    [SerializeField] private PlacesController placesController;
    [SerializeField] private TimeManager timeManager;

    private FavoriteItems_DataHandler _favoriteItems_DataHandler;
    private Dictionary<string, FavoriteItems_Template> _favoriteItemsDic;

    private Npcs_DataHandler npcs_DataHandler;
    private Dictionary<string, Npc> npcsDic;

    private ActivitiesNPC_DataHandler activitiesNPC_DataHandler;
    private Dictionary<string, ActivitiesNpc_Template> activitiesDic;

    public Dictionary<string, Npc> NpcsDic { get => npcsDic; }
    public Dictionary<string, FavoriteItems_Template> FavoriteItemsDic { get => _favoriteItemsDic; }

    private static float minute, hour, date, second, month, year;
    private Day currentDay;

    protected override void Awake()
    {
        base.Awake();
        npcs_DataHandler = FindObjectOfType<Npcs_DataHandler>();
        npcsDic = new Dictionary<string, Npc>();

        activitiesNPC_DataHandler = FindObjectOfType<ActivitiesNPC_DataHandler>();
        activitiesDic = new Dictionary<string, ActivitiesNpc_Template>();

        _favoriteItems_DataHandler = FindObjectOfType<FavoriteItems_DataHandler>();
        _favoriteItemsDic = new Dictionary<string, FavoriteItems_Template>();

        timeManager.OnTenMinute.AddListener(OnTenMinuteHandler);
        timeManager.OnStartNewDayComplete.AddListener(OnNewDayHandler);

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

        //favorite Items
        if (!ReferenceEquals(_favoriteItems_DataHandler.GetFavoriteItemDic, null))
        {
            foreach (KeyValuePair<string, FavoriteItems_Template> item in _favoriteItems_DataHandler.GetFavoriteItemDic)
            {
                _favoriteItemsDic.Add(item.Key, item.Value);
            }
        }
    }

    private void OnNewDayHandler()
    {
        if (!ReferenceEquals(npcsDic, null))
        {
            foreach (KeyValuePair<string, Npc> npc in npcsDic)
            {
                npc.Value.SetOnNewDay();
            }
        }
    }

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
                            Arriver arriver = npc.Value.Arriver;
                            if (currentPlaceNpc == Place.Null || currentPlaceNpc == Place.NotAtPlace)
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
                                    || currentPlaceActivity == Place.NotAtPlace)
                                {
                                    if (currentPlaceActivity == Place.NotAtPlace)
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
                            OnHasPlaceArriverUpdate?.Invoke();
                        }
                        
                    }
                    
                }
            }
        }
    }
}
