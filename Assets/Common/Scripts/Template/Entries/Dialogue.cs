using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private string text = string.Empty;
    private Feel feel = Feel.Normal;

    public Dialogue(string text, Feel feel)
    {
        this.text = text;
        this.feel = feel;
    }

    public string GetTextDialogue()
    {
        return text;
    }
    public Feel GetFeelDialogue()
    {
        return feel;
    }
}
