using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeasController : Manager<IdeasController>
{
    private Ideas_DataHandler ideas_DataHandler;
    private Dictionary<string, Idea> goalIdeas;
    private Dictionary<string, Idea> mechanicIdeas;
    private Dictionary<string, Idea> themeIdeas;
    private Dictionary<string, Idea> platformIdeas;
    private Dictionary<string, Idea> playerIdeas;
    public Dictionary<string, Idea> GoalIdeas { get => goalIdeas; }
    public Dictionary<string, Idea> MechanicIdeas { get => mechanicIdeas; }
    public Dictionary<string, Idea> ThemeIdeas { get => themeIdeas; }
    public Dictionary<string, Idea> PlatformIdeas { get => platformIdeas; }
    public Dictionary<string, Idea> PlayerIdeas { get => playerIdeas; }
    protected override void Awake()
    {
        base.Awake();
        ideas_DataHandler = FindObjectOfType<Ideas_DataHandler>();
        goalIdeas = new Dictionary<string, Idea>();
        mechanicIdeas = new Dictionary<string, Idea>();
        themeIdeas = new Dictionary<string, Idea>();
        platformIdeas = new Dictionary<string, Idea>();
        playerIdeas = new Dictionary<string, Idea>();

        if (!ReferenceEquals(ideas_DataHandler.GetIdeasDic, null))
        {
            foreach (KeyValuePair<string, Idea_Template> idea in ideas_DataHandler.GetIdeasDic)
            {
                switch (idea.Value.IdeaType)
                {
                    case IdeaType.Goal:
                        goalIdeas.Add(idea.Key, new Idea(idea.Value));
                        break;
                    case IdeaType.Mechanic:
                        mechanicIdeas.Add(idea.Key, new Idea(idea.Value));
                        break;
                    case IdeaType.Theme:
                        themeIdeas.Add(idea.Key, new Idea(idea.Value));
                        break;
                    case IdeaType.Platform:
                        platformIdeas.Add(idea.Key, new Idea(idea.Value));
                        break;
                    case IdeaType.User:
                        playerIdeas.Add(idea.Key, new Idea(idea.Value));
                        break;
                }

            }
            Debug.Log("wait implementation for load save data");
        }
    }
    
    public bool ReceiveIdea(string id)
    {
        IdeaType ideaType = ideas_DataHandler.GetIdeasDic[id].IdeaType;
        bool check = false;
        switch (ideaType)
        {
            case IdeaType.Goal:
                check = goalIdeas[id].ReceiveIdea();
                break;
            case IdeaType.Mechanic:
                check = mechanicIdeas[id].ReceiveIdea();
                break;
            case IdeaType.Theme:
                check = themeIdeas[id].ReceiveIdea();
                break;
            case IdeaType.Platform:
                check = platformIdeas[id].ReceiveIdea();
                break;
            case IdeaType.User:
                check = playerIdeas[id].ReceiveIdea();
                break;
        }
        return check;
    }
}
