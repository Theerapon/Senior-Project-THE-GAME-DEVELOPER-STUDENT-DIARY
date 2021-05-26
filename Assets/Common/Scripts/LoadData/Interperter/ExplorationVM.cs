using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_DefaultLocked = "DefaultLocked";
    private const string INST_SET_MaxLevel = "MaxLevel";
    private const string INST_SET_ExpRequire = "ExpRequire";
    private const string INST_SET_CreateDialogueSetPerLevel = "CDiaLevel";
    private const string INST_SET_EndDialogueSetPerLevel = "EDiaLevel";
    #endregion

    [SerializeField] private Exploration_Loading exploration_Loading;
}
