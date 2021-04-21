using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedDialogue : MonoBehaviour, IDialogue
{

    private GameObject found_home_controller;
    private MenuController menuController;

    private void Start()
    {
        found_home_controller = GameObject.FindGameObjectWithTag("HomeController");
        menuController = found_home_controller.GetComponent<MenuController>();
    }

    public void SelectedDialogue(int choice)
    {
        switch (choice)
        {
            case 1:
                SwitchScene.Instance.DisplaySaving(true);
                break;
            case 2:
                menuController.Close(GameManager.Instance.CurrentGameScene);
                break;
        }
    }

}
