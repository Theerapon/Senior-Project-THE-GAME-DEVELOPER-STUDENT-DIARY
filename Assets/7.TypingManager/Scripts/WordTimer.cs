using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;

    private float wordDelay = 3f;
    private float time;
    private const int TIMESCALE = 1;

    private void Start()
    {
        wordManager.AddWord();
    }

    void Update()
    {
        time += Time.deltaTime * TIMESCALE;

        Debug.Log(wordDelay);

        if (time >= wordDelay)
        {
            time = 0;
            wordDelay *= 0.99f;
            wordManager.AddWord();
        }
    }
}
