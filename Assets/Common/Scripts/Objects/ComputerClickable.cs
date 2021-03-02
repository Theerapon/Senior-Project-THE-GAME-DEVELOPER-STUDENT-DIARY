using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        GameManager.Instance.OpenDialogue(GameManager.Scene.UI_COMPUTER);
    }
}
