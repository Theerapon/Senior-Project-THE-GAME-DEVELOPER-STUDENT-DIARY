using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkill : MonoBehaviour
{
    private HardSkill_Template definition;

    private int currentLevel;
    private int currentExp;
    private int currentTotalBonusCodingStatus;
    private int currentTotalBonusDesignStatus;
    private int currentTotalBonusTestingStatus;
    private int currentTotalBonusArtStatus;
    private int currentTotalBonusSoundStatus;

    public HardSkill(HardSkill_Template hardSkill_Template)
    {
        definition = Instantiate(hardSkill_Template);
        Initializing();
    }

    private void Initializing()
    {
        currentLevel = 0;
        currentExp = 0;
        currentTotalBonusCodingStatus = definition.HardskillLevelRequired[currentLevel].bonus_coding;
        currentTotalBonusDesignStatus = definition.HardskillLevelRequired[currentLevel].bonus_design;
        currentTotalBonusTestingStatus = definition.HardskillLevelRequired[currentLevel].bonus_testing;
        currentTotalBonusArtStatus = definition.HardskillLevelRequired[currentLevel].bonus_art;
        currentTotalBonusSoundStatus = definition.HardskillLevelRequired[currentLevel].bonus_sound;
    }

    #region Stat Increasers
    public void IncreaseEXP(int xp)
    {
        currentExp += xp;
        if (currentLevel < definition.HardskillLevelRequired.Length - 1)
        {
            int levelTarget = definition.HardskillLevelRequired[currentLevel + 1].exp_required;

            if (currentExp >= levelTarget)
            {
                SetHardSkillLevelUp(currentLevel);
            }
        }
        else
        {
            Debug.Log("maxlevel");
        }
    }
    #endregion
    #region Hard Skill Level UP
    private void SetHardSkillLevelUp(int hardSkillLevel)
    {
        currentLevel = hardSkillLevel + 1;
        if (currentLevel > 0)
        {

            currentTotalBonusCodingStatus = definition.HardskillLevelRequired[currentLevel].bonus_coding;
            currentTotalBonusDesignStatus = definition.HardskillLevelRequired[currentLevel].bonus_design;
            currentTotalBonusTestingStatus = definition.HardskillLevelRequired[currentLevel].bonus_testing;
            currentTotalBonusArtStatus = definition.HardskillLevelRequired[currentLevel].bonus_art;
            currentTotalBonusSoundStatus = definition.HardskillLevelRequired[currentLevel].bonus_sound;
            //OnLevelUp.Invoke(charLevel);
        }

        if (currentLevel < definition.HardskillLevelRequired.Length - 1)
        {
            int levelTarget = definition.HardskillLevelRequired[currentLevel + 1].exp_required;
            if (currentExp > levelTarget)
            {
                SetHardSkillLevelUp(currentLevel);
            }
        }


    }
    #endregion
    #region Reporter
    public int CurrentLevel { get => currentLevel; }
    public int CurrentExp { get => currentExp; }
    public int CurrentTotalBonusCodingStatus { get => currentTotalBonusCodingStatus; }
    public int CurrentTotalBonusDesignStatus { get => currentTotalBonusDesignStatus; }
    public int CurrentTotalBonusTestingStatus { get => currentTotalBonusTestingStatus; }
    public int CurrentTotalBonusArtStatus { get => currentTotalBonusArtStatus; }
    public int CurrentTotalBonusSoundStatus { get => currentTotalBonusSoundStatus; }
    public Sprite Icon { get => definition.Icon; }
    public string Hardskill_id { get => definition.Hardskill_id; }
    public string Hardskill_name { get => definition.Hardskill_name; }
    public string Hardskill_description { get => definition.Hardskill_description; }
    public int Maxlevel { get => definition.Maxlevel; }
    #endregion
    #region Get Next Bonus
    public int GetNextBonusCoding()
    {
        int value;
        if (currentLevel < definition.Maxlevel)
        {
            value = definition.HardskillLevelRequired[currentLevel + 1].bonus_coding;
        }
        else
        {
            value = currentTotalBonusCodingStatus;
        }

        return value;
    }
    public int GetNextBonusDesign()
    {
        int value;
        if (currentLevel < definition.Maxlevel)
        {
            value = definition.HardskillLevelRequired[currentLevel + 1].bonus_design;
        }
        else
        {
            value = currentTotalBonusDesignStatus;
        }

        return value;
    }
    public int GetNextBonusArt()
    {
        int value;
        if (currentLevel < definition.Maxlevel)
        {
            value = definition.HardskillLevelRequired[currentLevel + 1].bonus_art;
        }
        else
        {
            value = currentTotalBonusArtStatus;
        }

        return value;
    }
    public int GetNextBonusTesting()
    {
        int value;
        if (currentLevel < definition.Maxlevel)
        {
            value = definition.HardskillLevelRequired[currentLevel + 1].bonus_testing;
        }
        else
        {
            value = currentTotalBonusTestingStatus;
        }

        return value;
    }
    public int GetNextBonusSound()
    {
        int value;
        if (currentLevel < definition.Maxlevel)
        {
            value = definition.HardskillLevelRequired[currentLevel + 1].bonus_sound;
        }
        else
        {
            value = currentTotalBonusSoundStatus;
        }

        return value;
    }
    public int GetExpRequire()
    {
        int exp;

        if (currentLevel < definition.HardskillLevelRequired.Length - 1)
        {
            exp = definition.HardskillLevelRequired[currentLevel + 1].exp_required;
        }
        else
        {
            exp = definition.HardskillLevelRequired[currentLevel].exp_required;
        }

        return exp;
    }
    public float GetExpFillAmount()
    {
        float fillamount = 0f;

        if (currentLevel < definition.Maxlevel)
        {
            fillamount = (float)currentExp / definition.HardskillLevelRequired[currentLevel + 1].exp_required;
        }
        else
        {
            fillamount = 1f;
        }


        return fillamount;
    }
    #endregion
}
