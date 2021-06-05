using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Softskills_Display : MonoBehaviour
{
    #region Events
    public Events.EventOnPointEnterSoftSkillSlot OnPointEnterSoftSkillSlotEvent;
    public Events.EventOnPointExitSoftSkillSlot OnPointExitSoftSkillSlotEvent;
    public Events.EventOnLeftClickSoftSkillSlot OnLeftClickSoftSkillSlotEvent;
    #endregion

    protected SoftSkillsController softSkillsController;

    [SerializeField] private Transform itemsParent;
    public List<BaseSoftSkillSlot> softSkillSlots;

    bool displayed = false;

    private void Awake()
    {
        //set Item Slots
        softSkillSlots = new List<BaseSoftSkillSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: softSkillSlots);
    }

    void Start()
    {
        softSkillsController = SoftSkillsController.Instance;

        for (int index = 0; index < softSkillSlots.Count; index++)
        {
            softSkillSlots[index].OnLeftClickSoftSkillSlotEvent.AddListener(OnLeftClickSoftSkillSlotHandler);
            softSkillSlots[index].OnPointEnterSoftSkillSlotEvent.AddListener(OnPointEnterSoftSkillSlotHandler);
            softSkillSlots[index].OnPointExitSoftSkillSlotEvent.AddListener(OnPointExitSoftSkillSlotHandler);
        }

        displayed = false;
    }

    private void Update()
    {
        if (!displayed)
        {
            DisplayedSoftSkills();
            displayed = true;
        }
    }

    private void DisplayedSoftSkills()
    {
        int i = 0;
        Debug.Log("wair for implementation");
        foreach (KeyValuePair<string, SoftSkill> softskill in softSkillsController.Softskills)
        {
            SoftSkill copy = softskill.Value;
            if (!ReferenceEquals(copy, null))
            {
                softSkillSlots[i].SOFTSKILL = softskill.Value;
            }
            i++;
        }
    }

    private void OnLeftClickSoftSkillSlotHandler(BaseSoftSkillSlot softSkillSlot, bool selected)
    {
        OnLeftClickSoftSkillSlotEvent?.Invoke(softSkillSlot, selected);
    }

    private void OnPointEnterSoftSkillSlotHandler(BaseSoftSkillSlot softSkillSlot)
    {
        OnPointEnterSoftSkillSlotEvent?.Invoke(softSkillSlot);
    }

    private void OnPointExitSoftSkillSlotHandler(BaseSoftSkillSlot softSkillSlot)
    {
        OnPointExitSoftSkillSlotEvent?.Invoke(softSkillSlot);
    }
}
