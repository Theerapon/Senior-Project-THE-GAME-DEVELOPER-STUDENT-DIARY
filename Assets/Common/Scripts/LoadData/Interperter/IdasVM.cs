using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdasVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_IdeaType = "ideaType";
    private const string INST_SET_IdeaName = "ideaName";
    private const string INST_SET_IdeaDescription = "ideaDescription";
    private const string INST_SET_IconPath = "iconPath";
    private const string INST_SET_DefaultCollected = "defaultCollected";
    #endregion

    [SerializeField] private Ideas_Loading ideas_Loading;
}
