using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : Manager<PlayerAction>, ISleepAction
{
    [SerializeField] private CharacterStatusController characterStatusController;
    [SerializeField] private HardSkillsController hardSkillsController;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private SoftSkillsController softSkillsController;
    [SerializeField] private OtherBonusController otherBonusController;

    #region Instace
    private const float inst_plus_charm = 1f;
    private const float inst_plus_baseBootupProject = 1f;
    private const float inst_plus_goldenBootupProject = 1f;
    private const float inst_plus_baseBootupMotivation = 0f;
    private const float inst_plus_goldenBootupMotivation = 0f;
    private const float inst_minus_baseEnergy = 1f;
    private const float inst_minus_goldenEnergy = 1f;
    private const float inst_plus_reduceBugChance = 0f;
    private const float inst_minus_timeCourse = 1f;
    private const float inst_minus_timeTransport = 1f;
    private const float inst_plus_droprate = 1f;
    #endregion

    #region Course
    public int GetCalculateCourseTimeSecond(int time)
    {   
        return (int)(time * GetTotalBonusReduceTimeCourse());
    }
    public void CalCourseProcess(Course course)
    {
        //chracter_handler.TakeEnergy(GetEnergyCourse(course));
        //chracter_handler.ReduceCurrentMotivation(course.GetMotivationConsume());

        #region Exp
        //mathHardSkill.GiveXP(course.GetdefaultMathExpReward());

        //programmingHardSkill.GiveXP(course.GetdefaultProgrammingExpReward());

        //gameEngineHardSkill.GiveXP(course.GetdefaultEngineExpReward());

        //networkHardSkill.GiveXP(course.GetdefaultAiExpReward());

        //aiHardSkill.GiveXP(course.GetdefaultNetwordExpReward());

        //designHardSkill.GiveXP(course.GetdefaultDesignExpReward());

        //testingHardSkill.GiveXP(course.GetdefaultTestingExpReward());

        //artHardSkill.GiveXP(course.GetdefaultArtExpReward());

        //soundHardSkill.GiveXP(course.GetdefaultSoundExpReward());

        #endregion

        #region Stat
        //chracter_handler.ApplyCodingStatus(course.GetdefaultCodingStatReward());

        //chracter_handler.ApplyDesignStatus(course.GetdefaultDesignStatReward());

        //chracter_handler.ApplyTestStatus(course.GetdefaultTestingStatReward());

        //chracter_handler.ApplyArtStatus(course.GetdefaultArtStatReward());

        //chracter_handler.ApplySoundStatus(course.GetdefaultSoundStatReward());
        #endregion
        
    }
    #endregion

    #region Sleep
    public void Sleep(int totalSecond)
    {
        TimeManager.Instance.SkilpTime(totalSecond, 3);
    }
    #endregion

    #region Status
    //status = currentCharacterStatus + bonus form hardskill + bonus from other
    public int GetTotalCodingStatus()
    {
        int totalStatus = 0;
        totalStatus += GetStatusFromHardSkills(StatusID.Coding);
        totalStatus += characterStatusController.CurrentCodingStatus;
        totalStatus += otherBonusController.Bonus_coding_status;
        return totalStatus;
    }
    public int GetTotalDesignStatus()
    {
        int totalStatus = 0;
        totalStatus += GetStatusFromHardSkills(StatusID.Design);
        totalStatus += characterStatusController.CurrentDesignStatus;
        totalStatus += otherBonusController.Bonus_design_status;
        return totalStatus;
    }
    public int GetTotalArtStatus()
    {
        int totalStatus = 0;
        totalStatus += GetStatusFromHardSkills(StatusID.Art);
        totalStatus += characterStatusController.CurrentArtStatus;
        totalStatus += otherBonusController.Bounus_art_status;
        return totalStatus;
    }
    public int GetTotalSoundStatus()
    {
        int totalStatus = 0;
        totalStatus += GetStatusFromHardSkills(StatusID.Sound);
        totalStatus += characterStatusController.CurrentSoundStatus;
        totalStatus += otherBonusController.Bonus_sound_status;
        return totalStatus;
    }
    public int GetTotalTestingStatus()
    {
        int totalStatus = 0;
        totalStatus += GetStatusFromHardSkills(StatusID.Testing);
        totalStatus += characterStatusController.CurrentTestingStatus;
        totalStatus += otherBonusController.Bonus_testing_status;
        return totalStatus;
    }
    public float GetMaxEnergy()
    {
        float totalEnergy = 0;
        totalEnergy += characterStatusController.Default_maxEnergy;
        totalEnergy += otherBonusController.Bonus_max_energy;
        return totalEnergy;
    }

    private int GetStatusFromHardSkills(StatusID id)
    {
        int totalStatus = 0;
        foreach (KeyValuePair<string, HardSkill> hardskill in hardSkillsController.Hardskills)
        {
            switch (id)
            {
                case StatusID.Coding:
                    totalStatus += hardskill.Value.CurrentTotalBonusCodingStatus;
                    break;
                case StatusID.Design:
                    totalStatus += hardskill.Value.CurrentTotalBonusDesignStatus;
                    break;
                case StatusID.Testing:
                    totalStatus += hardskill.Value.CurrentTotalBonusTestingStatus;
                    break;
                case StatusID.Art:
                    totalStatus += hardskill.Value.CurrentTotalBonusArtStatus;
                    break;
                case StatusID.Sound:
                    totalStatus += hardskill.Value.CurrentTotalBonusSoundStatus;
                    break;

            }
            
        }
        return totalStatus;
    }
    #endregion

    #region Bonus
    //total bonus = character + softskill + item equipment + events
    public float GetTotalBonusBootUpProject()
    {
        float totalBonus = inst_plus_baseBootupProject;
        totalBonus += characterStatusController.Default_baseBootUpProject;
        totalBonus += GetBonusFromSoftSkill(BonusCharacter.BonusProject);
        totalBonus += otherBonusController.Bonus_bootup_project;
        return totalBonus;
    }
    public float GetTotalBonusBootUpProjectGoldenTime()
    {
        float totalBonus = inst_plus_goldenBootupProject;
        totalBonus += characterStatusController.Default_goldenTimeBootUpProject;
        totalBonus += GetBonusFromSoftSkill(BonusCharacter.BonusProjectGoldenTime);
        totalBonus += otherBonusController.Bonus_goldentime_bootup_project;
        return totalBonus;
    }
    public float GetTotalBonusCharm()
    {
        float totalBonus = inst_plus_charm;
        totalBonus += characterStatusController.Default_charm;
        totalBonus += GetBonusFromSoftSkill(BonusCharacter.Charm);
        totalBonus += otherBonusController.Bonus_charm;
        return totalBonus;
    }
    public float GetTotalBonusBootUpMotivation()
    {
        float totalBonus = inst_plus_baseBootupMotivation;
        totalBonus += characterStatusController.Default_baseBootUpMotivation;
        totalBonus += GetBonusFromSoftSkill(BonusCharacter.BonusMotivation);
        totalBonus += otherBonusController.Bonus_bootup_motivation;
        return totalBonus;
    }
    public float GetTotalBonusBootUpMotivationGoldenTime()
    {
        float totalBonus = inst_plus_goldenBootupMotivation;
        totalBonus += characterStatusController.Default_goldenTimeBootUpMotivation;
        totalBonus += GetBonusFromSoftSkill(BonusCharacter.BonusMotivationGoldenTime);
        totalBonus += otherBonusController.Bonus_goldentime_bootup_motivation;
        return totalBonus;
    }
    public float GetTotalBonusReduceEnergyConsume()
    {
        float totalBonus = inst_minus_baseEnergy;
        totalBonus -= characterStatusController.Default_baseReduceEnergyConsumption;
        totalBonus -= GetBonusFromSoftSkill(BonusCharacter.ReduceEnergyConsume);
        totalBonus -= otherBonusController.Bonus_reduce_energy_consume;
        if (totalBonus <= 0)
        {
            totalBonus = 0;
        }
        return totalBonus;
    }
    public float GetTotalBonusReduceEnergyConsumeGoldenTime()
    {
        float totalBonus = inst_minus_goldenEnergy;
        totalBonus -= characterStatusController.Defautl_goldenTimeReduceEnergyConsuption;
        totalBonus -= GetBonusFromSoftSkill(BonusCharacter.ReduceEnergyConsumeGoldenTime);
        totalBonus -= otherBonusController.Bonus_goldentime_reduce_energy_consume;
        if (totalBonus <= 0)
        {
            totalBonus = 0;
        }
        return totalBonus;
    }
    public float GetTotalBonusReduceBugChance()
    {
        float totalBonus = inst_plus_reduceBugChance;
        totalBonus += characterStatusController.Default_reduceBugChance;
        totalBonus += GetBonusFromSoftSkill(BonusCharacter.ReduceChanceBug);
        totalBonus += otherBonusController.Bonus_reduce_bug_chance;
        return totalBonus;
    }
    public float GetTotalBonusReduceTimeCourse()
    {
        float totalBonus = inst_minus_timeCourse;
        totalBonus -= characterStatusController.Default_reduceTimeTrainCourse;
        totalBonus -= GetBonusFromSoftSkill(BonusCharacter.ReduceCourseTime);
        totalBonus -= otherBonusController.Bonus_reduce_time_course;
        if (totalBonus <= 0)
        {
            totalBonus = 0;
        }
        return totalBonus;
    }
    public float GetTotalBonusReduceTimeTransport()
    {
        float totalBonus = inst_minus_timeTransport;
        totalBonus -= characterStatusController.Default_reduceTimeTransport;
        totalBonus -= GetBonusFromSoftSkill(BonusCharacter.ReduceTransportTime);
        totalBonus -= otherBonusController.Bonus_reduce_time_transport;
        if(totalBonus <= 0)
        {
            totalBonus = 0;
        }
        return totalBonus;
    }
    public float GetTotalBonusIncreaseDropRate()
    {
        float totalBonus = inst_plus_droprate;
        totalBonus += characterStatusController.Default_dropRate;
        totalBonus += GetBonusFromSoftSkill(BonusCharacter.IncreaseDropRate);
        totalBonus += otherBonusController.Bonus_increase_drop_rate;
        return totalBonus;
    }
    private float GetBonusFromSoftSkill(BonusCharacter bonus)
    {
        float totalBonus = 0;
        foreach (KeyValuePair<string, SoftSkill> softskill in softSkillsController.Softskills)
        {
            switch (bonus)
            {
                case BonusCharacter.Charm:
                    totalBonus += softskill.Value.GetTotalBONUS_charm();
                    break;
                case BonusCharacter.BonusMotivation:
                    totalBonus += softskill.Value.GetTotalBONUS_baseBootUpMotivation();
                    break;
                case BonusCharacter.BonusMotivationGoldenTime:
                    totalBonus += softskill.Value.GetTotalBONUS_goldenTimeBootUpMotivation();
                    break;
                case BonusCharacter.BonusProject:
                    totalBonus += softskill.Value.GetTotalBONUS_baseBootUpProject();
                    break;
                case BonusCharacter.BonusProjectGoldenTime:
                    totalBonus += softskill.Value.GetTotalBONUS_goldenTimeBootUpProject();
                    break;
                case BonusCharacter.ReduceChanceBug:
                    totalBonus += softskill.Value.GetTotalBONUS_reduceBugChance();
                    break;
                case BonusCharacter.ReduceCourseTime:
                    totalBonus += softskill.Value.GetTotalBONUS_reduceTimeTrainCourse();
                    break;
                case BonusCharacter.ReduceEnergyConsume:
                    totalBonus += softskill.Value.GetTotalBONUS_baseReduceEnergyConsumption();
                    break;
                case BonusCharacter.ReduceEnergyConsumeGoldenTime:
                    totalBonus += softskill.Value.GetTotalBONUS_goldenTimeReduceEnergyConsuption();
                    break;
                case BonusCharacter.ReduceTransportTime:
                    totalBonus += softskill.Value.GetTotalBONUS_reduceTimeTransport();
                    break;
                case BonusCharacter.IncreaseDropRate:
                    break;
                default:
                    break;

            }

        }
        return totalBonus;
    }
    #endregion

    #region Calculate
    public float CalReduceEnergyToCunsume(float amount)
    {
        float energy = 0;
        if (timeManager.GetGoldenTime())
        {
            energy = amount * GetTotalBonusReduceEnergyConsumeGoldenTime();
        }
        else
        {
            energy = amount * GetTotalBonusReduceEnergyConsume();
        }
        return energy;
    }
    public float GetMinMotivation()
    {
        float motivation = 0;
        if (timeManager.GetGoldenTime())
        {
            motivation = GetTotalBonusBootUpMotivationGoldenTime();
        }
        else
        {
            motivation = GetTotalBonusBootUpMotivation();
        }
        return motivation * characterStatusController.Default_maxMotivation;
    }
    public float GetTotalBonusBootupProjectByTime()
    {
        float bonus = 0f;
        if (timeManager.GetGoldenTime())
        {
            bonus = GetTotalBonusBootUpProjectGoldenTime();
        }
        else
        {
            bonus = GetTotalBonusBootUpProject();
        }
        return bonus;
    }
    public bool EnergyIsEnough(float amount)
    {
        return characterStatusController.CurrentEnergy >= amount;
    }
    public void TakeEnergy(float amount)
    {
        characterStatusController.TakeEnergy(amount);
    }
    public void TakeMotivation(float amount)
    {
        characterStatusController.TakeMotivation(amount);
    }
    #endregion

    #region Transport
    public int GetTimeSecondToTransport(int second)
    {
        return (int)(second * GetTotalBonusReduceTimeTransport());
    }
    #endregion

}
