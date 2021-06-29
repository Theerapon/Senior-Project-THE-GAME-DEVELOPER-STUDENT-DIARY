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
    public Events.EventOnExpUpdated OnExpUpdated;
    public Events.EventOnStatusUpdated OnStatusUpdated;
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
        }

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
        OnEnergyUpdated?.Invoke();
    }

    public void IncreaseCurrentEnergy(int energyAmount)
    {
        characterStatus.IncreaseCurrentEnergy(energyAmount);
        OnEnergyUpdated?.Invoke();
    }
    public void IncreaseEXP(int xp)
    {
        characterStatus.IncreaseEXP(xp);
        OnExpUpdated?.Invoke();
    }

    public void IncreaseCurrentMotivation(int currentMotivation)
    {
        characterStatus.IncreaseCurrentMotivation(currentMotivation);
        OnMotivationUpdated?.Invoke();
    }

    public void IncreaseCurrentMoney(int currentMoney)
    {
        characterStatus.IncreaseCurrentMoney(currentMoney);
        OnMoneyUpdated?.Invoke();
    }

    public void IncreaseCodingStatus(int codingAmount)
    {
        characterStatus.IncreaseCodingStatus(codingAmount);
        OnStatusUpdated?.Invoke();
    }

    public void IncreaseDesignStatus(int designAmount)
    {
        characterStatus.IncreaseDesignStatus(designAmount);
        OnStatusUpdated?.Invoke();
    }

    public void IncreaseArtStatus(int artAmount)
    {
        characterStatus.IncreaseArtStatus(artAmount);
        OnStatusUpdated?.Invoke();
    }

    public void IncreaseSoundStatus(int soundAmount)
    {
        characterStatus.IncreaseSoundStatus(soundAmount);
        OnStatusUpdated?.Invoke();
    }

    public void IncreaseTestingStatus(int testingAmount)
    {
        characterStatus.IncreaseTestingStatus(testingAmount);
        OnStatusUpdated?.Invoke();
    }
    #endregion

    #region Stat Reducers
    public void TakeEnergy(float energyAmount)
    {
        characterStatus.TakeEnergy(energyAmount);
        OnEnergyUpdated?.Invoke();
    }

    public void TakeStatusPoint()
    {
        characterStatus.TakeStatusPoint();
        OnStatusUpdated?.Invoke();
    }

    public void TakeSoftSkillPoint()
    {
        characterStatus.TakeSoftSkillPoint();
        OnStatusUpdated?.Invoke();
    }

    public void TakeMotivation(float currentMotivation)
    {
        characterStatus.TakeMotivation(currentMotivation);
        OnMotivationUpdated?.Invoke();
    }

    public void ReducedCodingStatus(int codingAmount)
    {
        characterStatus.ReducedCodingStatus(codingAmount);
        OnStatusUpdated?.Invoke();
    }

    public void ReducedDesignStatus(int designAmount)
    {
        characterStatus.ReducedDesignStatus(designAmount);
        OnStatusUpdated?.Invoke();
    }

    public void ReducedArtStatus(int artAmount)
    {
        characterStatus.ReducedArtStatus(artAmount);
        OnStatusUpdated?.Invoke();
    }

    public void ReducedSoundStatus(int soundAmount)
    {
        characterStatus.ReducedSoundStatus(soundAmount);
        OnStatusUpdated?.Invoke();
    }

    public void ReducedTestingStatus(int testAmount)
    {
        characterStatus.ReducedTestingStatus(testAmount);
        OnStatusUpdated?.Invoke();
    }

    public void TakeMoney(int currentMoney)
    {
        characterStatus.TakeMoney(currentMoney);
        OnMoneyUpdated?.Invoke();
    }
    #endregion
    #region Reporter
    public Sprite CharacterProfile { get => characterStatus.CharacterProfile; }
    public Sprite CharacterIcon { get => characterStatus.CharacterIcon; }
    public string Character_ID { get => characterStatus.Character_ID; }
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
    public float Default_reduceTimeTrainCourse { get => characterStatus.Default_reduceTimeTrainCourse; }
    public float Default_reduceTimeTransport { get => characterStatus.Default_reduceTimeTransport; }
    public int GetNextExpRequire()
    {
        return characterStatus.GetNextExpRequire();
    }
    #endregion

    public void ValidateDisplay()
    {
        OnEnergyUpdated?.Invoke();
        OnMoneyUpdated?.Invoke();
        OnExpUpdated?.Invoke();
        OnMotivationUpdated?.Invoke();
        OnStatusUpdated?.Invoke();
    }
}
