using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassActivitiesVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Type = "Type";
    private const string INST_SET_Name = "Name";
    private const string INST_SET_Icon = "Icon";
    private const string INST_SET_Day = "Day";
    private const string INST_SET_StartTime = "StartTime";
    private const string INST_SET_EndTime = "EndTime";
    #endregion

    [SerializeField] private ClassActivities_Loading classActivities_Loading;
}
