using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguesNpcVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_NpcID = "NpcID";
    private const string INST_SET_Loop = "Loop";
    private const string INST_SET_FirstRelationship = "FRelationship";
    private const string INST_SET_EndRelationship = "ERelationship";
    private const string INST_SET_GiftCondition = "Gift";
    private const string INST_SET_EquipCondition = "Equip";
    private const string INST_SET_TimeCondition = "Time";
    private const string INST_SET_PlaceCondition = "Place";
    private const string INST_SET_Dialogue = "Dia";
    private const string INST_SET_Event = "Event";
    private const string INST_SET_CreateIdea = "Cidea";
    private const string INST_SET_EndIdea = "Eidea";
    private const string INST_SET_CreateItem = "Citem";
    private const string INST_SET_EndItem = "Eitem";
    #endregion

    [SerializeField] private DialoguesNPC_Loading dialoguesNPC_Loading;
}
