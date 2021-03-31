using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Info_Handler : MonoBehaviour
{
    [SerializeField] private GameObject energy_motivation_obj;
    [SerializeField] private GameObject date_time_obj;
    [SerializeField] private GameObject button_back_obj;
    [SerializeField] private GameObject money_obj;
    [SerializeField] private GameObject button_menu_obj;
    [SerializeField] private GameObject content_panel;


    void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(OnGameStateChangedHandler);
        
        Reset();
    }

    private void OnGameStateChangedHandler(GameManager.GameState current_game_state, GameManager.GameState previouse_game_state)
    {
        if (current_game_state == GameManager.GameState.MENU || current_game_state == GameManager.GameState.HOME_ACTION)
        {
            ShowAll();
        }

        if (current_game_state == GameManager.GameState.HOME || current_game_state == GameManager.GameState.MAP)
        {
            Reset();
        }
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
    private void ShowAll()
    {
        DisplayEnergyAndMotivation(true);
        DisplayDateTime(true);
        DisplayButtonBack(true);
        DisplayMoney(true);
        DisplayButtonMenu(true);
        DisplayConttentPanel(true);
    }

    private void Reset()
    {
        DisplayEnergyAndMotivation(true);
        DisplayDateTime(true);
        DisplayButtonBack(false);
        DisplayButtonMenu(false);
        DisplayMoney(true);
        DisplayConttentPanel(false);
    }
}
