using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HardSkillsDisplay : MonoBehaviour
{
    [Header("Math")]
    [SerializeField] private HardSkill math;
    [SerializeField] private TMP_Text mathLevelText;
    [SerializeField] private TMP_Text mathNameText;
    [SerializeField] private TMP_Text mathCodingBonusText;
    [SerializeField] private TMP_Text mathDesignBonusText;
    [SerializeField] private TMP_Text mathTestingBonusText;
    [SerializeField] private TMP_Text mathArtBonusText;
    [SerializeField] private TMP_Text mathSoundBonusText;
    [SerializeField] private TMP_Text mathCurrentExpText;
    [SerializeField] private TMP_Text mathRequireExpText;
    [SerializeField] private Image mathExpBar;

    [Header("Programming")]
    [SerializeField] private HardSkill programming;
    [SerializeField] private TMP_Text programmingLevelText;
    [SerializeField] private TMP_Text programmingNameText;
    [SerializeField] private TMP_Text programmingCodingBonusText;
    [SerializeField] private TMP_Text programmingDesignBonusText;
    [SerializeField] private TMP_Text programmingTestingBonusText;
    [SerializeField] private TMP_Text programmingArtBonusText;
    [SerializeField] private TMP_Text programmingSoundBonusText;
    [SerializeField] private TMP_Text programmingCurrentExpText;
    [SerializeField] private TMP_Text programmingRequireExpText;
    [SerializeField] private Image programmingExpBar;

    [Header("Game Engine")]
    [SerializeField] private HardSkill gameEngine;
    [SerializeField] private TMP_Text gameEngineLevelText;
    [SerializeField] private TMP_Text gameEngineNameText;
    [SerializeField] private TMP_Text gameEngineCodingBonusText;
    [SerializeField] private TMP_Text gameEngineDesignBonusText;
    [SerializeField] private TMP_Text gameEngineTestingBonusText;
    [SerializeField] private TMP_Text gameEngineArtBonusText;
    [SerializeField] private TMP_Text gameEngineSoundBonusText;
    [SerializeField] private TMP_Text gameEngineCurrentExpText;
    [SerializeField] private TMP_Text gameEngineRequireExpText;
    [SerializeField] private Image gameEngineExpBar;

    [Header("Network")]
    [SerializeField] private HardSkill network;
    [SerializeField] private TMP_Text networkLevelText;
    [SerializeField] private TMP_Text networkNameText;
    [SerializeField] private TMP_Text networkCodingBonusText;
    [SerializeField] private TMP_Text networkDesignBonusText;
    [SerializeField] private TMP_Text networkTestingBonusText;
    [SerializeField] private TMP_Text networkArtBonusText;
    [SerializeField] private TMP_Text networkSoundBonusText;
    [SerializeField] private TMP_Text networkCurrentExpText;
    [SerializeField] private TMP_Text networkRequireExpText;
    [SerializeField] private Image networkExpBar;

    [Header("Ai")]
    [SerializeField] private HardSkill ai;
    [SerializeField] private TMP_Text aiLevelText;
    [SerializeField] private TMP_Text aiNameText;
    [SerializeField] private TMP_Text aiCodingBonusText;
    [SerializeField] private TMP_Text aiDesignBonusText;
    [SerializeField] private TMP_Text aiTestingBonusText;
    [SerializeField] private TMP_Text aiArtBonusText;
    [SerializeField] private TMP_Text aiSoundBonusText;
    [SerializeField] private TMP_Text aiCurrentExpText;
    [SerializeField] private TMP_Text aiRequireExpText;
    [SerializeField] private Image aiExpBar;

    [Header("Design")]
    [SerializeField] private HardSkill design;
    [SerializeField] private TMP_Text designLevelText;
    [SerializeField] private TMP_Text designNameText;
    [SerializeField] private TMP_Text designCodingBonusText;
    [SerializeField] private TMP_Text designDesignBonusText;
    [SerializeField] private TMP_Text designTestingBonusText;
    [SerializeField] private TMP_Text designArtBonusText;
    [SerializeField] private TMP_Text designSoundBonusText;
    [SerializeField] private TMP_Text designCurrentExpText;
    [SerializeField] private TMP_Text designRequireExpText;
    [SerializeField] private Image designExpBar;

    [Header("Testing")]
    [SerializeField] private HardSkill testing;
    [SerializeField] private TMP_Text testingLevelText;
    [SerializeField] private TMP_Text testingNameText;
    [SerializeField] private TMP_Text testingCodingBonusText;
    [SerializeField] private TMP_Text testingDesignBonusText;
    [SerializeField] private TMP_Text testingTestingBonusText;
    [SerializeField] private TMP_Text testingArtBonusText;
    [SerializeField] private TMP_Text testingSoundBonusText;
    [SerializeField] private TMP_Text testingCurrentExpText;
    [SerializeField] private TMP_Text testingRequireExpText;
    [SerializeField] private Image testingExpBar;

    [Header("Art")]
    [SerializeField] private HardSkill art;
    [SerializeField] private TMP_Text artLevelText;
    [SerializeField] private TMP_Text artNameText;
    [SerializeField] private TMP_Text artCodingBonusText;
    [SerializeField] private TMP_Text artDesignBonusText;
    [SerializeField] private TMP_Text artTestingBonusText;
    [SerializeField] private TMP_Text artArtBonusText;
    [SerializeField] private TMP_Text artSoundBonusText;
    [SerializeField] private TMP_Text artCurrentExpText;
    [SerializeField] private TMP_Text artRequireExpText;
    [SerializeField] private Image artExpBar;

    [Header("Sound")]
    [SerializeField] private HardSkill sound;
    [SerializeField] private TMP_Text soundLevelText;
    [SerializeField] private TMP_Text soundNameText;
    [SerializeField] private TMP_Text soundCodingBonusText;
    [SerializeField] private TMP_Text soundDesignBonusText;
    [SerializeField] private TMP_Text soundTestingBonusText;
    [SerializeField] private TMP_Text soundArtBonusText;
    [SerializeField] private TMP_Text soundSoundBonusText;
    [SerializeField] private TMP_Text soundCurrentExpText;
    [SerializeField] private TMP_Text soundRequireExpText;
    [SerializeField] private Image soundExpBar;



    void Start()
    {
        MenuInGameManager.Instance.OnHardSkillsShowed.AddListener(HandleHardSkillsShowed);
    }

    private void HandleHardSkillsShowed()
    {
        SetMath();
        SetProgramming();
        SetAi();
        SetNetwork();
        SetGameEngine();
        SetDesign();
        SetArt();
        SetTesting();
        SetSound();
    }

    private float CalculateExpBar(HardSkill hardSkill)
    {
        float cal =  (float) hardSkill.GetCurrentHardSkillEXP() / hardSkill.GetExpRequire();
        return cal;
    }
    private void SetMath()
    {
        mathLevelText.text = math.GetCurrentHardSkillLevel().ToString();
        mathNameText.text = math.GetHardSkillName();
        mathCodingBonusText.text = math.GetTotalBonusCoding().ToString();
        mathDesignBonusText.text = math.GetTotalBonusDesign().ToString();
        mathTestingBonusText.text = math.GetTotalBonusTesting().ToString();
        mathArtBonusText.text = math.GetTotalBonusArt().ToString();
        mathSoundBonusText.text = math.GetTotalBonusSound().ToString();
        mathCurrentExpText.text = math.GetCurrentHardSkillEXP().ToString();
        mathRequireExpText.text = math.GetExpRequire().ToString();
        mathExpBar.fillAmount = CalculateExpBar(math);
    }
    private void SetProgramming()
    {
        programmingLevelText.text = programming.GetCurrentHardSkillLevel().ToString();
        programmingNameText.text = programming.GetHardSkillName();
        programmingCodingBonusText.text = programming.GetTotalBonusCoding().ToString();
        programmingDesignBonusText.text = programming.GetTotalBonusDesign().ToString();
        programmingTestingBonusText.text = programming.GetTotalBonusTesting().ToString();
        programmingArtBonusText.text = programming.GetTotalBonusArt().ToString();
        programmingSoundBonusText.text = programming.GetTotalBonusSound().ToString();
        programmingCurrentExpText.text = programming.GetCurrentHardSkillEXP().ToString();
        programmingRequireExpText.text = programming.GetExpRequire().ToString();
        programmingExpBar.fillAmount = CalculateExpBar(programming);
    }
    private void SetGameEngine()
    {
        gameEngineLevelText.text = gameEngine.GetCurrentHardSkillLevel().ToString();
        gameEngineNameText.text = gameEngine.GetHardSkillName();
        gameEngineCodingBonusText.text = gameEngine.GetTotalBonusCoding().ToString();
        gameEngineDesignBonusText.text = gameEngine.GetTotalBonusDesign().ToString();
        gameEngineTestingBonusText.text = gameEngine.GetTotalBonusTesting().ToString();
        gameEngineArtBonusText.text = gameEngine.GetTotalBonusArt().ToString();
        gameEngineSoundBonusText.text = gameEngine.GetTotalBonusSound().ToString();
        gameEngineCurrentExpText.text = gameEngine.GetCurrentHardSkillEXP().ToString();
        gameEngineRequireExpText.text = gameEngine.GetExpRequire().ToString();
        gameEngineExpBar.fillAmount = CalculateExpBar(gameEngine);
    }
    private void SetAi()
    {
        aiLevelText.text = ai.GetCurrentHardSkillLevel().ToString();
        aiNameText.text = ai.GetHardSkillName();
        aiCodingBonusText.text = ai.GetTotalBonusCoding().ToString();
        aiDesignBonusText.text = ai.GetTotalBonusDesign().ToString();
        aiTestingBonusText.text = ai.GetTotalBonusTesting().ToString();
        aiArtBonusText.text = ai.GetTotalBonusArt().ToString();
        aiSoundBonusText.text = ai.GetTotalBonusSound().ToString();
        aiCurrentExpText.text = ai.GetCurrentHardSkillEXP().ToString();
        aiRequireExpText.text = ai.GetExpRequire().ToString();
       aiExpBar.fillAmount = CalculateExpBar(ai);
    }
    private void SetNetwork()
    {
        networkLevelText.text = network.GetCurrentHardSkillLevel().ToString();
        networkNameText.text = network.GetHardSkillName();
        networkCodingBonusText.text = network.GetTotalBonusCoding().ToString();
        networkDesignBonusText.text = network.GetTotalBonusDesign().ToString();
        networkTestingBonusText.text = network.GetTotalBonusTesting().ToString();
        networkArtBonusText.text = network.GetTotalBonusArt().ToString();
        networkSoundBonusText.text = network.GetTotalBonusSound().ToString();
        networkCurrentExpText.text = network.GetCurrentHardSkillEXP().ToString();
        networkRequireExpText.text = network.GetExpRequire().ToString();
        networkExpBar.fillAmount = CalculateExpBar(network);
    }
    private void SetDesign()
    {
        designLevelText.text = design.GetCurrentHardSkillLevel().ToString();
        designNameText.text = design.GetHardSkillName();
        designCodingBonusText.text = design.GetTotalBonusCoding().ToString();
        designDesignBonusText.text = design.GetTotalBonusDesign().ToString();
        designTestingBonusText.text = design.GetTotalBonusTesting().ToString();
        designArtBonusText.text = design.GetTotalBonusArt().ToString();
        designSoundBonusText.text = design.GetTotalBonusSound().ToString();
        designCurrentExpText.text = design.GetCurrentHardSkillEXP().ToString();
        designRequireExpText.text = design.GetExpRequire().ToString();
        designExpBar.fillAmount = CalculateExpBar(design);
    }
    private void SetTesting()
    {
        testingLevelText.text = testing.GetCurrentHardSkillLevel().ToString();
        testingNameText.text = testing.GetHardSkillName();
        testingCodingBonusText.text = testing.GetTotalBonusCoding().ToString();
        testingDesignBonusText.text = testing.GetTotalBonusDesign().ToString();
        testingTestingBonusText.text = testing.GetTotalBonusTesting().ToString();
        testingArtBonusText.text = testing.GetTotalBonusArt().ToString();
        testingSoundBonusText.text = testing.GetTotalBonusSound().ToString();
        testingCurrentExpText.text = testing.GetCurrentHardSkillEXP().ToString();
        testingRequireExpText.text = testing.GetExpRequire().ToString();
        testingExpBar.fillAmount = CalculateExpBar(testing);
    }
    private void SetArt()
    {
        artLevelText.text = art.GetCurrentHardSkillLevel().ToString();
        artNameText.text = art.GetHardSkillName();
        artCodingBonusText.text = art.GetTotalBonusCoding().ToString();
        artDesignBonusText.text = art.GetTotalBonusDesign().ToString();
        artTestingBonusText.text = art.GetTotalBonusTesting().ToString();
        artArtBonusText.text = art.GetTotalBonusArt().ToString();
        artSoundBonusText.text = art.GetTotalBonusSound().ToString();
        artCurrentExpText.text = art.GetCurrentHardSkillEXP().ToString();
        artRequireExpText.text = art.GetExpRequire().ToString();
        artExpBar.fillAmount = CalculateExpBar(art);
    }
    private void SetSound()
    {
        soundLevelText.text = sound.GetCurrentHardSkillLevel().ToString();
        soundNameText.text = sound.GetHardSkillName();
        soundCodingBonusText.text = sound.GetTotalBonusCoding().ToString();
        soundDesignBonusText.text = sound.GetTotalBonusDesign().ToString();
        soundTestingBonusText.text = sound.GetTotalBonusTesting().ToString();
        soundArtBonusText.text = sound.GetTotalBonusArt().ToString();
        soundSoundBonusText.text = sound.GetTotalBonusSound().ToString();
        soundCurrentExpText.text = sound.GetCurrentHardSkillEXP().ToString();
        soundRequireExpText.text = sound.GetExpRequire().ToString();
        soundExpBar.fillAmount = CalculateExpBar(sound);
    }
}
