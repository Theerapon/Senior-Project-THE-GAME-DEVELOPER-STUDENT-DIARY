using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcsVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Name = "Name";
    private const string INST_SET_Icon = "Icon";
    private const string INST_SET_HappinessImage = "HappinessImage";
    private const string INST_SET_SadnessImage = "SadnessImage";
    private const string INST_SET_FearImage = "FearImage";
    private const string INST_SET_DisgustImage = "DisgustImage";
    private const string INST_SET_AngerImage = "AngerImage";
    private const string INST_SET_SurpriseImage = "SurpriseImage";
    private const string INST_SET_NormalImage = "NormalImage";
    private const string INST_SET_RelationshipDescription = "RelationshipDescription";
    private const string INST_SET_FavItemID = "FavItemID";
    private const string INST_SET_Home = "Home";
    private const string INST_SET_Birthday = "Birthday";
    #endregion

    [SerializeField] private NPCs_Loading nPCs_Loading;
}
