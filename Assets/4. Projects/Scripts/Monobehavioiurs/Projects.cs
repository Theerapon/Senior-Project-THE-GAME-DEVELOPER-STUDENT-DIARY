using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projects : MonoBehaviour
{
    #region Fields

    [SerializeField]
    public Projects_SO project_Template;
    public Projects_SO project_Current;
    public CharacterStats characterStats;

    #endregion

    #region Initializations
    private void Awake()
    {
        if (project_Template != null)
        {
            project_Current = Instantiate(project_Template);
        }
    }

    private void Start()
    {
    }
    #endregion

    #region Quality Increasers
    public void ApplyQualityCoding(int codingAmount)
    {
        project_Current.ApplyQualityCoding(codingAmount);
    }

    public void ApplyQualityDesign(int designAmount)
    {
        project_Current.ApplyQualityDesign(designAmount);
    }

    public void ApplyQualityArt(int artAmount)
    {
        project_Current.ApplyQualityArt(artAmount);
    }

    public void ApplyQualityTest(int testingAmount)
    {
        project_Current.ApplyQualityTest(testingAmount);
    }

    public void ApplyQualityAudio(int audioAmount)
    {
        project_Current.ApplyQualityAudio(audioAmount);
    }

    public void ApplyQualityBug(int bugAmount)
    {
        project_Current.ApplyQualityBug(bugAmount);
    }

    #endregion

    #region Quality Reducers
    public void ReducedCoding(int codingAmount)
    {
        project_Current.ReducedCoding(codingAmount);
    }

    public void ReducedDesign(int designAmount)
    {
        project_Current.ReducedDesign(designAmount);
    }

    public void ReducedArt(int artAmount)
    {
        project_Current.ReducedArt(artAmount);
    }

    public void ReducedAudio(int audioAmount)
    {
        project_Current.ReducedAudio(audioAmount);
    }

    public void ReducedTest(int testingAmount)
    {
        project_Current.ReducedTest(testingAmount);
    }

    public void ReducedBug(int bugAmount)
    {
        project_Current.ReducedBug(bugAmount);
    }
    #endregion

    #region Reporter
    public string GetNameProject()
    {
        return project_Current.GetNameProject();
    }

    public string GetId()
    {
        return project_Current.GetId();
    }

    public int GetCodingQuality()
    {
        return project_Current.GetCodingQuality();
    }

    public int GetDesignQuality()
    {
        return project_Current.GetDesignQuality();
    }

    public int GetArtQuality()
    {
        return project_Current.GetArtQuality();
    }

    public int GetTestingQuality()
    {
        return project_Current.GetTestingQuality();
    }

    public int GetAudioQuality()
    {
        return project_Current.GetAudioQuality();
    }

    public int GetBugValue()
    {
        return project_Current.GetBugValue();
    }

    public int GetCurrentXpProject()
    {
        return project_Current.GetCurrentXpProject();
    }

    public int GetRequireXpProject(int index)
    {
        return project_Current.GetRequireXpProject(index);
    }
    #endregion
}
