using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInputBetaTyping : MonoBehaviour
{
    [SerializeField] private BetaTypingManager wordManager;
    [SerializeField] private BetaTypingPlayerManager playerManager;

    void Update()
    {
        switch (wordManager.GetTypingGameState())
        {
            case BetaTypingManager.TypingGameState.PreGame:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    wordManager.PlaysGame();
                }
                break;
            case BetaTypingManager.TypingGameState.Playing:
                if (playerManager.HasAlive())
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
