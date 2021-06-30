using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum CourseTag { NONE, MATH, PROGRAMMING, ENGINE, AI, NETWORK, ART, DESIGN, TESTING, SOUND }
public enum LevelRecommended { All, BEGINNER, INTERMEDIATE, EXPERT }

public class Course_Template : MonoBehaviour
{
    

    private string id;

    [Header("Detail")]
    private string courseName;
    private string authorName;
    private string description;
    private int courseOriginalPrice;
    private int secondTimeUsed;
    private float energyUsed;
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
        int priceCourse, int secondTimeUsed, float energyUsed, int motivationUsed, int expPlayer, 
        int defaultMathExpReward, int defaultProgrammingExpReward, int defaultEngineExpReward, 
        int defaultAiExpReward, int defaultNetwordExpReward, int defaultDesignExpReward, int defaultArtExpReward, 
        int defaultSoundExpReward, int defaultTestingExpReward, int defaultCodingStatReward, int defaultDesignStatReward, 
        int defaultArtStatReward, int defaultTestingStatReward, int defaultSoundStatReward, 
        List<CourseTag> courseTypeNum, LevelRecommended courseRecommended, Sprite icon)
    {
        this.id = id;
        this.courseName = nameCourse;
        this.authorName = nameAuthor;
        this.description = description;
        this.courseOriginalPrice = priceCourse;
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


    #region Reporter
    public string Id { get => id; }
    public string CourseName { get => courseName; }
    public string AuthorName { get => authorName; }
    public string Description { get => description; }
    public int CourseOriginalPrice { get => courseOriginalPrice; }
    public int SecondTimeUsed { get => secondTimeUsed; }
    public float EnergyUsed { get => energyUsed; }
    public int MotivationUsed { get => motivationUsed; }
    public int ExpPlayer { get => expPlayer; }
    public Sprite Course_icon { get => course_icon; }
    public int DefaultMathExpReward { get => defaultMathExpReward; }
    public int DefaultProgrammingExpReward { get => defaultProgrammingExpReward; }
    public int DefaultEngineExpReward { get => defaultEngineExpReward; }
    public int DefaultAiExpReward { get => defaultAiExpReward; }
    public int DefaultNetwordExpReward { get => defaultNetwordExpReward; }
    public int DefaultDesignExpReward { get => defaultDesignExpReward; }
    public int DefaultArtExpReward { get => defaultArtExpReward; }
    public int DefaultSoundExpReward { get => defaultSoundExpReward; }
    public int DefaultTestingExpReward { get => defaultTestingExpReward; }
    public int DefaultCodingStatReward { get => defaultCodingStatReward; }
    public int DefaultDesignStatReward { get => defaultDesignStatReward; }
    public int DefaultArtStatReward { get => defaultArtStatReward; }
    public int DefaultTestingStatReward { get => defaultTestingStatReward; }
    public int DefaultSoundStatReward { get => defaultSoundStatReward; }
    public List<CourseTag> CourseTypeNum { get => courseTypeNum; }
    public LevelRecommended CourseRecommended { get => courseRecommended; }
    #endregion

}
