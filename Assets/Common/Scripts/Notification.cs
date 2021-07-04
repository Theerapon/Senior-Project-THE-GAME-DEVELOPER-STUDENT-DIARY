using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        gameManager.OnGameStateChanged.AddListener(DestroyHandler);
    }

    private void DestroyHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        OnDestroy();
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
