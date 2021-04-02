﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Communication_Template;
using static CriticalThinking_Template;
using static Leadership_Template;
using static TimeManagement_Template;
using static WorkEthic_Template;

public class SoftSkillsVM : Manager<SoftSkillsVM>
{
    private const string INST_SET_softskillID = "softskillID";
    private const string INST_SET_softskillName = "softskillName";
    private const string INST_SET_softskillDescription = "softskillDescription";
    private const string INST_SET_softskillMaxcreateLevel = "softskillMaxcreateLevel";
    private const string INST_SET_createLevel = "createLevel";
    private const string INST_SET_endcreateLevel = "endcreateLevel";

    private const string INST_SET_addCharm = "addCharm%";
    private const string INST_SET_addBaseBootUpProject = "addBaseBootUpProject%";
    
    private const string INST_SET_addBaseReduceEnergy = "addBaseReduceEnergy%";
    private const string INST_SET_addBaseBootUpMotivation = "addBaseBootUpMotivation%";
    private const string INST_SET_addReducBugChange = "addReducBugChange%";
    
    private const string INST_SET_addNegativeChance = "addNegativeChance%";
    private const string INST_SET_addNegativeEffect = "addNegativeEffect%";
    private const string INST_SET_addPositiveChange = "addPositiveChange%";
    
    private const string INST_SET_addReduceTimeCourse = "addReduceTimeCourse%";
    
    private const string INST_SET_addGoldReducEnnergy = "addGoldReducEnnergy%";
    private const string INST_SET_addGoldBootUpMotivation = "addGoldBootUpMotivation%";
    private const string INST_SET_addGoldBootUpProject = "addGoldBootUpProject%";

    private SoftSkillsLoading softskillsLoading;

    private void Start()
    {
        softskillsLoading = SoftSkillsLoading.instance;
    }

    public List<SoftSkill> Interpert()
    {

        List<SoftSkill> softSkills = new List<SoftSkill>();

        foreach (KeyValuePair<string, string> line in softskillsLoading.textLists)
        {
            SoftSkill softSkill = new SoftSkill();
            string key = line.Key;
            string value = line.Value;
            switch (key)
            {
                case "COMMUNICATION":
                    softSkill = new SoftSkill(CreateCommunication(value));
                    break;
                case "CRITICALTHINKING":
                    softSkill = new SoftSkill(CreateCriticalThinking(value));
                    break;
                case "LEADERSHIP":
                    softSkill = new SoftSkill(CreateLeadership(value));
                    break;
                case "TIMEMANAGEMENT":
                    softSkill = new SoftSkill(CreateTimeManagement(value));
                    break;
                case "WORKETHIC":
                    softSkill = new SoftSkill(CreateWorkEthic(value));
                    break;
            }

            softSkills.Add(softSkill);
        }


        return softSkills;
    }

    private Communication_Template CreateCommunication(string line)
    {
        CommunicationSkillLevel[] softSkillLevelsList = null;
        string softSkill_ID = "";
        string softSkill_Name = "";
        string softSkill_Description = "";
        int softSkill_MaxLevel = 0;
        Stack<int> stack_Level_Detail = new Stack<int>();
        
        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_softskillID:
                    softSkill_ID = entries[++i];
                    break;
                case INST_SET_softskillName:
                    softSkill_Name = entries[++i];
                    break;
                case INST_SET_softskillDescription:
                    softSkill_Description = entries[++i];
                    break;
                case INST_SET_softskillMaxcreateLevel:
                    softSkill_MaxLevel = int.Parse(entries[++i]);
                    softSkillLevelsList = new CommunicationSkillLevel[softSkill_MaxLevel + 1];
                    break;
                case INST_SET_createLevel:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_addCharm:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_addBaseBootUpProject:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_endcreateLevel:
                    float baseBootUpProject = stack_Level_Detail.Pop() / 100f;
                    float charm = stack_Level_Detail.Pop() / 100f;
                    int level = stack_Level_Detail.Pop();
                    softSkillLevelsList[level] = new CommunicationSkillLevel(charm, baseBootUpProject);
                    break;
            }

        }
        return new Communication_Template(softSkill_ID, softSkill_Name, softSkill_Description, softSkill_MaxLevel, softSkillLevelsList);
    }
    private CriticalThinking_Template CreateCriticalThinking(string line)
    {
        CriticalThinkingSkillLevel[] softSkillLevelsList = null;
        string softSkill_ID = "";
        string softSkill_Name = "";
        string softSkill_Description = "";
        int softSkill_MaxLevel = 0;
        Stack<int> stack_Level_Detail = new Stack<int>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_softskillID:
                    softSkill_ID = entries[++i];
                    break;
                case INST_SET_softskillName:
                    softSkill_Name = entries[++i];
                    break;
                case INST_SET_softskillDescription:
                    softSkill_Description = entries[++i];
                    break;
                case INST_SET_softskillMaxcreateLevel:
                    softSkill_MaxLevel = int.Parse(entries[++i]);
                    softSkillLevelsList = new CriticalThinkingSkillLevel[softSkill_MaxLevel + 1];
                    break;
                case INST_SET_createLevel:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_endcreateLevel:
                    float reduceBugChange = stack_Level_Detail.Pop() / 100f;
                    float basesBootUpMotivation = stack_Level_Detail.Pop() / 100f;
                    float baseReduceEnergy = stack_Level_Detail.Pop() / 100f;
                    softSkillLevelsList[stack_Level_Detail.Pop()] = new CriticalThinkingSkillLevel(baseReduceEnergy, basesBootUpMotivation, reduceBugChange);
                    break;
                case INST_SET_addBaseReduceEnergy:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_addBaseBootUpMotivation:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_addReducBugChange:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
            }

        }
        return new CriticalThinking_Template(softSkill_ID, softSkill_Name, softSkill_Description, softSkill_MaxLevel, softSkillLevelsList);
    }
    private Leadership_Template CreateLeadership(string line)
    {
        LeadershipSkillLevel[] softSkillLevelsList = null;
        string softSkill_ID = "";
        string softSkill_Name = "";
        string softSkill_Description = "";
        int softSkill_MaxLevel = 0;
        Stack<int> stack_Level_Detail = new Stack<int>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_softskillID:
                    softSkill_ID = entries[++i];
                    break;
                case INST_SET_softskillName:
                    softSkill_Name = entries[++i];
                    break;
                case INST_SET_softskillDescription:
                    softSkill_Description = entries[++i];
                    break;
                case INST_SET_softskillMaxcreateLevel:
                    softSkill_MaxLevel = int.Parse(entries[++i]);
                    softSkillLevelsList = new LeadershipSkillLevel[softSkill_MaxLevel + 1];
                    break;
                case INST_SET_createLevel:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_endcreateLevel:
                    float positiveChange = stack_Level_Detail.Pop() / 100f;
                    float negativeEffect = stack_Level_Detail.Pop() / 100f;
                    float negativeChance = stack_Level_Detail.Pop() / 100f;
                    softSkillLevelsList[stack_Level_Detail.Pop()] = new LeadershipSkillLevel(negativeChance, negativeEffect, positiveChange);
                    break;
                case INST_SET_addNegativeChance:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_addNegativeEffect:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_addPositiveChange:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                    
            }

        }
        return new Leadership_Template(softSkill_ID, softSkill_Name, softSkill_Description, softSkill_MaxLevel, softSkillLevelsList);
    }
    private TimeManagement_Template CreateTimeManagement(string line)
    {
        TimeManagementSkillLevel[] softSkillLevelsList = null;
        string softSkill_ID = "";
        string softSkill_Name = "";
        string softSkill_Description = "";
        int softSkill_MaxLevel = 0;
        Stack<int> stack_Level_Detail = new Stack<int>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_softskillID:
                    softSkill_ID = entries[++i];
                    break;
                case INST_SET_softskillName:
                    softSkill_Name = entries[++i];
                    break;
                case INST_SET_softskillDescription:
                    softSkill_Description = entries[++i];
                    break;
                case INST_SET_softskillMaxcreateLevel:
                    softSkill_MaxLevel = int.Parse(entries[++i]);
                    softSkillLevelsList = new TimeManagementSkillLevel[softSkill_MaxLevel + 1];
                    break;
                case INST_SET_createLevel:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_endcreateLevel:
                    float resuceTime = stack_Level_Detail.Pop() / 100f;
                    softSkillLevelsList[stack_Level_Detail.Pop()] = new TimeManagementSkillLevel(resuceTime);
                    break;
                case INST_SET_addReduceTimeCourse:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
            }

        }
        return new TimeManagement_Template(softSkill_ID, softSkill_Name, softSkill_Description, softSkill_MaxLevel, softSkillLevelsList);
    }
    private WorkEthic_Template CreateWorkEthic(string line)
    {
        WorkEthicSkillLevel[] softSkillLevelsList = null;
        string softSkill_ID = "";
        string softSkill_Name = "";
        string softSkill_Description = "";
        int softSkill_MaxLevel = 0;
        Stack<int> stack_Level_Detail = new Stack<int>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_softskillID:
                    softSkill_ID = entries[++i];
                    break;
                case INST_SET_softskillName:
                    softSkill_Name = entries[++i];
                    break;
                case INST_SET_softskillDescription:
                    softSkill_Description = entries[++i];
                    break;
                case INST_SET_softskillMaxcreateLevel:
                    softSkill_MaxLevel = int.Parse(entries[++i]);
                    softSkillLevelsList = new WorkEthicSkillLevel[softSkill_MaxLevel + 1];
                    break;
                case INST_SET_createLevel:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_endcreateLevel:
                    float bootupProject = stack_Level_Detail.Pop() / 100f;
                    float bootupMotivation = stack_Level_Detail.Pop() / 100f;
                    float reduceEnnergy = stack_Level_Detail.Pop() / 100f;
                    softSkillLevelsList[stack_Level_Detail.Pop()] = new WorkEthicSkillLevel(reduceEnnergy, bootupMotivation, bootupProject);
                    break;
                case INST_SET_addGoldReducEnnergy:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_addGoldBootUpMotivation:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
                case INST_SET_addGoldBootUpProject:
                    stack_Level_Detail.Push(int.Parse(entries[++i]));
                    break;
            }

        }
        return new WorkEthic_Template(softSkill_ID, softSkill_Name, softSkill_Description, softSkill_MaxLevel, softSkillLevelsList); ;
    }
}