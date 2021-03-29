using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageClickable : MonoBehaviour, IClickable
{
    public void OnClick()
    {
        GameManager.Instance.DisplerHUD(true, GameManager.GameScene.HUD_Storage);
    }
}
