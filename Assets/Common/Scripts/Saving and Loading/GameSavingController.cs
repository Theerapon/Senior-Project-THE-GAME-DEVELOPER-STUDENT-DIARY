using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSavingController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CountDownSaving());
    }


    IEnumerator CountDownSaving()
    {

        yield return new WaitForSecondsRealtime(3);

        SwitchScene.Instance.DisplayDiary(true);
    }
}
