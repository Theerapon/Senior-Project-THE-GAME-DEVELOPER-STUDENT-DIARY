using System;
using UnityEditor;
using UnityEngine;

public enum CourseType { NONE, MATH, PROGRAMMING, ENGINE, AI, NERWORK, ART, DESIGN, TESTING, AUDIO }
public enum LevelRecommended { BEGINNER, INTERMEDIATE, EXPERT }
[CreateAssetMenu(fileName = "NewCourse", menuName = "Course", order = 0)]
public class Course_SO : ScriptableObject
{
    [SerializeField] private string id;
    public string ID { get { return id; } }

    [SerializeField] private string nameCourse = "";
    [SerializeField] private int priceCourse = 0;

    private bool isUnlock = false;
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
    public bool GetCourseUnlock()
    {
        return isUnlock;
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
    #endregion

    private void OnValidate()
    {
        int basePrice = 0;
        int recomment = (int)courseRecommended;

        if (recomment == 1)
        {
            basePrice = 4;
        } 
        else if (recomment == 2)
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
