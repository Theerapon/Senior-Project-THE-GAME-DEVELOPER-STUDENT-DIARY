using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : Manager<CharacterStats>
{
    #region Fields

    [SerializeField]
    public CharacterStats_SO characterDefinition_Template;
    public CharacterStats_SO characterDeginition_Current;

    #endregion

    #region Initializations
    protected override void Awake()
    {
        base.Awake();
        if(characterDefinition_Template != null)
        {
            characterDeginition_Current = Instantiate(characterDefinition_Template);
            characterDeginition_Current.GiveXP(0);
        }
    }


    #endregion

    #region Stat Increasers
    public void ApplySleepFullTimeSelected(bool fullTime)
    {
        characterDeginition_Current.ApplySleepFullTimeSelected(fullTime);
    }
    public void ApplyMaxEnergy(int newEnergyAmount)
    {
        characterDeginition_Current.ApplyMaxEnergy(newEnergyAmount);
    }

    public void ApplyCurrentEnergy(int energyAmount)
    {
        characterDeginition_Current.ApplyCurrentEnergy(energyAmount);
    }
    public void GiveXP(int xp)
    {
        characterDeginition_Current.GiveXP(xp);
    }

    public void ApplyCurrentMotivation(int currentMotivation)
    {
        characterDeginition_Current.ApplyCurrentMotivation(currentMotivation);

    }

    public void ApplyCurrentMoney(int currentMoney)
    {
        characterDeginition_Current.ApplyCurrentMoney(currentMoney);
    }

    public void ApplyCodingStatus(int codingAmount)
    {
        characterDeginition_Current.ApplyCodingStatus(codingAmount);
    }

    public void ApplyDesignStatus(int designAmount)
    {
        characterDeginition_Current.ApplyDesignStatus(designAmount);
    }

    public void ApplyArtStatus(int artAmount)
    {
        characterDeginition_Current.ApplyArtStatus(artAmount);
    }

    public void ApplyAudioStatus(int audioAmount)
    {
        characterDeginition_Current.ApplyAudioStatus(audioAmount);
    }

    public void ApplyTestStatus(int testAmount)
    {
        characterDeginition_Current.ApplyTestStatus(testAmount);
    }
    #endregion

    #region Stat Reducers
    public void TakeEnergy(int energyAmount)
    {
        characterDeginition_Current.TakeEnergy(energyAmount);
    }

    public void UseStatusPoint()
    {
        characterDeginition_Current.UseStatusPoint();
    }

    public void UseSoftSkillPoint()
    {
        characterDeginition_Current.UseSoftSkillPoint();
    }

    public void ReduceCurrentMotivation(int currentMotivation)
    {
        characterDeginition_Current.ReduceCurrentMotivation(currentMotivation);
    }


    public void ReducedCoding(int codingAmount)
    {
        characterDeginition_Current.ReducedCoding(codingAmount);
    }

    public void ReducedDesign(int designAmount)
    {
        characterDeginition_Current.ReducedDesign(designAmount);
    }

    public void ReducedArt(int artAmount)
    {
        characterDeginition_Current.ReducedArt(artAmount);
    }

    public void ReducedAudio(int audioAmount)
    {
        characterDeginition_Current.ReducedAudio(audioAmount);
    }

    public void ReducedTest(int testAmount)
    {
        characterDeginition_Current.ReducedTest(testAmount);
    }

    public void TakeMoney(int currentMoney)
    {
        characterDeginition_Current.TakeMoney(currentMoney);
    }
    #endregion

    #region Reporter
    public bool GetSleepFullTimeSelected()
    {
        return characterDeginition_Current.GetSleepFullTimeSelected();
    }
    public string GetNameCharacter()
    {
        return characterDeginition_Current.GetNameCharacter();
    }

    public bool GetIsPlayer()
    {
        return characterDeginition_Current.GetIsPlayer();
    }

    public float GetMaxEnergy()
    {
        return characterDeginition_Current.GetMaxEnergy();
    }

    public float GetCurrentEnergy()
    {
        return characterDeginition_Current.GetCurrentEnergy();
    }

    public int GetCurrentMotivation()
    {
        return characterDeginition_Current.GetCurrentMotivation();
    }
    public int GetCurrentMoney()
    {
        return characterDeginition_Current.GetCurrentMoney();
    }

    public int GetDEFAULT_MaxMotivation()
    {
        return characterDeginition_Current.GetDEFAULT_MaxMotivation();
    }

    public float GetDEFAULT_baseReduceEnergyConsumption()
    {
        return characterDeginition_Current.GetDEFAULT_baseReduceEnergyConsumption();
    }
    public float GetDEFAULT_goldenTimeReduceEnergyConsuption()
    {
        return characterDeginition_Current.GetDEFAULT_goldenTimeReduceEnergyConsuption();
    }

    public float GetDEFAULT_baseBootUpMotivation()
    {
        return characterDeginition_Current.GetDEFAULT_baseBootUpMotivation();
    }
    public float GetDEFAULT_goldenTimeBootUpMotivation()
    {
        return characterDeginition_Current.GetDEFAULT_goldenTimeBootUpMotivation();
    }
    public int GetCodingStatus()
    {
        return characterDeginition_Current.GetCodingStatus();
    }
    public int GetDesignStatus()
    {
        return characterDeginition_Current.GetDesignStatus();
    }
    public int GetArtStatus()
    {
        return characterDeginition_Current.GetArtStatus();
    }
    public int GetAudioStatus()
    {
        return characterDeginition_Current.GetAudioStatus();
    }
    public int GetTestStatus()
    {
        return characterDeginition_Current.GetTestStatus();
    }
    public float GetDEFAULT_baseBootUpProject()
    {
        return characterDeginition_Current.GetDEFAULT_baseBootUpProject();
    }
    public float GetDEFAULT_goldenTimeBootUpProject()
    {
        return characterDeginition_Current.GetDEFAULT_goldenTimeBootUpProject();
    }
    public float GetDEFAULT_reduceBugChance()
    {
        return characterDeginition_Current.GetDEFAULT_reduceBugChance();
    }
    public float GetDEFAULT_charm()
    {
        return characterDeginition_Current.GetDEFAULT_charm();
    }
    public float GetDEFAULT_negativeEventsChance()
    {
        return characterDeginition_Current.GetDEFAULT_negativeEventsChance();
    }
    public float GetDEFAULT_negativeEventsEffect()
    {
        return characterDeginition_Current.GetDEFAULT_negativeEventsEffect();
    }
    public float GetDEFAULT_positiveEventsEffect()
    {
        return characterDeginition_Current.GetDEFAULT_positiveEventsEffect();
    }
    public int GetDEFAULT_fullTimeOfSleepingSecond()
    {
        return characterDeginition_Current.GetDEFAULT_fullTimeOfSleepingSecond();
    }
    public int GetDEFAULT_twoThirdTimeOfSleepingSeond()
    {
        return characterDeginition_Current.GetDEFAULT_twoThirdTimeOfSleepingSeond();
    }
    public float GetDEFAULT_reduceTimeSleeping()
    {
        return characterDeginition_Current.GetDEFAULT_reduceTimeSleeping();
    }
    public float GetDEFAULT_reduceTimeReadBook()
    {
        return characterDeginition_Current.GetDEFAULT_reduceTimeReadBook();
    }
    public float GetDEFAULT_reduceTimeTrainCourse()
    {
        return characterDeginition_Current.GetDEFAULT_reduceTimeTrainCourse();
    }
    public int GetCurrentCharacterLevel()
    {
        return characterDeginition_Current.GetCurrentCharacterLevel();
    }
    public int GetCurrentExp()
    {
        return characterDeginition_Current.GetCurrentExp();
    }
    public int GetPointStatus()
    {
        return characterDeginition_Current.GetPointStatus();
    }
    public int GetSoftSkillPoints()
    {
        return characterDeginition_Current.GetSoftSkillPoints();
    }

    public string GetFullTimeSleepText()
    {
        return characterDeginition_Current.GetFullTimeSleepText();
    }

    public string GetTwoThirdSleepText()
    {
        return characterDeginition_Current.GetTwoThirdSleepText();
    }
    #endregion


}
