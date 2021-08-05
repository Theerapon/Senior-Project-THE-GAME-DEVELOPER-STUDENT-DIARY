using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComClickable : MonoBehaviour, IClickable
{
    [SerializeField] MenuController menuController;

    public void OnClick()
    {
        menuController.OpenHomeAction(GameManager.GameScene.Home_COMPUTER);
    }
}
