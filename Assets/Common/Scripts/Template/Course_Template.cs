using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum CourseTag { NONE, MATH, PROGRAMMING, ENGINE, AI, NETWORK, ART, DESIGN, TESTING, SOUND }
public enum LevelRecommended { All, BEGINNER, INTERMEDIATE, EXPERT }

public class Course_Template : MonoBehaviour
{
    

    private string id;
    public string ID { get { return id; } }

    [Header("Detail")]
    private string nameCourse;
    private string nameAuthor;
    private string description;
    private int priceCourse;
    private float discountCourse = 0f;
    private bool isCollected = false;
    private int secondTimeUsed;
    private int energyUsed;
    private int motivationUsed;
    private int expPlayer;
    private Sprite course_icon;

    [Header("Exp Rewards")]
    private int defaultMathExpReward;
    private int defaultProgrammingExpReward;
    private int defaultEngineExpReward;
    private int defaultAiExpReward;
    private int defaultNetwordExpReward;
    private int defaultDesignExpReward;
    private int defaultArtExpReward;
    private int defaultSoundExpReward;
    private int defaultTestingExpReward;

    [Header("Stat Rewards")]
    private int defaultCodingStatReward;
    private int defaultDesignStatReward;
    private int defaultArtStatReward;
    private int defaultTestingStatReward;
    private int defaultSoundStatReward;


    [Header("Tag")]
    private List<CourseTag> courseTypeNum;
    private LevelRecommended courseRecommended;

    public Course_Template(string id, string nameCourse, string nameAuthor, string description, 
        int priceCourse, int secondTimeUsed, int energyUsed, int motivationUsed, int expPlayer, 
        int defaultMathExpReward, int defaultProgrammingExpReward, int defaultEngineExpReward, 
        int defaultAiExpReward, int defaultNetwordExpReward, int defaultDesignExpReward, int defaultArtExpReward, 
        int defaultSoundExpReward, int defaultTestingExpReward, int defaultCodingStatReward, int defaultDesignStatReward, 
        int defaultArtStatReward, int defaultTestingStatReward, int defaultSoundStatReward, 
        List<CourseTag> courseTypeNum, LevelRecommended courseRecommended, Sprite icon)
    {
        this.id = id;
        this.nameCourse = nameCourse;
        this.nameAuthor = nameAuthor;
        this.description = description;
        this.priceCourse = priceCourse;
        this.secondTimeUsed = secondTimeUsed;
        this.energyUsed = energyUsed;
        this.motivationUsed = motivationUsed;
        this.expPlayer = expPlayer;
        this.defaultMathExpReward = defaultMathExpReward;
        this.defaultProgrammingExpReward = defaultProgrammingExpReward;
        this.defaultEngineExpReward = defaultEngineExpReward;
        this.defaultAiExpReward = defaultAiExpReward;
        this.defaultNetwordExpReward = defaultNetwordExpReward;
        this.defaultDesignExpReward = defaultDesignExpReward;
        this.defaultArtExpReward = defaultArtExpReward;
        this.defaultSoundExpReward = defaultSoundExpReward;
        this.defaultTestingExpReward = defaultTestingExpReward;
        this.defaultCodingStatReward = defaultCodingStatReward;
        this.defaultDesignStatReward = defaultDesignStatReward;
        this.defaultArtStatReward = defaultArtStatReward;
        this.defaultTestingStatReward = defaultTestingStatReward;
        this.defaultSoundStatReward = defaultSoundStatReward;
        this.courseTypeNum = courseTypeNum;
        this.courseRecommended = courseRecommended;
        this.course_icon = icon;
    }

    public void SetDiscountCourse(float discount)
    {
        discountCourse = discount;
    }
    public void IsCollected()
    {
        isCollected = true;
    }
    public void UnIsCollected()
    {
        isCollected = false;
    }

    #region Reporter
    public Sprite GetCourseIcon()
    {
        return course_icon;
    }
    public int GetExpForPlayer()
    {
        return expPlayer;
    }
    public int GetDiscountPrice()
    {
        return Mathf.CeilToInt(priceCourse * discountCourse);
    }
    public int GetTotalPrice()
    {
        return priceCourse - (GetDiscountPrice());
    }
    public bool GetCourseCollected()
    {
        return isCollected;
    }
    public int GetSecondToConsume()
    {
        return secondTimeUsed;
    }
    public int GetEnergyToConsume()
    {
        return energyUsed;
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
    public int GetOriginalPrice()
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
    public List<CourseTag> GetCourseTag()
    {
        return courseTypeNum;
    }
    public LevelRecommended GetLevelRecommended()
    {
        return courseRecommended;
    }
    public int GetCountCourseType()
    {
        return courseTypeNum.Count;
    }
    public string GetNameCourse()
    {
        return nameCourse;
    }

    public int GetMotivationConsume()
    {
        return motivationUsed;
    }
    #endregion


    public virtual Course_Template GetCopy()
    {
        return this;
    }


}
