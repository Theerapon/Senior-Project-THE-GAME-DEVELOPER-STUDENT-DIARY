using UnityEngine;

public class CharacterStatus_Template : MonoBehaviour
{
    [System.Serializable]
    public class CharacterLevel
    {
        public int exp_required;
        public int maxEnergy;
        public int stats_points;

        public CharacterLevel(int exp, int maxEnergy, int point)
        {
            exp_required = exp;
            this.maxEnergy = maxEnergy;
            stats_points = point;
        }

    }
    
    private CharacterLevel [] characterLevels;


    public CharacterStatus_Template(string id, string name,
        float bReduceEnergy, float gReducEnergy, int maxMotivation, float bMotivation, float gMotivation,
        int money, int coding, int design, int testing, int art, int sound,
        float bProject, float gProject, float reduceBugChance, float charm, 
        float negativeEffect, float positiveEffect, float reduceTimeCourse, float reduceTimeTransport, float dropRate,
        float per_bReduceEnergy, float per_gReducEnergy, float per_bMotivation, float per_gMotivation,
        float per_bProject, float per_gProject, float per_reduceBugChance, float per_charm,
        float per_negativeEffect, float per_positiveEffect, float per_reduceTimeCourse, float per_reduceTimeTransport,
        int per_softskillPoints, float per_dropRate, int maxLevel, CharacterLevel[] characterLevels)
    {
        character_ID = id;
        character_Name = name;
        max_level = maxLevel;
        character_current_Level = 0;
        character_current_Exp = 0;
        hasStatsPoints = 0;
        hasSoftSkillPoints = 0;

        maxEnergy = 100;
        DEFAULT_baseReduceEnergyConsumption = bReduceEnergy;
        DEFAULT_goldenTimeReduceEnergyConsuption = gReducEnergy;
        currentEnergy = 0;

        DEFAULT_maxMotivation = maxMotivation;
        DEFAULT_baseBootUpMotivation = bMotivation;
        DEFAULT_goldenTimeReduceEnergyConsuption = gMotivation;
        currentMotivation = maxMotivation;
        MotivationCalculated();

        currentMoney = money;
        codingStats = coding;
        designStats = design;
        artStats = art;
        soundStats = sound;
        testingStats = testing;

        DEFAULT_baseBootUpProject = bProject;
        DEFAULT_goldenTimeBootUpProject = gProject;
        DEFAULT_reduceBugChance = reduceBugChance;

        DEFAULT_charm = charm;

        DEFAULT_negativeEventsEffect = negativeEffect;
        DEFAULT_positiveEventsEffect = positiveEffect;

        DEFAULT_reduceTimeTrainCourse = reduceTimeCourse;
        DEFAULT_reduceTimeTransport = reduceTimeTransport;

        DEFAULT_dropRate = dropRate;

        _baseReduceEnergyConsumption = per_bReduceEnergy;
        _goldenTimeReduceEnergyConsuption = per_gReducEnergy;

        _baseBootUpMotivation = per_bMotivation;
        _goldenTimeBootUpMotivation = per_gMotivation;

        _baseBootUpProject = per_bProject;
        _goldenTimeBootUpProject = per_gProject;
        _reduceBugChance = per_reduceBugChance;

        _charm = per_charm;

        _negativeEventsEffect = per_negativeEffect;
        _positiveEventsEffect = per_positiveEffect;

        _reduceTimeTrainCourse = per_reduceTimeCourse;
        _reduceTimeTransport = per_reduceTimeTransport;

        _softskillPoints = per_softskillPoints;
        _dropRate = per_dropRate;

        this.characterLevels = characterLevels;

        SetCharacterLevel(character_current_Level);
}

    [Header("Identity")]
    #region Fields
    private string character_ID = "";
    private string character_Name = "";
    private int max_level;
    private int character_current_Level;
    private int character_current_Exp;
    private int hasStatsPoints;
    private int hasSoftSkillPoints;

    private float DEFAULT_dropRate;

    [Header("Energy")]
    private int maxEnergy;
    private float DEFAULT_baseReduceEnergyConsumption; // 0%
    private float DEFAULT_goldenTimeReduceEnergyConsuption; // 5%
    private int currentEnergy;

    [Header("Motivation")]
    private int DEFAULT_maxMotivation;
    private float DEFAULT_baseBootUpMotivation;
    private float DEFAULT_goldenTimeBootUpMotivation;
    private int currentMotivation;
    private float motivationCalculated;

    [Header("Money")]
    private int currentMoney;

    [Header("Programming")]
    private int codingStats;
    private int designStats;
    private int artStats;
    private int soundStats;
    private int testingStats;

    [Header("BootUp Project")]
    private float DEFAULT_baseBootUpProject;
    private float DEFAULT_goldenTimeBootUpProject;
    private float DEFAULT_reduceBugChance;

    [Header("Relationship")]
    private float DEFAULT_charm;

    [Header("Events")]
    private float DEFAULT_negativeEventsEffect;
    private float DEFAULT_positiveEventsEffect;

    [Header("Time")]
    private float DEFAULT_reduceTimeTrainCourse;
    private float DEFAULT_reduceTimeTransport;

    #endregion

    #region Stats UP Per Level
    private float _baseReduceEnergyConsumption;
    private float _goldenTimeReduceEnergyConsuption;

    private float _baseBootUpMotivation;
    private float _goldenTimeBootUpMotivation;

    private float _baseBootUpProject;
    private float _goldenTimeBootUpProject;
    private float _reduceBugChance;

    private float _charm;

    private float _negativeEventsEffect;
    private float _positiveEventsEffect;

    private float _reduceTimeTrainCourse;
    private float _reduceTimeTransport;

    private int _softskillPoints;
    private float _dropRate;
    #endregion


    #region Stat Increasers
    public void ApplyMaxEnergy(int newEnergyAmount)
    {
        maxEnergy = newEnergyAmount;
    }

    public void ApplyCurrentEnergy(int energyAmount)
    {
        if ((currentEnergy + energyAmount) > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
        else
        {
            currentEnergy += energyAmount;
        } 
    }
    public void GiveXP(int xp)
    {
        character_current_Exp += xp;
        if (character_current_Level < characterLevels.Length - 1)
        {
            int levelTarget = characterLevels[character_current_Level + 1].exp_required;

            if (character_current_Exp >= levelTarget)
                SetCharacterLevel(character_current_Level);
        } else
        {
            Debug.Log("maxlevel");
        }
    }

    public void ApplyCurrentMotivation(int currentMotivation)
    {
        if ((this.currentMotivation + currentMotivation) > DEFAULT_maxMotivation)
        {
            this.currentMotivation = DEFAULT_maxMotivation;
        }
        else
        {
            this.currentMotivation += currentMotivation;
        }
        MotivationCalculated();
    }

    public void ApplyCurrentMoney(int currentMoney)
    {
        this.currentMoney += currentMoney;
    }

    public void ApplyCodingStatus(int codingAmount)
    {
        codingStats += codingAmount;
    }

    public void ApplyDesignStatus(int designAmount)
    {
        designStats += designAmount;
    }

    public void ApplyArtStatus(int artAmount)
    {
        artStats += artAmount;
    }

    public void ApplySoundStatus(int soundAmount)
    {
        soundStats += soundAmount;
    }

    public void ApplyTestStatus(int testAmount)
    {
        testingStats += testAmount;
    }
    #endregion

    #region Stat Reducers
    public void TakeEnergy(int energyAmount)
    {
        if(currentEnergy - energyAmount <= 0)
        {
            currentEnergy = 0;
        }
        else
        {
            currentEnergy -= energyAmount;
        }
    }

    public void UseStatusPoint()
    {
        if (hasStatsPoints - 1 <= 0)
        {
            hasStatsPoints = 0;
        }
        else
        {
            hasStatsPoints--;
        }
    }

    public void UseSoftSkillPoint()
    {
        if (hasSoftSkillPoints - 1 <= 0)
        {
            hasSoftSkillPoints = 0;
        }
        else
        {
            hasSoftSkillPoints--;
        }
    }

    public void TakeMotivation(int currentMotivation)
    {
        if (this.currentMotivation - currentMotivation <= 0)
        {
            this.currentMotivation = 0;
        }
        else
        {
            this.currentMotivation -= currentMotivation;
        }
        MotivationCalculated();
    }


    public void ReducedCoding(int codingAmount)
    {
        if(codingStats - codingAmount <= 0)
        {
            codingStats = 0;
        }
        else
        {
            codingStats -= codingAmount;
        }
    }

    public void ReducedDesign(int designAmount)
    {
        if (designStats - designAmount <= 0)
        {
            designStats = 0;
        }
        else
        {
            designStats -= designAmount;
        }
    }

    public void ReducedArt(int artAmount)
    {
        if (artStats - artAmount <= 0)
        {
            artStats = 0;
        }
        else
        {
            artStats -= artAmount;
        }
    }

    public void ReducedSound(int soundAmount)
    {
        if (soundStats - soundAmount <= 0)
        {
            soundStats = 0;
        }
        else
        {
            soundStats -= soundAmount;
        }
    }

    public void ReducedTest(int testAmount)
    {
        if (testingStats - testAmount <= 0)
        {
            testingStats = 0;
        }
        else
        {
            testingStats -= testAmount;
        }
    }

    public void TakeMoney(int currentMoney)
    {
        this.currentMoney -= currentMoney;
    }
    #endregion

    #region Reporter
    public string GetNameCharacter()
    {
        return character_Name;
    }


    public float GetMaxEnergy()
    {
        return maxEnergy;
    }

    public float GetCurrentEnergy()
    {
        return currentEnergy;
    }

    public int GetCurrentMotivation()
    {
        return currentMotivation;
    }
    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public int GetDEFAULT_MaxMotivation()
    {
        return DEFAULT_maxMotivation;
    }

    public float GetDEFAULT_baseReduceEnergyConsumption()
    {
        return DEFAULT_baseReduceEnergyConsumption;
    }
    public float GetDEFAULT_goldenTimeReduceEnergyConsuption()
    {
        return DEFAULT_goldenTimeReduceEnergyConsuption;
    }

    public float GetDEFAULT_baseBootUpMotivation()
    {
        return DEFAULT_baseBootUpMotivation;
    }
    public float GetDEFAULT_goldenTimeBootUpMotivation()
    {
        return DEFAULT_goldenTimeBootUpMotivation;
    }
    public int GetCodingStatus()
    {
        return codingStats;
    }
    public int GetDesignStatus()
    {
        return designStats;
    }
    public int GetArtStatus()
    {
        return artStats;
    }
    public int GetSoundStatus()
    {
        return soundStats;
    }
    public int GetTestingStatus()
    {
        return testingStats;
    }
    public float GetDEFAULT_baseBootUpProject()
    {
        return DEFAULT_baseBootUpProject;
    }
    public float GetDEFAULT_goldenTimeBootUpProject()
    {
        return DEFAULT_goldenTimeBootUpProject;
    }
    public float GetDEFAULT_reduceBugChance()
    {
        return DEFAULT_reduceBugChance;
    }
    public float GetDEFAULT_charm()
    {
        return DEFAULT_charm;
    }
    public float GetDEFAULT_negativeEventsEffect()
    {
        return DEFAULT_negativeEventsEffect;
    }
    public float GetDEFAULT_positiveEventsEffect()
    {
        return DEFAULT_positiveEventsEffect;
    }
    public float GetDEFAULT_reduceTimeTrainCourse()
    {
        return DEFAULT_reduceTimeTrainCourse;
    }
    public float GetDEFAULT_reduceTimeTransport()
    {
        return DEFAULT_reduceTimeTransport;
    }
    public int GetCurrentCharacterLevel()
    {
        return character_current_Level;
    }
    public int GetCurrentExp()
    {
        return character_current_Exp;
    }
    public int GetPointStatus()
    {
        return hasStatsPoints;
    }
    public int GetSoftSkillPoints()
    {
        return hasSoftSkillPoints;
    }
    public float GetMotivationCalculated()
    {
        return motivationCalculated;
    }
    public float GetDropRate()
    {
        return DEFAULT_dropRate;
    }
    #endregion

    #region Character Level Up
    public void SetCharacterLevel(int characterLevel)
    {
        character_current_Level = characterLevel + 1;

        hasStatsPoints += characterLevels[character_current_Level].stats_points;

        maxEnergy = characterLevels[character_current_Level].maxEnergy;
        
        currentEnergy = maxEnergy;
        currentMotivation = DEFAULT_maxMotivation;

        hasSoftSkillPoints += _softskillPoints;

        if (characterLevel > 1)
        {
            DEFAULT_baseReduceEnergyConsumption += _baseReduceEnergyConsumption;
            DEFAULT_goldenTimeReduceEnergyConsuption += _goldenTimeReduceEnergyConsuption;

            DEFAULT_baseBootUpMotivation += _baseBootUpMotivation;
            DEFAULT_goldenTimeBootUpMotivation += _goldenTimeBootUpMotivation;

            DEFAULT_baseBootUpProject += _baseBootUpProject;
            DEFAULT_goldenTimeBootUpProject += _goldenTimeBootUpProject;
            DEFAULT_reduceBugChance += _reduceBugChance;

            DEFAULT_charm += _charm;

            DEFAULT_negativeEventsEffect -= _negativeEventsEffect;

            DEFAULT_positiveEventsEffect += _positiveEventsEffect;

            DEFAULT_reduceTimeTrainCourse += _reduceTimeTrainCourse;
            DEFAULT_reduceTimeTransport += _reduceTimeTransport;

            DEFAULT_dropRate += _dropRate;
            //OnLevelUp.Invoke(charLevel);
        }

        int levelTarget = characterLevels[character_current_Level + 1].exp_required;
        if (character_current_Exp > levelTarget)
        {
            SetCharacterLevel(character_current_Level);
        }
    }
    #endregion

    #region Calculated Motivation
    private void MotivationCalculated()
    {
        float motivation;
        if(currentMotivation > 79)
        {
            motivation = 1f;
        } else if (currentMotivation > 59)
        {
            motivation = 0.9f;
        } else if (currentMotivation > 39)
        {
            motivation = 0.7f;
        } else if (currentMotivation > 19)
        {
            motivation = 0.5f;
        } else
        {
            motivation = 0.3f;
        }
        motivationCalculated = motivation;
    }
    #endregion
}
