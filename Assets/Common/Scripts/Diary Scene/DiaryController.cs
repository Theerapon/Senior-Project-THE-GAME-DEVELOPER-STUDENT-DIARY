using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiaryController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private TMP_Text date;
    [SerializeField] private TMP_Text time;

    TimeManager timeManager;
    CharacterStatusController characterStatusController;

    private float _SleepTimeHour;

    private void Start()
    {
        timeManager = TimeManager.Instance;
        characterStatusController = CharacterStatusController.Instance;

        _SleepTimeHour = timeManager.Hour;
        date.text = timeManager.GetOnDate();
        time.text = timeManager.GetOnTime();

        if(_SleepTimeHour >= 0f && _SleepTimeHour <= 5f)
        {
            characterStatusController.Sleep(true);
            Debug.Log("late");
        }
        else
        {
            characterStatusController.Sleep(false);
            Debug.Log("early");
        }

        StartCoroutine(UpdateDateTime());
    }

    IEnumerator UpdateDateTime()
    {
        //yield return new WaitForSecondsRealtime(2f);
        date.text = timeManager.GetTomorrowOnDate();
        time.text = timeManager.GetTomorrowOnTime();
        timeManager.SetNewDay();

        yield return new WaitForSecondsRealtime(2f);
        SwitchScene.Instance.DisplayDiary(false);
    }
}
