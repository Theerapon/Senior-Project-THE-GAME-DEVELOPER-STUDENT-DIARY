using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleRegisterVM : MonoBehaviour
{
    #region Instance
    private const string INST_SET_ID = "ID";
    private const string INST_SET_RegisterName = "RegisterName";
    private const string INST_SET_DefaultRegister = "DefaultRegister";
    private const string INST_SET_Register = "Register";
    #endregion

    [SerializeField] private ScheduleRegister_Loading scheduleRegister_Loading;

    public Dictionary<string, ScheduleRegister_Template> Interpert()
    {
        if (!ReferenceEquals(scheduleRegister_Loading, null))
        {
            Dictionary<string, ScheduleRegister_Template> scheduleRegisterDic = new Dictionary<string, ScheduleRegister_Template>();

            foreach (KeyValuePair<string, string> line in scheduleRegister_Loading.textLists)
            {
                ScheduleRegister_Template scheduleRegister = null;
                string key = line.Key;
                string value = line.Value;

                scheduleRegister = CreateTemplate(value);

                if (!ReferenceEquals(scheduleRegister, null))
                {
                    scheduleRegisterDic.Add(key, scheduleRegister);
                }

            }
            if (!ReferenceEquals(scheduleRegisterDic, null))
            {
                return scheduleRegisterDic;
            }
        }

        return null;
    }

    private ScheduleRegister_Template CreateTemplate(string line)
    {
        string id = string.Empty;
        string registerName = string.Empty;
        bool defaultRegister = true;
        List<string> scheduleIds = new List<string>();

        string[] entries = line.Split(',');
        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            switch (entry)
            {
                case INST_SET_ID:
                    id = entries[++i];
                    break;
                case INST_SET_RegisterName:
                    registerName = entries[++i];
                    break;
                case INST_SET_DefaultRegister:
                    defaultRegister = bool.Parse(entries[++i]);
                    break;
                case INST_SET_Register:
                    scheduleIds.Add(entries[++i]);
                    break;

            }

        }

        return new ScheduleRegister_Template(id, registerName, defaultRegister, scheduleIds);
    }
}
