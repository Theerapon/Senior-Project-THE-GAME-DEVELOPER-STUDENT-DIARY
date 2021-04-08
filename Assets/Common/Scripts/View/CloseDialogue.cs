using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDialogue : MonoBehaviour
{
    private GameObject found_home_controller;
    private MenuController menuController;

    private void Start()
    {
        found_home_controller = GameObject.FindGameObjectWithTag("HomeController");
        menuController = found_home_controller.GetComponent<MenuController>();
    }

    public void OnClick()
    {
        menuController.Close(GameManager.Instance.CurrentGameScene);
    }

}
