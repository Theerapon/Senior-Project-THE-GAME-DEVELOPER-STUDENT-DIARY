using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepController : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;

    private void Awake()
    {
        timeManager.OnTenMinute.AddListener(OnTemMinuteHandler);
    }

    private void OnTemMinuteHandler()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameState.HOME || GameManager.Instance.CurrentGameState == GameManager.GameState.MAP)
        {
            float hour = timeManager.Hour;
            if (hour >= 2 && hour <= 5)
            {
                GameManager.Instance.SleepLate();
                SwitchScene.Instance.DisplaySleeplate(true);
            }
        }
    }
}
