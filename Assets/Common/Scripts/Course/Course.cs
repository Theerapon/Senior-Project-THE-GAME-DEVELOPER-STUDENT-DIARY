using UnityEngine;

public class Course : MonoBehaviour
{
    protected Course_SO course_current;

    public Course(Course_SO course_Template)
    {
        if (course_Template != null)
        {
            course_current = Instantiate(course_Template);
        }
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

    public int GetPrice()
    {
        return course_current.GetPrice();
    }

    public string GetNameAuthor()
    {
        return course_current.GetNameAuthor();
    }

    public string GetDescription()
    {
        return course_current.GetDescription();
    }

    public CourseType[] GetCourseType()
    {
        return course_current.GetCourseType();
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
    public Course_SO GetCopy()
    {
        return course_current.GetCopy();
    }
}
