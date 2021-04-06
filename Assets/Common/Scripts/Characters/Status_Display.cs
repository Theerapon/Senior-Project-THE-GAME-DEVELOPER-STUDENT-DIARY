using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Display : MonoBehaviour
{
    #region Description
    private const string INST_CODING = "สเตตัส Coding ช่วยในการเขียนโปรแกรม";
    private const string INST_DESIGN = "สเตตัส Design ช่วยในการวิเคราะห์ปัญหา ออกแบบโครงสร้างระบบ";
    private const string INST_TESTING = "สเตตัส Testing ช่วยในการตรวจสอบความถูกต้องของโปรแกรม ว่าทำงานตรงตามความต้องการหรือไม่";
    private const string INST_ART = "สเตตัส Art ช่วยในการทำงานเกี่ยวกับภาพนิ่ง และภาพเคลื่อนไหว";
    private const string INST_SOUND = "สเตตัส Sound ช่วยในการทำงานเกี่ยวกับเรื่องเสียงภายในเกม เพื่อให้ผู้เล่นได้รับประสบการณ์ทางด้านอารมณ์เสียงให้สอดคล้องไปกับธีมของเกม";
    #endregion

    #region Events
    public Events.EventOnPointEnterStatusSlot OnPointEnterStatusSlot;
    public Events.EventOnPointExitStatusSlot OnPointExitStatusSlot;
    public Events.EventOnLeftClickStatusSlot OnLeftClickStatusSlot;
    #endregion

    protected GameObject found_player;
    protected Characters_Handler characters_Handler;

    [SerializeField] private Transform itemsParent;
    public List<BaseStatusSlot> statusSlots;

    bool displayed = false;

    private void Awake()
    {
        //set Item Slots
        statusSlots = new List<BaseStatusSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: statusSlots);
    }

    private void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        characters_Handler = found_player.GetComponentInChildren<Characters_Handler>();

        for (int index = 0; index < statusSlots.Count; index++)
        {
            statusSlots[index].OnLeftClickStatusSlot.AddListener(OnLeftClickStatusSlotHandler);
            statusSlots[index].OnPointEnterStatusSlot.AddListener(OnPointEnterStatusSlotHandler);
            statusSlots[index].OnPointExitStatusSlot.AddListener(OnPointExitStatusSlotHandler);
        }

        displayed = false;
    }

    private void Update()
    {
        if (!displayed)
        {
            DisplayedStatus();
            displayed = true;
        }
    }

    private void DisplayedStatus()
    {
        for (int i = 0; i < statusSlots.Count; i++)
        {
            if(!ReferenceEquals(characters_Handler, null))
            {
                switch (statusSlots[i].TYPE)
                {
                    case StatusType.Coding:
                        statusSlots[i].VALUE = characters_Handler.STATUS.GetCodingStatus();
                        statusSlots[i].DESCRIPTION = INST_CODING;
                        break;
                    case StatusType.Design:
                        statusSlots[i].VALUE = characters_Handler.STATUS.GetDesignStatus();
                        statusSlots[i].DESCRIPTION = INST_DESIGN;
                        break;
                    case StatusType.Testing:
                        statusSlots[i].VALUE = characters_Handler.STATUS.GetTestingStatus();
                        statusSlots[i].DESCRIPTION = INST_TESTING;
                        break;
                    case StatusType.Art:
                        statusSlots[i].VALUE = characters_Handler.STATUS.GetArtStatus();
                        statusSlots[i].DESCRIPTION = INST_ART;
                        break;
                    case StatusType.Sound:
                        statusSlots[i].VALUE = characters_Handler.STATUS.GetSoundStatus();
                        statusSlots[i].DESCRIPTION = INST_SOUND;
                        break;
                    default:
                        break;
                }
            }

            
        }
    }

    private void OnPointExitStatusSlotHandler(BaseStatusSlot statusSlot)
    {
        OnPointExitStatusSlot?.Invoke(statusSlot);
    }

    private void OnPointEnterStatusSlotHandler(BaseStatusSlot statusSlot)
    {
        OnPointEnterStatusSlot?.Invoke(statusSlot);
    }

    private void OnLeftClickStatusSlotHandler(BaseStatusSlot statusSlot)
    {
        OnLeftClickStatusSlot?.Invoke(statusSlot);
    }
    protected virtual void OnValidate()
    {
        
        if (itemsParent == null)
            itemsParent = transform.GetChild(0).GetComponent<Transform>();
    }
}
