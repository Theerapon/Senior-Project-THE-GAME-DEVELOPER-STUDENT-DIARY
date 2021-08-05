using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idea : MonoBehaviour
{
    private Idea_Template definition;

    public Idea(Idea_Template idea_Template)
    {
        definition = idea_Template;
    }

    #region Get
    public string Id { get => definition.Id; }
    public IdeaType IdeaType { get => definition.IdeaType; }
    public string IdeaName { get => definition.IdeaName; }
    public string Description { get => definition.Description; }
    public Sprite Icon { get => definition.Icon; }
    public bool Collected { get => definition.Collected; }
    public string Message { get => definition.Message; }
    #endregion

    #region Set
    public bool ReceiveIdea()
    {
        if(definition.Collected == false)
        {
            definition.Collected = true;
            return true;
        }
        else
        {
            return false;
        }
        
    }
    #endregion
}
