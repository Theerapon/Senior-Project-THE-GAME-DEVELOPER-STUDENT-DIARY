using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoresVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_ItemSetOnMon = "Mon";
    private const string INST_SET_ItemSetOnTue = "Tue";
    private const string INST_SET_ItemSetOnWed = "Wed";
    private const string INST_SET_ItemSetOnThu = "Thu";
    private const string INST_SET_ItemSetOnFri = "Fri";
    private const string INST_SET_ItemSetOnSat = "Sat";
    private const string INST_SET_ItemSetOnSun = "Sun";
    #endregion

    [SerializeField] private Stores_Loading stores_Loading;
}
