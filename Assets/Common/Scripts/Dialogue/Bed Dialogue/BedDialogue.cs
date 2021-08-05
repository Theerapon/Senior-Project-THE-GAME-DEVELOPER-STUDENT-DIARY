using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedDialogue : MonoBehaviour, IDialogue
{

    private GameObject found_home_controller;
    private MenuController menuController;
    private ClassActivityController classActivityController;
    private NotificationController notificationController;

    private void Start()
    {
        found_home_controller = GameObject.FindGameObjectWithTag("HomeController");
        menuController = found_home_controller.GetComponent<MenuController>();
        classActivityController = ClassActivityController.Instance;
        notificationController = NotificationController.Instance;
    }

    public void SelectedDialogue(int choice)
    {
        switch (choice)
        {
            case 1:
                if (!classActivityController.HasEvent() || (classActivityController.HasEvent() && classActivityController.HasFinishEvent()))
                {
                    SwitchScene.Instance.DisplaySaving(true);
                }
                else
                {
                    menuController.Close(GameManager.Instance.CurrentGameScene);
                    notificationController.HasEventToFinish();
                }
                
                break;
            case 2:
                menuController.Close(GameManager.Instance.CurrentGameScene);
                break;
        }
    }

}
