using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]
public class CharacterStats_SO : ScriptableObject
{
    [System.Serializable]
    public class CharacterLevel
    {
        public int maxEnergy;
        public int pointStatus;
        public int requiredXP;

    }


    [Header("Level")]
    [SerializeField] private CharacterLevel [] characterLevels;

    [Header("Identity")]
    #region Fields
    [SerializeField] private string nameCharacter = "";
    [SerializeField] private bool isPlayer = false;
    private int currentCharacterLevel = 0;
    private int currentExp = 0;
    private int hasPointStatus = 0;
    private int hasSoftSkillPoints = 0;

    [Header("Energy")]
    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private float DEFAULT_baseReduceEnergyConsumption = 0f; // 0%
    [SerializeField] private float DEFAULT_goldenTimeReduceEnergyConsuption = 0.05f; // 5%
    private int currentEnergy;

    [Header("Motivation")]
    private float DEFAULT_maxMotivation = 100f;
    [SerializeField] private float DEFAULT_baseBootUpMotivation = 0f; // 0%
    [SerializeField] private float DEFAULT_goldenTimeBootUpMotivation = 0.05f; // 5%
    private float currentMotivation;

    [Header("Money")]
    [SerializeField] private int currentMoney = 0;

    [Header("Programming")]
    [SerializeField] private int codingStatus = 10;
    [SerializeField] private int designStatus = 10;
    [SerializeField] private int artStatus = 10;
    [SerializeField] private int audioStatus = 10;
    [SerializeField] private int testStatus = 10;

    [Header("BootUp Project")]
    [SerializeField] private float DEFAULT_baseBootUpProject = 0f; // 0%
    [SerializeField] private float DEFAULT_goldenTimeBootUpProject = 0.05f; // 5%
    [SerializeField] private float DEFAULT_reduceBugChance = 0f;

    [Header("Relationship")]
    [SerializeField] private float DEFAULT_charm = 1f;

    [Header("Events")]
    [SerializeField] private float DEFAULT_negativeEventsChance = 0.3f; // 30%
    [SerializeField] private float DEFAULT_negativeEventsEffect = 1f; // 100%
    [SerializeField] private float DEFAULT_positiveEventsEffect = 1f; // 100%

    [Header("Time")]
    [SerializeField] private int DEFAULT_fullTimeOfSleepingSecond = 28800; // 9 hour
    [SerializeField] private int DEFAULT_twoThirdTimeOfSleepingSeond; // 5 hour 20 miniue
    [SerializeField] private float DEFAULT_reduceTimeSleeping = 0f;

    [SerializeField] private float DEFAULT_reduceTimeReadBook = 0f;
    [SerializeField] private float DEFAULT_reduceTimeTrainCourse = 0f;

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
        currentExp += xp;
        if (currentCharacterLevel < characterLevels.Length - 1)
        {
            int levelTarget = characterLevels[currentCharacterLevel + 1].requiredXP;

            if (currentExp >= levelTarget)
                SetCharacterLevel(currentCharacterLevel);
        } else
        {
            Debug.Log("maxlevel");
        }
    }

    public void ApplyCurrentMotivation(float currentMotivation)
    {
        if ((this.currentMotivation + currentMotivation) > DEFAULT_maxMotivation)
        {
            this.currentMotivation = DEFAULT_maxMotivation;
        }
        else
        {
            this.currentMotivation += currentMotivation;
        }

    }

    public void ApplyCurrentMoney(int currentMoney)
    {
        this.currentMoney += currentMoney;
    }

    public void ApplyCodingStatus(int codingAmount)
    {
        codingStatus += codingAmount;
    }

    public void ApplyDesignStatus(int designAmount)
    {
        designStatus += designAmount;
    }

    public void ApplyArtStatus(int artAmount)
    {
        artStatus += artAmount;
    }

    public void ApplyAudioStatus(int audioAmount)
    {
        audioStatus += audioAmount;
    }

    public void ApplyTestStatus(int testAmount)
    {
        testStatus += testAmount;
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
        if (hasPointStatus - 1 <= 0)
        {
            hasPointStatus = 0;
        }
        else
        {
            hasPointStatus--;
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

    public void ReduceCurrentMotivation(float currentMotivation)
    {
        if (this.currentMotivation - currentMotivation <= 0)
        {
            this.currentMotivation = 0;
        }
        else
        {
            this.currentMotivation -= currentMotivation;
        }
    }


    public void ReducedCoding(int codingAmount)
    {
        if(codingStatus - codingAmount <= 0)
        {
            codingStatus = 0;
        }
        else
        {
            codingStatus -= codingAmount;
        }
    }

    public void ReducedDesign(int designAmount)
    {
        if (designStatus - designAmount <= 0)
        {
            designStatus = 0;
        }
        else
        {
            designStatus -= designAmount;
        }
    }

    public void ReducedArt(int artAmount)
    {
        if (artStatus - artAmount <= 0)
        {
            artStatus = 0;
        }
        else
        {
            artStatus -= artAmount;
        }
    }

    public void ReducedAudio(int audioAmount)
    {
        if (audioStatus - audioAmount <= 0)
        {
            audioStatus = 0;
        }
        else
        {
            audioStatus -= audioAmount;
        }
    }

    public void ReducedTest(int testAmount)
    {
        if (testStatus - testAmount <= 0)
        {
            testStatus = 0;
        }
        else
        {
            testStatus -= testAmount;
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
        return nameCharacter;
    }

    public bool GetIsPlayer()
    {
        return isPlayer;
    }

    public float GetMaxEnergy()
    {
        return maxEnergy;
    }

    public float GetCurrentEnergy()
    {
        return currentEnergy;
    }

    public float GetCurrentMotivation()
    {
        return currentMotivation;
    }
    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public float GetDEFAULT_MaxMotivation()
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
        return codingStatus;
    }
    public int GetDesignStatus()
    {
        return designStatus;
    }
    public int GetArtStatus()
    {
        return artStatus;
    }
    public int GetAudioStatus()
    {
        return audioStatus;
    }
    public int GetTestStatus()
    {
        return testStatus;
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
    public float GetDEFAULT_negativeEventsChance()
    {
        return DEFAULT_negativeEventsChance;
    }
    public float GetDEFAULT_negativeEventsEffect()
    {
        return DEFAULT_negativeEventsEffect;
    }
    public float GetDEFAULT_positiveEventsEffect()
    {
        return DEFAULT_positiveEventsEffect;
    }
    public float GetDEFAULT_fullTimeOfSleepingSecond()
    {
        return DEFAULT_fullTimeOfSleepingSecond;
    }
    public float GetDEFAULT_twoThirdTimeOfSleepingSeond()
    {
        return DEFAULT_twoThirdTimeOfSleepingSeond;
    }
    public float GetDEFAULT_reduceTimeSleeping()
    {
        return DEFAULT_reduceTimeSleeping;
    }
    public float GetDEFAULT_reduceTimeReadBook()
    {
        return DEFAULT_reduceTimeReadBook;
    }
    public float GetDEFAULT_reduceTimeTrainCourse()
    {
        return DEFAULT_reduceTimeTrainCourse;
    }
    public int GetCurrentCharacterLevel()
    {
        return currentCharacterLevel;
    }
    public int GetCurrentExp()
    {
        return currentExp;
    }
    public int GetPointStatus()
    {
        return hasPointStatus;
    }
    public int GetSoftSkillPoints()
    {
        return hasSoftSkillPoints;
    }



    #endregion

    #region Character Level Up
    public void SetCharacterLevel(int characterLevel)
    {
        currentCharacterLevel = characterLevel + 1;
        currentExp = 0;

        hasPointStatus += characterLevels[currentCharacterLevel].pointStatus;
        hasSoftSkillPoints++;

        maxEnergy = characterLevels[currentCharacterLevel].maxEnergy;

        currentEnergy = maxEnergy;
        currentMotivation = DEFAULT_maxMotivation;

        DEFAULT_baseReduceEnergyConsumption += 0.01f;
        DEFAULT_goldenTimeReduceEnergyConsuption += 0.01f;

        DEFAULT_baseBootUpMotivation += 0.01f;
        DEFAULT_goldenTimeBootUpMotivation += 0.01f;

        DEFAULT_baseBootUpProject += 0.01f;
        DEFAULT_goldenTimeBootUpProject += 0.01f;
        DEFAULT_reduceBugChance += 0.01f;

        DEFAULT_charm += 0.1f;

        DEFAULT_negativeEventsChance -= 0.01f;
        DEFAULT_negativeEventsEffect -= 0.005f;

        DEFAULT_positiveEventsEffect += 0.005f;

        DEFAULT_fullTimeOfSleepingSecond -= 60;
        DEFAULT_twoThirdTimeOfSleepingSeond = (int) Mathf.RoundToInt(DEFAULT_fullTimeOfSleepingSecond * (0.6f));

        DEFAULT_reduceTimeSleeping += 0.005f;
        DEFAULT_reduceTimeReadBook += 0.005f;
        DEFAULT_reduceTimeTrainCourse += 0.005f;

        if (characterLevel > 1)
        {
            //OnLevelUp.Invoke(charLevel);
        }

    }
    #endregion
}
