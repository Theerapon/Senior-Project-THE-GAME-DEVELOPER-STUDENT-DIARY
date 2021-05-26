using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesNpcVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_NpcID = "NpcID";
    private const string INST_SET_Date = "Date";
    private const string INST_SET_StartTime = "StartTime";
    private const string INST_SET_EndTime = "EndTime";
    private const string INST_SET_Place = "Place";
    private const string INST_SET_CanChat = "CanChat";
    #endregion

    [SerializeField] private ActivitiesNPC_Loading activitiesNPC_Loading;
}
