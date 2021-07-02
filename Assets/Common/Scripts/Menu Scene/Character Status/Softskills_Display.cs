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
    public Events.EventOnSoftSkillUpLevel OnSoftSkillUpLevel;
    #endregion

    [SerializeField] private Transform itemsParent;
    public List<BaseSoftSkillSlot> softSkillSlots;
    private SoftSkillsController softSkillsController;

    private int lastIndex;

    bool displayed = false;

    private void Awake()
    {
        softSkillsController = SoftSkillsController.Instance;
        softSkillsController.OnSoftSkillUpdate.AddListener(OnSoftSkillUpdateHandler);

        //set Item Slots
        softSkillSlots = new List<BaseSoftSkillSlot>();
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: softSkillSlots);
    }

    private void OnSoftSkillUpdateHandler()
    {
        DisplayedSoftSkills();
        OnSoftSkillUpLevel?.Invoke(softSkillSlots[lastIndex]);
    }

    void Start()
    {
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
        foreach (KeyValuePair<string, SoftSkill> softskill in SoftSkillsController.Instance.Softskills)
        {
            SoftSkill copy = softskill.Value;
            if (!ReferenceEquals(copy, null))
            {
                softSkillSlots[i].SOFTSKILL = softskill.Value;
            }
            softSkillSlots[i].Index = i;
            i++;
        }
    }

    private void OnLeftClickSoftSkillSlotHandler(BaseSoftSkillSlot softSkillSlot, bool selected)
    {
        OnLeftClickSoftSkillSlotEvent?.Invoke(softSkillSlot, selected);
        lastIndex = softSkillSlot.Index;
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
