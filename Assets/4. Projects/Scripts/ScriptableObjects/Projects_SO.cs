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
    public string nameProject = "";
    public string id = "";
    public int codingQuality = 0;
    public int designQuality = 0;
    public int artQuality = 0;
    public int testingQuality = 0;
    public int audioQuality = 0;
    public int bug = 0;

    public ProjectPhase[] projectPhase;
    #endregion

}
