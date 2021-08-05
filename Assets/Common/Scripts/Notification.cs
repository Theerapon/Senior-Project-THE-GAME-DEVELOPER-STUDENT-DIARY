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


    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        OnDestroy();
        

    }

    private void DestroyHandler(GameManager.GameState current, GameManager.GameState previous)
    {
        if(current == GameManager.GameState.PLACE && previous == GameManager.GameState.DIALOUGE)
        {
            StartCoroutine("WaitToDestroy");
        }
        else
        {
            OnDestroy();
        }
        
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
