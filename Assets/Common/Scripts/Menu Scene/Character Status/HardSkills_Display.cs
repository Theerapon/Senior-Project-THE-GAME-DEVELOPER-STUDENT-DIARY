using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSkills_Display : MonoBehaviour
{
    #region Events
    public Events.EventOnPointEnterHardSkillSlot OnPointEnterHardSkillSlotEvent;
    public Events.EventOnPointExitHardSkillSlot OnPointExitHardSkillSlotEvent;
    public Events.EventOnLeftClickHardSkillSlot OnLeftClickHardSkillSlotEvent;
    #endregion

    protected HardSkillsController hardSkillsController;

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
        hardSkillsController = HardSkillsController.Instance;

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
        int i = 0;
        foreach (KeyValuePair<string, HardSkill> hardskill in hardSkillsController.Hardskills)
        {
            HardSkill hardSkill = hardskill.Value;
            if (!ReferenceEquals(hardSkill, null))
            {
                hardSkillSlots[i].HARDSKILL = hardskill.Value;
            }
            i++;
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

    private void OnLeftClickHardSkillSlotHandler(BaseHardSkillSlot hardSkillSlot, bool selected)
    {
        OnLeftClickHardSkillSlotEvent?.Invoke(hardSkillSlot, selected);
    }

}
