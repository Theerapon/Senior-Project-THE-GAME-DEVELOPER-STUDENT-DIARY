using System;
using UnityEditor;
using UnityEngine;

public enum CourseType { NONE, MATH, PROGRAM, ENGINE, AI, NERWORK, ART, DESIGN, TESTING, AUDIO }
public enum LevelRecommended { All_LEVELS, BEGINNER, INTERMEDIATE, EXPERT }
[CreateAssetMenu(fileName = "NewCourse", menuName = "Course", order = 0)]
public class Course_SO : ScriptableObject
{
    [SerializeField] private string id;
    public string ID { get { return id; } }

    [Header("Detail")]
    [SerializeField] private string nameCourse = "";
    [SerializeField] private string nameAuthor = "";
    [SerializeField] private string description = "";
    [SerializeField] private int priceCourse = 0;
    [SerializeField] private bool isCollected = false;
    [SerializeField] private int secondToConsume;
    [SerializeField] private int energyToConsume;
    [SerializeField] private int motivationToConsume;

    [Header("Exp Rewards")]
    [SerializeField] private int defaultMathExpReward;
    [SerializeField] private int defaultProgrammingExpReward;
    [SerializeField] private int defaultEngineExpReward;
    [SerializeField] private int defaultAiExpReward;
    [SerializeField] private int defaultNetwordExpReward;
    [SerializeField] private int defaultDesignExpReward;
    [SerializeField] private int defaultArtExpReward;
    [SerializeField] private int defaultSoundExpReward;
    [SerializeField] private int defaultTestingExpReward;

    [Header("Stat Rewards")]
    [SerializeField] private int defaultCodingStatReward;
    [SerializeField] private int defaultDesignStatReward;
    [SerializeField] private int defaultArtStatReward;
    [SerializeField] private int defaultTestingStatReward;
    [SerializeField] private int defaultSoundStatReward;

    [SerializeField] private CourseType[] courseTypeNum;
    [SerializeField] private LevelRecommended courseRecommended;


    public void IsCollected()
    {
        isCollected = true;
    }
    public void UnIsCollected()
    {
        isCollected = false;
    }

    #region Reporter
    public bool GetCourseCollected()
    {
        return isCollected;
    }
    public int GetSecondToConsume()
    {
        return secondToConsume;
    }
    public int GetEnergyToConsume()
    {
        return energyToConsume;
    }
    public int GetdefaultMathExpReward()
    {
        return defaultMathExpReward;
    }
    public int GetdefaultProgrammingExpReward()
    {
        return defaultProgrammingExpReward;
    }
    public int GetdefaultEngineExpReward()
    {
        return defaultEngineExpReward;
    }
    public int GetdefaultAiExpReward()
    {
        return defaultAiExpReward;
    }
    public int GetdefaultNetwordExpReward()
    {
        return defaultNetwordExpReward;
    }
    public int GetdefaultDesignExpReward()
    {
        return defaultDesignExpReward;
    }
    public int GetdefaultArtExpReward()
    {
        return defaultArtExpReward;
    }
    public int GetdefaultSoundExpReward()
    {
        return defaultSoundExpReward;
    }
    public int GetdefaultTestingExpReward()
    {
        return defaultTestingExpReward;
    }
    public int GetdefaultCodingStatReward()
    {
        return defaultCodingStatReward;
    }
    public int GetdefaultDesignStatReward()
    {
        return defaultDesignStatReward;;
    }
    public int GetdefaultArtStatReward()
    {
        return defaultArtStatReward;
    }
    public int GetdefaultTestingStatReward()
    {
        return defaultTestingStatReward;
    }
    public int GetdefaultSoundStatReward()
    {
        return defaultSoundStatReward;
    }
    public int GetPrice()
    {
        return priceCourse;
    }
    public string GetNameAuthor()
    {
        return nameAuthor;
    }
    public string GetDescription()
    {
        return description;
    }
    public CourseType[] GetCourseType()
    {
        return courseTypeNum;
    }
    public LevelRecommended GetLevelRecommended()
    {
        return courseRecommended;
    }
    public int GetCountCourseType()
    {
        return courseTypeNum.Length;
    }
    public string GetNameCourse()
    {
        return nameCourse;
    }

    public int GetMotivationConsume()
    {
        return motivationToConsume;
    }
    #endregion

    private void OnValidate()
    {
        int basePrice = 0;
        int recomment = (int)courseRecommended;

        if (recomment == 0)
        {
            basePrice = 1;
            motivationToConsume = 5;
        } else if (recomment == 1)
        {
            basePrice = 0;
            motivationToConsume = 3;
        } 
        else if (recomment == 2)
        {
            basePrice = 4;
            motivationToConsume = 7;
        }
        else if (recomment == 3)
        {
            basePrice = 10;
            motivationToConsume = 10;
        }

        priceCourse = (courseTypeNum.Length * 399) + (basePrice * 1000);

        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);

    }

    public virtual Course_SO GetCopy()
    {
        return this;
    }


}
