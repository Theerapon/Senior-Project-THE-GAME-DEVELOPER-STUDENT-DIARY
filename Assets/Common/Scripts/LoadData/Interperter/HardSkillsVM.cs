using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HardSkill_Template;

public class HardSkillsVM : Manager<HardSkillsVM>
{
    private const string INST_SET_hardskillID = "hardskillID";
    private const string INST_SET_hardskillName = "hardskillName";
    private const string INST_SET_hardskillDescription = "hardskillDescription";
    private const string INST_SET_hardskillMaxLevel = "hardskillMaxLevel";
    private const string INST_SET_createLevel = "createLevel";
    private const string INST_SET_endcreateLevel = "endcreateLevel";

    private const string INST_SET_expRequired = "expRequired";
    private const string INST_SET_bonusCoding = "bonusCoding";
    private const string INST_SET_bonusDesign = "bonusDesign";
    private const string INST_SET_bonusTesting = "bonusTesting";
    private const string INST_SET_bonusArt = "bonusArt";
    private const string INST_SET_bonusSound = "bonusSound";


    private HardSkillsLoading hardskillsLoading;


    private void Start()
    {
        hardskillsLoading = HardSkillsLoading.instance;
    }


    public List<HardSkill> Interpert()
    {
        if(hardskillsLoading != null)
        {
            List<HardSkill> hardSkills = new List<HardSkill>();

            foreach (KeyValuePair<string, string> line in hardskillsLoading.textLists)
            {
                HardSkill hardSkill = new HardSkill();
                string key = line.Key;
                string value = line.Value;

                hardSkill = new HardSkill(CreateTemplate(value));
                hardSkills.Add(hardSkill);

            }
            return hardSkills;
        }

        return null;
    }

    private HardSkill_Template CreateTemplate(string line)
    {
        HardSkillLevel[] hardSkillLevelsList = null;
        string hardSkill_ID = "";
        string hardSkill_Name = "";
        string hardSkill_Description = "";
        int hardSkill_MaxLevel = 0;
        Stack<int> stack_Level_Detail = new Stack<int>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_hardskillID:
                    hardSkill_ID = entries[++i];
                    break;
                case INST_SET_hardskillName:
                    hardSkill_Name = entries[++i];
                    break;
                case INST_SET_hardskillDescription:
                    hardSkill_Description = entries[++i];
                    break;
                case INST_SET_hardskillMaxLevel:
                    hardSkill_MaxLevel = int.Parse(entries[++i]);
                    hardSkillLevelsList = new HardSkillLevel[hardSkill_MaxLevel + 1];
                    break;
                case INST_SET_createLevel:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_bonusCoding:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_expRequired:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_bonusDesign:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_bonusTesting:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_bonusArt:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_bonusSound:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_endcreateLevel:
                    int sound = stack_Level_Detail.Pop();
                    int art = stack_Level_Detail.Pop();
                    int testing = stack_Level_Detail.Pop();
                    int design = stack_Level_Detail.Pop();
                    int coding = stack_Level_Detail.Pop();
                    int exp = stack_Level_Detail.Pop();
                    int level = stack_Level_Detail.Pop();
                    hardSkillLevelsList[level] = new HardSkillLevel(exp, coding, design, testing, art, sound);
                    break;
            }

        }
        return new HardSkill_Template(hardSkill_ID, hardSkill_Name, hardSkill_Description, hardSkill_MaxLevel, hardSkillLevelsList);
    }
}
