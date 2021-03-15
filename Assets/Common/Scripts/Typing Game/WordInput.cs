using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public TypingGame1Manager wordManager;

    void Update()
    {
        foreach(char letter in Input.inputString)
        {
            wordManager.TypeLetterManager(letter);
        }
    }
}
