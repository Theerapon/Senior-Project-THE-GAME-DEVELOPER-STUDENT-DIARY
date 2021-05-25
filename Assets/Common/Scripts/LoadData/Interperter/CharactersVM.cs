using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatus_Template;

public class CharactersVM : Manager<CharactersVM>
{
    private const string INST_SET_charID = "charID";
    private const string INST_SET_charName = "charName";

    private const string INST_SET_default_bReduceEnerg = "default_bReduceEnergy%";
    private const string INST_SET_default_gReduceEnergy = "default_gReduceEnergy%";
    private const string INST_SET_default_maxMotivation = "default_maxMotivation";
    private const string INST_SET_default_bMotivation = "default_bMotivation%";
    private const string INST_SET_default_gMotivation = "default_gMotivation%";
    private const string INST_SET_default_money = "default_money";
    private const string INST_SET_default_coding = "default_coding";
    private const string INST_SET_default_design = "default_design";
    private const string INST_SET_default_testing = "default_testing";
    private const string INST_SET_default_art = "default_art";
    private const string INST_SET_default_sound = "default_sound";
    private const string INST_SET_default_bProject = "default_bProject%";
    private const string INST_SET_default_gProject = "default_gProject%";
    private const string INST_SET_default_reduceBugChange = "default_reduceBugChange%";
    private const string INST_SET_default_charm = "default_charm%";
    private const string INST_SET_default_negativeEventEffect = "default_negativeEventEffect%";
    private const string INST_SET_default_positiveEventEffect = "default_positiveEventEffect%";
    private const string INST_SET_default_reduceTimeCourse = "default_reduceTimeCourse%";
    private const string INST_SET_default_reduceTimeTransport = "default_reduceTimeTransport%";
    private const string INST_SET_default_dropRate = "perLevel_default_dropRate%";

    private const string INST_SET_perLevel_bReduceEnergy = "perLevel_bReduceEnergy%";
    private const string INST_SET_perLevel_gReduceEnergy = "perLevel_gReduceEnergy%";
    private const string INST_SET_perLevel_bMotivation = "perLevel_bMotivation%";
    private const string INST_SET_perLevel_gMotivation = "perLevel_gMotivation%";
    private const string INST_SET_perLevel_bProject = "perLevel_bProject%";
    private const string INST_SET_perLevel_gProject = "perLevel_gProject%";
    private const string INST_SET_perLevel_reduceBugChance = "perLevel_reduceBugChance%";
    private const string INST_SET_perLevel_charm = "perLevel_charm%";
    private const string INST_SET_perLevel_negativeEffect = "perLevel_negativeEffect%";
    private const string INST_SET_perLevel_positiveEffect = "perLevel_positiveEffect%";
    private const string INST_SET_perLevel_reduceTimeCourse = "perLevel_reduceTimeCourse%";
    private const string INST_SET_perLevel_reduceTimeTransport = "perLevel_reduceTimeTransport%";
    private const string INST_SET_perLevel_softskillPoints = "perLevel_softskillPoints";
    private const string INST_SET_perLevel_DropRate = "perLevel_perLevel_DropRate%";

    private const string INST_SET_maxLevel = "maxLevel";
    private const string INST_SET_createLevel = "createLevel";
    private const string INST_SET_expRequired = "expRequired";
    private const string INST_SET_maxEnergy = "maxEnergy";
    private const string INST_SET_statsPoints = "statsPoints";
    private const string INST_SET_endcreateLevel = "endcreateLevel";

    private Characters_Loading chractersLoading;

    private void Start()
    {
        chractersLoading = Characters_Loading.instance;
    }

    public CharacterStatus_Template Interpert()
    {
        if(!ReferenceEquals(chractersLoading, null))
        {
            CharacterStatus_Template template = null;

            foreach (KeyValuePair<string, string> line in chractersLoading.textLists)
            {
                string value = line.Value;
                template = CreateCharacterStatsTemplate(value);
            }

            if(!ReferenceEquals(template, null))
            {
                return template;
            }
        }
        return null;
    }

    private CharacterStatus_Template CreateCharacterStatsTemplate(string line)
    {
        CharacterLevel[] characterLevelsList = null;
        string charID = "";
        string charName = "";

        float default_bReduceEnergy = 0f;
        float default_gReduceEnergy = 0f;
        int default_maxMotivation = 0;
        float default_bMotivation = 0f;
        float default_gMotivation = 0f;
        int default_money = 0;
        int default_coding = 0;
        int default_design = 0;
        int default_testing = 0;
        int default_art = 0;
        int default_sound = 0;
        float default_bProject = 0f;
        float default_gProject = 0f;
        float default_reduceBugChange = 0f;
        float default_charm = 0f;
        float default_negativeEventEffect = 0f;
        float default_positiveEventEffect = 0f;
        float default_reduceTimeCourse = 0f;
        float default_reduceTimeTransport = 0f;
        float default_dropRate = 0f;

        float perLevel_bReduceEnergy = 0f;
        float perLevel_gReduceEnergy = 0f;
        float perLevel_bMotivation = 0f;
        float perLevel_gMotivation = 0f;
        float perLevel_bProject = 0f;
        float perLevel_gProject = 0f;
        float perLevel_reduceBugChance =0f;
        float perLevel_charm = 0f;
        float perLevel_negativeEffect = 0f;
        float perLevel_positiveEffect = 0f;
        float perLevel_reduceTimeCourse = 0f;
        float perLevel_reduceTimeTransport = 0f;
        int perLevel_softskillPoints = 0;
        float perLevel_dropRate = 0f;

        int maxLevel = 0;
        Stack<int> stack_Level_Detail = new Stack<int>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_charID:
                    charID = entries[++i];
                    break;
                case INST_SET_charName:
                    charName = entries[++i];
                    break;
                case INST_SET_default_bReduceEnerg:
                    default_bReduceEnergy = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_gReduceEnergy:
                    default_gReduceEnergy = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_maxMotivation:
                    default_maxMotivation = int.Parse(entries[++i]);
                    break;
                case INST_SET_default_bMotivation:
                    default_bMotivation = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_gMotivation:
                    default_gMotivation = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_money:
                    default_money = int.Parse(entries[++i]);
                    break;
                case INST_SET_default_coding:
                    default_coding = int.Parse(entries[++i]);
                    break;
                case INST_SET_default_design:
                    default_design = int.Parse(entries[++i]);
                    break;
                case INST_SET_default_testing:
                    default_testing = int.Parse(entries[++i]);
                    break;
                case INST_SET_default_art:
                    default_art = int.Parse(entries[++i]);
                    break;
                case INST_SET_default_sound:
                    default_sound = int.Parse(entries[++i]);
                    break;
                case INST_SET_default_bProject:
                    default_bProject = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_gProject:
                    default_gProject = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_reduceBugChange:
                    default_reduceBugChange = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_charm:
                    default_charm = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_negativeEventEffect:
                    default_negativeEventEffect = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_positiveEventEffect:
                    default_positiveEventEffect = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_reduceTimeCourse:
                    default_reduceTimeCourse = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_reduceTimeTransport:
                    default_reduceTimeTransport = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_default_dropRate:
                    default_dropRate = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_bReduceEnergy:
                    perLevel_bReduceEnergy = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_gReduceEnergy:
                    perLevel_gReduceEnergy = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_bMotivation:
                    perLevel_bMotivation = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_gMotivation:
                    perLevel_gMotivation = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_bProject:
                    perLevel_bProject = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_gProject:
                    perLevel_gProject = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_reduceBugChance:
                    perLevel_reduceBugChance = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_charm:
                    perLevel_charm = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_negativeEffect:
                    perLevel_negativeEffect = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_positiveEffect:
                    perLevel_positiveEffect = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_reduceTimeCourse:
                    perLevel_reduceTimeCourse = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_reduceTimeTransport:
                    perLevel_reduceTimeTransport = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_perLevel_softskillPoints:
                    perLevel_softskillPoints = int.Parse(entries[++i]);
                    break;
                case INST_SET_perLevel_DropRate:
                    perLevel_dropRate = float.Parse(entries[++i]) / 100f;
                    break;
                case INST_SET_maxLevel:
                    maxLevel = int.Parse(entries[++i]);
                    characterLevelsList = new CharacterLevel[maxLevel + 1];
                    break;
                case INST_SET_createLevel:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_expRequired:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_maxEnergy:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_statsPoints:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_endcreateLevel:
                    int statsPoints = stack_Level_Detail.Pop();
                    int maxEnergy = stack_Level_Detail.Pop();
                    int expRequired = stack_Level_Detail.Pop();
                    int level = stack_Level_Detail.Pop();
                    characterLevelsList[level] = new CharacterLevel(expRequired, maxEnergy, statsPoints);
                    break;
            }
        }

        return new CharacterStatus_Template(charID, charName, 
            default_bReduceEnergy, default_gReduceEnergy, default_maxMotivation, default_bMotivation, default_gMotivation, 
            default_money, default_coding, default_design, default_testing, default_art, default_sound,
            default_bProject, default_gProject, default_reduceBugChange, default_charm,
            default_negativeEventEffect, default_positiveEventEffect, default_reduceTimeCourse, default_reduceTimeTransport, default_dropRate,
            perLevel_bReduceEnergy, perLevel_gReduceEnergy, perLevel_bMotivation, perLevel_gMotivation,
            perLevel_bProject, perLevel_gProject, perLevel_reduceBugChance, perLevel_charm,
            perLevel_negativeEffect, perLevel_positiveEffect, perLevel_reduceTimeCourse, perLevel_reduceTimeTransport,
            perLevel_softskillPoints, perLevel_dropRate, maxLevel, characterLevelsList);
    }
}

