using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWordWorkTypingRandom : baseWord
{
    protected WorkTypingRandomBox wordDisplayHandler;

    public BaseWordWorkTypingRandom(string word, WorkTypingRandomSpawner spawner)
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

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordDisplayHandler.UpdatedOrderLayer();
    }

}
