using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]
public class CharacterStats_SO : ScriptableObject
{

    #region Fields
    [SerializeField] private string nameCharacter = "";

    [SerializeField] private bool isPlayer = false;

    [SerializeField] private int maxEnergy = 0;
    [SerializeField] private int currentEnergy = 0;

    [SerializeField] private int currentMoney = 0;

    [SerializeField] private int codingStatus = 0;
    [SerializeField] private int designStatus = 0;
    [SerializeField] private int artStatus = 0;
    [SerializeField] private int audioStatus = 0;
    [SerializeField] private int testStatus = 0;

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

    public int GetMaxEnergy()
    {
        return maxEnergy;
    }

    public int GetCurrentEnergy()
    {
        return currentEnergy;
    }

    public int GetStatusCoding()
    {
        return codingStatus;
    }

    public int GetStatusDesign()
    {
        return designStatus;
    }

    public int GetStatusArt()
    {
        return artStatus;
    }

    public int GetStatusTest()
    {
        return testStatus;
    }

    public int GetStatusAudio()
    {
        return audioStatus;
    }

    #endregion
}
