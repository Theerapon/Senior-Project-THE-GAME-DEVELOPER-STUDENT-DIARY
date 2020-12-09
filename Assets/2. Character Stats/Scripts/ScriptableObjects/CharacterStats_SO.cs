using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]
public class CharacterStats_SO : ScriptableObject
{
    #region jobs
    public enum Jobs
    {
        STUDENT,
        PROGRAMMER,
        DESIGNER,
        ARTIST,
        SOUNDENGINEER,
        TESTER
    }
    #endregion

    #region Fields
    public string nameCharacter = "";

    public bool isPlayer = false;

    public int maxEnergy = 0;
    public int courrentEnergy = 0;

    public int codingStatus = 0;
    public int designStatus = 0;
    public int artStatus = 0;
    public int audioStatus = 0;
    public int testStatus = 0;

    public Jobs currentJobs = Jobs.STUDENT;
    #endregion
}
