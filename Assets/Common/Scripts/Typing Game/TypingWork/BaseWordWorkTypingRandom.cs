using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWordWorkTypingRandom : baseWord
{
    protected WorkTypingRandomBox wordBox;

    public BaseWordWorkTypingRandom(string word, WorkTypingRandomSpawner spawner)
    {
        this._word = word;
        typeIndex = 0;

        wordBox = spawner.SpawnWord();
        wordBox.SetWord(word);
        wordBox.setMoveDirection(spawner.GetIsRight());
    }

    public override void TypeLetterEachWord()
    {
        base.TypeLetterEachWord();
        wordBox.RemoveLetter();
    }

    public override void RemoveWord()
    {
        base.RemoveWord();
        wordBox.RemoveWord();
    }

    public void SetID(string id)
    {
        wordBox.SetID(id);
    }

    public override void UpdatedOrderLayer()
    {
        base.UpdatedOrderLayer();
        wordBox.UpdatedOrderLayer();
    }

    public override void TypedCompleted()
    {
        base.TypedCompleted();
        wordBox.TypedCompleted();
    }
}
