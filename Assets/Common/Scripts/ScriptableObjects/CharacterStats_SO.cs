using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]
public class CharacterStats_SO : ScriptableObject
{

    #region Fields
    [SerializeField] private string nameCharacter = "";

    [SerializeField] private bool isPlayer = false;

    [SerializeField] private float maxEnergy = 100f;
    [SerializeField] private const float DEFAULT_currentEnergy = 0f;
    [SerializeField] private const float DEFAULT_baseReduceEnergyConsumption = 0f; // 0%
    [SerializeField] private const float DEFAULT_goldenTimeReduceEnergyConsuption = 0.05f; // 5%
    private float currentEnergy = DEFAULT_currentEnergy;
    private float baseReduceEnergyConsumption = DEFAULT_baseReduceEnergyConsumption;
    private float goldenTimeReduceEnergyConsuption = DEFAULT_goldenTimeReduceEnergyConsuption;


    [SerializeField] private const float DEFAULT_maxMotivation = 100f;
    [SerializeField] private const float DEFAULT_currentMotivation = 0f;
    [SerializeField] private const float DEFAULT_baseBootUpMotivation = 0f; // 0%
    [SerializeField] private const float DEFAULT_goldenTimeBootUpMotivation = 0.05f; // 5%
    private float currentMotivation = DEFAULT_currentMotivation;
    private float baseBootUpMotivation = DEFAULT_baseBootUpMotivation;
    private float goldenTimeBootUpMotivation = DEFAULT_goldenTimeBootUpMotivation;


    [SerializeField] private int currentMoney = 0;

    [SerializeField] private const int DEFAULT_codingStatus = 10;
    [SerializeField] private const int DEFAULT_designStatus = 10;
    [SerializeField] private const int DEFAULT_artStatus = 10;
    [SerializeField] private const int DEFAULT_audioStatus = 10;
    [SerializeField] private const int DEFAULT_testStatus = 10;
    private int codingStatus = DEFAULT_codingStatus;
    private int designStatus = DEFAULT_designStatus;
    private int artStatus = DEFAULT_artStatus;
    private int audioStatus = DEFAULT_audioStatus;
    private int testStatus = DEFAULT_testStatus;

    [SerializeField] private const float DEFAULT_baseBootUpProject = 0f; // 0%
    [SerializeField] private const float DEFAULT_goldenTimeBootUpProject = 0.05f; // 5%
    private float baseBootUpProject = DEFAULT_baseBootUpProject;
    private float goldenTimeBootUpProject = DEFAULT_goldenTimeBootUpProject;
    [SerializeField] private const float DEFAULT_reduceBugChance = 0f;
    private float reduceBugChance = DEFAULT_reduceBugChance;

    [SerializeField] private const float DEFAULT_charm = 1f;
    private float charm = DEFAULT_charm;

    [SerializeField] private const float DEFAULT_negativeEventsChance = 0.3f; // 30%
    [SerializeField] private const float DEFAULT_negativeEventsEffect = 1f; // 100%
    [SerializeField] private const float DEFAULT_positiveEventsEffect = 1f; // 100%
    private float negativeEventsChance = DEFAULT_negativeEventsChance; // 30%
    private float negativeEventsEffect = DEFAULT_negativeEventsEffect; // 100%
    private float positiveEventsEffect = DEFAULT_positiveEventsEffect; // 100%

    [SerializeField] private const int DEFAULT_fullTimeOfSleepingSecond = 28800; // 9 hour
    [SerializeField] private const int DEFAULT_twoThirdTimeOfSleepingSeond = DEFAULT_fullTimeOfSleepingSecond * (2 / 3); // 5 hour 20 miniue
    [SerializeField] private const float DEFAULT_reduceTimeSleeping = 0f;
    private float reduceTimeSleeping = DEFAULT_reduceTimeSleeping;

    [SerializeField] private const float DEFAULT_reduceTimeReadBook = 0f;
    [SerializeField] private const float DEFAULT_reduceTimeTrainCourse = 0f;
    private float reduceTimeReadBook = DEFAULT_reduceTimeReadBook;
    private float reduceTimeTrainCourse = DEFAULT_reduceTimeTrainCourse;

    #endregion


    #region Stat Increasers
    public void ApplyMaxEnergy(float newEnergyAmount)
    {
        maxEnergy = newEnergyAmount;
    }

    public void ApplyCurrentEnergy(float energyAmount)
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

    public void ApplyBaseReduceEnergyConsumption(float baseReduceEnergyConsumption)
    {
        this.baseReduceEnergyConsumption += baseReduceEnergyConsumption;
    }

    public void ApplyGoldenTimeReduceEnergyConsuption(float goldenTimeReduceEnergyConsuption)
    {
        this.goldenTimeReduceEnergyConsuption += goldenTimeReduceEnergyConsuption;
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

    public void ApplyBaseBootUpMotivation(float baseBootUpMotivation)
    {
        this.baseBootUpMotivation += baseBootUpMotivation;
    }

    public void ApplyGoldenTimeBootUpMotivation(float goldenTimeBootUpMotivation)
    {
        this.goldenTimeBootUpMotivation += goldenTimeBootUpMotivation;
    }

    public void ApplyBaseBootUpProject(float baseBootUpProject)
    {
        this.baseBootUpProject += baseBootUpProject;
    }

    public void ApplyGoldenTimeBootUpProject(float goldenTimeBootUpProject)
    {
        this.goldenTimeBootUpProject += goldenTimeBootUpProject;
    }

    public void ApplyReduceBugChance(float reduceBugChance)
    {
        this.reduceBugChance += reduceBugChance;
    }

    public void ApplyNegativeEventsChance(float negativeEventsChance)
    {
        this.negativeEventsChance += negativeEventsChance;
    }

    public void ApplyNegativeEventsEffect(float negativeEventsEffect)
    {
        this.negativeEventsEffect += negativeEventsEffect;
    }

    public void ApplyPositiveEventsEffect(float positiveEventsEffect)
    {
        this.positiveEventsEffect += positiveEventsEffect;
    }

    public void ApplyReduceTimeSleeping(float reduceTimeSleeping)
    {
        this.reduceTimeSleeping += reduceTimeSleeping;
    }

    public void ApplyReduceTimeReadBook(float reduceTimeReadBook)
    {
        this.reduceTimeReadBook += reduceTimeReadBook;
    }

    public void ApplyReduceTimeTrainCourse(float reduceTimeTrainCourse)
    {
        this.reduceTimeTrainCourse += reduceTimeTrainCourse;
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
    public void TakeEnergy(float energyAmount)
    {
        if(currentEnergy - energyAmount <= DEFAULT_currentEnergy)
        {
            currentEnergy = DEFAULT_currentEnergy;
        }
        else
        {
            currentEnergy -= energyAmount;
        }
    }

    public void ReduceBaseReduceEnergyConsumption(float baseReduceEnergy)
    {
        if(baseReduceEnergyConsumption - baseReduceEnergy <= DEFAULT_baseReduceEnergyConsumption)
        {
            baseReduceEnergyConsumption = DEFAULT_baseReduceEnergyConsumption;
        }
        else
        {
            baseReduceEnergyConsumption -= baseReduceEnergy;
        }
    }

    public void ReduceGoldenTimeReduceEnergyConsuption(float goldenTimeReduceEnergy)
    {
        if (goldenTimeReduceEnergyConsuption - goldenTimeReduceEnergy <= DEFAULT_goldenTimeReduceEnergyConsuption)
        {
            goldenTimeReduceEnergyConsuption = DEFAULT_goldenTimeReduceEnergyConsuption;
        }
        else
        {
            goldenTimeReduceEnergyConsuption -= goldenTimeReduceEnergy;
        }
    }

    public void ReduceCurrentMotivation(float currentMotivation)
    {
        if (this.currentMotivation - currentMotivation <= DEFAULT_currentMotivation)
        {
            this.currentMotivation = DEFAULT_currentMotivation;
        }
        else
        {
            this.currentMotivation -= currentMotivation;
        }
    }

    public void ReduceBaseBootUpMotivation(float baseBootUpMotivation)
    {
        if (this.baseBootUpMotivation - baseBootUpMotivation <= DEFAULT_baseBootUpMotivation)
        {
            this.baseBootUpMotivation = DEFAULT_baseBootUpMotivation;
        }
        else
        {
            this.baseBootUpMotivation -= baseBootUpMotivation;
        }
    }

    public void ReduceGoldenTimeBootUpMotivation(float goldenTimeBootUpMotivation)
    {
        if (this.goldenTimeBootUpMotivation - goldenTimeBootUpMotivation <= DEFAULT_goldenTimeBootUpMotivation)
        {
            this.goldenTimeBootUpMotivation = DEFAULT_goldenTimeBootUpMotivation;
        }
        else
        {
            this.goldenTimeBootUpMotivation -= goldenTimeBootUpMotivation;
        }
    }

    public void ReduceBaseBootUpProject(float baseBootUpProject)
    {
        if (this.baseBootUpProject - baseBootUpProject <= DEFAULT_baseBootUpProject)
        {
            this.baseBootUpProject = DEFAULT_baseBootUpProject;
        }
        else
        {
            this.baseBootUpProject -= baseBootUpProject;
        }
    }

    public void ReduceGoldenTimeBootUpProject(float goldenTimeBootUpProject)
    {
        if (this.goldenTimeBootUpProject - goldenTimeBootUpProject <= DEFAULT_goldenTimeBootUpProject)
        {
            this.goldenTimeBootUpProject = DEFAULT_goldenTimeBootUpProject;
        }
        else
        {
            this.goldenTimeBootUpProject -= goldenTimeBootUpProject;
        }
    }

    public void ReduceReduceBugChance(float reduceBugChance)
    {
        if (this.reduceBugChance - reduceBugChance <= DEFAULT_reduceBugChance)
        {
            this.reduceBugChance = DEFAULT_reduceBugChance;
        }
        else
        {
            this.reduceBugChance -= reduceBugChance;
        }
    }

    public void ReduceCharm(float charm)
    {
        if (this.charm - charm <= DEFAULT_charm)
        {
            this.charm = DEFAULT_charm;
        }
        else
        {
            this.charm -= charm;
        }
    }

    public void ReduceNegativeEventsChance(float negativeEventsChance)
    {
        if (this.negativeEventsChance - negativeEventsChance <= DEFAULT_negativeEventsChance)
        {
            this.negativeEventsChance = DEFAULT_negativeEventsChance;
        }
        else
        {
            this.negativeEventsChance -= negativeEventsChance;
        }
    }

    public void ReduceNegativeEventsEffect(float negativeEventsEffect)
    {
        if (this.negativeEventsEffect - negativeEventsEffect <= DEFAULT_negativeEventsEffect)
        {
            this.negativeEventsEffect = DEFAULT_negativeEventsEffect;
        }
        else
        {
            this.negativeEventsEffect -= negativeEventsEffect;
        }
    }

    public void ReducePositiveEventsEffect(float positiveEventsEffect)
    {
        if (this.positiveEventsEffect - positiveEventsEffect <= DEFAULT_positiveEventsEffect)
        {
            this.positiveEventsEffect = DEFAULT_positiveEventsEffect;
        }
        else
        {
            this.positiveEventsEffect -= positiveEventsEffect;
        }
    }

    public void ReduceReduceTimeSleeping(float reduceTimeSleeping)
    {
        if (this.reduceTimeSleeping - reduceTimeSleeping <= DEFAULT_reduceTimeSleeping)
        {
            this.reduceTimeSleeping = DEFAULT_reduceTimeSleeping;
        }
        else
        {
            this.reduceTimeSleeping -= reduceTimeSleeping;
        }
    }

    public void ReduceReduceTimeReadBook(float reduceTimeReadBook)
    {
        if (this.reduceTimeReadBook - reduceTimeReadBook <= DEFAULT_reduceTimeReadBook)
        {
            this.reduceTimeReadBook = DEFAULT_reduceTimeReadBook;
        }
        else
        {
            this.reduceTimeReadBook -= reduceTimeReadBook;
        }
    }

    public void ReduceReduceTimeTrainCourse(float reduceTimeTrainCourse)
    {
        if (this.reduceTimeTrainCourse - reduceTimeReadBook <= DEFAULT_reduceTimeTrainCourse)
        {
            this.reduceTimeTrainCourse = DEFAULT_reduceTimeTrainCourse;
        }
        else
        {
            this.reduceTimeTrainCourse -= reduceTimeTrainCourse;
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

    public float GetBaseReduceEnergyConsumption()
    {
        return baseReduceEnergyConsumption;
    }

    public float GetGoldenTimeReduceEnergyConsuption()
    {
        return goldenTimeReduceEnergyConsuption;
    }

    public float GetCurrentMotivation()
    {
        return currentMotivation;
    }

    public float GetGoldenTimeBootUpMotivation()
    {
        return goldenTimeBootUpMotivation;
    }

    public float GetBaseBootUpMotivation()
    {
        return baseBootUpMotivation;
    }

    public float GetBaseBootUpProject()
    {
        return baseBootUpProject;
    }

    public float GetGoldenTimeBootUpProject()
    {
        return goldenTimeBootUpProject;
    }

    public float GetReduceBugChance()
    {
        return reduceBugChance;
    }
    public float GetCharm()
    {
        return charm;
    }
    public float GetNegativeEventsChance()
    {
        return negativeEventsChance;
    }
    public float GetNegativeEventsEffect()
    {
        return negativeEventsEffect;
    }
    public float GetPositiveEventsEffect()
    {
        return positiveEventsEffect;
    }

    public float GetReduceTimeSleeping()
    {
        return reduceTimeSleeping;
    }

    public float GetReduceTimeReadBook()
    {
        return reduceTimeReadBook;
    }
    public float GetReduceTimeTrainCourse()
    {
        return reduceTimeTrainCourse;
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

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public float GetDEFAULT_MaxMotivation()
    {
        return DEFAULT_maxMotivation;
    }
    public float GetDEFAULT_currentEnergy()
    {
        return DEFAULT_currentEnergy;
    }

    public float GetDEFAULT_baseReduceEnergyConsumption()
    {
        return DEFAULT_baseReduceEnergyConsumption;
    }
    public float GetDEFAULT_goldenTimeReduceEnergyConsuption()
    {
        return DEFAULT_goldenTimeReduceEnergyConsuption;
    }
    public float GetDEFAULT_currentMotivation()
    {
        return DEFAULT_currentMotivation;
    }
    public float GetDEFAULT_baseBootUpMotivation()
    {
        return DEFAULT_baseBootUpMotivation;
    }
    public float GetDEFAULT_goldenTimeBootUpMotivation()
    {
        return DEFAULT_goldenTimeBootUpMotivation;
    }
    public float GetDEFAULT_codingStatus()
    {
        return DEFAULT_codingStatus;
    }
    public float GetDEFAULT_designStatus()
    {
        return DEFAULT_designStatus;
    }
    public float GetDEFAULT_artStatus()
    {
        return DEFAULT_artStatus;
    }
    public float GetDEFAULT_audioStatus()
    {
        return DEFAULT_audioStatus;
    }
    public float GetDEFAULT_testStatus()
    {
        return DEFAULT_testStatus;
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


    #endregion
}
