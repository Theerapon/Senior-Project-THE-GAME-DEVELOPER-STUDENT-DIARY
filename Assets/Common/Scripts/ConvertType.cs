﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Day { None, Mon, Tue, Wed, Thu, Fri, Sat, Sun }
public enum Place { Null, Secret, Home, Food, Clothing, Sell, Mystic, Park, Teacher, University, Exploration }
public enum CreateEvent { Null, CreateIdea, CreateItem }
public enum Feel { Normal, Happiness, Sadness, Fear, Disgust, Anger, Surprise }
public enum IdeaType { None, Goal, Mechanic, Theme, Platform, User }
public enum ItemDefinitionsType { ENERGY, COIN, EQUIPMENT, EMPTY };
public enum ItemEquipmentType { NONE, HAT, SHIRT, PANT, SHOES }

public class ConvertType : MonoBehaviour
{
    #region Instance NPC ID
    public static readonly string INST_SET_NpcId001 = "npc001";
    public static readonly string INST_SET_NpcId002 = "npc002";
    public static readonly string INST_SET_NpcId003 = "npc003";
    public static readonly string INST_SET_NpcId004 = "npc004";
    public static readonly string INST_SET_NpcId005 = "npc005";
    public static readonly string INST_SET_NpcId006 = "npc006";
    public static readonly string INST_SET_NpcId007 = "npc007";
    public static readonly string INST_SET_NpcId008 = "npc008";
    public static readonly string INST_SET_NpcId009 = "npc009";
    #endregion

    #region Day Instace
    private const string INST_Day_Mon = "Mon";
    private const string INST_Day_Tue = "Tue";
    private const string INST_Day_Wed = "Wed";
    private const string INST_Day_Thu = "Thu";
    private const string INST_Day_Fri = "Fri";
    private const string INST_Day_Sat = "Sat";
    private const string INST_Day_Sun = "Sun";
    #endregion

    public static Day CheckDay(string day)
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

    #region Place Instace
    private const string INST_Place_Null = "null";
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
    public static Place CheckPlace(string place)
    {
        Place placeTemp = Place.Null;

        switch (place)
        {
            case INST_Place_Null:
                placeTemp = Place.Null;
                break;
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

    #region Class Type Instance
    private const string INST_TYPE_Class = "Class";
    private const string INST_TYPE_Project = "Project";
    #endregion

    public static ClassActivityType CheckClassType(string type)
    {
        ClassActivityType typeTemp = ClassActivityType.Class;

        switch (type)
        {
            case INST_TYPE_Class:
                typeTemp = ClassActivityType.Class;
                break;
            case INST_TYPE_Project:
                typeTemp = ClassActivityType.Project;
                break;
        }

        return typeTemp;
    }

    public static string CheckString(string chat)
    {
        string temp = string.Empty;
        if (chat.Equals("null"))
        {
            temp = string.Empty;
        }
        else
        {
            temp = chat;
        }

        return temp;
    }

    #region Create Event Instace
    private const string INST_Event_Null = "null";
    private const string INST_Event_Idea = "idea";
    private const string INST_Event_Item = "item";
    #endregion
    public static CreateEvent CheckCreateEvent(string text)
    {
        CreateEvent temp = CreateEvent.Null;

        switch (text)
        {
            case INST_Event_Null:
                temp = CreateEvent.Null;
                break;
            case INST_Event_Idea:
                temp = CreateEvent.CreateIdea;
                break;
            case INST_Event_Item:
                temp = CreateEvent.CreateItem;
                break;
        }
        return temp;
    }


    #region Create Event Instace
    private const string INST_Feel_Normal = "Normal";
    private const string INST_Feel_Happiness = "Happiness";
    private const string INST_Feel_Sadness = "Sadness";
    private const string INST_Feel_Fear = "Fear";
    private const string INST_Feel_Disgust = "Disgust";
    private const string INST_Feel_Anger = "Anger";
    private const string INST_Feel_Surprise = "Surprise";
    #endregion
    public static Feel CheckFeel(string text)
    {
        Feel temp = Feel.Normal;

        switch (text)
        {
            case INST_Feel_Normal:
                temp = Feel.Normal;
                break;
            case INST_Feel_Happiness:
                temp = Feel.Happiness;
                break;
            case INST_Feel_Sadness:
                temp = Feel.Sadness;
                break;
            case INST_Feel_Fear:
                temp = Feel.Fear;
                break;
            case INST_Feel_Disgust:
                temp = Feel.Disgust;
                break;
            case INST_Feel_Anger:
                temp = Feel.Anger;
                break;
            case INST_Feel_Surprise:
                temp = Feel.Surprise;
                break;
        }
        return temp;
    }

    #region Idea Instace
    private const string INST_Idea_None = "None";
    private const string INST_Idea_Goal = "Goal";
    private const string INST_Idea_Mechanic = "Mechanic";
    private const string INST_Idea_Theme = "Theme";
    private const string INST_Idea_Platform = "Platform";
    private const string INST_Idea_User = "User";
    #endregion
    public static IdeaType CheckIdeaType(string text)
    {
        IdeaType temp = IdeaType.None;

        switch (text)
        {
            case INST_Idea_None:
                temp = IdeaType.None;
                break;
            case INST_Idea_Goal:
                temp = IdeaType.Goal;
                break;
            case INST_Idea_Mechanic:
                temp = IdeaType.Mechanic;
                break;
            case INST_Idea_Theme:
                temp = IdeaType.Theme;
                break;
            case INST_Idea_Platform:
                temp = IdeaType.Platform;
                break;
            case INST_Idea_User:
                temp = IdeaType.User;
                break;
        }
        return temp;
    }


    #region ItemEquipment Instace
    private const string INST_Eqipment_None = "NONE";
    private const string INST_Eqipment_Hat = "HAT";
    private const string INST_Eqipment_Shirt = "SHIRT";
    private const string INST_Eqipment_Pant = "PANT";
    private const string INST_Eqipment_Shoes = "SHOES";
    #endregion
    public static ItemEquipmentType CheckEquipmentType(string text)
    {
        ItemEquipmentType subType = ItemEquipmentType.NONE;
        switch (text)
        {
            case INST_Eqipment_None:
                subType = ItemEquipmentType.NONE;
                break;
            case INST_Eqipment_Hat:
                subType = ItemEquipmentType.HAT;
                break;
            case INST_Eqipment_Shirt:
                subType = ItemEquipmentType.SHIRT;
                break;
            case INST_Eqipment_Pant:
                subType = ItemEquipmentType.PANT;
                break;
            case INST_Eqipment_Shoes:
                subType = ItemEquipmentType.SHOES;
                break;
        }
        return subType;
    }

    #region ItemEquipment Instace
    private const string INST_DefinitionType_EMPTY = "EMPTY";
    private const string INST_DefinitionType_ENERGY = "ENERGY";
    private const string INST_DefinitionType_COIN = "COIN";
    private const string INST_DefinitionType_EQUIPMENT = "EQUIPMENT";
    #endregion
    public static ItemDefinitionsType CheckDefinitionsType(string type)
    {
        ItemDefinitionsType itemType = ItemDefinitionsType.EMPTY;
        switch (type)
        {
            case INST_DefinitionType_EMPTY:
                itemType = ItemDefinitionsType.EMPTY; 
                break;
            case INST_DefinitionType_ENERGY:
                itemType = ItemDefinitionsType.ENERGY;
                break;
            case INST_DefinitionType_COIN:
                itemType = ItemDefinitionsType.COIN;
                break;
            case INST_DefinitionType_EQUIPMENT:
                itemType = ItemDefinitionsType.EQUIPMENT;
                break;
        }
        return itemType;
    }
}
