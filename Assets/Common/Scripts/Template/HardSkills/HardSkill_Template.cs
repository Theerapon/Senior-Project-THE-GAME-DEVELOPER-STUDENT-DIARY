using UnityEngine;
public class HardSkill_Template : MonoBehaviour
{

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
    private HardSkillLevel[] hardskill_levels;

    private Sprite icon;
    private string hardskill_id = "";
    private string hardskill_name = "";
    private string hardskill_description = "";
    private int maxlevel;

    private int current_hardskill_level;
    private int current_hardskill_exp;

    private int totalBonus_coding_status;
    private int totalBonus_design_status;
    private int totalBonus_testing_status;
    private int totalBonus_art_status;
    private int totalBonus_sound_status;

    public HardSkill_Template(string id, string name, string description, int size, HardSkillLevel[] hardskillLevelsList, Sprite icon)
    {
        hardskill_id = id;
        hardskill_name = name;
        hardskill_description = description;
        maxlevel = size;
        current_hardskill_level = 0;
        current_hardskill_exp = 0;

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
                SetHardSkillLevelUp(current_hardskill_level);
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
    #region Current
    public int GetTotalBonusCoding()
    {
        return totalBonus_coding_status;
    }
    public int GetTotalBonusDesign()
    {
        return totalBonus_design_status;
    }
    public int GetTotalBonusArt()
    {
        return totalBonus_art_status;
    }
    public int GetTotalBonusTesting()
    {
        return totalBonus_testing_status;
    }
    public int GetTotalBonusSound()
    {
        return totalBonus_sound_status;
    }
    #endregion
    #region Next
    public int GetNextBonusCoding()
    {
        int value;
        if (current_hardskill_level < maxlevel)
        {
            value = hardskill_levels[current_hardskill_level + 1].bonus_coding;
        }
        else
        {
            value = totalBonus_coding_status;
        }

        return value;
    }
    public int GetNextBonusDesign()
    {
        int value;
        if (current_hardskill_level < maxlevel)
        {
            value = hardskill_levels[current_hardskill_level + 1].bonus_design;
        }
        else
        {
            value = totalBonus_design_status;
        }

        return value;
    }
    public int GetNextBonusArt()
    {
        int value;
        if (current_hardskill_level < maxlevel)
        {
            value = hardskill_levels[current_hardskill_level + 1].bonus_art;
        }
        else
        {
            value = totalBonus_art_status;
        }

        return value;
    }
    public int GetNextBonusTesting()
    {
        int value;
        if (current_hardskill_level < maxlevel)
        {
            value = hardskill_levels[current_hardskill_level + 1].bonus_testing;
        }
        else
        {
            value = totalBonus_testing_status;
        }

        return value;
    }
    public int GetNextBonusSound()
    {
        int value;
        if (current_hardskill_level < maxlevel)
        {
            value = hardskill_levels[current_hardskill_level + 1].bonus_sound;
        }
        else
        {
            value = totalBonus_sound_status;
        }

        return value;
    }
    #endregion

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
            totalBonus_coding_status = hardskill_levels[0].bonus_coding;
            totalBonus_design_status = hardskill_levels[0].bonus_design;
            totalBonus_testing_status = hardskill_levels[0].bonus_testing;
            totalBonus_art_status = hardskill_levels[0].bonus_art;
            totalBonus_sound_status = hardskill_levels[0].bonus_sound;
        }
    }

    private void SetHardSkillLevelUp(int hardSkillLevel)
    {
        current_hardskill_level = hardSkillLevel + 1;


        if (current_hardskill_level > 0)
        {

            totalBonus_coding_status = hardskill_levels[current_hardskill_level].bonus_coding;
            totalBonus_design_status = hardskill_levels[current_hardskill_level].bonus_design;
            totalBonus_testing_status = hardskill_levels[current_hardskill_level].bonus_testing;
            totalBonus_art_status = hardskill_levels[current_hardskill_level].bonus_art;
            totalBonus_sound_status = hardskill_levels[current_hardskill_level].bonus_sound;
            //OnLevelUp.Invoke(charLevel);
        }

        if (current_hardskill_level < hardskill_levels.Length - 1)
        {
            int levelTarget = hardskill_levels[current_hardskill_level + 1].exp_required;
            if (current_hardskill_exp > levelTarget)
            {
                SetHardSkillLevelUp(current_hardskill_level);
            }
        }


    }


}
