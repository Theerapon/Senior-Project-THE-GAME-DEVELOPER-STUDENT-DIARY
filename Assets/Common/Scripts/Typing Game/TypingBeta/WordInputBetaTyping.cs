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
                if (Input.anyKeyDown)
                {
                    wordManager.PlaysGame();
                }
                break;
            case BetaTypingManager.TypingGameState.Playing:
                if (playerManager.HasAlive())
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (playerManager.CanUseUltimateSkill())
                        {
                            playerManager.UseUlitmateSkill();
                        }
                    }
                    else
                    {
                        if(wordManager.mainWordlist.Count > 0)
                        {
                            foreach (char letter in Input.inputString)
                            {
                                wordManager.TypeLetterManager(letter);
                            }
                        }

                    }

                }
                break;
        }
    }
}
