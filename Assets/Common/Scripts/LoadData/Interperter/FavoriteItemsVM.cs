using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteItemsVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_Type = "Clike";
    private const string INST_SET_Name = "Elike";
    private const string INST_SET_Icon = "Cunlike";
    private const string INST_SET_Day = "Eunlike";
    private const string INST_SET_StartTime = "Cexcept";
    private const string INST_SET_EndTime = "Eexcept";
    #endregion

    [SerializeField] private FavoriteItems_Loading favoriteItems_Loading;
}
