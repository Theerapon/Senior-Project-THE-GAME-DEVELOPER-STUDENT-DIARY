using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SleeplateController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private TMP_Text date;
    [SerializeField] private TMP_Text time;

    TimeManager timeManager;

    void Start()
    {
        timeManager = TimeManager.Instance;
        date.text = timeManager.GetOnDate();
        time.text = timeManager.GetOnTime();
        StartCoroutine(CountDownSaving());

    }


    IEnumerator CountDownSaving()
    {

        yield return new WaitForSecondsRealtime(2f);

        SwitchScene.Instance.DisplaySaving(true);
    }
}
