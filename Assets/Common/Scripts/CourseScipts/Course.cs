using System.Collections.Generic;
using UnityEngine;

public class Course : MonoBehaviour
{
    protected Course_Template course_current;

    public Course(Course_Template course_Template)
    {
        course_current = course_Template;
    }
    public void SetDiscountCourse(float discount)
    {
        course_current.SetDiscountCourse(discount);
    }
    public void IsCollected()
    {
        course_current.IsCollected();
    }
    public void UnIsCollected()
    {
        course_current.UnIsCollected();
    }

    #region Reporter
    public Sprite GetCourseIcon()
    {
        return course_current.GetCourseIcon();
    }
    public int GetExpForPlayer()
    {
        return course_current.GetExpForPlayer();
    }
    public int GetDiscountPrice()
    {
        return course_current.GetDiscountPrice();
    }
    public int GetTotalPrice()
    {
        return course_current.GetTotalPrice();
    }
    public bool GetCourseCollected()
    {
        return course_current.GetCourseCollected();
    }

    public int GetSecondToConsume()
    {
        return course_current.GetSecondToConsume();
    }

    public int GetEnergyToConsume()
    {
        return course_current.GetEnergyToConsume();
    }

    public int GetdefaultMathExpReward()
    {
        return course_current.GetdefaultMathExpReward();
    }

    public int GetdefaultProgrammingExpReward()
    {
        return course_current.GetdefaultProgrammingExpReward();
    }

    public int GetdefaultEngineExpReward()
    {
        return course_current.GetdefaultEngineExpReward();
    }

    public int GetdefaultAiExpReward()
    {
        return course_current.GetdefaultAiExpReward();
    }

    public int GetdefaultNetwordExpReward()
    {
        return course_current.GetdefaultNetwordExpReward();
    }

    public int GetdefaultDesignExpReward()
    {
        return course_current.GetdefaultDesignExpReward();
    }

    public int GetdefaultArtExpReward()
    {
        return course_current.GetdefaultArtExpReward();
    }

    public int GetdefaultSoundExpReward()
    {
        return course_current.GetdefaultSoundExpReward();
    }


    public int GetdefaultTestingExpReward()
    {
        return course_current.GetdefaultTestingExpReward();
    }

    public int GetdefaultCodingStatReward()
    {
        return course_current.GetdefaultCodingStatReward();
    }

    public int GetdefaultDesignStatReward()
    {
        return course_current.GetdefaultDesignStatReward();
    }

    public int GetdefaultArtStatReward()
    {
        return course_current.GetdefaultArtStatReward();
    }

    public int GetdefaultTestingStatReward()
    {
        return course_current.GetdefaultTestingStatReward();
    }

    public int GetdefaultSoundStatReward()
    {
        return course_current.GetdefaultSoundStatReward();
    }

    public int GetOriginalPrice()
    {
        return course_current.GetOriginalPrice();
    }

    public string GetNameAuthor()
    {
        return course_current.GetNameAuthor();
    }

    public string GetDescription()
    {
        return course_current.GetDescription();
    }

    public List<CourseTag> GetCourseTag()
    {
        return course_current.GetCourseTag();
    }

    public LevelRecommended GetLevelRecommended()
    {
        return course_current.GetLevelRecommended();
    }

    public string GetNameCourse()
    {
        return course_current.GetNameCourse();
    }
    public int GetCountCourseType()
    {
        return course_current.GetCountCourseType();
    }
    public int GetMotivationConsume()
    {
        return course_current.GetMotivationConsume();
    }
    #endregion
    public Course_Template GetCopy()
    {
        return course_current.GetCopy();
    }
}
