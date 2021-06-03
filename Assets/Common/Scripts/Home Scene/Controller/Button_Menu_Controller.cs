using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Menu_Controller : MonoBehaviour
{
    private GameObject found_home_controller;
    private MenuController menuController;

    [Header("Button")]
    [SerializeField] private Button[] buttons;

    private void Start()
    {
        found_home_controller = GameObject.FindGameObjectWithTag("HomeController");
        menuController = found_home_controller.GetComponent<MenuController>();

        menuController.OnGameOpenMaenu.AddListener(OnOpenMenu);
        OnButtonClicked(buttons[0]);
    }

    private void OnOpenMenu(GameManager.GameScene currnetScene)
    {
        if(currnetScene == GameManager.GameScene.Menu_Bag)
        {
            OnButtonClicked(buttons[0]);
        }
    }

    public void Back()
    {
        menuController.Close(GameManager.Instance.CurrentGameScene);
    }

    #region Button Menu
    public void OpenBagMenu(Button clickedButton)
    {
        OnButtonClicked(clickedButton);
        OpenMenu(GameManager.GameScene.Menu_Bag);
    }

    public void OpenCharacterMenu(Button clickedButton)
    {
        OnButtonClicked(clickedButton);
        OpenMenu(GameManager.GameScene.Menu_Characters);
    }

    public void OpenIdeasMenu(Button clickedButton)
    {
        OnButtonClicked(clickedButton);
        OpenMenu(GameManager.GameScene.Menu_Ideas);
    }

    public void OpenFriendsMenu(Button clickedButton)
    {
        OnButtonClicked(clickedButton);
        OpenMenu(GameManager.GameScene.Menu_Friends);
    }

    public void OpenExitMenu(Button clickedButton)
    {
        OnButtonClicked(clickedButton);
        OpenMenu(GameManager.GameScene.Menu_Exit);
    }
    #endregion
    private void OpenMenu(GameManager.GameScene gameScene)
    {
        menuController.OpenMenu(gameScene);
    }



    public void SetAllButtonsInteractable(Button clickedButton)
    {
        foreach (Button button in buttons)
        {
            if(button == clickedButton)
            {
                clickedButton.interactable = false;
            }
            else
            {
                button.interactable = true;
            }

        }
    }

    public void OnButtonClicked(Button clickedButton)
    {
        int buttonIndex = System.Array.IndexOf(buttons, clickedButton);

        if (buttonIndex == -1)
            return;

        SetAllButtonsInteractable(clickedButton);
    }
}
