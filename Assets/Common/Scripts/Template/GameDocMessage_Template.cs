using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDocMessage_Template : MonoBehaviour
{
    private string id;
    private string detailMessage;
    private string contextMessage;
    private string nameReplace;
    private string goalReplace;
    private string mechanic1Replace;
    private string mechanic2Replace;
    private string themeReplace;
    private string platformReplace;
    private string playerReplace;

    public string Id { get => id; }
    public string DetailMessage { get => detailMessage; }
    public string ContextMessage { get => contextMessage; }
    public string NameReplace { get => nameReplace; }
    public string GoalReplace { get => goalReplace; }
    public string Mechanic1Replace { get => mechanic1Replace; }
    public string Mechanic2Replace { get => mechanic2Replace; }
    public string ThemeReplace { get => themeReplace; }
    public string PlatformReplace { get => platformReplace; }
    public string PlayerReplace { get => playerReplace; }

    public GameDocMessage_Template(string id, string detailMessage, string contextMessage, string nameReplace, string goalReplace, string mechanic1Replace, string mechanic2Replace, string themeReplace, string platformReplace, string playerReplace)
    {
        this.id = id;
        this.detailMessage = detailMessage;
        this.contextMessage = contextMessage;
        this.nameReplace = nameReplace;
        this.goalReplace = goalReplace;
        this.mechanic1Replace = mechanic1Replace;
        this.mechanic2Replace = mechanic2Replace;
        this.themeReplace = themeReplace;
        this.platformReplace = platformReplace;
        this.playerReplace = playerReplace;
    }
}
