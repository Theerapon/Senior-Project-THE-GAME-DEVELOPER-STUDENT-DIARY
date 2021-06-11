using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInputWorkTyping : MonoBehaviour
{
    public WorkTypingManager wordManager;

    void Update()
    {
        foreach(char letter in Input.inputString)
        {
            wordManager.TypeLetterManager(letter);
        }
    }
}
