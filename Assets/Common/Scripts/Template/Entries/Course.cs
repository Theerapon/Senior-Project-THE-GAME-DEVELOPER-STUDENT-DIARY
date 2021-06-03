using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    protected Course_Template definition;
    private float courseDiscount;
    private bool hasCollected;

    public Course(Course_Template course_Template)
    {
        definition = Instantiate(course_Template);
        Initializing();
    }
    private void Initializing()
    {
        courseDiscount = 0;
        hasCollected = false;
    }

    #region Reporter
    public float CourseDiscount { get => courseDiscount; }
    public bool HasCollected { get => hasCollected; }
    public string Id { get => definition.Id; }
    public string CourseName { get => definition.CourseName; }
    public string AuthorName { get => definition.AuthorName; }
    public string Description { get => definition.Description; }
    public int CourseOriginalPrice { get => definition.CourseOriginalPrice; }
    public int SecondTimeUsed { get => definition.SecondTimeUsed; }
    public int EnergyUsed { get => definition.EnergyUsed; }
    public int MotivationUsed { get => definition.MotivationUsed; }
    public int ExpPlayer { get => definition.ExpPlayer; }
    public Sprite Course_icon { get => definition.Course_icon; }
    public int DefaultMathExpReward { get => definition.DefaultMathExpReward; }
    public int DefaultProgrammingExpReward { get => definition.DefaultProgrammingExpReward; }
    public int DefaultEngineExpReward { get => definition.DefaultEngineExpReward; }
    public int DefaultAiExpReward { get => definition.DefaultAiExpReward; }
    public int DefaultNetwordExpReward { get => definition.DefaultNetwordExpReward; }
    public int DefaultDesignExpReward { get => definition.DefaultDesignExpReward; }
    public int DefaultArtExpReward { get => definition.DefaultArtExpReward; }
    public int DefaultSoundExpReward { get => definition.DefaultSoundExpReward; }
    public int DefaultTestingExpReward { get => definition.DefaultTestingExpReward; }
    public int DefaultCodingStatReward { get => definition.DefaultCodingStatReward; }
    public int DefaultDesignStatReward { get => definition.DefaultDesignStatReward; }
    public int DefaultArtStatReward { get => definition.DefaultArtStatReward; }
    public int DefaultTestingStatReward { get => definition.DefaultTestingStatReward; }
    public int DefaultSoundStatReward { get => definition.DefaultSoundStatReward; }
    public List<CourseTag> CourseTypeNum { get => definition.CourseTypeNum; }
    public LevelRecommended CourseRecommended { get => definition.CourseRecommended; }
    #endregion

    #region Set Get
    public int GetDiscountPrice()
    {
        return Mathf.CeilToInt(definition.CourseOriginalPrice * courseDiscount);
    }
    public int GetTotalPrice()
    {
        return definition.CourseOriginalPrice - (GetDiscountPrice());
    }
    #endregion
}
