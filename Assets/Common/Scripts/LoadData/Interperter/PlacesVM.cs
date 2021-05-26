using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Name = "Name";
    private const string INST_SET_Open = "Open";
    private const string INST_SET_Close = "Close";
    private const string INST_SET_OnClick = "OnClick";
    private const string INST_SET_Mon = "Mon";
    private const string INST_SET_Tue = "Tue";
    private const string INST_SET_Wed = "Wed";
    private const string INST_SET_Thu = "Thu";
    private const string INST_SET_Fri = "Fri";
    private const string INST_SET_Sat = "Sat";
    private const string INST_SET_Sun = "Sun";
    private const string INST_SET_StoreID = "StoreID";
    #endregion

    [SerializeField] private Places_Loading places_Loading;
}
