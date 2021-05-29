using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploration_Template : MonoBehaviour
{
    private string id = string.Empty;
    private bool locked = false;
    private int maxLevel = 5;
    private string explorationIdRequired = string.Empty;
    private int levelRequired = 0;
    private List<int> expRequired = null;
    private Dictionary<int, List<string>> explorationDialogueIdList = null;

    public string Id { get => id; }
    public bool Locked { get => locked; set => locked = value; }
    public int MaxLevel { get => maxLevel; }
    public string ExplorationIdRequired { get => explorationIdRequired; }
    public int LevelRequired { get => levelRequired; }
    public List<int> ExpRequired { get => expRequired; }
    public Dictionary<int, List<string>> ExplodialogueIdList { get => explorationDialogueIdList; }

    public Exploration_Template(string id, bool locked, int maxLevel, string explorationIdRequired, int levelRequired, List<int> expRequired, Dictionary<int, List<string>> explodialogueIdList)
    {
        this.id = id;
        this.locked = locked;
        this.maxLevel = maxLevel;
        this.explorationIdRequired = explorationIdRequired;
        this.levelRequired = levelRequired;
        this.expRequired = expRequired;
        this.explorationDialogueIdList = explodialogueIdList;
    }
}
