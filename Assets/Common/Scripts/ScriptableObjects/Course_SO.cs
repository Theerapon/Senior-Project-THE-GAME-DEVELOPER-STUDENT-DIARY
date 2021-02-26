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

    [SerializeField] private string nameCourse = "";
    [SerializeField] private string nameAuthor = "";
    [SerializeField] private string description = "";
    [SerializeField] private int priceCourse = 0;

    private bool isCollected = false;
    private int secondToConsume;
    private int energyToConsume;

    private int defaultMathExpReward;
    private int defaultProgrammingExpReward;
    private int defaultEngineExpReward;
    private int defaultAiExpReward;
    private int defaultNetwordExpReward;
    private int defaultDesignExpReward;
    private int defaultArtExpReward;
    private int defaultAudioExpReward;
    private int defaultTestingExpReward;

    private int defaultCodingStatReward;
    private int defaultDesignStatReward;
    private int defaultArtStatReward;
    private int defaultTestingStatReward;
    private int defaultAudioStatReward;

    [SerializeField] private CourseType[] courseTypeNum;
    [SerializeField] private LevelRecommended courseRecommended;

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
    public int GetdefaultAudioExpReward()
    {
        return defaultAudioExpReward;
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
    public int GetdefaultAudioStatReward()
    {
        return defaultAudioStatReward;
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
    #endregion

    private void OnValidate()
    {
        int basePrice = 0;
        int recomment = (int)courseRecommended;

        if (recomment == 0)
        {
            basePrice = 1;        } 
        else if (recomment == 2)
        {
            basePrice = 4;
        }
        else if (recomment == 3)
        {
            basePrice = 10;
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
