using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiaryController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private TMP_Text date;
    [SerializeField] private TMP_Text time;


    private void Start()
    {
        date.text = TimeManager.Instance.GetOnDate();
        time.text = TimeManager.Instance.GetOnTime();
        StartCoroutine(UpdateDateTime());
    }

    IEnumerator UpdateDateTime()
    {
        //yield return new WaitForSecondsRealtime(2f);
        date.text = TimeManager.Instance.GetTomorrowOnDate();
        time.text = TimeManager.Instance.GetTomorrowOnTime();
        TimeManager.Instance.SetNewDay();

        yield return new WaitForSecondsRealtime(2f);
        SwitchScene.Instance.DisplayDiary(false);
    }
}
