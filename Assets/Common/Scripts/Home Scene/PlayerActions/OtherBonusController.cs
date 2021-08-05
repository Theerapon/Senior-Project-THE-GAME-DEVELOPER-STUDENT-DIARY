using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBonusController : Manager<OtherBonusController>
{

    private float bonus_charm;
    private float bonus_bootup_project;
    private float bonus_goldentime_bootup_project;
    private float bonus_bootup_motivation;
    private float bonus_goldentime_bootup_motivation;
    private float bonus_reduce_energy_consume;
    private float bonus_goldentime_reduce_energy_consume;
    private float bonus_reduce_bug_chance;
    private float bonus_reduce_negative;
    private float bonus_increase_positive;
    private float bonus_increase_drop_rate;
    private float bonus_reduce_time_course;
    private float bonus_reduce_time_transport;
    private int bonus_max_energy;
    private int bonus_coding_status;
    private int bonus_design_status;
    private int bonus_testing_status;
    private int bounus_art_status;
    private int bonus_sound_status;

    public float Bonus_charm { get => bonus_charm; }
    public float Bonus_bootup_project { get => bonus_bootup_project; }
    public float Bonus_goldentime_bootup_project { get => bonus_goldentime_bootup_project; }
    public float Bonus_bootup_motivation { get => bonus_bootup_motivation; }
    public float Bonus_goldentime_bootup_motivation { get => bonus_goldentime_bootup_motivation; }
    public float Bonus_reduce_energy_consume { get => bonus_reduce_energy_consume; }
    public float Bonus_goldentime_reduce_energy_consume { get => bonus_goldentime_reduce_energy_consume; }
    public float Bonus_reduce_bug_chance { get => bonus_reduce_bug_chance; }
    public float Bonus_reduce_negative { get => bonus_reduce_negative; }
    public float Bonus_increase_positive { get => bonus_increase_positive; }
    public float Bonus_increase_drop_rate { get => bonus_increase_drop_rate; }
    public float Bonus_reduce_time_course { get => bonus_reduce_time_course; }
    public float Bonus_reduce_time_transport { get => bonus_reduce_time_transport; }
    public int Bonus_max_energy { get => bonus_max_energy; }
    public int Bonus_coding_status { get => bonus_coding_status;  }
    public int Bonus_design_status { get => bonus_design_status; }
    public int Bonus_testing_status { get => bonus_testing_status; }
    public int Bounus_art_status { get => bounus_art_status; }
    public int Bonus_sound_status { get => bonus_sound_status; }

    #region Increase
    public void IncreaseCharm(float amount)
    {
        bonus_charm += amount;
    }
    public void IncreaseBootupProject(float amount)
    {
        bonus_bootup_project += amount;
    }
    public void IncreaseBootupProjectInGoldenTime(float amount)
    {
        bonus_goldentime_bootup_project += amount;
    }
    public void IncreaseBootupMotivation(float amount)
    {
        bonus_bootup_motivation += amount;
    }
    public void IncreaseBootupMotivationInGoldenTime(float amount)
    {
        bonus_goldentime_bootup_motivation += amount;
    }
    public void IncreaseEnergyConsume(float amount)
    {
        bonus_reduce_energy_consume += amount;
    }
    public void IncreaseEnergyConsumeInGoldenTime(float amount)
    {
        bonus_goldentime_reduce_energy_consume += amount;
    }
    public void IncreaseReduceBugChance(float amount)
    {
        bonus_reduce_bug_chance += amount;
    }
    public void IncreaseEffectNegative(float amount)
    {
        bonus_reduce_negative += amount;
    }
    public void IncreaseEffectPositive(float amount)
    {
        bonus_increase_positive += amount;
    }
    public void IncreaseDropRate(float amount)
    {
        bonus_increase_drop_rate += amount;
    }
    public void IncreaseReduceTimeCourse(float amount)
    {
        bonus_reduce_time_course += amount;
    }
    public void IncreaseReduceTimeTransport(float amount)
    {
        bonus_reduce_time_transport += amount;
    }
    public void IncreaseMaxEnergy(int amount)
    {
        bonus_max_energy += amount;
    }
    public void IncreaseCodingStatus(int amount)
    {
        bonus_coding_status += amount;
    }
    public void IncreaseDesignStatus(int amount)
    {
        bonus_design_status += amount;
    }
    public void IncreaseTestingStatus(int amount)
    {
        bonus_testing_status += amount;
    }
    public void IncreaseArtStatus(int amount)
    {
        bounus_art_status += amount;
    }
    public void IncreaseSoundStatus(int amount)
    {
        bonus_sound_status += amount;
    }
    #endregion
    #region Reduce
    public void ReduceCharm(float amount)
    {
        bonus_charm -= amount;
    }
    public void ReduceBootupProject(float amount)
    {
        bonus_bootup_project -= amount;
    }
    public void ReduceBootupProjectInGoldenTime(float amount)
    {
        bonus_goldentime_bootup_project -= amount;
    }
    public void ReduceBootupMotivation(float amount)
    {
        bonus_bootup_motivation -= amount;
    }
    public void ReduceBootupMotivationInGoldenTime(float amount)
    {
        bonus_goldentime_bootup_motivation -= amount;
    }
    public void ReduceEnergyConsume(float amount)
    {
        bonus_reduce_energy_consume -= amount;
    }
    public void ReduceEnergyConsumeInGoldenTime(float amount)
    {
        bonus_goldentime_reduce_energy_consume -= amount;
    }
    public void ReduceReduceBugChance(float amount)
    {
        bonus_reduce_bug_chance -= amount;
    }
    public void ReduceEffectNegative(float amount)
    {
        bonus_reduce_negative -= amount;
    }
    public void ReduceEffectPositive(float amount)
    {
        bonus_increase_positive -= amount;
    }
    public void ReduceDropRate(float amount)
    {
        bonus_increase_drop_rate -= amount;
    }
    public void ReduceReduceTimeCourse(float amount)
    {
        bonus_reduce_time_course -= amount;
    }
    public void ReduceReduceTimeTransport(float amount)
    {
        bonus_reduce_time_transport -= amount;
    }
    public void ReduceMaxEnergy(int amount)
    {
        bonus_max_energy -= amount;
    }
    public void ReduceCodingStatus(int amount)
    {
        bonus_coding_status -= amount;
    }
    public void ReduceDesignStatus(int amount)
    {
        bonus_design_status -= amount;
    }
    public void ReduceTestingStatus(int amount)
    {
        bonus_testing_status -= amount;
    }
    public void ReduceArtStatus(int amount)
    {
        bounus_art_status -= amount;
    }
    public void ReduceSoundStatus(int amount)
    {
        bonus_sound_status -= amount;
    }
    #endregion
}
