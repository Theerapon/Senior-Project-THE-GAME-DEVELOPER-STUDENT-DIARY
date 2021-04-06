using UnityEngine;
public enum HardSkillType { NONE, MATH, PROGRAMMING, GAMEENGINE, AI, NETWORK, ART, DESIGN, TESTING, SOUND}
public class HardSkill_Template : MonoBehaviour
{
    private const string INST_ID_MATH = "MATH";
    private const string INST_ID_PROGRAMMING = "PROGRAMMING";
    private const string INST_ID_GAMEENGINE = "GAMEENGINE";
    private const string INST_ID_NETWORK = "NETWORK";
    private const string INST_ID_AI = "AI";
    private const string INST_ID_DESIGN = "DESIGN";
    private const string INST_ID_TESTING = "TESTING";
    private const string INST_ID_ART = "ART";
    private const string INST_ID_SOUND = "SOUND";

    [System.Serializable]
    public class HardSkillLevel
    {
        public int exp_required;
        public int bonus_coding;
        public int bonus_design;
        public int bonus_testing;
        public int bonus_art;
        public int bonus_sound;

        public HardSkillLevel(int requiredXP, int bonusCoding, int bonusDesign, int bonusTesting, int bonusArt, int bonusSound)
        {
            this.exp_required = requiredXP;
            this.bonus_coding = bonusCoding;
            this.bonus_design = bonusDesign;
            this.bonus_testing = bonusTesting;
            this.bonus_art = bonusArt;
            this.bonus_sound = bonusSound;
        }
    }
    private HardSkillType hardskill_type = HardSkillType.NONE;
    private HardSkillLevel[] hardskill_levels;

    private Sprite icon;
    private string hardskill_id = "";
    private string hardskill_name = "";
    private string hardskill_description = "";
    private int maxlevel;

    private int current_hardskill_level;
    private int current_hardskill_exp;

    private int totalBonus_coding_stats;
    private int totalBonus_design_stats;
    private int totalBonus_testing_stats;
    private int totalBonus_art_stats;
    private int totalBonus_sound_stats;

    public HardSkill_Template(string id, string name, string description, int size, HardSkillLevel[] hardskillLevelsList, Sprite icon)
    {
        hardskill_id = id;
        hardskill_name = name;
        hardskill_description = description;
        maxlevel = size;
        current_hardskill_level = 0;
        current_hardskill_exp = 0;

        SetHardSkillType(hardskill_id);
        hardskill_levels = hardskillLevelsList;

        this.icon = icon;
    }

    #region Stat Increasers
    public void GiveXP(int xp)
    {
        current_hardskill_exp += xp;
        if (current_hardskill_level < hardskill_levels.Length - 1)
        {
            int levelTarget = hardskill_levels[current_hardskill_level + 1].exp_required;

            if (current_hardskill_exp >= levelTarget)
            {
                SetHardSkillLevel(current_hardskill_level);
            }
        }
        else
        {
            Debug.Log("maxlevel");
        }
    }
    #endregion

    #region Reporter
    public Sprite GetIconHardSKill()
    {
        return icon;
    }
    public string GetHardSkillName()
    {
        return hardskill_name;
    }
    public string GetHardSkillID()
    {
        return hardskill_id;
    }
    public string GetHardSkillDescription()
    {
        return hardskill_description;
    }
    public int GetMaxLevelHardSkill()
    {
        return maxlevel;
    }
    public int GetCurrentHardSkillLevel()
    {
        return current_hardskill_level;
    }
    public int GetCurrentHardSkillEXP()
    {
        return current_hardskill_exp;
    }
    public int GetTotalBonusCoding()
    {
        return totalBonus_coding_stats;
    }
    public int GetTotalBonusDesign()
    {
        return totalBonus_design_stats;
    }
    public int GetTotalBonusArt()
    {
        return totalBonus_art_stats;
    }
    public int GetTotalBonusTesting()
    {
        return totalBonus_testing_stats;
    }
    public int GetTotalBonusSound()
    {
        return totalBonus_sound_stats;
    }
    public HardSkillType GetHardSkillType()
    {
        return hardskill_type;
    }
    public int GetExpRequire()
    {
        int exp;

        if (current_hardskill_level < hardskill_levels.Length - 1)
        {
            exp =  hardskill_levels[current_hardskill_level + 1].exp_required;
        }
        else
        {
            exp = hardskill_levels[current_hardskill_level].exp_required;
        }

        return exp;
    }
    public float GetExpFillAmount()
    {
        float fillamount = 0f;

        if(current_hardskill_level < maxlevel)
        {
            fillamount = (float) current_hardskill_exp / hardskill_levels[current_hardskill_level + 1].exp_required;
        }
        else
        {
            fillamount = 1f;
        }


        return fillamount;
    }
    #endregion


    protected void Initiate()
    {
        if (current_hardskill_level == 0)
        {
            totalBonus_coding_stats = hardskill_levels[0].bonus_coding;
            totalBonus_design_stats = hardskill_levels[0].bonus_design;
            totalBonus_testing_stats = hardskill_levels[0].bonus_testing;
            totalBonus_art_stats = hardskill_levels[0].bonus_art;
            totalBonus_sound_stats = hardskill_levels[0].bonus_sound;
        }
    }

    private void SetHardSkillLevel(int hardSkillLevel)
    {
        current_hardskill_level = hardSkillLevel + 1;


        if (current_hardskill_level > 0)
        {

            totalBonus_coding_stats = hardskill_levels[current_hardskill_level].bonus_coding;
            totalBonus_design_stats = hardskill_levels[current_hardskill_level].bonus_design;
            totalBonus_testing_stats = hardskill_levels[current_hardskill_level].bonus_testing;
            totalBonus_art_stats = hardskill_levels[current_hardskill_level].bonus_art;
            totalBonus_sound_stats = hardskill_levels[current_hardskill_level].bonus_sound;
            //OnLevelUp.Invoke(charLevel);
        }

        if (current_hardskill_level < hardskill_levels.Length - 1)
        {
            int levelTarget = hardskill_levels[current_hardskill_level + 1].exp_required;
            if (current_hardskill_exp > levelTarget)
            {
                SetHardSkillLevel(current_hardskill_level);
            }
        }


    }

    private void SetHardSkillType(string id)
    {
        switch (id)
        {
            case INST_ID_MATH:
                hardskill_type = HardSkillType.MATH;
                break;
            case INST_ID_PROGRAMMING:
                hardskill_type = HardSkillType.PROGRAMMING;
                break;
            case INST_ID_GAMEENGINE:
                hardskill_type = HardSkillType.GAMEENGINE;
                break;
            case INST_ID_NETWORK:
                hardskill_type = HardSkillType.NETWORK;
                break;
            case INST_ID_AI:
                hardskill_type = HardSkillType.AI;
                break;
            case INST_ID_DESIGN:
                hardskill_type = HardSkillType.DESIGN;
                break;
            case INST_ID_TESTING:
                hardskill_type = HardSkillType.TESTING;
                break;
            case INST_ID_ART:
                hardskill_type = HardSkillType.ART;
                break;
            case INST_ID_SOUND:
                hardskill_type = HardSkillType.SOUND;
                break;
            default:
                hardskill_type = HardSkillType.NONE;
                break;

        }
    }

}
