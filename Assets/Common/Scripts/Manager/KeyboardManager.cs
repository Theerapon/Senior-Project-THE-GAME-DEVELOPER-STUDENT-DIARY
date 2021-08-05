using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : Manager<KeyboardManager>
{
    [SerializeField] private KeyCode BACK_KEYCODE = KeyCode.Escape;

    public KeyCode GetBackKeyCode()
    {
        return BACK_KEYCODE;
    }
}
