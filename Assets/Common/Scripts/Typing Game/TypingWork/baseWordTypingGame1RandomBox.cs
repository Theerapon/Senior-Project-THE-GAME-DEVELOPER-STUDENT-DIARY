using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseWordTypingGame1RandomBox : baseWord
{
    protected TypingGame1RandomBox wordDisplayHandler;

    public baseWordTypingGame1RandomBox(string word, TypingGame1RandomSpawner spawner)
    {
        this._word = word;
        typeIndex = 0;

        wordDisplayHandler = spawner.SpawnWord();
        wordDisplayHandler.SetWord(word);
        wordDisplayHandler.setMoveDirection(spawner.GetIsRight());
    }

    public override void TypeLetterEachWord()
    {
        base.TypeLetterEachWord();
        wordDisplayHandler.RemoveLetter();
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
        wordDisplayHandler.RemoveWord();
    }

    public void SetID(string id)
    {
        wordDisplayHandler.SetID(id);
    }

}
