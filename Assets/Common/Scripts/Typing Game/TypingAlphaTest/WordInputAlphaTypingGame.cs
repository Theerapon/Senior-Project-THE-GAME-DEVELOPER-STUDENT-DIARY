using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInputAlphaTypingGame : MonoBehaviour
{
    public AlphaTypingManager wordManager;

    void Update()
    {
        switch (wordManager.GetTypingGameState())
        {
            case AlphaTypingManager.TypingGameState.PreGame:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    wordManager.PlaysGame();
                }
                break;
            case AlphaTypingManager.TypingGameState.Playing:
                foreach (char letter in Input.inputString)
                {
                    wordManager.TypeLetterManager(letter);
                }
                break;
        }
    }
}
