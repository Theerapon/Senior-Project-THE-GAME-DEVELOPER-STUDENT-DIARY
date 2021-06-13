using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordStatistics : Manager<WordStatistics>
{
    #region Instace
    private const int INST_Value_CorrectWord = 5;
    private const int INST_Value_IncorrectWord = 10;
    #endregion

    private int correctWord;
    private int incoreectWord;

    public int CorrectWord { get => correctWord; }
    public int IncoreectWord { get => incoreectWord; }

    private void Start()
    {
        correctWord = 0;
        incoreectWord = 0;
    }

    public void WordIsCorrect()
    {
        correctWord++;
    }

    public void WordIsIncorrect()
    {
        incoreectWord++;
    }
    public void WordIsIncorrect(int amount)
    {
        incoreectWord += amount;
    }

    public int GetTotalWordTyping()
    {
        return correctWord + incoreectWord;
    }

    public float GetAccuracy()
    {
        if(correctWord + incoreectWord <= 0)
        {
            return 0;
        }
        else
        {
            return (float)correctWord / (correctWord + incoreectWord);
        }
    }

    public int GetWordPerMinute(int second)
    {
        int times = second / 60;
        return CalWordPerTimes(times);
    }

    public int GetWordPerMinuteIn30s(int second)
    {
        int times = second / 30;
        return CalWordPerTimes(times) * 2;
    }

    private int CalWordPerTimes(int times)
    {
        Debug.Log(string.Format("correct {0}, incorrect {1} ", correctWord, incoreectWord));
        return ((correctWord / INST_Value_CorrectWord) - (incoreectWord * INST_Value_IncorrectWord)) / times;
    }
}
