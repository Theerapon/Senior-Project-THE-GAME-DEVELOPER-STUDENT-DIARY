using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WorkTypingMainBox : WordBox
{
    [Header("Word Time")]
    [SerializeField] private Image timeFillBar;

    private WorkTypingTimer wordTypingWorkTimer;

    private WorkTypingManager wordManager;

    private float time;
    private const int TIMESCALE = 1;
    private const int SLOW_TIMESCALE = 10;

    protected void Start()
    {
        wordTypingWorkTimer = FindObjectOfType<WorkTypingTimer>();
        wordManager = WorkTypingManager.Instance;
    }


    protected void Update()
    {
        time += Time.deltaTime * TIMESCALE;
        float wordDelay = wordTypingWorkTimer.GetWordTimeDelay();

        SetTimeFillBar();
        if (time >= wordDelay)
        {
            time = 0;
            wordManager.WordOutOffTime();
            gameObject.SetActive(false);
        }
    }

    public void SlowTime()
    {
        time -= Time.deltaTime * SLOW_TIMESCALE;
        SetTimeFillBar();
    }

    private void SetTimeFillBar()
    {
        timeFillBar.fillAmount = 1 - (time / wordTypingWorkTimer.GetWordTimeDelay());
    }

}
