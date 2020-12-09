using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Character/Skill", order = 2)]
public class CharacterSkill_SO : ScriptableObject
{
    [System.Serializable]
    public class SkillLevel
    { 
        public int requiredXP;
    }

    [System.Serializable]
    public enum TypeSkill
    {
        HARD,
        SOFT
    }

    #region Fields
    public string nameSkill = "";
    public int currentXP = 0;
    #endregion

    public TypeSkill typeSkill = TypeSkill.HARD;
    public SkillLevel[] skillLevels;
    
}
