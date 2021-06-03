using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    #region Events
    public Events.EventOnEnergyUpdated OnEnergyUpdated;
    public Events.EventOnMotivationUpdated OnMotivationUpdated;
    public Events.EventOnMoneyUpdated OnMoneyUpdated;
    #endregion

    #region Fields
    private CharacterStatus_Template definition;
    private int currentLevel;
    private int currentExp;
    private int currentStatusPoints;
    private int currentSoftSkillPoints;
    private int currentEnergy;
    private int currentMotivation;
    private int currentMoney;
    private int currentCodingStatus;
    private int currentDesignStatus;
    private int currentTestingStatus;
    private int currentArtStatus;
    private int currentSoundStatus;
    #endregion

    public CharacterStatus(CharacterStatus_Template characterStatus_Template)
    {
        definition = Instantiate(characterStatus_Template);
        Initializing();
    }

    private void Initializing()
    {
        currentLevel = 0;
        currentExp = 0;
        currentStatusPoints = 0;
        currentSoftSkillPoints = 0;
        currentEnergy = definition.Default_maxEnergy;
        currentMotivation = definition.Default_maxMotivation;
        currentMoney = definition.DefaultMoney;
        currentCodingStatus = definition.Default_codingStatus;
        currentDesignStatus = definition.Default_designStatus;
        currentTestingStatus = definition.Default_testingStats;
        currentArtStatus = definition.Default_artStats;
        currentSoundStatus = definition.Default_soundStats;
        IncreaseEXP(0);
    }

    #region Stat Increasers
    public void IncreaseMaxEnergy(int newEnergyAmount)
    {
        definition.Default_maxEnergy = newEnergyAmount;
        OnEnergyUpdated?.Invoke();
    }

    public void IncreaseCurrentEnergy(int energyAmount)
    {
        if ((currentEnergy + energyAmount) > definition.Default_maxEnergy)
        {
            currentEnergy = definition.Default_maxEnergy;
        }
        else
        {
            currentEnergy += energyAmount;
        }
        OnEnergyUpdated?.Invoke();
    }
    public void IncreaseEXP(int xp)
    {
        currentExp += xp;
        if (currentLevel < definition.CharacterLevelRequiedList.Length - 1)
        {
            int levelTarget = definition.CharacterLevelRequiedList[currentLevel + 1].exp_required;

            if (currentExp >= levelTarget)
                SetCharacterLevelUp(currentLevel);
        }
        else
        {
            Debug.Log("maxlevel");
        }
    }

    public void IncreaseCurrentMotivation(int currentMotivation)
    {
        if ((this.currentMotivation + currentMotivation) > definition.Default_maxMotivation)
        {
            this.currentMotivation = definition.Default_maxMotivation;
        }
        else
        {
            this.currentMotivation += currentMotivation;
        }
        MotivationCalculated();
        OnMotivationUpdated?.Invoke();
    }

    public void IncreaseCurrentMoney(int currentMoney)
    {
        this.currentMoney += currentMoney;
        OnMoneyUpdated?.Invoke();
    }

    public void IncreaseCodingStatus(int codingAmount)
    {
        currentCodingStatus += codingAmount;
    }

    public void IncreaseDesignStatus(int designAmount)
    {
        currentDesignStatus += designAmount;
    }

    public void IncreaseArtStatus(int artAmount)
    {
        currentArtStatus += artAmount;
    }

    public void IncreaseSoundStatus(int soundAmount)
    {
        currentSoundStatus += soundAmount;
    }

    public void IncreaseTestingStatus(int testingAmount)
    {
        currentTestingStatus += testingAmount;
    }
    #endregion

    #region Stat Reducers
    public void TakeEnergy(int energyAmount)
    {
        if (currentEnergy - energyAmount <= 0)
        {
            currentEnergy = 0;
        }
        else
        {
            currentEnergy -= energyAmount;
        }
        OnEnergyUpdated?.Invoke();
    }

    public void TakeStatusPoint()
    {
        if (currentStatusPoints - 1 <= 0)
        {
            currentStatusPoints = 0;
        }
        else
        {
            currentStatusPoints--;
        }
    }

    public void TakeSoftSkillPoint()
    {
        if (currentSoftSkillPoints - 1 <= 0)
        {
            currentSoftSkillPoints = 0;
        }
        else
        {
            currentSoftSkillPoints--;
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
        OnMotivationUpdated?.Invoke();
    }

    public void ReducedCodingStatus(int codingAmount)
    {
        if (definition.Default_codingStatus - codingAmount <= 0)
        {
            currentCodingStatus = 0;
        }
        else
        {
            currentCodingStatus -= codingAmount;
        }
    }

    public void ReducedDesignStatus(int designAmount)
    {
        if (definition.Default_designStatus - designAmount <= 0)
        {
            currentDesignStatus = 0;
        }
        else
        {
            currentDesignStatus -= designAmount;
        }
    }

    public void ReducedArtStatus(int artAmount)
    {
        if (definition.Default_artStats - artAmount <= 0)
        {
            currentArtStatus = 0;
        }
        else
        {
            currentArtStatus -= artAmount;
        }
    }

    public void ReducedSoundStatus(int soundAmount)
    {
        if (definition.Default_soundStats - soundAmount <= 0)
        {
            currentSoundStatus = 0;
        }
        else
        {
            currentSoundStatus -= soundAmount;
        }
    }

    public void ReducedTestingStatus(int testAmount)
    {
        if (definition.Default_testingStats - testAmount <= 0)
        {
            currentTestingStatus = 0;
        }
        else
        {
            currentTestingStatus -= testAmount;
        }
    }

    public void TakeMoney(int currentMoney)
    {
        this.currentMoney -= currentMoney;
        OnMoneyUpdated?.Invoke();
    }
    #endregion

    #region Character Level Up
    public void SetCharacterLevelUp(int characterLevel)
    {
        currentLevel = characterLevel + 1;

        currentStatusPoints += definition.CharacterLevelRequiedList[currentLevel].stats_points;

        definition.Default_maxEnergy = definition.CharacterLevelRequiedList[currentLevel].maxEnergy;

        currentEnergy = definition.Default_maxEnergy;
        currentMotivation = definition.Default_maxMotivation;

        currentSoftSkillPoints += definition.LevelUp_softskillPoints;

        if (characterLevel > 1)
        {
            definition.Default_baseReduceEnergyConsumption += definition.LevelUp_baseReduceEnergyConsumption;
            definition.Defautl_goldenTimeReduceEnergyConsuption += definition.LevelUp_goldenTimeReduceEnergyConsuption;

            definition.Default_baseBootUpMotivation += definition.LevelUp_baseBootUpMotivation;
            definition.Default_goldenTimeBootUpMotivation += definition.LevelUp_goldenTimeBootUpMotivation;

            definition.Default_baseBootUpProject += definition.LevelUp_baseBootUpProject;
            definition.Default_goldenTimeBootUpProject += definition.LevelUp_goldenTimeBootUpProject;
            definition.Default_reduceBugChance += definition.LevelUp_reduceBugChance;

            definition.Default_charm += definition.LevelUp_charm;

            definition.Default_negativeEventsEffect -= definition.LevelUp_negativeEventsEffect;

            definition.Default_positiveEventsEffect += definition.LevelUp_positiveEventsEffect;

            definition.Default_reduceTimeTrainCourse += definition.LevelUp_reduceTimeTrainCourse;
            definition.Default_reduceTimeTransport += definition.LevelUp_reduceTimeTransport;

            definition.Default_dropRate += definition.LevelUp_dropRate;
            //OnLevelUp.Invoke(charLevel);
        }

        int levelTarget = definition.CharacterLevelRequiedList[currentLevel + 1].exp_required;
        if (currentExp > levelTarget)
        {
            SetCharacterLevelUp(currentLevel);
        }
    }
    #endregion

    #region Calculated Motivation
    private float MotivationCalculated()
    {
        float motivationCalculated;
        if (currentMotivation > 79)
        {
            motivationCalculated = 1f;
        }
        else if (currentMotivation > 59)
        {
            motivationCalculated = 0.9f;
        }
        else if (currentMotivation > 39)
        {
            motivationCalculated = 0.7f;
        }
        else if (currentMotivation > 19)
        {
            motivationCalculated = 0.5f;
        }
        else
        {
            motivationCalculated = 0.3f;
        }
        return motivationCalculated;
    }
    #endregion

    #region Reporter
    public int CurrentLevel { get => currentLevel; }
    public int CurrentExp { get => currentExp; }
    public int CurrentStatusPoints { get => currentStatusPoints; }
    public int CurrentSoftSkillPoints { get => currentSoftSkillPoints; }
    public int CurrentEnergy { get => currentEnergy; }
    public int CurrentMotivation { get => currentMotivation; }
    public int CurrentMoney { get => currentMoney; }
    public int CurrentCodingStatus { get => currentCodingStatus; }
    public int CurrentDesignStatus { get => currentDesignStatus; }
    public int CurrentTestingStatus { get => currentTestingStatus; }
    public int CurrentArtStatus { get => currentArtStatus; }
    public int CurrentSoundStatus { get => currentSoundStatus; }
    public string Character_Name { get => definition.Character_Name; }
    public int Default_maxMotivation { get => definition.Default_maxMotivation; }
    public int Default_maxEnergy { get => definition.Default_maxEnergy; }
    public float Default_dropRate { get => definition.Default_dropRate; }
    public float Default_baseReduceEnergyConsumption { get => definition.Default_baseReduceEnergyConsumption; }
    public float Defautl_goldenTimeReduceEnergyConsuption { get => definition.Defautl_goldenTimeReduceEnergyConsuption; }
    public float Default_baseBootUpMotivation { get => definition.Default_baseBootUpMotivation; }
    public float Default_goldenTimeBootUpMotivation { get => definition.Default_goldenTimeBootUpMotivation; }
    public int DefaultMoney { get => definition.DefaultMoney; }
    public int Default_codingStatus { get => definition.Default_codingStatus; }
    public int Default_designStatus { get => definition.Default_designStatus; }
    public int Default_artStats { get => definition.Default_artStats; }
    public int Default_soundStats { get => definition.Default_soundStats; }
    public int Default_testingStats { get => definition.Default_testingStats; }
    public float Default_baseBootUpProject { get => definition.Default_baseBootUpProject; }
    public float Default_goldenTimeBootUpProject { get => definition.Default_goldenTimeBootUpProject; }
    public float Default_reduceBugChance { get => definition.Default_reduceBugChance; }
    public float Default_charm { get => definition.Default_charm; }
    public float Default_negativeEventsEffect { get => definition.Default_negativeEventsEffect; }
    public float Default_positiveEventsEffect { get => definition.Default_positiveEventsEffect; }
    public float Default_reduceTimeTrainCourse { get => definition.Default_reduceTimeTrainCourse; }
    public float Default_reduceTimeTransport { get => definition.Default_reduceTimeTransport; }
    #endregion
}
