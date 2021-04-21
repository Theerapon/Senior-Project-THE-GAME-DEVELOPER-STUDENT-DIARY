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
        Debug.Log("wait");

        yield return new WaitForSecondsRealtime(3);

        Debug.Log("finished");
        SwitchScene.Instance.DisplayDiary(true);
    }
}
