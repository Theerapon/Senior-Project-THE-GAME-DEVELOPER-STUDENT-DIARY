using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idea_Template : MonoBehaviour
{
    private string id = string.Empty;
    private IdeaType ideaType = IdeaType.None;
    private string ideaName = string.Empty;
    private string description = string.Empty;
    private Sprite icon = null;
    private bool collected = false;

    public string Id { get => id; }
    public IdeaType IdeaType { get => ideaType; }
    public string IdeaName { get => ideaName; }
    public string Description { get => description; }
    public Sprite Icon { get => icon; }
    public bool Collected { get => collected; set => collected = value; }

    public Idea_Template(string id, IdeaType ideaType, string ideaName, string description, Sprite icon, bool collected)
    {
        this.id = id;
        this.ideaType = ideaType;
        this.ideaName = ideaName;
        this.description = description;
        this.icon = icon;
        this.collected = collected;
    }
}
