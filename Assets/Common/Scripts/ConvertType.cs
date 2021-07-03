using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Day { None, Mon, Tue, Wed, Thu, Fri, Sat, Sun }
public enum PlaceType { None, Place, Home, Treasure }
public enum Place { Null, NotAtPlace, Home, Food, Clothing, Sell, Mystic, Park, Teacher, University, Treasure1, Treasure2, Treasure3, Treasure4, Treasure5 }
public enum CreateEvent { Null, CreateIdea}
public enum Feel { Normal, Happiness, Sadness, Fear, Disgust, Anger, Surprise }
public enum IdeaType { None, Goal, Mechanic, Theme, Platform, User }
public enum ItemDefinitionsType { Food, Treasure, Equipment}; 
public enum ItemEquipmentType { NONE, Hat, Shirt, Pant, Shoes }
public enum OnClickSwitchScene { None, UniversityScene, FoodScene, ClothingScene, TeacherScene, MysticScene, SellScene, ParkScene, TreasureScene }
public enum ItemPropertyType { None, Charm, BonusProject, BonusProjectGoldenTime, BonusMotivation, BonusMotivationGoldenTime, ReduceEnergyConsume, ReduceEnergyConsumeGoldenTime, ReduceChanceBug, ReduceCourseTime, ReduceTransportTime, IncreaseDropRate, Energy, MaxEnergy, Motivation, Coding, Design, Testing, Art, Sound, StatusPoint, SoftSkillPoint, CharacterExp, HSMathExp, HSProgramingExp, HSEngineExp, HSNetworkExp, HSAiExp, HSDesignExp, HSTesting, HSArtExp, HSSoundExp }
public enum BonusCharacter { Charm, BonusProject, BonusProjectGoldenTime, BonusMotivation, BonusMotivationGoldenTime, ReduceEnergyConsume, ReduceEnergyConsumeGoldenTime, ReduceChanceBug, ReduceCourseTime, ReduceTransportTime, IncreaseDropRate }
public enum ClassActivityType { None, Project, Class }
public enum ScheduleEvent { None, DiscountFoodStore, ClothingFestival101, ClothingFestival202, ClothingFestival303, ClothingFestival404, Project, Class, MysticFestival1st, MysticFestival2nd, MysticFestival3rd, MysticFestival4th, Birthday}
public enum ProjectPhase { Decision, Design, FirstPlayable, Prototype, VerticalSlice, AlphaTest, BetaTest, Master }
public enum HardSkillId { MATH, PROGRAMMING, GAMEENGINE, NETWORK, AI, DESIGN, TESTING, ART, SOUND }
public enum SoftSkillId { COMMUNICATION, CRITICALTHINKING, LEADERSHIP, TIMEMANAGEMENT, WORKETHIC }
public enum StatusID { Coding, Design, Testing, Art, Sound, Bug }
public enum StoreType { None, FoodStore, ClothingStore, MysticStore }

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
    #endregion

    public static ClassActivityType ConvertScheduleEventToClassActivityType(ScheduleEvent scheduleEvent)
    {
        if(scheduleEvent == ScheduleEvent.Project)
        {
            return ClassActivityType.Project;
        }
        else if(scheduleEvent == ScheduleEvent.Class)
        {
            return ClassActivityType.Class;
        }
        else
        {
            return ClassActivityType.None;
        }
    }

    public static string GetStringItemType(ItemDefinitionsType itemDefinitionsType, ItemEquipmentType itemEquipmentType)
    {
        if(itemDefinitionsType == ItemDefinitionsType.Equipment)
        {
            return itemEquipmentType.ToString();
        }
        else
        {
            return itemDefinitionsType.ToString();
        }

        
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
    public static int ConvertDayToIne(Day day)
    {
        int index = 0;
        switch (day)
        {
            case Day.Mon:
                index = 0;
                break;
            case Day.Tue:
                index = 1;
                break;
            case Day.Wed:
                index = 2;
                break;
            case Day.Thu:
                index = 3;
                break;
            case Day.Fri:
                index = 4;
                break;
            case Day.Sat:
                index = 5;
                break;
            case Day.Sun:
                index = 6;
                break;
        }
        return index;
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
                placeTemp = Place.NotAtPlace;
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
            default:
                placeTemp = Place.NotAtPlace;
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
                subType = ItemEquipmentType.Hat;
                break;
            case INST_Eqipment_Shirt:
                subType = ItemEquipmentType.Shirt;
                break;
            case INST_Eqipment_Pant:
                subType = ItemEquipmentType.Pant;
                break;
            case INST_Eqipment_Shoes:
                subType = ItemEquipmentType.Shoes;
                break;
        }
        return subType;
    }

    #region ItemEquipment Instace
    private const string INST_DefinitionType_TREASURE = "TREASURE";
    private const string INST_DefinitionType_FOOD = "FOOD";
    private const string INST_DefinitionType_EQUIPMENT = "EQUIPMENT";
    #endregion
    public static ItemDefinitionsType CheckDefinitionsType(string type)
    {
        ItemDefinitionsType itemType = ItemDefinitionsType.Treasure;
        switch (type)
        {
            case INST_DefinitionType_TREASURE:
                itemType = ItemDefinitionsType.Treasure;
                break;
            case INST_DefinitionType_FOOD:
                itemType = ItemDefinitionsType.Food;
                break;
            case INST_DefinitionType_EQUIPMENT:
                itemType = ItemDefinitionsType.Equipment;
                break;
        }
        return itemType;
    }

    #region Scene Instace
    private const string INST_Scene_HomeScene = "HomeScene";
    private const string INST_Scene_UniversityScene = "UniversityScene";
    private const string INST_Scene_FoodScene = "FoodScene"; 
    private const string INST_Scene_ClothingScene = "ClothingScene";
    private const string INST_Scene_TeacherScene = "TeacherScene";
    private const string INST_Scene_MysticScene = "MysticScene";
    private const string INST_Scene_SellScene = "SellScene";
    private const string INST_Scene_ParkScene = "ParkScene";
    private const string INST_Scene_TreasureScene = "TreasureScene";

    #endregion
    public static OnClickSwitchScene CheckOnClickSwitchScene(string text)
    {
        OnClickSwitchScene temp = OnClickSwitchScene.None;
        switch (text)
        {
            case INST_Scene_HomeScene:
                temp = OnClickSwitchScene.None;
                break;
            case INST_Scene_UniversityScene:
                temp = OnClickSwitchScene.UniversityScene;
                break;
            case INST_Scene_FoodScene:
                temp = OnClickSwitchScene.FoodScene;
                break;
            case INST_Scene_ClothingScene:
                temp = OnClickSwitchScene.ClothingScene;
                break;
            case INST_Scene_TeacherScene:
                temp = OnClickSwitchScene.TeacherScene;
                break;
            case INST_Scene_MysticScene:
                temp = OnClickSwitchScene.MysticScene;
                break;
            case INST_Scene_SellScene:
                temp = OnClickSwitchScene.SellScene;
                break;
            case INST_Scene_ParkScene:
                temp = OnClickSwitchScene.ParkScene;
                break;
            case INST_Scene_TreasureScene:
                temp = OnClickSwitchScene.TreasureScene;
                break;
        }
        return temp;
    }

    #region Item Property Instace
    private const string INST_Itemproperty_Charm = "Charm";
    private const string INST_Itemproperty_BonusProject = "BonusProject";
    private const string INST_Itemproperty_BonusProjectGoldenTime = "BonusProjectGoldenTime";
    private const string INST_Itemproperty_BonusMotivation = "BonusMotivation";
    private const string INST_Itemproperty_BonusMotivationGoldenTime = "BonusMotivationGoldenTime";
    private const string INST_Itemproperty_ReduceEnergyConsume = "ReduceEnergyConsume";
    private const string INST_Itemproperty_ReduceEnergyConsumeGoldenTime = "ReduceEnergyConsumeGoldenTime";
    private const string INST_Itemproperty_ReduceChanceBug = "ReduceChanceBug";
    private const string INST_Itemproperty_ReduceCourseTime = "ReduceCourseTime";
    private const string INST_Itemproperty_ReduceTransportTime = "ReduceTransportTime";
    private const string INST_Itemproperty_IncreaseDropRate = "IncreaseDropRate";
    private const string INST_Itemproperty_Energy = "Energy";
    private const string INST_Itemproperty_MaxEnergy = "MaxEnergy";
    private const string INST_Itemproperty_Motivation = "Motivation";
    private const string INST_Itemproperty_Coding = "Coding";
    private const string INST_Itemproperty_Design = "Design";
    private const string INST_Itemproperty_Testing = "Testing";
    private const string INST_Itemproperty_Art = "Art";
    private const string INST_Itemproperty_Sound = "Sound";
    private const string INST_Itemproperty_StatusPoint = "StatusPoint";
    private const string INST_Itemproperty_SoftSkillPoint = "SoftSkillPoint";
    private const string INST_Itemproperty_CharacterExp = "CharacterExp";
    private const string INST_Itemproperty_HSMathExp = "HSMathExp";
    private const string INST_Itemproperty_HSProgramingExp = "HSProgramingExp";
    private const string INST_Itemproperty_HSEngineExp = "HSEngineExp";
    private const string INST_Itemproperty_HSNetworkExp = "HSNetworkExp";
    private const string INST_Itemproperty_HSAiExp = "HSAiExp";
    private const string INST_Itemproperty_HSDesignExp = "HSDesignExp";
    private const string INST_Itemproperty_HSTesting = "HSTesting";
    private const string INST_Itemproperty_HSArtExp = "HSArtExp";
    private const string INST_Itemproperty_HSSoundExp = "HSSoundExp";


    #endregion
    public static ItemPropertyType CheckItemProperty(string text)
    {
        ItemPropertyType temp = ItemPropertyType.None;
        switch (text)
        {
            case INST_Itemproperty_Charm:
                temp = ItemPropertyType.Charm;
                break;
            case INST_Itemproperty_BonusProject:
                temp = ItemPropertyType.BonusProject;
                break;
            case INST_Itemproperty_BonusProjectGoldenTime:
                temp = ItemPropertyType.BonusProjectGoldenTime;
                break;
            case INST_Itemproperty_BonusMotivation:
                temp = ItemPropertyType.BonusMotivation;
                break;
            case INST_Itemproperty_BonusMotivationGoldenTime:
                temp = ItemPropertyType.BonusMotivationGoldenTime;
                break;
            case INST_Itemproperty_ReduceEnergyConsume:
                temp = ItemPropertyType.ReduceEnergyConsume;
                break;
            case INST_Itemproperty_ReduceEnergyConsumeGoldenTime:
                temp = ItemPropertyType.ReduceEnergyConsumeGoldenTime;
                break;
            case INST_Itemproperty_ReduceChanceBug:
                temp = ItemPropertyType.ReduceChanceBug;
                break;
            case INST_Itemproperty_ReduceCourseTime:
                temp = ItemPropertyType.ReduceCourseTime;
                break;
            case INST_Itemproperty_ReduceTransportTime:
                temp = ItemPropertyType.ReduceTransportTime;
                break;
            case INST_Itemproperty_IncreaseDropRate:
                temp = ItemPropertyType.IncreaseDropRate;
                break;
            case INST_Itemproperty_Energy:
                temp = ItemPropertyType.Energy;
                break;
            case INST_Itemproperty_MaxEnergy:
                temp = ItemPropertyType.MaxEnergy;
                break;
            case INST_Itemproperty_Motivation:
                temp = ItemPropertyType.Motivation;
                break;
            case INST_Itemproperty_Coding:
                temp = ItemPropertyType.Coding;
                break;
            case INST_Itemproperty_Design:
                temp = ItemPropertyType.Design;
                break;
            case INST_Itemproperty_Testing:
                temp = ItemPropertyType.Testing;
                break;
            case INST_Itemproperty_Art:
                temp = ItemPropertyType.Art;
                break;
            case INST_Itemproperty_Sound:
                temp = ItemPropertyType.Sound;
                break;
            case INST_Itemproperty_StatusPoint:
                temp = ItemPropertyType.StatusPoint;
                break;
            case INST_Itemproperty_SoftSkillPoint:
                temp = ItemPropertyType.SoftSkillPoint;
                break;
            case INST_Itemproperty_CharacterExp:
                temp = ItemPropertyType.CharacterExp;
                break;
            case INST_Itemproperty_HSMathExp:
                temp = ItemPropertyType.HSMathExp;
                break;
            case INST_Itemproperty_HSProgramingExp:
                temp = ItemPropertyType.HSProgramingExp;
                break;
            case INST_Itemproperty_HSEngineExp:
                temp = ItemPropertyType.HSEngineExp;
                break;
            case INST_Itemproperty_HSNetworkExp:
                temp = ItemPropertyType.HSNetworkExp;
                break;
            case INST_Itemproperty_HSAiExp:
                temp = ItemPropertyType.HSAiExp;
                break;
            case INST_Itemproperty_HSDesignExp:
                temp = ItemPropertyType.HSDesignExp;
                break;
            case INST_Itemproperty_HSTesting:
                temp = ItemPropertyType.HSTesting;
                break;
            case INST_Itemproperty_HSArtExp:
                temp = ItemPropertyType.HSArtExp;
                break;
            case INST_Itemproperty_HSSoundExp:
                temp = ItemPropertyType.HSSoundExp;
                break;


        }
        return temp;
    }


    #region Schedule Event Instace
    private const string INST_Schedule_None = "None";
    private const string INST_Schedule_DiscountFoodStore = "DiscountFoodStore";
    private const string INST_Schedule_ClothingFestival101 = "ClothingFestival101";
    private const string INST_Schedule_ClothingFestival202 = "ClothingFestival202";
    private const string INST_Schedule_ClothingFestival303 = "ClothingFestival303";
    private const string INST_Schedule_ClothingFestival404 = "ClothingFestival404";
    private const string INST_Schedule_Project = "Project";
    private const string INST_Schedule_Class = "Class";
    private const string INST_Schedule_MysticFestival1st = "MysticFestival1st";
    private const string INST_Schedule_MysticFestival2nd = "MysticFestival2nd";
    private const string INST_Schedule_MysticFestival3rd = "MysticFestival3rd";
    private const string INST_Schedule_MysticFestival4th = "MysticFestival4th";
    private const string INST_Schedule_Birthday = "Birthday";
    #endregion
    public static ScheduleEvent CheckScheuleEvent(string text)
    {
        ScheduleEvent temp = ScheduleEvent.None;
        switch (text)
        {
            case INST_Schedule_None:
                temp = ScheduleEvent.None;
                break;
            case INST_Schedule_DiscountFoodStore:
                temp = ScheduleEvent.DiscountFoodStore;
                break;
            case INST_Schedule_ClothingFestival101:
                temp = ScheduleEvent.ClothingFestival101;
                break;
            case INST_Schedule_ClothingFestival202:
                temp = ScheduleEvent.ClothingFestival202;
                break;
            case INST_Schedule_ClothingFestival303:
                temp = ScheduleEvent.ClothingFestival303;
                break;
            case INST_Schedule_ClothingFestival404:
                temp = ScheduleEvent.ClothingFestival404;
                break;
            case INST_Schedule_Project:
                temp = ScheduleEvent.Project;
                break;
            case INST_Schedule_Class:
                temp = ScheduleEvent.Class;
                break;
            case INST_Schedule_MysticFestival1st:
                temp = ScheduleEvent.MysticFestival1st;
                break;
            case INST_Schedule_MysticFestival2nd:
                temp = ScheduleEvent.MysticFestival2nd;
                break;
            case INST_Schedule_MysticFestival3rd:
                temp = ScheduleEvent.MysticFestival3rd;
                break;
            case INST_Schedule_MysticFestival4th:
                temp = ScheduleEvent.MysticFestival4th;
                break;
            case INST_Schedule_Birthday:
                temp = ScheduleEvent.Birthday;
                break;

        }
        return temp;
    }


    #region Instace IdeaType
    private const string INST_Goal = "เป้าหมาย";
    private const string INST_Mechanic = "กลไก";
    private const string INST_Theme = "ธีม";
    private const string INST_Default = "ไอเดีย";
    #endregion

    public static string ConvertIdeaTypeToString(IdeaType ideaType)
    {
        string unit = string.Empty;
        switch (ideaType)
        {
            case IdeaType.Goal:
                unit = INST_Goal;
                break;
            case IdeaType.Mechanic:
                unit = INST_Mechanic;
                break;
            case IdeaType.Theme:
                unit = INST_Theme;
                break;
            default:
                unit = INST_Default;
                break;
        }
        return unit;
    }

    #region Instace Place Id
    private const string Inst_PlaceId_Home = "place000";
    private const string Inst_PlaceId_University = "place001";
    private const string Inst_PlaceId_FoodScene = "place002";
    private const string Inst_PlaceId_Clothing = "place003";
    private const string Inst_PlaceId_Teacher = "place004";
    private const string Inst_PlaceId_Mystic = "place005";
    private const string Inst_PlaceId_Sell = "place006";
    private const string Inst_PlaceId_Park = "place007";
    private const string Inst_PlaceId_Treasure1 = "place008";
    private const string Inst_PlaceId_Treasure2 = "place009";
    private const string Inst_PlaceId_Treasure3 = "place010";
    private const string Inst_PlaceId_Treasure4 = "place011";
    private const string Inst_PlaceId_Treasure5 = "place012";
    #endregion

    public static string GetPlaceId(Place place)
    {
        string str = string.Empty;
        switch (place)
        {
            case Place.Home:
                str = Inst_PlaceId_Home;
                break;
            case Place.Clothing:
                str = Inst_PlaceId_Clothing;
                break;
            case Place.Food:
                str = Inst_PlaceId_FoodScene;
                break;
            case Place.Mystic:
                str = Inst_PlaceId_Mystic;
                break;
            case Place.Park:
                str = Inst_PlaceId_Park;
                break;
            case Place.Sell:
                str = Inst_PlaceId_Sell;
                break;
            case Place.Teacher:
                str = Inst_PlaceId_Teacher;
                break;
            case Place.University:
                str = Inst_PlaceId_University;
                break;
            case Place.Treasure1:
                str = Inst_PlaceId_Treasure1;
                break;
            case Place.Treasure2:
                str = Inst_PlaceId_Treasure2;
                break;
            case Place.Treasure3:
                str = Inst_PlaceId_Treasure3;
                break;
            case Place.Treasure4:
                str = Inst_PlaceId_Treasure4;
                break;
            case Place.Treasure5:
                str = Inst_PlaceId_Treasure5;
                break;
            default:
                str = string.Empty;
                break;
        }
        return str;
    }

    #region Place Type
    private const string INST_PlaceType_Place = "Place";
    private const string INST_PlaceType_Home = "Home";
    private const string INST_PlaceType_Treasure = "Treasure";
    #endregion
    public static PlaceType ConvertPlaceType(string place)
    {
        PlaceType type = PlaceType.None;
        switch (place)
        {
            case INST_PlaceType_Place:
                type = PlaceType.Place;
                break;
            case INST_PlaceType_Home:
                type = PlaceType.Home;
                break;
            case INST_PlaceType_Treasure:
                type = PlaceType.Treasure;
                break;
            default:
                type = PlaceType.None;
                break;
        }
        return type;
    }

    #region Instace Store Id
    private const string Inst_StoreId_Food = "store001";
    private const string Inst_StoreId_Clothing = "store002";
    private const string Inst_StoreId_Mystic = "store003";
    #endregion

    public static string GetStoreId(StoreType type)
    {
        string str = string.Empty;
        switch (type)
        {
            case StoreType.FoodStore:
                str = Inst_StoreId_Food;
                break;
            case StoreType.ClothingStore:
                str = Inst_StoreId_Clothing;
                break;
            case StoreType.MysticStore:
                str = Inst_StoreId_Mystic;
                break;
            default:
                str = string.Empty;
                break;
        }
        return str;
    }
    #region Instace Store Type
    private const string Inst_StoreType_Food = "Food";
    private const string Inst_StoreType_Clothing = "Clothing";
    private const string Inst_StoreType_Mystic = "Mystic";
    #endregion

    public static StoreType ConvertStoreType(string type)
    {
        StoreType storeType = StoreType.None;
        switch (type)
        {
            case Inst_StoreType_Food:
                storeType = StoreType.FoodStore;
                break;
            case Inst_StoreType_Clothing:
                storeType = StoreType.ClothingStore;
                break;
            case Inst_StoreType_Mystic:
                storeType = StoreType.MysticStore;
                break;
        }
        return storeType;
    }
}
