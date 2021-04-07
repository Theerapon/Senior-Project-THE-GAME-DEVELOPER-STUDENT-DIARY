using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    protected string bonus_id;
    protected string bonus_name;
    protected Sprite bonus_icon;

    public Bonus(string id, string name, Sprite icon)
    {
        bonus_id = id;
        bonus_name = name;
        bonus_icon = icon;

    }

    public string BonusID
    {
        get { return bonus_id; }
    }

    public string BonusName
    {
        get { return bonus_name; }
    }
    public Sprite BonusIcon
    {
        get { return bonus_icon; }
    }
}
