using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProject", menuName = "Quest/Project", order = 1)]
public class Projects_SO : ScriptableObject
{

    [System.Serializable]
    public class ProjectPhase
    {
        public string namePhase;
        public Phase projectPhase;
        public int requireXP;
    }

    #region Phase Development
    public enum Phase
    {
        DESIGN,
        FIRST_PLAYABLE,
        PROTOTYPE,
        VERTICAL_SLICES,
        ALPHA_TEST,
        BETA_TEST,
        MASTER
    }
    #endregion


    #region Field
    [SerializeField] private string nameProject = "";
    [SerializeField] private string id = "";
    [SerializeField] private int codingQuality = 0;
    [SerializeField] private int designQuality = 0;
    [SerializeField] private int artQuality = 0;
    [SerializeField] private int testingQuality = 0;
    [SerializeField] private int audioQuality = 0;
    [SerializeField] private int bugValue = 0;
    private int currentXpProject = 20;

    public ProjectPhase[] projectPhase;
    #endregion

    #region Quality Increasers
    public void ApplyQualityCoding(int codingAmount)
    {
        codingQuality += codingAmount;
    }

    public void ApplyQualityDesign(int designAmount)
    {
        designQuality += designAmount;
    }

    public void ApplyQualityArt(int artAmount)
    {
        artQuality +=  artAmount;
    }

    public void ApplyQualityTest(int testingAmount)
    {
        testingQuality += testingAmount;
    }

    public void ApplyQualityAudio(int audioAmount)
    {
        audioQuality += audioAmount;
    }

    public void ApplyQualityBug(int bugAmount)
    {
        bugValue += bugAmount;
    }

    #endregion

    #region Quality Reducers
    public void ReducedCoding(int codingAmount)
    {
        if (codingQuality - codingAmount <= 0)
        {
            codingQuality = 0;
        }
        else
        {
            codingQuality -= codingAmount;
        }
    }

    public void ReducedDesign(int designAmount)
    {
        if (designQuality - designAmount <= 0)
        {
            designQuality = 0;
        }
        else
        {
            designQuality -= designAmount;
        }
    }

    public void ReducedArt(int artAmount)
    {
        if (artQuality - artAmount <= 0)
        {
            artQuality = 0;
        }
        else
        {
            artQuality -= artAmount;
        }
    }

    public void ReducedAudio(int audioAmount)
    {
        if (audioQuality - audioAmount <= 0)
        {
            audioQuality = 0;
        }
        else
        {
            audioQuality -= audioAmount;
        }
    }

    public void ReducedTest(int testingAmount)
    {
        if (testingQuality - testingAmount <= 0)
        {
            testingQuality = 0;
        }
        else
        {
            testingQuality -= testingAmount;
        }
    }

    public void ReducedBug(int bugAmount)
    {
        if (bugValue - bugAmount <= 0)
        {
            bugValue = 0;
        }
        else
        {
            bugValue -= bugAmount;
        }
    }
    #endregion

    #region Reporter
    public string GetNameProject()
    {
        return nameProject;
    }

    public string GetId()
    {
        return id;
    }

    public int GetCodingQuality()
    {
        return codingQuality;
    }

    public int GetDesignQuality()
    {
        return designQuality;
    }

    public int GetArtQuality()
    {
        return artQuality;
    }

    public int GetTestingQuality()
    {
        return testingQuality;
    }

    public int GetAudioQuality()
    {
        return audioQuality;
    }

    public int GetBugValue()
    {
        return bugValue;
    }

    public int GetCurrentXpProject()
    {
        return currentXpProject;
    }

    public int GetRequireXpProject(int index)
    {
        return projectPhase[index].requireXP;
    }
    #endregion
}
