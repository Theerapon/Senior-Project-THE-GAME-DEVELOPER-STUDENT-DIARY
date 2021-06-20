using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInputWorkTyping : MonoBehaviour
{
    [SerializeField] private WorkTypingManager wordManager;
    [SerializeField] private WorkTypingPlayerManager playerManager;

    void Update()
    {
        switch (wordManager.GetTypingGameState)
        {
            case WorkTypingManager.TypingGameState.PreGame:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    wordManager.PlaysGame();
                }
                break;
            case WorkTypingManager.TypingGameState.Playing:
                if (playerManager.HasAlive() && wordManager.GetTypingGameState == WorkTypingManager.TypingGameState.Playing)
                {
                    foreach (char letter in Input.inputString)
                    {
                        wordManager.TypeLetterManager(letter);
                    }
                }
                break;
        }

        

    }
}
