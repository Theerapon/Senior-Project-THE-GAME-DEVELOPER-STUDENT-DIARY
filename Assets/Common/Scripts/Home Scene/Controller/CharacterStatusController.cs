using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusController : Manager<CharacterStatusController>
{
    #region Events
    public Events.EventOnEnergyUpdated OnEnergyUpdated;
    public Events.EventOnMotivationUpdated OnMotivationUpdated;
    public Events.EventOnMoneyUpdated OnMoneyUpdated;
    #endregion

    private CharacterStatus_DataHandler characterStatus_DataHandler;
    private CharacterStatus characterStatus;
    public CharacterStatus CharacterStatus { get => characterStatus; }

    protected override void Awake()
    {
        base.Awake();
        characterStatus_DataHandler = FindObjectOfType<CharacterStatus_DataHandler>();
        if (!ReferenceEquals(characterStatus_DataHandler, null))
        {
            characterStatus = new CharacterStatus(characterStatus_DataHandler.GetCharacterTemplate);
            Debug.Log("wait implementation for load save data");
        }

    }

    private void MoneyHandler()
    {
        OnEnergyUpdated?.Invoke();
    }

    private void MotivationHandler()
    {
        OnMotivationUpdated?.Invoke();
    }

    private void EnergyHandler()
    {
        OnMoneyUpdated?.Invoke();
    }

    public float GetEfficiencyToDo()
    {
        return characterStatus.GetEfficiencyToDo();
    }
    public float CalEfficiencyToDo(float motivation)
    {
        return characterStatus.CalEfficiencyToDo(motivation);
    }

    #region Stat Increasers
    public void IncreaseMaxEnergy(int newEnergyAmount)
    {
        characterStatus.IncreaseMaxEnergy(newEnergyAmount);
    }

    public void IncreaseCurrentEnergy(int energyAmount)
    {
        characterStatus.IncreaseCurrentEnergy(energyAmount);
    }
    public void IncreaseEXP(int xp)
    {
        characterStatus.IncreaseEXP(xp);
    }

    public void IncreaseCurrentMotivation(int currentMotivation)
    {
        characterStatus.IncreaseCurrentMotivation(currentMotivation);
    }

    public void IncreaseCurrentMoney(int currentMoney)
    {
        characterStatus.IncreaseCurrentMoney(currentMoney);
    }

    public void IncreaseCodingStatus(int codingAmount)
    {
        characterStatus.IncreaseCodingStatus(codingAmount);
    }

    public void IncreaseDesignStatus(int designAmount)
    {
        characterStatus.IncreaseDesignStatus(designAmount);
    }

    public void IncreaseArtStatus(int artAmount)
    {
        characterStatus.IncreaseArtStatus(artAmount);
    }

    public void IncreaseSoundStatus(int soundAmount)
    {
        characterStatus.IncreaseSoundStatus(soundAmount);
    }

    public void IncreaseTestingStatus(int testingAmount)
    {
        characterStatus.IncreaseTestingStatus(testingAmount);
    }
    #endregion

    #region Stat Reducers
    public void TakeEnergy(int energyAmount)
    {
        characterStatus.TakeEnergy(energyAmount);
    }

    public void TakeStatusPoint()
    {
        characterStatus.TakeStatusPoint();
    }

    public void TakeSoftSkillPoint()
    {
        characterStatus.TakeSoftSkillPoint();
    }

    public void TakeMotivation(int currentMotivation)
    {
        characterStatus.TakeMotivation(currentMotivation);
    }

    public void ReducedCodingStatus(int codingAmount)
    {
        characterStatus.ReducedCodingStatus(codingAmount);
    }

    public void ReducedDesignStatus(int designAmount)
    {
        characterStatus.ReducedDesignStatus(designAmount);
    }

    public void ReducedArtStatus(int artAmount)
    {
        characterStatus.ReducedArtStatus(artAmount);
    }

    public void ReducedSoundStatus(int soundAmount)
    {
        characterStatus.ReducedSoundStatus(soundAmount);
    }

    public void ReducedTestingStatus(int testAmount)
    {
        characterStatus.ReducedTestingStatus(testAmount);
    }

    public void TakeMoney(int currentMoney)
    {
        characterStatus.TakeMoney(currentMoney);
    }
    #endregion
    #region Reporter
    public int CurrentLevel { get => characterStatus.CurrentLevel; }
    public int CurrentExp { get => characterStatus.CurrentExp; }
    public int CurrentStatusPoints { get => characterStatus.CurrentStatusPoints; }
    public int CurrentSoftSkillPoints { get => characterStatus.CurrentSoftSkillPoints; }
    public float CurrentEnergy { get => characterStatus.CurrentEnergy; }
    public float CurrentMotivation { get => characterStatus.CurrentMotivation; }
    public int CurrentMoney { get => characterStatus.CurrentMoney; }
    public int CurrentCodingStatus { get => characterStatus.CurrentCodingStatus; }
    public int CurrentDesignStatus { get => characterStatus.CurrentDesignStatus; }
    public int CurrentTestingStatus { get => characterStatus.CurrentTestingStatus; }
    public int CurrentArtStatus { get => characterStatus.CurrentArtStatus; }
    public int CurrentSoundStatus { get => characterStatus.CurrentSoundStatus; }
    public string Character_Name { get => characterStatus.Character_Name; }
    public float Default_maxMotivation { get => characterStatus.Default_maxMotivation; }
    public float Default_maxEnergy { get => characterStatus.Default_maxEnergy; }
    public float Default_dropRate { get => characterStatus.Default_dropRate; }
    public float Default_baseReduceEnergyConsumption { get => characterStatus.Default_baseReduceEnergyConsumption; }
    public float Defautl_goldenTimeReduceEnergyConsuption { get => characterStatus.Defautl_goldenTimeReduceEnergyConsuption; }
    public float Default_baseBootUpMotivation { get => characterStatus.Default_baseBootUpMotivation; }
    public float Default_goldenTimeBootUpMotivation { get => characterStatus.Default_goldenTimeBootUpMotivation; }
    public int DefaultMoney { get => characterStatus.DefaultMoney; }
    public int Default_codingStatus { get => characterStatus.Default_codingStatus; }
    public int Default_designStatus { get => characterStatus.Default_designStatus; }
    public int Default_artStats { get => characterStatus.Default_artStats; }
    public int Default_soundStats { get => characterStatus.Default_soundStats; }
    public int Default_testingStats { get => characterStatus.Default_testingStats; }
    public float Default_baseBootUpProject { get => characterStatus.Default_baseBootUpProject; }
    public float Default_goldenTimeBootUpProject { get => characterStatus.Default_goldenTimeBootUpProject; }
    public float Default_reduceBugChance { get => characterStatus.Default_reduceBugChance; }
    public float Default_charm { get => characterStatus.Default_charm; }
    public float Default_negativeEventsEffect { get => characterStatus.Default_negativeEventsEffect; }
    public float Default_positiveEventsEffect { get => characterStatus.Default_positiveEventsEffect; }
    public float Default_reduceTimeTrainCourse { get => characterStatus.Default_reduceTimeTrainCourse; }
    public float Default_reduceTimeTransport { get => characterStatus.Default_reduceTimeTransport; }
    #endregion
}
