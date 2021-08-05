using UnityEngine;

public class CharacterStatus_Template : MonoBehaviour
{
    [System.Serializable]
    public class CharacterLevelRequired
    {
        public int exp_required;
        public float maxEnergy;
        public int stats_points;

        public CharacterLevelRequired(int exp, float maxEnergy, int point)
        {
            exp_required = exp;
            this.maxEnergy = maxEnergy;
            stats_points = point;
        }

    }

    private CharacterLevelRequired[] characterLevelRequiedList;

    public CharacterStatus_Template(CharacterLevelRequired[] characterLevelRequiedList, string character_ID, string character_Name, int default_max_level, float default_dropRate, int default_maxEnergy, float default_baseReduceEnergyConsumption, float defautl_goldenTimeReduceEnergyConsuption, int default_maxMotivation, float default_baseBootUpMotivation, float default_goldenTimeBootUpMotivation, int defaultMoney, int default_codingStatus, int default_designStatus, int default_artStats, int default_soundStats, int default_testingStats, float default_baseBootUpProject, float default_goldenTimeBootUpProject, float default_reduceBugChance, float default_charm, float default_reduceTimeTrainCourse, float default_reduceTimeTransport, float levelUp_baseReduceEnergyConsumption, float levelUp_goldenTimeReduceEnergyConsuption, float levelUp_baseBootUpMotivation, float levelUp_goldenTimeBootUpMotivation, float levelUp_baseBootUpProject, float levelUp_goldenTimeBootUpProject, float levelUp_reduceBugChance, float levelUp_charm, float levelUp_reduceTimeTrainCourse, float levelUp_reduceTimeTransport, int levelUp_softskillPoints, float levelUp_dropRate, Sprite characterProfile, Sprite characterIcon)
    {
        this.characterLevelRequiedList = characterLevelRequiedList;
        this.character_ID = character_ID;
        this.character_Name = character_Name;
        this.default_max_level = default_max_level;
        this.default_dropRate = default_dropRate;
        this.default_maxEnergy = default_maxEnergy;
        this.default_baseReduceEnergyConsumption = default_baseReduceEnergyConsumption;
        this.defautl_goldenTimeReduceEnergyConsuption = defautl_goldenTimeReduceEnergyConsuption;
        this.default_maxMotivation = default_maxMotivation;
        this.default_baseBootUpMotivation = default_baseBootUpMotivation;
        this.default_goldenTimeBootUpMotivation = default_goldenTimeBootUpMotivation;
        this.defaultMoney = defaultMoney;
        this.default_codingStatus = default_codingStatus;
        this.default_designStatus = default_designStatus;
        this.default_artStats = default_artStats;
        this.default_soundStats = default_soundStats;
        this.default_testingStats = default_testingStats;
        this.default_baseBootUpProject = default_baseBootUpProject;
        this.default_goldenTimeBootUpProject = default_goldenTimeBootUpProject;
        this.default_reduceBugChance = default_reduceBugChance;
        this.default_charm = default_charm;
        this.default_reduceTimeTrainCourse = default_reduceTimeTrainCourse;
        this.default_reduceTimeTransport = default_reduceTimeTransport;
        this.levelUp_baseReduceEnergyConsumption = levelUp_baseReduceEnergyConsumption;
        this.levelUp_goldenTimeReduceEnergyConsuption = levelUp_goldenTimeReduceEnergyConsuption;
        this.levelUp_baseBootUpMotivation = levelUp_baseBootUpMotivation;
        this.levelUp_goldenTimeBootUpMotivation = levelUp_goldenTimeBootUpMotivation;
        this.levelUp_baseBootUpProject = levelUp_baseBootUpProject;
        this.levelUp_goldenTimeBootUpProject = levelUp_goldenTimeBootUpProject;
        this.levelUp_reduceBugChance = levelUp_reduceBugChance;
        this.levelUp_charm = levelUp_charm;
        this.levelUp_reduceTimeTrainCourse = levelUp_reduceTimeTrainCourse;
        this.levelUp_reduceTimeTransport = levelUp_reduceTimeTransport;
        this.levelUp_softskillPoints = levelUp_softskillPoints;
        this.levelUp_dropRate = levelUp_dropRate;
        this.characterProfile = characterProfile;
        this.characterIcon = characterIcon;
    }

    [Header("Identity")]
    #region Fields
    private string character_ID = "";
    private Sprite characterProfile;
    private Sprite characterIcon;
    private string character_Name = "";
    private int default_max_level;

    private float default_dropRate;

    [Header("Energy")]
    private float default_maxEnergy;
    private float default_baseReduceEnergyConsumption; // 0%
    private float defautl_goldenTimeReduceEnergyConsuption; // 5%

    [Header("Motivation")]
    private float default_maxMotivation;
    private float default_baseBootUpMotivation;
    private float default_goldenTimeBootUpMotivation;

    [Header("Money")]
    private int defaultMoney;

    [Header("Programming")]
    private int default_codingStatus;
    private int default_designStatus;
    private int default_artStats;
    private int default_soundStats;
    private int default_testingStats;

    [Header("BootUp Project")]
    private float default_baseBootUpProject;
    private float default_goldenTimeBootUpProject;
    private float default_reduceBugChance;

    [Header("Relationship")]
    private float default_charm;

    [Header("Time")]
    private float default_reduceTimeTrainCourse;
    private float default_reduceTimeTransport;

    #endregion

    #region Stats UP Per Level
    private float levelUp_baseReduceEnergyConsumption;
    private float levelUp_goldenTimeReduceEnergyConsuption;

    private float levelUp_baseBootUpMotivation;
    private float levelUp_goldenTimeBootUpMotivation;

    private float levelUp_baseBootUpProject;
    private float levelUp_goldenTimeBootUpProject;
    private float levelUp_reduceBugChance;

    private float levelUp_charm;

    private float levelUp_reduceTimeTrainCourse;
    private float levelUp_reduceTimeTransport;

    private int levelUp_softskillPoints;
    private float levelUp_dropRate;


    public string Character_ID { get => character_ID; }
    public string Character_Name { get => character_Name; }
    public int Default_max_level { get => default_max_level; }
    public float Default_dropRate { get => default_dropRate; set => default_dropRate = value; }
    public float Default_maxEnergy { get => default_maxEnergy; set => default_maxEnergy = value; }
    public float Default_baseReduceEnergyConsumption { get => default_baseReduceEnergyConsumption; set => default_baseReduceEnergyConsumption = value; }
    public float Defautl_goldenTimeReduceEnergyConsuption { get => defautl_goldenTimeReduceEnergyConsuption; set => defautl_goldenTimeReduceEnergyConsuption = value; }
    public float Default_maxMotivation { get => default_maxMotivation; set => default_maxMotivation = value; }
    public float Default_baseBootUpMotivation { get => default_baseBootUpMotivation; set => default_baseBootUpMotivation = value; }
    public float Default_goldenTimeBootUpMotivation { get => default_goldenTimeBootUpMotivation; set => default_goldenTimeBootUpMotivation = value; }
    public int DefaultMoney { get => defaultMoney; set => defaultMoney = value; }
    public int Default_codingStatus { get => default_codingStatus; }
    public int Default_designStatus { get => default_designStatus; }
    public int Default_artStats { get => default_artStats; }
    public int Default_soundStats { get => default_soundStats; }
    public int Default_testingStats { get => default_testingStats; }
    public float Default_baseBootUpProject { get => default_baseBootUpProject; set => default_baseBootUpProject = value; }
    public float Default_goldenTimeBootUpProject { get => default_goldenTimeBootUpProject; set => default_goldenTimeBootUpProject = value; }
    public float Default_reduceBugChance { get => default_reduceBugChance; set => default_reduceBugChance = value; }
    public float Default_charm { get => default_charm; set => default_charm = value; }
    public float Default_reduceTimeTrainCourse { get => default_reduceTimeTrainCourse; set => default_reduceTimeTrainCourse = value; }
    public float Default_reduceTimeTransport { get => default_reduceTimeTransport; set => default_reduceTimeTransport = value; }
    public float LevelUp_baseReduceEnergyConsumption { get => levelUp_baseReduceEnergyConsumption; }
    public float LevelUp_goldenTimeReduceEnergyConsuption { get => levelUp_goldenTimeReduceEnergyConsuption; }
    public float LevelUp_baseBootUpMotivation { get => levelUp_baseBootUpMotivation; }
    public float LevelUp_goldenTimeBootUpMotivation { get => levelUp_goldenTimeBootUpMotivation; }
    public float LevelUp_baseBootUpProject { get => levelUp_baseBootUpProject; }
    public float LevelUp_goldenTimeBootUpProject { get => levelUp_goldenTimeBootUpProject; }
    public float LevelUp_reduceBugChance { get => levelUp_reduceBugChance; }
    public float LevelUp_charm { get => levelUp_charm; }
    public float LevelUp_reduceTimeTrainCourse { get => levelUp_reduceTimeTrainCourse; }
    public float LevelUp_reduceTimeTransport { get => levelUp_reduceTimeTransport; }
    public int LevelUp_softskillPoints { get => levelUp_softskillPoints; }
    public float LevelUp_dropRate { get => levelUp_dropRate; }
    public CharacterLevelRequired[] CharacterLevelRequiedList { get => characterLevelRequiedList; }
    public Sprite CharacterProfile { get => characterProfile; }
    public Sprite CharacterIcon { get => characterIcon; }
    #endregion

}
