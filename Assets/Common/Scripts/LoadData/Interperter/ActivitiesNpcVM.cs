using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActivitiesNpc_Template;

public class ActivitiesNpcVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_NpcID = "NpcID";
    private const string INST_SET_Date = "Date";
    private const string INST_SET_StartTime = "StartTime";
    private const string INST_SET_EndTime = "EndTime";
    private const string INST_SET_Place = "Place";
    private const string INST_SET_CanChat = "CanChat";
    #endregion

    #region Instance NPC ID
    private const string INST_SET_Npc1 = "npc001";
    private const string INST_SET_Npc2 = "npc002";
    private const string INST_SET_Npc3 = "npc003";
    private const string INST_SET_Npc4 = "npc004";
    private const string INST_SET_Npc5 = "npc005";
    private const string INST_SET_Npc6 = "npc006";
    private const string INST_SET_Npc7 = "npc007";
    private const string INST_SET_Npc8 = "npc008";
    private const string INST_SET_Npc9 = "npc009";
    #endregion

    [SerializeField] private ActivitiesNPC_Loading activitiesNPC_Loading;

    public Dictionary<string, ActivitiesNpc_Template> Interpert()
    {
        if (!ReferenceEquals(activitiesNPC_Loading, null))
        {
            Dictionary<string, ActivitiesNpc_Template> dic = new Dictionary<string, ActivitiesNpc_Template>();

            #region Instace NPC

            #region NPC1
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc1 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc1 = new List<Activity>();
            List<Activity> activityListTueOnNpc1 = new List<Activity>();
            List<Activity> activityListWedOnNpc1 = new List<Activity>();
            List<Activity> activityListThuOnNpc1 = new List<Activity>();
            List<Activity> activityListFriOnNpc1 = new List<Activity>();
            List<Activity> activityListSatOnNpc1 = new List<Activity>();
            List<Activity> activityListSunOnNpc1 = new List<Activity>();
            #endregion

            #region NPC2
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc2 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc2 = new List<Activity>();
            List<Activity> activityListTueOnNpc2 = new List<Activity>();
            List<Activity> activityListWedOnNpc2 = new List<Activity>();
            List<Activity> activityListThuOnNpc2 = new List<Activity>();
            List<Activity> activityListFriOnNpc2 = new List<Activity>();
            List<Activity> activityListSatOnNpc2 = new List<Activity>();
            List<Activity> activityListSunOnNpc2 = new List<Activity>();
            #endregion

            #region NPC3
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc3 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc3 = new List<Activity>();
            List<Activity> activityListTueOnNpc3 = new List<Activity>();
            List<Activity> activityListWedOnNpc3 = new List<Activity>();
            List<Activity> activityListThuOnNpc3 = new List<Activity>();
            List<Activity> activityListFriOnNpc3 = new List<Activity>();
            List<Activity> activityListSatOnNpc3 = new List<Activity>();
            List<Activity> activityListSunOnNpc3 = new List<Activity>();
            #endregion

            #region NPC4
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc4 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc4 = new List<Activity>();
            List<Activity> activityListTueOnNpc4 = new List<Activity>();
            List<Activity> activityListWedOnNpc4 = new List<Activity>();
            List<Activity> activityListThuOnNpc4 = new List<Activity>();
            List<Activity> activityListFriOnNpc4 = new List<Activity>();
            List<Activity> activityListSatOnNpc4 = new List<Activity>();
            List<Activity> activityListSunOnNpc4 = new List<Activity>();
            #endregion

            #region NPC5
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc5 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc5 = new List<Activity>();
            List<Activity> activityListTueOnNpc5 = new List<Activity>();
            List<Activity> activityListWedOnNpc5 = new List<Activity>();
            List<Activity> activityListThuOnNpc5 = new List<Activity>();
            List<Activity> activityListFriOnNpc5 = new List<Activity>();
            List<Activity> activityListSatOnNpc5 = new List<Activity>();
            List<Activity> activityListSunOnNpc5 = new List<Activity>();
            #endregion

            #region NPC6
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc6 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc6 = new List<Activity>();
            List<Activity> activityListTueOnNpc6 = new List<Activity>();
            List<Activity> activityListWedOnNpc6 = new List<Activity>();
            List<Activity> activityListThuOnNpc6 = new List<Activity>();
            List<Activity> activityListFriOnNpc6 = new List<Activity>();
            List<Activity> activityListSatOnNpc6 = new List<Activity>();
            List<Activity> activityListSunOnNpc6 = new List<Activity>();
            #endregion

            #region NPC7
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc7 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc7 = new List<Activity>();
            List<Activity> activityListTueOnNpc7 = new List<Activity>();
            List<Activity> activityListWedOnNpc7 = new List<Activity>();
            List<Activity> activityListThuOnNpc7 = new List<Activity>();
            List<Activity> activityListFriOnNpc7 = new List<Activity>();
            List<Activity> activityListSatOnNpc7 = new List<Activity>();
            List<Activity> activityListSunOnNpc7 = new List<Activity>();
            #endregion

            #region NPC8
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc8 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc8 = new List<Activity>();
            List<Activity> activityListTueOnNpc8 = new List<Activity>();
            List<Activity> activityListWedOnNpc8 = new List<Activity>();
            List<Activity> activityListThuOnNpc8 = new List<Activity>();
            List<Activity> activityListFriOnNpc8 = new List<Activity>();
            List<Activity> activityListSatOnNpc8 = new List<Activity>();
            List<Activity> activityListSunOnNpc8 = new List<Activity>();
            #endregion

            #region NPC9
            Dictionary<Day, List<Activity>> dic_activity_byDayOnNpc9 = new Dictionary<Day, List<Activity>>();
            List<Activity> activityListMonOnNpc9 = new List<Activity>();
            List<Activity> activityListTueOnNpc9 = new List<Activity>();
            List<Activity> activityListWedOnNpc9 = new List<Activity>();
            List<Activity> activityListThuOnNpc9 = new List<Activity>();
            List<Activity> activityListFriOnNpc9 = new List<Activity>();
            List<Activity> activityListSatOnNpc9 = new List<Activity>();
            List<Activity> activityListSunOnNpc9 = new List<Activity>();
            #endregion

            #endregion

            foreach (KeyValuePair<string, string> line in activitiesNPC_Loading.textLists)
            {
                Activity activityDetail = null;

                string key = line.Key;
                string value = line.Value;

                activityDetail = CreateTemplate(value);

                if (!ReferenceEquals(activityDetail, null))
                {

                    #region ByNpc
                    if (activityDetail.npc_id.Equals(INST_SET_Npc1))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc1.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc1.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc1.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc1.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc1.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc1.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc1.Add(activityDetail);
                                break;

                        }
                    }
                    else if (activityDetail.npc_id.Equals(INST_SET_Npc2))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc2.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc2.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc2.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc2.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc2.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc2.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc2.Add(activityDetail);
                                break;

                        }
                    }
                    else if (activityDetail.npc_id.Equals(INST_SET_Npc3))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc3.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc3.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc3.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc3.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc3.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc3.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc3.Add(activityDetail);
                                break;

                        }
                    }
                    else if (activityDetail.npc_id.Equals(INST_SET_Npc4))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc4.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc4.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc4.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc4.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc4.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc4.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc4.Add(activityDetail);
                                break;

                        }
                    }
                    else if (activityDetail.npc_id.Equals(INST_SET_Npc5))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc5.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc5.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc5.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc5.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc5.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc5.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc5.Add(activityDetail);
                                break;

                        }
                    }
                    else if (activityDetail.npc_id.Equals(INST_SET_Npc6))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc6.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc6.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc6.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc6.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc6.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc6.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc6.Add(activityDetail);
                                break;

                        }
                    }
                    else if (activityDetail.npc_id.Equals(INST_SET_Npc7))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc7.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc7.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc7.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc7.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc7.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc7.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc7.Add(activityDetail);
                                break;

                        }
                    }
                    else if (activityDetail.npc_id.Equals(INST_SET_Npc8))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc8.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc8.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc8.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc8.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc8.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc8.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc8.Add(activityDetail);
                                break;

                        }
                    }
                    else if (activityDetail.npc_id.Equals(INST_SET_Npc9))
                    {
                        switch (activityDetail.day)
                        {
                            case Day.Mon:
                                activityListMonOnNpc9.Add(activityDetail);
                                break;
                            case Day.Tue:
                                activityListTueOnNpc9.Add(activityDetail);
                                break;
                            case Day.Wed:
                                activityListWedOnNpc9.Add(activityDetail);
                                break;
                            case Day.Thu:
                                activityListThuOnNpc9.Add(activityDetail);
                                break;
                            case Day.Fri:
                                activityListFriOnNpc9.Add(activityDetail);
                                break;
                            case Day.Sat:
                                activityListSatOnNpc9.Add(activityDetail);
                                break;
                            case Day.Sun:
                                activityListSunOnNpc9.Add(activityDetail);
                                break;

                        }
                    }
                    #endregion

                }

            }

            dic_activity_byDayOnNpc1.Clear();
            dic_activity_byDayOnNpc1.Add(Day.Mon, activityListMonOnNpc1);
            dic_activity_byDayOnNpc1.Add(Day.Tue, activityListTueOnNpc1);
            dic_activity_byDayOnNpc1.Add(Day.Wed, activityListWedOnNpc1);
            dic_activity_byDayOnNpc1.Add(Day.Thu, activityListThuOnNpc1);
            dic_activity_byDayOnNpc1.Add(Day.Fri, activityListFriOnNpc1);
            dic_activity_byDayOnNpc1.Add(Day.Sat, activityListSatOnNpc1);
            dic_activity_byDayOnNpc1.Add(Day.Sun, activityListSunOnNpc1);

            dic_activity_byDayOnNpc2.Clear();
            dic_activity_byDayOnNpc2.Add(Day.Mon, activityListMonOnNpc2);
            dic_activity_byDayOnNpc2.Add(Day.Tue, activityListTueOnNpc2);
            dic_activity_byDayOnNpc2.Add(Day.Wed, activityListWedOnNpc2);
            dic_activity_byDayOnNpc2.Add(Day.Thu, activityListThuOnNpc2);
            dic_activity_byDayOnNpc2.Add(Day.Fri, activityListFriOnNpc2);
            dic_activity_byDayOnNpc2.Add(Day.Sat, activityListSatOnNpc2);
            dic_activity_byDayOnNpc2.Add(Day.Sun, activityListSunOnNpc2);

            dic_activity_byDayOnNpc3.Clear();
            dic_activity_byDayOnNpc3.Add(Day.Mon, activityListMonOnNpc3);
            dic_activity_byDayOnNpc3.Add(Day.Tue, activityListTueOnNpc3);
            dic_activity_byDayOnNpc3.Add(Day.Wed, activityListWedOnNpc3);
            dic_activity_byDayOnNpc3.Add(Day.Thu, activityListThuOnNpc3);
            dic_activity_byDayOnNpc3.Add(Day.Fri, activityListFriOnNpc3);
            dic_activity_byDayOnNpc3.Add(Day.Sat, activityListSatOnNpc3);
            dic_activity_byDayOnNpc3.Add(Day.Sun, activityListSunOnNpc3);

            dic_activity_byDayOnNpc4.Clear();
            dic_activity_byDayOnNpc4.Add(Day.Mon, activityListMonOnNpc4);
            dic_activity_byDayOnNpc4.Add(Day.Tue, activityListTueOnNpc4);
            dic_activity_byDayOnNpc4.Add(Day.Wed, activityListWedOnNpc4);
            dic_activity_byDayOnNpc4.Add(Day.Thu, activityListThuOnNpc4);
            dic_activity_byDayOnNpc4.Add(Day.Fri, activityListFriOnNpc4);
            dic_activity_byDayOnNpc4.Add(Day.Sat, activityListSatOnNpc4);
            dic_activity_byDayOnNpc4.Add(Day.Sun, activityListSunOnNpc4);

            dic_activity_byDayOnNpc5.Clear();
            dic_activity_byDayOnNpc5.Add(Day.Mon, activityListMonOnNpc5);
            dic_activity_byDayOnNpc5.Add(Day.Tue, activityListTueOnNpc5);
            dic_activity_byDayOnNpc5.Add(Day.Wed, activityListWedOnNpc5);
            dic_activity_byDayOnNpc5.Add(Day.Thu, activityListThuOnNpc5);
            dic_activity_byDayOnNpc5.Add(Day.Fri, activityListFriOnNpc5);
            dic_activity_byDayOnNpc5.Add(Day.Sat, activityListSatOnNpc5);
            dic_activity_byDayOnNpc5.Add(Day.Sun, activityListSunOnNpc5);

            dic_activity_byDayOnNpc6.Clear();
            dic_activity_byDayOnNpc6.Add(Day.Mon, activityListMonOnNpc6);
            dic_activity_byDayOnNpc6.Add(Day.Tue, activityListTueOnNpc6);
            dic_activity_byDayOnNpc6.Add(Day.Wed, activityListWedOnNpc6);
            dic_activity_byDayOnNpc6.Add(Day.Thu, activityListThuOnNpc6);
            dic_activity_byDayOnNpc6.Add(Day.Fri, activityListFriOnNpc6);
            dic_activity_byDayOnNpc6.Add(Day.Sat, activityListSatOnNpc6);
            dic_activity_byDayOnNpc6.Add(Day.Sun, activityListSunOnNpc6);

            dic_activity_byDayOnNpc7.Clear();
            dic_activity_byDayOnNpc7.Add(Day.Mon, activityListMonOnNpc7);
            dic_activity_byDayOnNpc7.Add(Day.Tue, activityListTueOnNpc7);
            dic_activity_byDayOnNpc7.Add(Day.Wed, activityListWedOnNpc7);
            dic_activity_byDayOnNpc7.Add(Day.Thu, activityListThuOnNpc7);
            dic_activity_byDayOnNpc7.Add(Day.Fri, activityListFriOnNpc7);
            dic_activity_byDayOnNpc7.Add(Day.Sat, activityListSatOnNpc7);
            dic_activity_byDayOnNpc7.Add(Day.Sun, activityListSunOnNpc7);

            dic_activity_byDayOnNpc8.Clear();
            dic_activity_byDayOnNpc8.Add(Day.Mon, activityListMonOnNpc8);
            dic_activity_byDayOnNpc8.Add(Day.Tue, activityListTueOnNpc8);
            dic_activity_byDayOnNpc8.Add(Day.Wed, activityListWedOnNpc8);
            dic_activity_byDayOnNpc8.Add(Day.Thu, activityListThuOnNpc8);
            dic_activity_byDayOnNpc8.Add(Day.Fri, activityListFriOnNpc8);
            dic_activity_byDayOnNpc8.Add(Day.Sat, activityListSatOnNpc8);
            dic_activity_byDayOnNpc8.Add(Day.Sun, activityListSunOnNpc8);

            dic_activity_byDayOnNpc9.Clear();
            dic_activity_byDayOnNpc9.Add(Day.Mon, activityListMonOnNpc9);
            dic_activity_byDayOnNpc9.Add(Day.Tue, activityListTueOnNpc9);
            dic_activity_byDayOnNpc9.Add(Day.Wed, activityListWedOnNpc9);
            dic_activity_byDayOnNpc9.Add(Day.Thu, activityListThuOnNpc9);
            dic_activity_byDayOnNpc9.Add(Day.Fri, activityListFriOnNpc9);
            dic_activity_byDayOnNpc9.Add(Day.Sat, activityListSatOnNpc9);
            dic_activity_byDayOnNpc9.Add(Day.Sun, activityListSunOnNpc9);

            dic.Clear();
            dic.Add(INST_SET_Npc1, new ActivitiesNpc_Template(dic_activity_byDayOnNpc1));
            dic.Add(INST_SET_Npc2, new ActivitiesNpc_Template(dic_activity_byDayOnNpc2));
            dic.Add(INST_SET_Npc3, new ActivitiesNpc_Template(dic_activity_byDayOnNpc3));
            dic.Add(INST_SET_Npc4, new ActivitiesNpc_Template(dic_activity_byDayOnNpc4));
            dic.Add(INST_SET_Npc5, new ActivitiesNpc_Template(dic_activity_byDayOnNpc5));
            dic.Add(INST_SET_Npc6, new ActivitiesNpc_Template(dic_activity_byDayOnNpc6));
            dic.Add(INST_SET_Npc7, new ActivitiesNpc_Template(dic_activity_byDayOnNpc7));
            dic.Add(INST_SET_Npc8, new ActivitiesNpc_Template(dic_activity_byDayOnNpc8));
            dic.Add(INST_SET_Npc9, new ActivitiesNpc_Template(dic_activity_byDayOnNpc9));

            if (!ReferenceEquals(dic, null))
            {
                return dic;
            }
        }

        return null;
    }

    private Activity CreateTemplate(string line)
    {
        string id = string.Empty;
        string npc_id = string.Empty;
        Day day = Day.None;
        int start_time_hour = 0;
        int start_time_minute = 0;
        int end_time_hour = 0;
        int end_time_minute = 0;
        Place place = Place.Secret;
        bool can_chat = false;
        string chat = string.Empty;

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_NpcID:
                    npc_id = entries[++i];
                    break;
                case INST_SET_Date:
                    day = CheckDay(entries[++i]);
                    break;
                case INST_SET_StartTime:
                    string start_time = entries[++i];
                    string[] startTime_entries = start_time.Split(':');
                    start_time_hour = int.Parse(startTime_entries[0]);
                    start_time_minute = int.Parse(startTime_entries[1]);
                    break;
                case INST_SET_EndTime:
                    string end_time = entries[++i];
                    string[] endTime_entries = end_time.Split(':');
                    end_time_hour = int.Parse(endTime_entries[0]);
                    end_time_minute = int.Parse(endTime_entries[1]);
                    break;
                case INST_SET_Place:
                    place = CheckPlace(entries[++i]);
                    break;
                case INST_SET_CanChat:
                    can_chat = bool.Parse(entries[++i]);
                    string chatTmep = entries[++i];
                    if (chatTmep.Equals("null"))
                    {
                        chat = string.Empty;
                    }
                    else
                    {
                        chat = chatTmep;
                    }
                    break;

            }

        }
        return new Activity(id, npc_id, day, start_time_hour, start_time_minute, end_time_hour, end_time_minute, place, can_chat, chat);
    }

    #region Day Instace
    private const string INST_Day_Mon = "Mon";
    private const string INST_Day_Tue = "Tue";
    private const string INST_Day_Wed = "Wed";
    private const string INST_Day_Thu = "Thu";
    private const string INST_Day_Fri = "Fri";
    private const string INST_Day_Sat = "Sat";
    private const string INST_Day_Sun = "Sun";
    #endregion

    private Day CheckDay(string day)
    {
        Day dayTemp = Day.None;

        switch (day)
        {
            case INST_Day_Mon:
                dayTemp = Day.Mon;
                break;
            case INST_Day_Tue:
                dayTemp = Day.Tue;
                break;
            case INST_Day_Wed:
                dayTemp = Day.Wed;
                break;
            case INST_Day_Thu:
                dayTemp = Day.Thu;
                break;
            case INST_Day_Fri:
                dayTemp = Day.Fri;
                break;
            case INST_Day_Sat:
                dayTemp = Day.Sat;
                break;
            case INST_Day_Sun:
                dayTemp = Day.Sun;
                break;
            default:
                dayTemp = Day.None;
                break;
        }
        return dayTemp;
    }


    #region Day Instace
    private const string INST_Place_Secret = "Secret";
    private const string INST_Place_Home = "Home";
    private const string INST_Place_Food = "Food";
    private const string INST_Place_Clothing = "Clothing";
    private const string INST_Place_Sell = "Sell";
    private const string INST_Place_Mystic = "Mystic";
    private const string INST_Place_Park = "Park";
    private const string INST_Place_Teacher = "Teacher";
    private const string INST_Place_University = "University";
    private const string INST_Place_Exploration = "Exploration";
    #endregion
    private Place CheckPlace(string place)
    {
        Place placeTemp = Place.Secret;

        switch (place)
        {
            case INST_Place_Secret:
                placeTemp = Place.Secret;
                break;
            case INST_Place_Home:
                placeTemp = Place.Home;
                break;
            case INST_Place_Food:
                placeTemp = Place.Food;
                break;
            case INST_Place_Clothing:
                placeTemp = Place.Clothing;
                break;
            case INST_Place_Sell:
                placeTemp = Place.Sell;
                break;
            case INST_Place_Mystic:
                placeTemp = Place.Mystic;
                break;
            case INST_Place_Park:
                placeTemp = Place.Park;
                break;
            case INST_Place_Teacher:
                placeTemp = Place.Teacher;
                break;
            case INST_Place_University:
                placeTemp = Place.University;
                break;
            case INST_Place_Exploration:
                placeTemp = Place.Exploration;
                break;
            default:
                placeTemp = Place.Secret;
                break;
        }
        return placeTemp;
    }
}
