using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour, ICourseAction, ISleepAction
{
    private Characters_Handler chracter_handler;
    private GameObject found_Player;

    [Header("Hard Skills")]
    [SerializeField] private HardSkill mathHardSkill;
    [SerializeField] private HardSkill programmingHardSkill;
    [SerializeField] private HardSkill gameEngineHardSkill;
    [SerializeField] private HardSkill networkHardSkill;
    [SerializeField] private HardSkill aiHardSkill;
    [SerializeField] private HardSkill designHardSkill;
    [SerializeField] private HardSkill artHardSkill;
    [SerializeField] private HardSkill soundHardSkill;
    [SerializeField] private HardSkill testingHardSkill;


    private void Start()
    {
        found_Player = GameObject.FindGameObjectWithTag("Player");
        chracter_handler = found_Player.GetComponentInChildren<Characters_Handler>();

    }

    #region Course
    public int GetEnergyCourse(Course course)
    {
        int energy = 0;
        float reduceEnergy;
        if (TimeManager.Instance.GetGoldenTime())
        {
            //reduceEnergy = chracter_handler.GetDEFAULT_goldenTimeReduceEnergyConsuption();
            
        }
        else
        {
            //reduceEnergy = chracter_handler.GetDEFAULT_baseReduceEnergyConsumption();
        }

        //energy = (int)(course.GetEnergyToConsume() * (1 - reduceEnergy));

        return energy;
    }
    public int GetCalculateCourseTimeSecond(Course courese)
    {   /*
        int second = 0;
        float totalBonusReduced = (characterStats.GetDEFAULT_reduceTimeTrainCourse() + timeManagement.GetTotalBONUS_reduceTimeTrainCourse());

        second = (int)(courese.GetSecondToConsume() * (1 - totalBonusReduced));
        */
        return 0;
    }
    public void CalCourseProcess(Course course)
    {
        //chracter_handler.TakeEnergy(GetEnergyCourse(course));
        //chracter_handler.ReduceCurrentMotivation(course.GetMotivationConsume());

        #region Exp
        mathHardSkill.GiveXP(course.GetdefaultMathExpReward());

        programmingHardSkill.GiveXP(course.GetdefaultProgrammingExpReward());

        gameEngineHardSkill.GiveXP(course.GetdefaultEngineExpReward());

        networkHardSkill.GiveXP(course.GetdefaultAiExpReward());

        aiHardSkill.GiveXP(course.GetdefaultNetwordExpReward());

        designHardSkill.GiveXP(course.GetdefaultDesignExpReward());

        testingHardSkill.GiveXP(course.GetdefaultTestingExpReward());

        artHardSkill.GiveXP(course.GetdefaultArtExpReward());

        soundHardSkill.GiveXP(course.GetdefaultSoundExpReward());

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
        TimeManager.Instance.SkilpTime(totalSecond);
    }
    public int GetCalculateSleepTimeSecond(bool fullTimeSelected)
    {
        /*
        int second = 0;
        float totalBonusReduced = (characterStats.GetDEFAULT_reduceTimeSleeping() + timeManagement.GetTotalBONUS_reduceTimeSleeping());
        if (fullTimeSelected)
        {
            second = (int)(characterStats.GetDEFAULT_fullTimeOfSleepingSecond() * (1 - totalBonusReduced));
        }
        else
        {
            second = (int)(characterStats.GetDEFAULT_twoThirdTimeOfSleepingSeond() * (1 - totalBonusReduced));
        }
        */
        return 0;
    }
    #endregion

    #region Stats
    public int GetBonusCodingStatus()
    {
        int totalBonusCodingStatus = 0;
        totalBonusCodingStatus += mathHardSkill.GetTotalBonusCoding();
        totalBonusCodingStatus += programmingHardSkill.GetTotalBonusCoding();
        totalBonusCodingStatus += gameEngineHardSkill.GetTotalBonusCoding();
        totalBonusCodingStatus += aiHardSkill.GetTotalBonusCoding();
        totalBonusCodingStatus += designHardSkill.GetTotalBonusCoding();
        totalBonusCodingStatus += artHardSkill.GetTotalBonusCoding();
        totalBonusCodingStatus += testingHardSkill.GetTotalBonusCoding();
        totalBonusCodingStatus += soundHardSkill.GetTotalBonusCoding();

        return totalBonusCodingStatus;
    }
    public int GetBonusDesignStatus()
    {
        int totalBonusDesignStatus = 0;
        totalBonusDesignStatus += mathHardSkill.GetTotalBonusDesign();
        totalBonusDesignStatus += programmingHardSkill.GetTotalBonusDesign();
        totalBonusDesignStatus += gameEngineHardSkill.GetTotalBonusDesign();
        totalBonusDesignStatus += aiHardSkill.GetTotalBonusDesign();
        totalBonusDesignStatus += designHardSkill.GetTotalBonusDesign();
        totalBonusDesignStatus += artHardSkill.GetTotalBonusDesign();
        totalBonusDesignStatus += testingHardSkill.GetTotalBonusDesign();
        totalBonusDesignStatus += soundHardSkill.GetTotalBonusDesign();

        return totalBonusDesignStatus;
    }
    public int GetBonusArtStatus()
    {
        int totalBonusArtStatus = 0;
        totalBonusArtStatus += mathHardSkill.GetTotalBonusArt();
        totalBonusArtStatus += programmingHardSkill.GetTotalBonusArt();
        totalBonusArtStatus += gameEngineHardSkill.GetTotalBonusArt();
        totalBonusArtStatus += aiHardSkill.GetTotalBonusArt();
        totalBonusArtStatus += designHardSkill.GetTotalBonusArt();
        totalBonusArtStatus += artHardSkill.GetTotalBonusArt();
        totalBonusArtStatus += testingHardSkill.GetTotalBonusArt();
        totalBonusArtStatus += soundHardSkill.GetTotalBonusArt();

        return totalBonusArtStatus;
    }
    public int GetBonusSoundStatus()
    {
        int totalBonusSoundStatus = 0;
        totalBonusSoundStatus += mathHardSkill.GetTotalBonusSound();
        totalBonusSoundStatus += programmingHardSkill.GetTotalBonusSound();
        totalBonusSoundStatus += gameEngineHardSkill.GetTotalBonusSound();
        totalBonusSoundStatus += aiHardSkill.GetTotalBonusSound();
        totalBonusSoundStatus += designHardSkill.GetTotalBonusSound();
        totalBonusSoundStatus += artHardSkill.GetTotalBonusSound();
        totalBonusSoundStatus += testingHardSkill.GetTotalBonusSound();
        totalBonusSoundStatus += soundHardSkill.GetTotalBonusSound();

        return totalBonusSoundStatus;
    }
    public int GetBonusTestingStatus()
    {
        int totalBonusTestingStatus = 0;
        totalBonusTestingStatus += mathHardSkill.GetTotalBonusTesting();
        totalBonusTestingStatus += programmingHardSkill.GetTotalBonusTesting();
        totalBonusTestingStatus += gameEngineHardSkill.GetTotalBonusTesting();
        totalBonusTestingStatus += aiHardSkill.GetTotalBonusTesting();
        totalBonusTestingStatus += designHardSkill.GetTotalBonusTesting();
        totalBonusTestingStatus += artHardSkill.GetTotalBonusTesting();
        totalBonusTestingStatus += testingHardSkill.GetTotalBonusTesting();
        totalBonusTestingStatus += soundHardSkill.GetTotalBonusTesting();

        return totalBonusTestingStatus;
    }
    #endregion

}
