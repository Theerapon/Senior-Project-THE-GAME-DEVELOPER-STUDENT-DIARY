using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInputTypingGame2 : MonoBehaviour
{
    public TypingGame2Manager wordManager;

    void Update()
    {
        switch (wordManager.GetTypingGameState())
        {
            case TypingGame2Manager.TypingGameState.PreGame:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    wordManager.PlaysGame();
                }
                break;
            case TypingGame2Manager.TypingGameState.Playing:
                foreach (char letter in Input.inputString)
                {
                    wordManager.TypeLetterManager(letter);
                }
                break;
        }
    }
}
