using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDesignMessageController : Manager<GameDesignMessageController>
{
    private GameDocMessage_DataHandler gameDocMessage_DataHandler;
    private GameDocMessage_Template gameDocMessage_Template;

    protected override void Awake()
    {
        base.Awake();
        gameDocMessage_Template = null;
        gameDocMessage_DataHandler = FindObjectOfType<GameDocMessage_DataHandler>();
        if (!ReferenceEquals(gameDocMessage_DataHandler.GetGameDocMessage, null))
        {
            gameDocMessage_Template = gameDocMessage_DataHandler.GetGameDocMessage;
            Debug.Log("messageeeeeeeeeeeeeeeeeeeeeeeeeeee");
        }
        
    }

    //ตัวเกมทำงานบนแพลต์ฟอร์ม #PLATFORM และรองรับการเล่นแบบ #PLAYER
    public string GetDetailMessage(string platformMessage, string playerMessage)
    {
        string str = gameDocMessage_Template.DetailMessage;
        string platfomrReplace = gameDocMessage_Template.PlatformReplace;
        string playerReplace = gameDocMessage_Template.PlayerReplace;
        str = str.Replace(platfomrReplace, platformMessage);
        str = str.Replace(playerReplace, playerMessage);
        return str;
    }

    public void Getsdf()
    {
        Debug.Log("sdfsf");
    }

    //#NAME เป็นเกม #MECHANIC1 #MECHANIC2 เพื่อ #GOAL ในรูปแบบ #THEME
    public string GetContextMessage(string projectName, string mechanic1Message, string mechanic2Message, string goalMessage, string themeMessage)
    {
        string str = gameDocMessage_Template.ContextMessage;
        string mechanic1Replace = gameDocMessage_Template.Mechanic1Replace;
        string mechanic2Replace = gameDocMessage_Template.Mechanic2Replace;
        string goalReplace = gameDocMessage_Template.GoalReplace;
        string themeReplace = gameDocMessage_Template.ThemeReplace;
        string projectNameReplace = gameDocMessage_Template.NameReplace;
        str = str.Replace(mechanic1Replace, mechanic1Message);
        str = str.Replace(mechanic2Replace, mechanic2Message);
        str = str.Replace(goalReplace, goalMessage);
        str = str.Replace(themeReplace, themeMessage);
        str = str.Replace(projectNameReplace, projectName);
        return str;
    }
}
