using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;

    private float wordDelay = 4f;
    private float time;
    private const int TIMESCALE = 1;

    private void Start()
    {
        wordManager.AddWord();
    }

    void Update()
    {
        time += Time.deltaTime * TIMESCALE;


        if (time >= wordDelay)
        {
            time = 0;
            wordDelay *= 0.5f;
            wordManager.AddWord();
        }
    }
}
