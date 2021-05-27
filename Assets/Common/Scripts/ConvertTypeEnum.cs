using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertTypeEnum : MonoBehaviour
{
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
}
