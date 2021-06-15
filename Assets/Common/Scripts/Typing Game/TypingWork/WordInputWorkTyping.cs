using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInputWorkTyping : MonoBehaviour
{
    [SerializeField] private WorkTypingManager wordManager;
    [SerializeField] private WorkTypingPlayerManager playerManager;

    void Update()
    {
        if (playerManager.HasAlive() && wordManager.GetTypingGameState == WorkTypingManager.TypingGameState.Playing)
        {
            foreach (char letter in Input.inputString)
            {
                wordManager.TypeLetterManager(letter);
            }
        }

    }
}
