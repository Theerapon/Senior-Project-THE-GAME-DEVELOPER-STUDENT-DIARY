using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageClickable : MonoBehaviour, IClickable
{
    [SerializeField] MenuController menuController;


    public void OnClick()
    {
        menuController.OpenHomeAction(GameManager.GameScene.Home_Storage);
    }
}
