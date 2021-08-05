using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleRegister_Template : MonoBehaviour
{
    private string id = string.Empty;
    private string registerName = string.Empty;
    private bool defaultRegister = true;
    private List<string> scheduleIds = null;

    public string Id { get => id; }
    public string RegisterName { get => registerName; }
    public bool DefaultRegister { get => defaultRegister; }
    public List<string> ScheduleId { get => scheduleIds; }

    public ScheduleRegister_Template(string id, string registerName, bool defaultRegister, List<string> scheduleId)
    {
        this.id = id;
        this.registerName = registerName;
        this.defaultRegister = defaultRegister;
        this.scheduleIds = scheduleId;
    }
}
