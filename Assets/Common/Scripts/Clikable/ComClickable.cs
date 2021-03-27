using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        Debug.Log("Com");
        //GameManager.Instance.OpenDialogue(GameManager.Scene.UI_COMPUTER);
    }
}
