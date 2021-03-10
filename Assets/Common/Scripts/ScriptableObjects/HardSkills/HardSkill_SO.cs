using UnityEngine;
public enum HardSkillType { NONE, MATH, PROGRAMMING, ENGINE, AI, NERWORK, ART, DESIGN, TESTING, SOUND}
[CreateAssetMenu(fileName = "NewSkill", menuName = "Character/Skills/HardSkill", order = 0)]
public class HardSkill_SO : ScriptableObject
{
    [System.Serializable]
    public class HardSkillLevel
    {
        public int requiredXP;
        public int bonusCoding;
        public int bonusDesign;
        public int bonusTesting;
        public int bonusArt;
        public int bonusSound;
    }

    [SerializeField] private string nameHardSkill = "";
    private int currentHardSkillLevel;
    private int currentHardSkillEXP;

    private int totalBonus_CodingStats;
    private int totalBonus_DesignStats;
    private int totalBonus_TestingStats;
    private int totalBonus_ArtStats;
    private int totalBonus_SoundStats;

    [SerializeField] private HardSkillType hardSkillType = HardSkillType.NONE;
    [SerializeField] private HardSkillLevel[] hardSkillLevels;

    #region Stat Increasers
    public void GiveXP(int xp)
    {
        currentHardSkillEXP += xp;
        if (currentHardSkillLevel < hardSkillLevels.Length - 1)
        {
            int levelTarget = hardSkillLevels[currentHardSkillLevel + 1].requiredXP;

            if (currentHardSkillEXP >= levelTarget)
            {
                SetCharacterLevel(currentHardSkillLevel);
            }
        }
        else
        {
            Debug.Log("maxlevel");
        }
    }
    #endregion

    #region Reporter
    public string GetHardSkillName()
    {
        return nameHardSkill;
    }
    public int GetCurrentHardSkillLevel()
    {
        return currentHardSkillLevel;
    }
    public int GetCurrentHardSkillEXP()
    {
        return currentHardSkillEXP;
    }
    public int GetTotalBonusCoding()
    {
        return totalBonus_CodingStats;
    }
    public int GetTotalBonusDesign()
    {
        return totalBonus_DesignStats;
    }
    public int GetTotalBonusArt()
    {
        return totalBonus_ArtStats;
    }
    public int GetTotalBonusTesting()
    {
        return totalBonus_TestingStats;
    }
    public int GetTotalBonusSound()
    {
        return totalBonus_SoundStats;
    }
    public HardSkillType GetHardSkillType()
    {
        return hardSkillType;
    }
    public int GetExpRequire()
    {
        return hardSkillLevels[currentHardSkillLevel + 1].requiredXP;
    }
    #endregion

    private void SetCharacterLevel(int hardSkillLevel)
    {
        currentHardSkillLevel = hardSkillLevel + 1;


        if (currentHardSkillLevel > 0)
        {

            totalBonus_CodingStats += hardSkillLevels[currentHardSkillLevel].bonusCoding;
            totalBonus_DesignStats += hardSkillLevels[currentHardSkillLevel].bonusDesign;
            totalBonus_TestingStats += hardSkillLevels[currentHardSkillLevel].bonusTesting;
            totalBonus_ArtStats += hardSkillLevels[currentHardSkillLevel].bonusArt;
            totalBonus_SoundStats += hardSkillLevels[currentHardSkillLevel].bonusSound;
            //OnLevelUp.Invoke(charLevel);
        }

        int levelTarget = hardSkillLevels[currentHardSkillLevel + 1].requiredXP;
        if (currentHardSkillEXP > levelTarget)
        {
            SetCharacterLevel(currentHardSkillLevel);
        }

    }
}
