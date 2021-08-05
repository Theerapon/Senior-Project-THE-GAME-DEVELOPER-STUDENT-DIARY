using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkProjectQuestionDisplay : MonoBehaviour
{
    #region Instace
    private const string INST_ProjectName = "ตั้งชื่อโปรเจค";
    private const string INST_Goal = "เลือกเป้าหมายของเกม";
    private const string INST_Mechanic = "เลือกกลไกของเกม";
    private const string INST_Theme = "เลือกธีมของเกม";
    #endregion

    [Header("Question")]
    [SerializeField] private TMP_InputField projectNameTMP;
    [SerializeField] private TMP_Text goalIdeaTMP;
    [SerializeField] private TMP_Text mechanicIdeasTMP;
    [SerializeField] private TMP_Text themeIdeaTMP;
    [SerializeField] private TMP_Dropdown platformIdeasTMP;
    [SerializeField] private TMP_Dropdown playerIdeasTMP;

    //private List<string> platformNameIdeas;
    //private List<string> playerNameIdeas;

    private void Awake()
    {
        //platformNameIdeas = new List<string>();
        //playerNameIdeas = new List<string>();
        Initializing();
    }

    private void Start()
    {
        platformIdeasTMP.onValueChanged.AddListener(delegate { DropdownPlatformItemSelected(platformIdeasTMP); });
        playerIdeasTMP.onValueChanged.AddListener(delegate { DropdownplayerItemSelected(playerIdeasTMP); });
    }

    private void Initializing()
    {
        projectNameTMP.placeholder.GetComponent<TMP_Text>().text = INST_ProjectName;
        goalIdeaTMP.text = INST_Goal;
        mechanicIdeasTMP.text = INST_Mechanic;
        themeIdeaTMP.text = INST_Theme;
    }

    public void DisplayDropdown(List<string> platformIdeas, List<string> playerIdeas)
    {
        platformIdeasTMP.options.Clear();
        foreach (string platformIdea in platformIdeas)
        {
            platformIdeasTMP.options.Add(new TMP_Dropdown.OptionData() { text = platformIdea });
        }

        playerIdeasTMP.options.Clear();
        foreach (string playerIdea in playerIdeas)
        {
            playerIdeasTMP.options.Add(new TMP_Dropdown.OptionData() { text = playerIdea });
        }
    }

    private void DropdownPlatformItemSelected(TMP_Dropdown tMP_Dropdown)
    {
        int index = tMP_Dropdown.value;

        Debug.Log(tMP_Dropdown.options[index].text);
    }
    private void DropdownplayerItemSelected(TMP_Dropdown tMP_Dropdown)
    {
        int index = tMP_Dropdown.value;
        Debug.Log(tMP_Dropdown.options[index].text);
    }

    public void DisplayGoal(string name, bool select)
    {
        if (select)
        {
            goalIdeaTMP.text = name;
        }
        else
        {
            goalIdeaTMP.text = INST_Goal;
        }
    }

    public void DisplayTheme(string name, bool select)
    {
        if (select)
        {
            themeIdeaTMP.text = name;
        }
        else
        {
            themeIdeaTMP.text = INST_Theme;
        }
    }

    public void DisplayMechanic(List<string> name)
    {
        if(name.Count == 0)
        {
            mechanicIdeasTMP.text = INST_Mechanic;
        }
        else
        {
            string str = string.Empty;
            string[] entries = new string[name.Count];
            for(int i = 0; i < name.Count; i++)
            {
                if(i <= 0)
                {
                    entries[i] = name[i];
                }
                else
                {
                    entries[i] = ", " + name[i];
                }
            }
            for(int j = 0; j < entries.Length; j++)
            {
                str += entries[j];
            }
            mechanicIdeasTMP.text = str;
        }
    }

    public string GetNameProject()
    {
        if(projectNameTMP.text != string.Empty)
        {
            return projectNameTMP.text;
        }

        return string.Empty;
    }

    public int GetIndexPlatformDropdownSelect()
    {
        return platformIdeasTMP.value;
    }

    public int GetIndexPlayerDropdownSelect()
    {
        return playerIdeasTMP.value;
    }
}
