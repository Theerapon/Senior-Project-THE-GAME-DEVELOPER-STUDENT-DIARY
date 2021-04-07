using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    protected string status_id;
    protected string status_name;
    protected Sprite status_icon;
    protected Color32 status_color;

    public Status(string id, string name, Sprite icon, Color32 color)
    {
        status_id = id;
        status_name = name;
        status_icon = icon;
        status_color = color;
    }

    public string StatusID
    {
        get { return status_id; }
    }
    public string StatusName
    {
        get { return status_name; }
    }
    public Sprite StatusIcon
    {
        get { return status_icon; }
    }
    public Color32 StatusColor
    {
        get { return status_color; }
    }
}
