using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingGame1Timer : MonoBehaviour
{
    private TypingGame1Manager wordManager;

    [SerializeField] private float maxWordDelay;
    [SerializeField] private float minWordDelay;
    [SerializeField] private float timeReduce;
    private float currentWordDelay;
    private const int TIMESCALE = 1;

    private int minChangeGenerateBox = 0;
    private int maxChangeGenerateBox = 50000;

    private void Start()
    {
        wordManager = TypingGame1Manager.Instance;
        currentWordDelay = maxWordDelay;
        wordManager.AddMainWordBox();
    }

    void Update()
    {
        int ran = Random.Range(minChangeGenerateBox, maxChangeGenerateBox);
        if(ran < 10)
        {
            wordManager.AddRandomWordBox();
        }
    }

    public float GetWordTimeDelay()
    {
        return currentWordDelay;
    }

    public void ReduceWordTimeDelay()
    {
        currentWordDelay -= timeReduce;
        if(currentWordDelay < minWordDelay)
        {
            currentWordDelay = minWordDelay;
        }
    }

    public void IncreaseWordTimeDelay()
    {
        currentWordDelay += timeReduce;
        if (currentWordDelay > maxWordDelay)
        {
            currentWordDelay = maxWordDelay;
        }
    }
}
