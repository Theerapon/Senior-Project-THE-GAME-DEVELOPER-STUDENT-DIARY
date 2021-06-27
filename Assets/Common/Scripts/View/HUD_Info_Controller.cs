using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Info_Controller : MonoBehaviour
{
    [SerializeField] private GameObject energy_motivation_obj;
    [SerializeField] private GameObject date_time_obj;
    [SerializeField] private GameObject button_back_obj;
    [SerializeField] private GameObject money_obj;
    [SerializeField] private GameObject button_menu_obj;
    [SerializeField] private GameObject content_panel;
    [SerializeField] private GameObject inventory_obj;


    void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        Reset();
    }

    private void OnGameStateChangedHandler(GameManager.GameState current_game_state, GameManager.GameState previouse_game_state)
    {
        if (current_game_state == GameManager.GameState.MENU)
        {
            ShowInfo(true, true, true, true, true, true, false);
        }
        else if (current_game_state == GameManager.GameState.HOME || current_game_state == GameManager.GameState.MAP)
        {
            ShowInfo(true, true, true, false, false, false, false);
        }
        else if(current_game_state == GameManager.GameState.HOME_ACTION 
            && GameManager.Instance.CurrentGameScene == GameManager.GameScene.Home_Storage)
        {
            ShowInfo(true, true, true, false, false, false, false);
        }
        else if (current_game_state == GameManager.GameState.COURSE)
        {
            ShowInfo(true, true, true, true, false, false, false);
        }
        else if (current_game_state == GameManager.GameState.COURSE_NOTIFICATION)
        {
            ShowInfo(true, true, true, false, false, false, false);
        }
        else if(current_game_state == GameManager.GameState.Diary 
            || current_game_state == GameManager.GameState.WORK_PROJECT_MINI_GAME)
        {
            ShowInfo(false, false, false, false, false, false, false);
        }
        else if (current_game_state == GameManager.GameState.WORK_PROJECT)
        {
            ShowInfo(true, true, true, true, false, false, false);
        }
        else if (current_game_state == GameManager.GameState.WORK_PROJECT_DESIGN)
        {
            ShowInfo(true, true, true, false, false, false, false);
        }
        else if (current_game_state == GameManager.GameState.WORK_PROJECT_SUMMARY)
        {
            ShowInfo(true, false, true, false, false, false, false);
        }
        else if (current_game_state == GameManager.GameState.PLACE)
        {
            ShowInfo(true, true, true, true, false, true, true);
        }
        else if (current_game_state == GameManager.GameState.TRANSPORTING || current_game_state == GameManager.GameState.OPENINGTREASURE)
        {
            ShowInfo(true, false, false, false, false, false, false);
        }
        else if (current_game_state == GameManager.GameState.RECEIVE_ITEM)
        {
            ShowInfo(true, true, true, false, false, false, false);
        }

    }
    private void Reset()
    {
        ShowInfo(true, true, true, false, false, false, false);
    }

    private void DisplayEnergyAndMotivation(bool actived)
    {
        if(energy_motivation_obj != null)
        {
            energy_motivation_obj.SetActive(actived);
        }
    }
    private void DisplayDateTime(bool actived)
    {
        if (date_time_obj != null)
        {
            date_time_obj.SetActive(actived);
        }
    }
    private void DisplayButtonBack(bool actived)
    {
        if (button_back_obj != null)
        {
            button_back_obj.SetActive(actived);
        }
    }
    private void DisplayMoney(bool actived)
    {
        if (money_obj != null)
        {
            money_obj.SetActive(actived);
        }
    }
    private void DisplayButtonMenu(bool actived)
    {
        if (button_menu_obj != null)
        {
            button_menu_obj.SetActive(actived);
        }
    }
    private void DisplayConttentPanel(bool actived)
    {
        if (content_panel != null)
        {
            content_panel.SetActive(actived);
        }
    }
    private void DisplayInventory(bool actived)
    {
        if (inventory_obj != null)
        {
            inventory_obj.SetActive(actived);
        }
    }

    private void ShowInfo(bool energy, bool time, bool money, bool buttonBack, bool menu, bool panel, bool inv)
    {
        DisplayEnergyAndMotivation(energy);
        DisplayDateTime(time);
        DisplayMoney(money);
        DisplayButtonBack(buttonBack);
        DisplayButtonMenu(menu);
        DisplayConttentPanel(panel);
        DisplayInventory(inv);
    }
}
