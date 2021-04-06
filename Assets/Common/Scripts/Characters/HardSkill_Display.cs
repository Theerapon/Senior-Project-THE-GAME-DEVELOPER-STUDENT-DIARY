using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkill_Display : MonoBehaviour
{
    #region Events
    public Events.EventOnPointEnterHardSkillSlot OnPointEnterHardSkillSlotEvent;
    public Events.EventOnPointExitHardSkillSlot OnPointExitHardSkillSlotEvent;
    public Events.EventOnLeftClickHardSkillSlot OnLeftClickHardSkillSlotEvent;
    #endregion

    protected GameObject found_player;
    protected HardSkills_Handler hardSkills_Handler;

    [SerializeField] private Transform itemsParent;
    public List<BaseHardSkillSlot> hardSkillSlots;

    bool displayed = false;

    private void Awake()
    {
        //set Item Slots
        hardSkillSlots = new List<BaseHardSkillSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: hardSkillSlots);
    }


    void Start()
    {
        //fonud inventory container in main Scene
        found_player = GameObject.FindGameObjectWithTag("Player");
        hardSkills_Handler = found_player.GetComponentInChildren<HardSkills_Handler>();

        for (int index = 0; index < hardSkillSlots.Count; index++)
        {
            hardSkillSlots[index].OnLeftClickHardSkillSlotEvent.AddListener(OnLeftClickHardSkillSlotHandler);
            hardSkillSlots[index].OnPointEnterHardSkillSlotEvent.AddListener(OnPointEnterHardSkillSlotHandler);
            hardSkillSlots[index].OnPointExitHardSkillSlotEvent.AddListener(OnPointExitHardSkillSlotHandler);
        }

        displayed = false;
    }

    private void Update()
    {
        if (!displayed)
        {
            DisplayedHardSkill();
            displayed = true;
        }
    }

    private void DisplayedHardSkill()
    {
        for (int i = 0; i < hardSkills_Handler.HARDSKILLS.Count; i++)
        {
            HardSkill hardSkill = hardSkills_Handler.HARDSKILLS[i];
            if (!ReferenceEquals(hardSkill, null))
            {
                hardSkillSlots[i].HARDSKILL = hardSkills_Handler.HARDSKILLS[i];
            }
        }
    }

    private void OnPointExitHardSkillSlotHandler(BaseHardSkillSlot hardSkillSlot)
    {
        OnPointExitHardSkillSlotEvent?.Invoke(hardSkillSlot);
    }

    private void OnPointEnterHardSkillSlotHandler(BaseHardSkillSlot hardSkillSlot)
    {
        OnPointEnterHardSkillSlotEvent?.Invoke(hardSkillSlot);
    }

    private void OnLeftClickHardSkillSlotHandler(BaseHardSkillSlot hardSkillSlot)
    {
        OnLeftClickHardSkillSlotEvent?.Invoke(hardSkillSlot);
    }

}
