using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    #region Fields

    [SerializeField]
    public CharacterStats_SO characterDefinition_Template;
    public CharacterStats_SO characterDeginition_Current;
    public CharacterSkill characterSkill;
    public StatsDisplay displayStats;

    #endregion

    #region Constuctors
    public CharacterStats()
    {
        displayStats = StatsDisplay.instance;
    }
    #endregion

    #region Initializations
    private void Awake()
    {
        if(characterDefinition_Template != null)
        {
            characterDeginition_Current = Instantiate(characterDefinition_Template);
        }
    }

    private void Start()
    {
        if (GetIsPlayer())
        {

        }
    }
    #endregion

    #region Stat Increasers
    public void ApplyMaxEnergy(int newEnergyAmount)
    {
        characterDeginition_Current.ApplyMaxEnergy(newEnergyAmount);
    }

    public void ApplyCurrentEnergy(int energyAmount)
    {
        characterDeginition_Current.ApplyCurrentEnergy(energyAmount);
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
        characterDeginition_Current.ApplyAudioStatus(audioAmount);
    }

    public void ReducedTest(int testAmount)
    {
        characterDeginition_Current.ApplyTestStatus(testAmount);
    }
    #endregion

    #region Reporter
    public string GetNameCharacter()
    {
        return characterDeginition_Current.GetNameCharacter();
    }

    public bool GetIsPlayer()
    {
        return characterDeginition_Current.GetIsPlayer();
    }

    public int GetMaxEnergy()
    {
        return characterDeginition_Current.GetMaxEnergy();
    }

    public int GetCurrentEnergy()
    {
        return characterDeginition_Current.GetCurrentEnergy();
    }

    public int GetStatusCoding()
    {
        return characterDeginition_Current.GetStatusCoding();
    }

    public int GetStatusDesign()
    {
        return characterDeginition_Current.GetStatusDesign();
    }

    public int GetStatusArt()
    {
        return characterDeginition_Current.GetStatusArt();
    }

    public int GetStatusTest()
    {
        return characterDeginition_Current.GetStatusTest();
    }

    public int GetStatusAudio()
    {
        return characterDeginition_Current.GetStatusAudio();
    }
    #endregion


}
