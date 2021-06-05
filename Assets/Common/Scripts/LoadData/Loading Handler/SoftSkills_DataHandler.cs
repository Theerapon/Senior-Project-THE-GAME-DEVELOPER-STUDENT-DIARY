using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftSkills_DataHandler : DataHandler
{
    protected Dictionary<string, SoftSkill> softSkillsDic;
    [SerializeField] private SoftSkillsVM softSkillsVM;
    [SerializeField] private InterpretHandler interpretHandler;


    public Dictionary<string, SoftSkill> GetSoftSkillsDic
    {
        get { return softSkillsDic; }
    }

    protected void Awake()
    {
        softSkillsDic = new Dictionary<string, SoftSkill>();
        interpretHandler.EventOnPreparingInterpretData.AddListener(EventInterpretHandler);
    }


    private void EventInterpretHandler()
    {
        softSkillsDic = softSkillsVM.Interpert();
        if (!ReferenceEquals(softSkillsDic, null))
        {
            hasFinished = true;
            EventOnInterpretDataComplete?.Invoke();
        }
        else
        {
            Debug.Log("Fail");
        }
        //Debug.Log("SoftSkill interpret completed");
        //foreach (KeyValuePair<string, SoftSkill> softskill in softSkillsDic)
        //{
        //    Debug.Log(string.Format("ID = {0}, Name = {1}, Description = {2}",
        //        softskill.Key, softskill.Value.GetSoftSkillName(), softskill.Value.GetSoftSkillDescription()));

        //}
    }

}
