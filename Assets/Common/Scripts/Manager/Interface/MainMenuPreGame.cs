using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPreGame : MonoBehaviour
{
    public Events.EventLoadComplete OnMainMenuLoadComplete;

    private void LoadGame()
    {
        OnMainMenuLoadComplete?.Invoke(true);
    }

    private void UnLoadGame()
    {
        OnMainMenuLoadComplete?.Invoke(false);
    }

    public void NewGame()
    {
        LoadGame();
        GameManager.Instance.StartGameWithNewGame();
    }

    public void Continiue()
    {
        LoadGame();
        GameManager.Instance.StartGameWithContiniueGame();
    }

}
